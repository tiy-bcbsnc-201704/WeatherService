using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using Weather.EventNotifier;

namespace Weather.EarthquakeDataService
{
    class FileDownloader
    {
        private readonly string _url;
        private readonly string _fullPathWhereToSave;
        private bool _result = false;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        private readonly IRecordAnEvent _logger;

        public FileDownloader(string url, string fullPathWhereToSave, IRecordAnEvent logger)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            if (string.IsNullOrEmpty(fullPathWhereToSave)) throw new ArgumentNullException("fullPathWhereToSave");

            this._url = url;
            this._fullPathWhereToSave = fullPathWhereToSave;
            _logger = logger;
        }

        public bool StartDownload(int timeout)
        {
            try
            {
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(_fullPathWhereToSave));

                if (File.Exists(_fullPathWhereToSave))
                {
                    File.Delete(_fullPathWhereToSave);
                }
                using (WebClient client = new WebClient())
                {
                    var ur = new Uri(_url);
                    // client.Credentials = new NetworkCredential("username", "password");
                    client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                    client.DownloadFileCompleted += WebClientDownloadCompleted;
                    _logger.Record(ServiceName.EarthquakeService, $"Downloading file from {_url}");
                    client.DownloadFileAsync(ur, _fullPathWhereToSave);
                    _semaphore.Wait(timeout);
                    return _result && File.Exists(_fullPathWhereToSave);

                }
            }
            catch (Exception e)
            {
                _logger.Record(ServiceName.EarthquakeService, $"Failed to download file from {_url}");
                _logger.Record(ServiceName.EarthquakeService, e.ToString());
                return false;
            }
            finally
            {
                this._semaphore.Dispose();
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _logger.Record(ServiceName.EarthquakeService, $"{e.ProgressPercentage}% downloaded");
        }

        private void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            _result = !args.Cancelled;
            if (!_result)
            {
                _logger.Record(ServiceName.EarthquakeService, args.Error.ToString());
            }
            _logger.Record(ServiceName.EarthquakeService, "Download finished.");
            //_semaphore.Release();
        }

        public static bool DownloadFile(string url, string fullPathWhereToSave, int timeoutInMilliSec, IRecordAnEvent logger)
        {
            return new FileDownloader(url, fullPathWhereToSave, logger).StartDownload(timeoutInMilliSec);
        }
    }
}