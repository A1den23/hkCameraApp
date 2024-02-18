namespace hkCameraApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.CbCameraList = new Sunny.UI.UIComboBox();
            this.BnFindCamera = new Sunny.UI.UIButton();
            this.BnOpenCamera = new Sunny.UI.UIButton();
            this.BnCloseCamera = new Sunny.UI.UIButton();
            this.GbRealTimePicture = new Sunny.UI.UIGroupBox();
            this.PbImageBox = new System.Windows.Forms.PictureBox();
            this.GbCaptureImage = new Sunny.UI.UIGroupBox();
            this.BnTriggerExec = new Sunny.UI.UIButton();
            this.CbSoftTrigger = new Sunny.UI.UICheckBox();
            this.BnStopGrab = new Sunny.UI.UIButton();
            this.BnStartGrab = new Sunny.UI.UIButton();
            this.RbTriggerMode = new Sunny.UI.UIRadioButton();
            this.RbContinuesMode = new Sunny.UI.UIRadioButton();
            this.GbFocusFunction = new Sunny.UI.UIGroupBox();
            this.chartResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BnReset = new Sunny.UI.UIButton();
            this.BnStopCalculate = new Sunny.UI.UIButton();
            this.BnStartCalculate = new Sunny.UI.UIButton();
            this.CbCalculationMethod = new Sunny.UI.UIComboBox();
            this.tbCalculationResult = new Sunny.UI.UITextBox();
            this.tbCalculationInterval = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.GbCameraParameters = new Sunny.UI.UIGroupBox();
            this.GbROI = new Sunny.UI.UIGroupBox();
            this.tbOffsetY = new Sunny.UI.UITextBox();
            this.tbOffsetX = new Sunny.UI.UITextBox();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.tbHeight = new Sunny.UI.UITextBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.tbWidth = new Sunny.UI.UITextBox();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.BnGetParam = new Sunny.UI.UIButton();
            this.BnSetParam = new Sunny.UI.UIButton();
            this.tbBayerGamma = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.tbPixelFormat = new Sunny.UI.UITextBox();
            this.tbFrameRate = new Sunny.UI.UITextBox();
            this.tbGain = new Sunny.UI.UITextBox();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.tbExposure = new Sunny.UI.UITextBox();
            this.GbDataProcessing = new Sunny.UI.UIGroupBox();
            this.BnFrameCapture = new Sunny.UI.UIButton();
            this.BnSaveJpg = new Sunny.UI.UIButton();
            this.BnSaveBmp = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tbSavePath = new Sunny.UI.UITextBox();
            this.GbCalculatedPicture = new Sunny.UI.UIGroupBox();
            this.PbCalculateBox = new System.Windows.Forms.PictureBox();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.GbRealTimePicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbImageBox)).BeginInit();
            this.GbCaptureImage.SuspendLayout();
            this.GbFocusFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).BeginInit();
            this.GbCameraParameters.SuspendLayout();
            this.GbROI.SuspendLayout();
            this.GbDataProcessing.SuspendLayout();
            this.GbCalculatedPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCalculateBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel1.Location = new System.Drawing.Point(14, 39);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(82, 32);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "选择相机：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CbCameraList
            // 
            this.CbCameraList.DataSource = null;
            this.CbCameraList.FillColor = System.Drawing.Color.White;
            this.CbCameraList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CbCameraList.Location = new System.Drawing.Point(93, 39);
            this.CbCameraList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbCameraList.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbCameraList.Name = "CbCameraList";
            this.CbCameraList.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbCameraList.Radius = 10;
            this.CbCameraList.Size = new System.Drawing.Size(421, 32);
            this.CbCameraList.TabIndex = 1;
            this.CbCameraList.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbCameraList.Watermark = "";
            // 
            // BnFindCamera
            // 
            this.BnFindCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnFindCamera.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnFindCamera.Location = new System.Drawing.Point(533, 39);
            this.BnFindCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnFindCamera.Name = "BnFindCamera";
            this.BnFindCamera.Size = new System.Drawing.Size(78, 32);
            this.BnFindCamera.TabIndex = 1;
            this.BnFindCamera.Text = "查找相机";
            this.BnFindCamera.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnFindCamera.Click += new System.EventHandler(this.BnFindCamera_Click);
            // 
            // BnOpenCamera
            // 
            this.BnOpenCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnOpenCamera.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnOpenCamera.Location = new System.Drawing.Point(646, 39);
            this.BnOpenCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnOpenCamera.Name = "BnOpenCamera";
            this.BnOpenCamera.Size = new System.Drawing.Size(78, 32);
            this.BnOpenCamera.TabIndex = 2;
            this.BnOpenCamera.Text = "打开相机";
            this.BnOpenCamera.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnOpenCamera.Click += new System.EventHandler(this.BnOpenCamera_Click);
            // 
            // BnCloseCamera
            // 
            this.BnCloseCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnCloseCamera.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnCloseCamera.Location = new System.Drawing.Point(767, 39);
            this.BnCloseCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnCloseCamera.Name = "BnCloseCamera";
            this.BnCloseCamera.Size = new System.Drawing.Size(78, 32);
            this.BnCloseCamera.TabIndex = 3;
            this.BnCloseCamera.Text = "关闭相机";
            this.BnCloseCamera.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnCloseCamera.Click += new System.EventHandler(this.BnCloseCamera_Click);
            // 
            // GbRealTimePicture
            // 
            this.GbRealTimePicture.Controls.Add(this.PbImageBox);
            this.GbRealTimePicture.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbRealTimePicture.Location = new System.Drawing.Point(6, 76);
            this.GbRealTimePicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbRealTimePicture.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbRealTimePicture.Name = "GbRealTimePicture";
            this.GbRealTimePicture.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbRealTimePicture.Size = new System.Drawing.Size(606, 629);
            this.GbRealTimePicture.TabIndex = 4;
            this.GbRealTimePicture.Text = "实时画面";
            this.GbRealTimePicture.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbImageBox
            // 
            this.PbImageBox.Location = new System.Drawing.Point(3, 25);
            this.PbImageBox.Name = "PbImageBox";
            this.PbImageBox.Size = new System.Drawing.Size(600, 600);
            this.PbImageBox.TabIndex = 0;
            this.PbImageBox.TabStop = false;
            // 
            // GbCaptureImage
            // 
            this.GbCaptureImage.Controls.Add(this.BnTriggerExec);
            this.GbCaptureImage.Controls.Add(this.CbSoftTrigger);
            this.GbCaptureImage.Controls.Add(this.BnStopGrab);
            this.GbCaptureImage.Controls.Add(this.BnStartGrab);
            this.GbCaptureImage.Controls.Add(this.RbTriggerMode);
            this.GbCaptureImage.Controls.Add(this.RbContinuesMode);
            this.GbCaptureImage.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbCaptureImage.Location = new System.Drawing.Point(620, 76);
            this.GbCaptureImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbCaptureImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbCaptureImage.Name = "GbCaptureImage";
            this.GbCaptureImage.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbCaptureImage.Size = new System.Drawing.Size(245, 144);
            this.GbCaptureImage.TabIndex = 5;
            this.GbCaptureImage.Text = "采集图像";
            this.GbCaptureImage.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnTriggerExec
            // 
            this.BnTriggerExec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnTriggerExec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnTriggerExec.Location = new System.Drawing.Point(146, 98);
            this.BnTriggerExec.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnTriggerExec.Name = "BnTriggerExec";
            this.BnTriggerExec.Size = new System.Drawing.Size(78, 32);
            this.BnTriggerExec.TabIndex = 11;
            this.BnTriggerExec.Text = "软触发一次";
            this.BnTriggerExec.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnTriggerExec.Click += new System.EventHandler(this.BnTriggerExec_Click);
            // 
            // CbSoftTrigger
            // 
            this.CbSoftTrigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CbSoftTrigger.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.CbSoftTrigger.Location = new System.Drawing.Point(31, 102);
            this.CbSoftTrigger.MinimumSize = new System.Drawing.Size(1, 1);
            this.CbSoftTrigger.Name = "CbSoftTrigger";
            this.CbSoftTrigger.Size = new System.Drawing.Size(72, 28);
            this.CbSoftTrigger.TabIndex = 10;
            this.CbSoftTrigger.Text = "软触发";
            this.CbSoftTrigger.CheckedChanged += new System.EventHandler(this.CbSoftTrigger_CheckedChanged);
            // 
            // BnStopGrab
            // 
            this.BnStopGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStopGrab.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStopGrab.Location = new System.Drawing.Point(147, 60);
            this.BnStopGrab.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStopGrab.Name = "BnStopGrab";
            this.BnStopGrab.Size = new System.Drawing.Size(78, 32);
            this.BnStopGrab.TabIndex = 9;
            this.BnStopGrab.Text = "停止采集";
            this.BnStopGrab.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStopGrab.Click += new System.EventHandler(this.BnStopGrab_Click);
            // 
            // BnStartGrab
            // 
            this.BnStartGrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStartGrab.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStartGrab.Location = new System.Drawing.Point(26, 60);
            this.BnStartGrab.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStartGrab.Name = "BnStartGrab";
            this.BnStartGrab.Size = new System.Drawing.Size(78, 32);
            this.BnStartGrab.TabIndex = 8;
            this.BnStartGrab.Text = "开始采集";
            this.BnStartGrab.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStartGrab.Click += new System.EventHandler(this.BnStartGrab_Click);
            // 
            // RbTriggerMode
            // 
            this.RbTriggerMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbTriggerMode.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.RbTriggerMode.Location = new System.Drawing.Point(146, 25);
            this.RbTriggerMode.MinimumSize = new System.Drawing.Size(1, 1);
            this.RbTriggerMode.Name = "RbTriggerMode";
            this.RbTriggerMode.Size = new System.Drawing.Size(78, 29);
            this.RbTriggerMode.TabIndex = 1;
            this.RbTriggerMode.Text = "触发模式";
            this.RbTriggerMode.CheckedChanged += new System.EventHandler(this.RbTriggerMode_CheckedChanged);
            // 
            // RbContinuesMode
            // 
            this.RbContinuesMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbContinuesMode.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.RbContinuesMode.Location = new System.Drawing.Point(25, 25);
            this.RbContinuesMode.MinimumSize = new System.Drawing.Size(1, 1);
            this.RbContinuesMode.Name = "RbContinuesMode";
            this.RbContinuesMode.Size = new System.Drawing.Size(79, 29);
            this.RbContinuesMode.TabIndex = 0;
            this.RbContinuesMode.Text = "连续模式";
            this.RbContinuesMode.CheckedChanged += new System.EventHandler(this.RbContinuesMode_CheckedChanged);
            // 
            // GbFocusFunction
            // 
            this.GbFocusFunction.Controls.Add(this.chartResult);
            this.GbFocusFunction.Controls.Add(this.BnReset);
            this.GbFocusFunction.Controls.Add(this.BnStopCalculate);
            this.GbFocusFunction.Controls.Add(this.BnStartCalculate);
            this.GbFocusFunction.Controls.Add(this.CbCalculationMethod);
            this.GbFocusFunction.Controls.Add(this.tbCalculationResult);
            this.GbFocusFunction.Controls.Add(this.tbCalculationInterval);
            this.GbFocusFunction.Controls.Add(this.uiLabel5);
            this.GbFocusFunction.Controls.Add(this.uiLabel4);
            this.GbFocusFunction.Controls.Add(this.uiLabel3);
            this.GbFocusFunction.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbFocusFunction.Location = new System.Drawing.Point(620, 384);
            this.GbFocusFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbFocusFunction.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbFocusFunction.Name = "GbFocusFunction";
            this.GbFocusFunction.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbFocusFunction.Size = new System.Drawing.Size(601, 321);
            this.GbFocusFunction.TabIndex = 6;
            this.GbFocusFunction.Text = "对焦函数评价";
            this.GbFocusFunction.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartResult
            // 
            this.chartResult.BackColor = System.Drawing.Color.Transparent;
            this.chartResult.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.chartResult.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartResult.BorderlineWidth = 5;
            chartArea1.Name = "ChartArea1";
            this.chartResult.ChartAreas.Add(chartArea1);
            this.chartResult.Location = new System.Drawing.Point(3, 23);
            this.chartResult.Name = "chartResult";
            this.chartResult.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartResult.Series.Add(series1);
            this.chartResult.Size = new System.Drawing.Size(474, 291);
            this.chartResult.TabIndex = 18;
            // 
            // BnReset
            // 
            this.BnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnReset.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnReset.Location = new System.Drawing.Point(499, 273);
            this.BnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnReset.Name = "BnReset";
            this.BnReset.Size = new System.Drawing.Size(78, 32);
            this.BnReset.TabIndex = 17;
            this.BnReset.Text = "重置";
            this.BnReset.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnReset.Click += new System.EventHandler(this.BnReset_Click);
            // 
            // BnStopCalculate
            // 
            this.BnStopCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStopCalculate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStopCalculate.Location = new System.Drawing.Point(499, 226);
            this.BnStopCalculate.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStopCalculate.Name = "BnStopCalculate";
            this.BnStopCalculate.Size = new System.Drawing.Size(78, 32);
            this.BnStopCalculate.TabIndex = 16;
            this.BnStopCalculate.Text = "停止计算";
            this.BnStopCalculate.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStopCalculate.Click += new System.EventHandler(this.BnStopCalculate_Click);
            // 
            // BnStartCalculate
            // 
            this.BnStartCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStartCalculate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStartCalculate.Location = new System.Drawing.Point(499, 179);
            this.BnStartCalculate.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStartCalculate.Name = "BnStartCalculate";
            this.BnStartCalculate.Size = new System.Drawing.Size(78, 32);
            this.BnStartCalculate.TabIndex = 15;
            this.BnStartCalculate.Text = "开始计算";
            this.BnStartCalculate.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStartCalculate.Click += new System.EventHandler(this.BnStartCalculate_Click);
            // 
            // CbCalculationMethod
            // 
            this.CbCalculationMethod.DataSource = null;
            this.CbCalculationMethod.FillColor = System.Drawing.Color.White;
            this.CbCalculationMethod.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.CbCalculationMethod.Location = new System.Drawing.Point(478, 48);
            this.CbCalculationMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbCalculationMethod.MinimumSize = new System.Drawing.Size(63, 0);
            this.CbCalculationMethod.Name = "CbCalculationMethod";
            this.CbCalculationMethod.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CbCalculationMethod.Size = new System.Drawing.Size(119, 25);
            this.CbCalculationMethod.TabIndex = 2;
            this.CbCalculationMethod.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.CbCalculationMethod.Watermark = "";
            this.CbCalculationMethod.SelectedIndexChanged += new System.EventHandler(this.CbCalculationMethod_SelectedIndexChanged);
            // 
            // tbCalculationResult
            // 
            this.tbCalculationResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCalculationResult.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbCalculationResult.Location = new System.Drawing.Point(478, 147);
            this.tbCalculationResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCalculationResult.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCalculationResult.Name = "tbCalculationResult";
            this.tbCalculationResult.Padding = new System.Windows.Forms.Padding(5);
            this.tbCalculationResult.ShowText = false;
            this.tbCalculationResult.Size = new System.Drawing.Size(119, 24);
            this.tbCalculationResult.TabIndex = 13;
            this.tbCalculationResult.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbCalculationResult.Watermark = "";
            // 
            // tbCalculationInterval
            // 
            this.tbCalculationInterval.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCalculationInterval.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbCalculationInterval.Location = new System.Drawing.Point(478, 98);
            this.tbCalculationInterval.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbCalculationInterval.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbCalculationInterval.Name = "tbCalculationInterval";
            this.tbCalculationInterval.Padding = new System.Windows.Forms.Padding(5);
            this.tbCalculationInterval.ShowText = false;
            this.tbCalculationInterval.Size = new System.Drawing.Size(119, 24);
            this.tbCalculationInterval.TabIndex = 11;
            this.tbCalculationInterval.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbCalculationInterval.Watermark = "";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.uiLabel5.Location = new System.Drawing.Point(511, 127);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(57, 24);
            this.uiLabel5.TabIndex = 10;
            this.uiLabel5.Text = "计算结果";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.uiLabel4.Location = new System.Drawing.Point(511, 23);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(57, 24);
            this.uiLabel4.TabIndex = 9;
            this.uiLabel4.Text = "对焦函数";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.uiLabel3.Location = new System.Drawing.Point(501, 78);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(78, 21);
            this.uiLabel3.TabIndex = 8;
            this.uiLabel3.Text = "计算间隔(ms)";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GbCameraParameters
            // 
            this.GbCameraParameters.Controls.Add(this.GbROI);
            this.GbCameraParameters.Controls.Add(this.BnGetParam);
            this.GbCameraParameters.Controls.Add(this.BnSetParam);
            this.GbCameraParameters.Controls.Add(this.tbBayerGamma);
            this.GbCameraParameters.Controls.Add(this.uiLabel10);
            this.GbCameraParameters.Controls.Add(this.tbPixelFormat);
            this.GbCameraParameters.Controls.Add(this.tbFrameRate);
            this.GbCameraParameters.Controls.Add(this.tbGain);
            this.GbCameraParameters.Controls.Add(this.uiLabel9);
            this.GbCameraParameters.Controls.Add(this.uiLabel8);
            this.GbCameraParameters.Controls.Add(this.uiLabel7);
            this.GbCameraParameters.Controls.Add(this.uiLabel6);
            this.GbCameraParameters.Controls.Add(this.tbExposure);
            this.GbCameraParameters.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbCameraParameters.Location = new System.Drawing.Point(873, 76);
            this.GbCameraParameters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbCameraParameters.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbCameraParameters.Name = "GbCameraParameters";
            this.GbCameraParameters.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbCameraParameters.Size = new System.Drawing.Size(348, 314);
            this.GbCameraParameters.TabIndex = 7;
            this.GbCameraParameters.Text = "相机参数";
            this.GbCameraParameters.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbROI
            // 
            this.GbROI.Controls.Add(this.tbOffsetY);
            this.GbROI.Controls.Add(this.tbOffsetX);
            this.GbROI.Controls.Add(this.uiLabel14);
            this.GbROI.Controls.Add(this.tbHeight);
            this.GbROI.Controls.Add(this.uiLabel13);
            this.GbROI.Controls.Add(this.uiLabel12);
            this.GbROI.Controls.Add(this.tbWidth);
            this.GbROI.Controls.Add(this.uiLabel11);
            this.GbROI.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbROI.Location = new System.Drawing.Point(4, 144);
            this.GbROI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbROI.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbROI.Name = "GbROI";
            this.GbROI.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbROI.Size = new System.Drawing.Size(340, 119);
            this.GbROI.TabIndex = 28;
            this.GbROI.Text = "ROI";
            this.GbROI.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbOffsetY
            // 
            this.tbOffsetY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOffsetY.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbOffsetY.Location = new System.Drawing.Point(244, 80);
            this.tbOffsetY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOffsetY.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbOffsetY.Name = "tbOffsetY";
            this.tbOffsetY.Padding = new System.Windows.Forms.Padding(5);
            this.tbOffsetY.ShowText = false;
            this.tbOffsetY.Size = new System.Drawing.Size(76, 25);
            this.tbOffsetY.TabIndex = 14;
            this.tbOffsetY.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbOffsetY.Watermark = "";
            // 
            // tbOffsetX
            // 
            this.tbOffsetX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbOffsetX.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbOffsetX.Location = new System.Drawing.Point(244, 31);
            this.tbOffsetX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOffsetX.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbOffsetX.Name = "tbOffsetX";
            this.tbOffsetX.Padding = new System.Windows.Forms.Padding(5);
            this.tbOffsetX.ShowText = false;
            this.tbOffsetX.Size = new System.Drawing.Size(76, 25);
            this.tbOffsetX.TabIndex = 14;
            this.tbOffsetX.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbOffsetX.Watermark = "";
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel14.Location = new System.Drawing.Point(164, 80);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(80, 25);
            this.uiLabel14.TabIndex = 27;
            this.uiLabel14.Text = "垂直偏移：";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHeight
            // 
            this.tbHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbHeight.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbHeight.Location = new System.Drawing.Point(81, 80);
            this.tbHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbHeight.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Padding = new System.Windows.Forms.Padding(5);
            this.tbHeight.ShowText = false;
            this.tbHeight.Size = new System.Drawing.Size(76, 25);
            this.tbHeight.TabIndex = 13;
            this.tbHeight.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbHeight.Watermark = "";
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel13.Location = new System.Drawing.Point(164, 31);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(80, 26);
            this.uiLabel13.TabIndex = 26;
            this.uiLabel13.Text = "水平偏移：";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel12.Location = new System.Drawing.Point(19, 81);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(55, 25);
            this.uiLabel12.TabIndex = 25;
            this.uiLabel12.Text = "高度：";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbWidth
            // 
            this.tbWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbWidth.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbWidth.Location = new System.Drawing.Point(81, 32);
            this.tbWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbWidth.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Padding = new System.Windows.Forms.Padding(5);
            this.tbWidth.ShowText = false;
            this.tbWidth.Size = new System.Drawing.Size(76, 25);
            this.tbWidth.TabIndex = 13;
            this.tbWidth.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbWidth.Watermark = "";
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel11.Location = new System.Drawing.Point(19, 32);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(55, 25);
            this.uiLabel11.TabIndex = 24;
            this.uiLabel11.Text = "宽度：";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnGetParam
            // 
            this.BnGetParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnGetParam.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnGetParam.Location = new System.Drawing.Point(83, 268);
            this.BnGetParam.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnGetParam.Name = "BnGetParam";
            this.BnGetParam.Size = new System.Drawing.Size(78, 32);
            this.BnGetParam.TabIndex = 23;
            this.BnGetParam.Text = "获取参数";
            this.BnGetParam.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnGetParam.Click += new System.EventHandler(this.BnGetParam_Click);
            // 
            // BnSetParam
            // 
            this.BnSetParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnSetParam.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSetParam.Location = new System.Drawing.Point(204, 268);
            this.BnSetParam.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnSetParam.Name = "BnSetParam";
            this.BnSetParam.Size = new System.Drawing.Size(78, 32);
            this.BnSetParam.TabIndex = 19;
            this.BnSetParam.Text = "设置参数";
            this.BnSetParam.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSetParam.Click += new System.EventHandler(this.BnSetParam_Click);
            // 
            // tbBayerGamma
            // 
            this.tbBayerGamma.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBayerGamma.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbBayerGamma.Location = new System.Drawing.Point(248, 74);
            this.tbBayerGamma.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBayerGamma.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbBayerGamma.Name = "tbBayerGamma";
            this.tbBayerGamma.Padding = new System.Windows.Forms.Padding(5);
            this.tbBayerGamma.ShowText = false;
            this.tbBayerGamma.Size = new System.Drawing.Size(76, 25);
            this.tbBayerGamma.TabIndex = 14;
            this.tbBayerGamma.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbBayerGamma.Watermark = "";
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel10.Location = new System.Drawing.Point(186, 74);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(55, 25);
            this.uiLabel10.TabIndex = 22;
            this.uiLabel10.Text = "伽马：";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPixelFormat
            // 
            this.tbPixelFormat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPixelFormat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbPixelFormat.Location = new System.Drawing.Point(122, 115);
            this.tbPixelFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPixelFormat.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbPixelFormat.Name = "tbPixelFormat";
            this.tbPixelFormat.Padding = new System.Windows.Forms.Padding(5);
            this.tbPixelFormat.ShowText = false;
            this.tbPixelFormat.Size = new System.Drawing.Size(181, 24);
            this.tbPixelFormat.TabIndex = 13;
            this.tbPixelFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbPixelFormat.Watermark = "";
            // 
            // tbFrameRate
            // 
            this.tbFrameRate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFrameRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbFrameRate.Location = new System.Drawing.Point(85, 74);
            this.tbFrameRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFrameRate.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbFrameRate.Name = "tbFrameRate";
            this.tbFrameRate.Padding = new System.Windows.Forms.Padding(5);
            this.tbFrameRate.ShowText = false;
            this.tbFrameRate.Size = new System.Drawing.Size(76, 25);
            this.tbFrameRate.TabIndex = 13;
            this.tbFrameRate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbFrameRate.Watermark = "";
            // 
            // tbGain
            // 
            this.tbGain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbGain.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbGain.Location = new System.Drawing.Point(248, 32);
            this.tbGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGain.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbGain.Name = "tbGain";
            this.tbGain.Padding = new System.Windows.Forms.Padding(5);
            this.tbGain.ShowText = false;
            this.tbGain.Size = new System.Drawing.Size(76, 25);
            this.tbGain.TabIndex = 13;
            this.tbGain.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbGain.Watermark = "";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel9.Location = new System.Drawing.Point(23, 115);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(81, 24);
            this.uiLabel9.TabIndex = 21;
            this.uiLabel9.Text = "像素格式：";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel8.Location = new System.Drawing.Point(23, 74);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(55, 25);
            this.uiLabel8.TabIndex = 20;
            this.uiLabel8.Text = "帧率：";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel7.Location = new System.Drawing.Point(186, 32);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(55, 25);
            this.uiLabel7.TabIndex = 19;
            this.uiLabel7.Text = "增益：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.uiLabel6.Location = new System.Drawing.Point(23, 32);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(55, 25);
            this.uiLabel6.TabIndex = 18;
            this.uiLabel6.Text = "曝光：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbExposure
            // 
            this.tbExposure.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbExposure.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbExposure.Location = new System.Drawing.Point(85, 32);
            this.tbExposure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbExposure.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Padding = new System.Windows.Forms.Padding(5);
            this.tbExposure.ShowText = false;
            this.tbExposure.Size = new System.Drawing.Size(76, 25);
            this.tbExposure.TabIndex = 12;
            this.tbExposure.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbExposure.Watermark = "";
            // 
            // GbDataProcessing
            // 
            this.GbDataProcessing.Controls.Add(this.BnFrameCapture);
            this.GbDataProcessing.Controls.Add(this.BnSaveJpg);
            this.GbDataProcessing.Controls.Add(this.BnSaveBmp);
            this.GbDataProcessing.Controls.Add(this.uiLabel2);
            this.GbDataProcessing.Controls.Add(this.tbSavePath);
            this.GbDataProcessing.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbDataProcessing.Location = new System.Drawing.Point(620, 220);
            this.GbDataProcessing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbDataProcessing.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbDataProcessing.Name = "GbDataProcessing";
            this.GbDataProcessing.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbDataProcessing.Size = new System.Drawing.Size(245, 170);
            this.GbDataProcessing.TabIndex = 6;
            this.GbDataProcessing.Text = "数据保存";
            this.GbDataProcessing.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnFrameCapture
            // 
            this.BnFrameCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnFrameCapture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnFrameCapture.Location = new System.Drawing.Point(23, 124);
            this.BnFrameCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnFrameCapture.Name = "BnFrameCapture";
            this.BnFrameCapture.Size = new System.Drawing.Size(203, 32);
            this.BnFrameCapture.TabIndex = 14;
            this.BnFrameCapture.Text = "连续采集每一帧";
            this.BnFrameCapture.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnFrameCapture.Click += new System.EventHandler(this.BnFrameCapture_Click);
            // 
            // BnSaveJpg
            // 
            this.BnSaveJpg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnSaveJpg.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSaveJpg.Location = new System.Drawing.Point(148, 86);
            this.BnSaveJpg.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnSaveJpg.Name = "BnSaveJpg";
            this.BnSaveJpg.Size = new System.Drawing.Size(78, 32);
            this.BnSaveJpg.TabIndex = 13;
            this.BnSaveJpg.Text = "保存JPG";
            this.BnSaveJpg.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSaveJpg.Click += new System.EventHandler(this.BnSaveJpg_Click);
            // 
            // BnSaveBmp
            // 
            this.BnSaveBmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnSaveBmp.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSaveBmp.Location = new System.Drawing.Point(23, 86);
            this.BnSaveBmp.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnSaveBmp.Name = "BnSaveBmp";
            this.BnSaveBmp.Size = new System.Drawing.Size(78, 32);
            this.BnSaveBmp.TabIndex = 12;
            this.BnSaveBmp.Text = "保存BMP";
            this.BnSaveBmp.TipsFont = new System.Drawing.Font("微软雅黑", 10F);
            this.BnSaveBmp.Click += new System.EventHandler(this.BnSaveBmp_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel2.Location = new System.Drawing.Point(23, 25);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(48, 21);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "路径：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSavePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tbSavePath.Location = new System.Drawing.Point(23, 51);
            this.tbSavePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSavePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Padding = new System.Windows.Forms.Padding(5);
            this.tbSavePath.ShowButton = true;
            this.tbSavePath.ShowText = false;
            this.tbSavePath.Size = new System.Drawing.Size(203, 27);
            this.tbSavePath.TabIndex = 2;
            this.tbSavePath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbSavePath.Watermark = "";
            this.tbSavePath.ButtonClick += new System.EventHandler(this.TbSavePath_ButtonClick);
            this.tbSavePath.TextChanged += new System.EventHandler(this.TbSavePath_TextChanged);
            // 
            // GbCalculatedPicture
            // 
            this.GbCalculatedPicture.Controls.Add(this.PbCalculateBox);
            this.GbCalculatedPicture.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.GbCalculatedPicture.Location = new System.Drawing.Point(1229, 76);
            this.GbCalculatedPicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GbCalculatedPicture.MinimumSize = new System.Drawing.Size(1, 1);
            this.GbCalculatedPicture.Name = "GbCalculatedPicture";
            this.GbCalculatedPicture.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GbCalculatedPicture.Size = new System.Drawing.Size(606, 629);
            this.GbCalculatedPicture.TabIndex = 5;
            this.GbCalculatedPicture.Text = "计算画面";
            this.GbCalculatedPicture.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbCalculateBox
            // 
            this.PbCalculateBox.Location = new System.Drawing.Point(3, 25);
            this.PbCalculateBox.Name = "PbCalculateBox";
            this.PbCalculateBox.Size = new System.Drawing.Size(600, 600);
            this.PbCalculateBox.TabIndex = 0;
            this.PbCalculateBox.TabStop = false;
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1842, 714);
            this.Controls.Add(this.GbCalculatedPicture);
            this.Controls.Add(this.BnOpenCamera);
            this.Controls.Add(this.GbCameraParameters);
            this.Controls.Add(this.CbCameraList);
            this.Controls.Add(this.GbDataProcessing);
            this.Controls.Add(this.GbFocusFunction);
            this.Controls.Add(this.GbCaptureImage);
            this.Controls.Add(this.BnFindCamera);
            this.Controls.Add(this.BnCloseCamera);
            this.Controls.Add(this.GbRealTimePicture);
            this.Controls.Add(this.uiLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(3840, 2160);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 29, 2, 2);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowTitleIcon = true;
            this.Text = "hkCameraApp_v1.6";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 8F);
            this.TitleHeight = 29;
            this.ZoomScaleDisabled = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(30, 30, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GbRealTimePicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbImageBox)).EndInit();
            this.GbCaptureImage.ResumeLayout(false);
            this.GbFocusFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResult)).EndInit();
            this.GbCameraParameters.ResumeLayout(false);
            this.GbROI.ResumeLayout(false);
            this.GbDataProcessing.ResumeLayout(false);
            this.GbCalculatedPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbCalculateBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox CbCameraList;
        private Sunny.UI.UIButton BnFindCamera;
        private Sunny.UI.UIButton BnOpenCamera;
        private Sunny.UI.UIButton BnCloseCamera;
        private Sunny.UI.UIGroupBox GbRealTimePicture;
        private System.Windows.Forms.PictureBox PbImageBox;
        private Sunny.UI.UIGroupBox GbCaptureImage;
        private Sunny.UI.UIGroupBox GbFocusFunction;
        private Sunny.UI.UIGroupBox GbCameraParameters;
        private Sunny.UI.UIGroupBox GbDataProcessing;
        private Sunny.UI.UIRadioButton RbTriggerMode;
        private Sunny.UI.UIRadioButton RbContinuesMode;
        private Sunny.UI.UIButton BnStopGrab;
        private Sunny.UI.UIButton BnStartGrab;
        private Sunny.UI.UIButton BnTriggerExec;
        private Sunny.UI.UICheckBox CbSoftTrigger;
        private Sunny.UI.UITextBox tbSavePath;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton BnFrameCapture;
        private Sunny.UI.UIButton BnSaveJpg;
        private Sunny.UI.UIButton BnSaveBmp;
        private Sunny.UI.UITextBox tbCalculationInterval;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox tbCalculationResult;
        private Sunny.UI.UITextBox tbExposure;
        private Sunny.UI.UIButton BnReset;
        private Sunny.UI.UIButton BnStopCalculate;
        private Sunny.UI.UIButton BnStartCalculate;
        private Sunny.UI.UIComboBox CbCalculationMethod;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox tbBayerGamma;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UITextBox tbPixelFormat;
        private Sunny.UI.UITextBox tbFrameRate;
        private Sunny.UI.UITextBox tbGain;
        private Sunny.UI.UIGroupBox GbCalculatedPicture;
        private System.Windows.Forms.PictureBox PbCalculateBox;
        private Sunny.UI.UIButton BnGetParam;
        private Sunny.UI.UIButton BnSetParam;
        private Sunny.UI.UITextBox tbOffsetY;
        private Sunny.UI.UITextBox tbOffsetX;
        private Sunny.UI.UITextBox tbHeight;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox tbWidth;
        private Sunny.UI.UILabel uiLabel11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResult;
        private Sunny.UI.UIGroupBox GbROI;
        public Sunny.UI.UIStyleManager StyleManager;
    }
}