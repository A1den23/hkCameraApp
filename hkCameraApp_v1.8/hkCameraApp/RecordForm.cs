using Sunny.UI;
using System;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace hkCameraApp
{
    public partial class RecordForm : UIForm
    {
        private Timer timer;
        private int elapsedTimeInSeconds;

        // 公共属性用于获取用户点击按钮时的结果
        public event EventHandler CaptureStop;
        public event EventHandler CaptureStart;

        public RecordForm()
        {
            InitializeComponent();
            InitializeTimer();
            BnStartCapture.Enabled = false;
        }

        private void RecordForm_Load(object sender, EventArgs e)
        {
            LbTime.ForeColor = Color.Red;
            timer.Start();
        }

        private void InitializeTimer()
        {
            timer = new Timer
            {
                Site = null,
                Tag = null,
                Enabled = false,
                Interval = 100
            };
            timer.Tick += Timer_Tick;
            elapsedTimeInSeconds = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++; // 增加经过的秒数
            var elapsedTime = TimeSpan.FromMilliseconds(elapsedTimeInSeconds * 100); // 将秒数转换为毫秒
            // 将经过的时间显示在UI中
            LbTime.Text = elapsedTime.ToString(@"ss\.ff");
        }

        private void BnStartCapture_Click(object sender, EventArgs e)
        {
            timer.Start();
            BnStartCapture.Enabled = false;
            BnStopCapture.Enabled = true;
            CaptureStart?.Invoke(this, EventArgs.Empty);
        }

        private void BnStopCapture_Click(object sender, EventArgs e)
        {
            // 当用户点击停止按钮时停止计时器
            timer.Stop();
            BnStartCapture.Enabled = true;
            BnStopCapture.Enabled = false;
            CaptureStop?.Invoke(this, EventArgs.Empty);
        }

        private void RecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BnStopCapture_Click(sender, e);
        }
    }
}