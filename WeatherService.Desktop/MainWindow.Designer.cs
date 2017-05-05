namespace WeatherService.Desktop
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel summaryPanel;
            System.Windows.Forms.Panel summaryHeaderPanel;
            System.Windows.Forms.Label logViewerLabel;
            System.Windows.Forms.Label solarWindCountLabel;
            System.Windows.Forms.Label earthquakeCountLabel;
            System.Windows.Forms.Label weatherRecordsCountLabel;
            System.Windows.Forms.Panel queryPanel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label longitudeLabel;
            System.Windows.Forms.Label latitiudeLabel;
            System.Windows.Forms.Label whenLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._htmlLogViewer = new System.Windows.Forms.WebBrowser();
            this._weatherCount = new System.Windows.Forms.Label();
            this._solarWindCount = new System.Windows.Forms.Label();
            this._earthquakeCount = new System.Windows.Forms.Label();
            this._currentState = new System.Windows.Forms.ComboBox();
            this._longitude = new System.Windows.Forms.NumericUpDown();
            this._latitude = new System.Windows.Forms.NumericUpDown();
            this._when = new System.Windows.Forms.DateTimePicker();
            summaryPanel = new System.Windows.Forms.Panel();
            summaryHeaderPanel = new System.Windows.Forms.Panel();
            logViewerLabel = new System.Windows.Forms.Label();
            solarWindCountLabel = new System.Windows.Forms.Label();
            earthquakeCountLabel = new System.Windows.Forms.Label();
            weatherRecordsCountLabel = new System.Windows.Forms.Label();
            queryPanel = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            longitudeLabel = new System.Windows.Forms.Label();
            latitiudeLabel = new System.Windows.Forms.Label();
            whenLabel = new System.Windows.Forms.Label();
            summaryPanel.SuspendLayout();
            summaryHeaderPanel.SuspendLayout();
            queryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._longitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._latitude)).BeginInit();
            this.SuspendLayout();
            // 
            // summaryPanel
            // 
            summaryPanel.Controls.Add(this._htmlLogViewer);
            summaryPanel.Controls.Add(summaryHeaderPanel);
            summaryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            summaryPanel.Location = new System.Drawing.Point(0, 0);
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Size = new System.Drawing.Size(200, 441);
            summaryPanel.TabIndex = 0;
            // 
            // _htmlLogViewer
            // 
            this._htmlLogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._htmlLogViewer.Location = new System.Drawing.Point(0, 129);
            this._htmlLogViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this._htmlLogViewer.Name = "_htmlLogViewer";
            this._htmlLogViewer.Size = new System.Drawing.Size(200, 312);
            this._htmlLogViewer.TabIndex = 6;
            // 
            // summaryHeaderPanel
            // 
            summaryHeaderPanel.Controls.Add(logViewerLabel);
            summaryHeaderPanel.Controls.Add(solarWindCountLabel);
            summaryHeaderPanel.Controls.Add(earthquakeCountLabel);
            summaryHeaderPanel.Controls.Add(this._weatherCount);
            summaryHeaderPanel.Controls.Add(weatherRecordsCountLabel);
            summaryHeaderPanel.Controls.Add(this._solarWindCount);
            summaryHeaderPanel.Controls.Add(this._earthquakeCount);
            summaryHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            summaryHeaderPanel.Location = new System.Drawing.Point(0, 0);
            summaryHeaderPanel.Name = "summaryHeaderPanel";
            summaryHeaderPanel.Size = new System.Drawing.Size(200, 129);
            summaryHeaderPanel.TabIndex = 7;
            // 
            // logViewerLabel
            // 
            logViewerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            logViewerLabel.AutoSize = true;
            logViewerLabel.Location = new System.Drawing.Point(12, 102);
            logViewerLabel.Name = "logViewerLabel";
            logViewerLabel.Size = new System.Drawing.Size(60, 13);
            logViewerLabel.TabIndex = 6;
            logViewerLabel.Text = "Log Viewer";
            // 
            // solarWindCountLabel
            // 
            solarWindCountLabel.AutoSize = true;
            solarWindCountLabel.Location = new System.Drawing.Point(12, 36);
            solarWindCountLabel.Name = "solarWindCountLabel";
            solarWindCountLabel.Size = new System.Drawing.Size(102, 13);
            solarWindCountLabel.TabIndex = 1;
            solarWindCountLabel.Text = "Solar Wind Records";
            // 
            // earthquakeCountLabel
            // 
            earthquakeCountLabel.AutoSize = true;
            earthquakeCountLabel.Location = new System.Drawing.Point(12, 13);
            earthquakeCountLabel.Name = "earthquakeCountLabel";
            earthquakeCountLabel.Size = new System.Drawing.Size(108, 13);
            earthquakeCountLabel.TabIndex = 0;
            earthquakeCountLabel.Text = "Earthquake Records:";
            // 
            // _weatherCount
            // 
            this._weatherCount.AutoSize = true;
            this._weatherCount.Location = new System.Drawing.Point(127, 59);
            this._weatherCount.Name = "_weatherCount";
            this._weatherCount.Size = new System.Drawing.Size(13, 13);
            this._weatherCount.TabIndex = 5;
            this._weatherCount.Text = "0";
            // 
            // weatherRecordsCountLabel
            // 
            weatherRecordsCountLabel.AutoSize = true;
            weatherRecordsCountLabel.Location = new System.Drawing.Point(12, 59);
            weatherRecordsCountLabel.Name = "weatherRecordsCountLabel";
            weatherRecordsCountLabel.Size = new System.Drawing.Size(94, 13);
            weatherRecordsCountLabel.TabIndex = 2;
            weatherRecordsCountLabel.Text = "Weather Records:";
            // 
            // _solarWindCount
            // 
            this._solarWindCount.AutoSize = true;
            this._solarWindCount.Location = new System.Drawing.Point(127, 36);
            this._solarWindCount.Name = "_solarWindCount";
            this._solarWindCount.Size = new System.Drawing.Size(13, 13);
            this._solarWindCount.TabIndex = 4;
            this._solarWindCount.Text = "0";
            // 
            // _earthquakeCount
            // 
            this._earthquakeCount.AutoSize = true;
            this._earthquakeCount.Location = new System.Drawing.Point(127, 12);
            this._earthquakeCount.Name = "_earthquakeCount";
            this._earthquakeCount.Size = new System.Drawing.Size(13, 13);
            this._earthquakeCount.TabIndex = 3;
            this._earthquakeCount.Text = "0";
            // 
            // queryPanel
            // 
            queryPanel.Controls.Add(this._currentState);
            queryPanel.Controls.Add(label1);
            queryPanel.Controls.Add(this._longitude);
            queryPanel.Controls.Add(longitudeLabel);
            queryPanel.Controls.Add(this._latitude);
            queryPanel.Controls.Add(latitiudeLabel);
            queryPanel.Controls.Add(this._when);
            queryPanel.Controls.Add(whenLabel);
            queryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            queryPanel.Location = new System.Drawing.Point(200, 0);
            queryPanel.Name = "queryPanel";
            queryPanel.Size = new System.Drawing.Size(424, 441);
            queryPanel.TabIndex = 1;
            // 
            // _currentState
            // 
            this._currentState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._currentState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._currentState.FormattingEnabled = true;
            this._currentState.Location = new System.Drawing.Point(66, 38);
            this._currentState.Name = "_currentState";
            this._currentState.Size = new System.Drawing.Size(346, 21);
            this._currentState.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 13);
            label1.TabIndex = 6;
            label1.Text = "State";
            // 
            // _longitude
            // 
            this._longitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._longitude.DecimalPlaces = 5;
            this._longitude.Location = new System.Drawing.Point(66, 91);
            this._longitude.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this._longitude.Minimum = new decimal(new int[] {
            365,
            0,
            0,
            -2147483648});
            this._longitude.Name = "_longitude";
            this._longitude.Size = new System.Drawing.Size(346, 20);
            this._longitude.TabIndex = 5;
            // 
            // longitudeLabel
            // 
            longitudeLabel.AutoSize = true;
            longitudeLabel.Location = new System.Drawing.Point(6, 94);
            longitudeLabel.Name = "longitudeLabel";
            longitudeLabel.Size = new System.Drawing.Size(54, 13);
            longitudeLabel.TabIndex = 4;
            longitudeLabel.Text = "Longitude";
            // 
            // _latitude
            // 
            this._latitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._latitude.DecimalPlaces = 5;
            this._latitude.Location = new System.Drawing.Point(66, 65);
            this._latitude.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this._latitude.Minimum = new decimal(new int[] {
            365,
            0,
            0,
            -2147483648});
            this._latitude.Name = "_latitude";
            this._latitude.Size = new System.Drawing.Size(346, 20);
            this._latitude.TabIndex = 3;
            // 
            // latitiudeLabel
            // 
            latitiudeLabel.AutoSize = true;
            latitiudeLabel.Location = new System.Drawing.Point(6, 68);
            latitiudeLabel.Name = "latitiudeLabel";
            latitiudeLabel.Size = new System.Drawing.Size(45, 13);
            latitiudeLabel.TabIndex = 2;
            latitiudeLabel.Text = "Latitude";
            // 
            // _when
            // 
            this._when.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._when.CustomFormat = "MM/dd/yyyy hh:mm";
            this._when.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._when.Location = new System.Drawing.Point(66, 12);
            this._when.Name = "_when";
            this._when.Size = new System.Drawing.Size(346, 20);
            this._when.TabIndex = 1;
            // 
            // whenLabel
            // 
            whenLabel.AutoSize = true;
            whenLabel.Location = new System.Drawing.Point(6, 15);
            whenLabel.Name = "whenLabel";
            whenLabel.Size = new System.Drawing.Size(36, 13);
            whenLabel.TabIndex = 0;
            whenLabel.Text = "When";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(queryPanel);
            this.Controls.Add(summaryPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Weather Service";
            summaryPanel.ResumeLayout(false);
            summaryHeaderPanel.ResumeLayout(false);
            summaryHeaderPanel.PerformLayout();
            queryPanel.ResumeLayout(false);
            queryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._longitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._latitude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _earthquakeCount;
        private System.Windows.Forms.Label _weatherCount;
        private System.Windows.Forms.Label _solarWindCount;
        private System.Windows.Forms.DateTimePicker _when;
        private System.Windows.Forms.NumericUpDown _latitude;
        private System.Windows.Forms.NumericUpDown _longitude;
        private System.Windows.Forms.WebBrowser _htmlLogViewer;
        private System.Windows.Forms.ComboBox _currentState;
    }
}

