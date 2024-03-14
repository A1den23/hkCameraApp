namespace hkCameraApp
{
    partial class RecordForm
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
            this.LbTime = new Sunny.UI.UILabel();
            this.BnStopCapture = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.BnStartCapture = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // LbTime
            // 
            this.LbTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbTime.ForeColor = System.Drawing.Color.Red;
            this.LbTime.Location = new System.Drawing.Point(42, 87);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(68, 32);
            this.LbTime.Style = Sunny.UI.UIStyle.Custom;
            this.LbTime.TabIndex = 1;
            this.LbTime.Text = "Time";
            this.LbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BnStopCapture
            // 
            this.BnStopCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStopCapture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStopCapture.Location = new System.Drawing.Point(216, 87);
            this.BnStopCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStopCapture.Name = "BnStopCapture";
            this.BnStopCapture.Size = new System.Drawing.Size(78, 32);
            this.BnStopCapture.TabIndex = 16;
            this.BnStopCapture.Text = "停止";
            this.BnStopCapture.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BnStopCapture.Click += new System.EventHandler(this.BnStopCapture_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(3, 35);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(306, 49);
            this.uiLabel1.TabIndex = 17;
            this.uiLabel1.Text = "开始连续采帧，结束请按停止！";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // BnStartCapture
            // 
            this.BnStartCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BnStartCapture.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.BnStartCapture.Location = new System.Drawing.Point(116, 87);
            this.BnStartCapture.MinimumSize = new System.Drawing.Size(1, 1);
            this.BnStartCapture.Name = "BnStartCapture";
            this.BnStartCapture.Size = new System.Drawing.Size(78, 32);
            this.BnStartCapture.TabIndex = 18;
            this.BnStartCapture.Text = "开始";
            this.BnStartCapture.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BnStartCapture.Click += new System.EventHandler(this.BnStartCapture_Click);
            // 
            // RecordForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(312, 136);
            this.Controls.Add(this.BnStartCapture);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.BnStopCapture);
            this.Controls.Add(this.LbTime);
            this.Name = "RecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RecordForm";
            this.ZoomScaleRect = new System.Drawing.Rectangle(30, 30, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordForm_FormClosing);
            this.Load += new System.EventHandler(this.RecordForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel LbTime;
        private Sunny.UI.UIButton BnStopCapture;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIStyleManager StyleManager;
        private Sunny.UI.UIButton BnStartCapture;
    }
}