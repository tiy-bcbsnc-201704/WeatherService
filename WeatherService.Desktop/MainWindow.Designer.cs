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
            System.Windows.Forms.Label latitiudeLabel;
            System.Windows.Forms.Label whenLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this._logViewer = new System.Windows.Forms.TextBox();
            this._weatherCount = new System.Windows.Forms.Label();
            this._solarWindCount = new System.Windows.Forms.Label();
            this._earthquakeCount = new System.Windows.Forms.Label();
            this._latitude = new System.Windows.Forms.NumericUpDown();
            this._when = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            summaryPanel = new System.Windows.Forms.Panel();
            summaryHeaderPanel = new System.Windows.Forms.Panel();
            logViewerLabel = new System.Windows.Forms.Label();
            solarWindCountLabel = new System.Windows.Forms.Label();
            earthquakeCountLabel = new System.Windows.Forms.Label();
            weatherRecordsCountLabel = new System.Windows.Forms.Label();
            queryPanel = new System.Windows.Forms.Panel();
            latitiudeLabel = new System.Windows.Forms.Label();
            whenLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            summaryPanel.SuspendLayout();
            summaryHeaderPanel.SuspendLayout();
            queryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._latitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // summaryPanel
            // 
            summaryPanel.Controls.Add(this._logViewer);
            summaryPanel.Controls.Add(summaryHeaderPanel);
            summaryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            summaryPanel.Location = new System.Drawing.Point(0, 0);
            summaryPanel.Name = "summaryPanel";
            summaryPanel.Size = new System.Drawing.Size(200, 441);
            summaryPanel.TabIndex = 0;
            // 
            // _logViewer
            // 
            this._logViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._logViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logViewer.Enabled = false;
            this._logViewer.Location = new System.Drawing.Point(0, 135);
            this._logViewer.Multiline = true;
            this._logViewer.Name = "_logViewer";
            this._logViewer.Size = new System.Drawing.Size(200, 306);
            this._logViewer.TabIndex = 6;
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
            summaryHeaderPanel.Size = new System.Drawing.Size(200, 135);
            summaryHeaderPanel.TabIndex = 7;
            // 
            // logViewerLabel
            // 
            logViewerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            logViewerLabel.AutoSize = true;
            logViewerLabel.Location = new System.Drawing.Point(12, 119);
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
            queryPanel.Controls.Add(this.numericUpDown1);
            queryPanel.Controls.Add(label1);
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
            // _latitude
            // 
            this._latitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._latitude.DecimalPlaces = 5;
            this._latitude.Location = new System.Drawing.Point(66, 38);
            this._latitude.Name = "_latitude";
            this._latitude.Size = new System.Drawing.Size(346, 20);
            this._latitude.TabIndex = 3;
            // 
            // latitiudeLabel
            // 
            latitiudeLabel.AutoSize = true;
            latitiudeLabel.Location = new System.Drawing.Point(6, 41);
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
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.DecimalPlaces = 5;
            this.numericUpDown1.Location = new System.Drawing.Point(66, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(346, 20);
            this.numericUpDown1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 67);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 13);
            label1.TabIndex = 4;
            label1.Text = "Longitude";
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
            summaryPanel.PerformLayout();
            summaryHeaderPanel.ResumeLayout(false);
            summaryHeaderPanel.PerformLayout();
            queryPanel.ResumeLayout(false);
            queryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._latitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _earthquakeCount;
        private System.Windows.Forms.Label _weatherCount;
        private System.Windows.Forms.Label _solarWindCount;
        private System.Windows.Forms.TextBox _logViewer;
        private System.Windows.Forms.DateTimePicker _when;
        private System.Windows.Forms.NumericUpDown _latitude;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

