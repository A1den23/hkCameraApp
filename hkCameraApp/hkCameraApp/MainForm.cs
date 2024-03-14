using MvCamCtrl.NET;
using MvCamCtrl.NET.CameraParams;
using OpenCvSharp;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace hkCameraApp
{
    public partial class MainForm : UIForm
    {
        /* 定义私有成员变量 */
        private CCamera camera = new CCamera();
        private List<CCameraInfo> deviceList = new List<CCameraInfo>();
        private bool grabbing;
        private Thread receiveThread;

        // 用于从驱动获取图像的缓存
        private static readonly object BufForDriverLock = new object();
        private CImage imgForDriver; // 图像信息
        private CFrameSpecInfo imgSpecInfo; // 图像的水印信息

        // Bitmap
        private Bitmap pcBitmap;
        private PixelFormat bitmapPixelFormat = PixelFormat.DontCare;

        // 计算函数成员变量
        private CancellationTokenSource cancellationTokenSource;
        private Mat bayerImg;
        private Mat grayImg;
        private Mat grayDouble;
        private bool deviceConnceted;
        private double calculationResult;
        private bool startFrameCapture;

        private bool isCalculating;
        private string selectedMethod;

        // 声明 DataStorage 的变量
        private string savePath = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            DeviceListAcq();
            CheckForIllegalCrossThreadCalls = false;
        }

        // 主窗体载入设置
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetCtrlWhenClose();
            deviceConnceted = false;
            tbSavePath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // 设置图表类型为折线图
            chartResult.Series.Clear();
            chartResult.Series.Add("Result");
            chartResult.Series["Result"].ChartType = SeriesChartType.Spline;
            chartResult.Series["Result"].BorderWidth = 2;
            chartResult.Series["Result"].Color = Color.Red;

            // 隐藏XY轴具体数字
            chartResult.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartResult.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            // 隐藏网格线
            chartResult.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartResult.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // 设置 tbCalculationInterval 计算间隔的初始值为 50
            tbCalculationInterval.Text = @"50";

            // 添加计算方式选项
            CbCalculationMethod.Items.AddRange(new object[]
                { "Variance", "Volt4", "TenGradient", "GaussianFilter", "Laplacian" });
            CbCalculationMethod.SelectedIndex = 2;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BnCloseCamera_Click(sender, e);
        }

        private void DeviceListAcq()
        {
            // 创建设备列表
            GC.Collect(); // 强制进行垃圾回收以释放内存
            CbCameraList.Items.Clear(); // 清空控件CbCameraList中的选项
            deviceList.Clear(); // 清空列表CbCameraList

            // 使用CSystem类的EnumDevices方法列举设备，获取设备列表，存储在m_ltDeviceList中
            var nRet = CSystem.EnumDevices(CSystem.MV_GIGE_DEVICE | CSystem.MV_USB_DEVICE, ref deviceList);
            if (0 != nRet) // 如果返回值不为0，说明列举设备失败
            {
                ErrorHelper.ShowErrorMessage("设备枚举失败！", nRet); // 显示错误消息并返回
                return;
            }

            // 在窗体列表中显示设备名
            foreach (var t in deviceList)
            {
                switch (t.nTLayerType)
                {
                    // 判断设备类型，如果是GigE设备
                    case CSystem.MV_GIGE_DEVICE:
                    {
                        var gigInfo = (CGigECameraInfo)t;

                        // 判断是否存在用户定义的设备名称
                        if (gigInfo.UserDefinedName != "")
                        {
                            // 在控件CbCameraList中添加设备信息（格式：GEV: 用户定义的设备名称 (设备序列号)）
                            CbCameraList.Items.Add(
                                "GEV: " + gigInfo.UserDefinedName + " (" + gigInfo.chSerialNumber + ")");
                        }
                        else
                        {
                            // 在控件CbCameraList中添加设备信息（格式：GEV: 制造商名称 型号名称 (设备序列号)）
                            CbCameraList.Items.Add("GEV: " + gigInfo.chManufacturerName + " " + gigInfo.chModelName +
                                                   " (" + gigInfo.chSerialNumber + ")");
                        }

                        break;
                    }
                    // 判断设备类型，如果是USB设备
                    case CSystem.MV_USB_DEVICE:
                    {
                        var usbInfo = (CUSBCameraInfo)t;

                        // 判断是否存在用户定义的设备名称
                        if (usbInfo.UserDefinedName != "")
                        {
                            // 在控件CbCameraList中添加设备信息（格式：U3V: 用户定义的设备名称 (设备序列号)）
                            CbCameraList.Items.Add("U3V: " + usbInfo.UserDefinedName + " (" + usbInfo.chSerialNumber +
                                                   ")");
                        }
                        else
                        {
                            // 在控件CbCameraList中添加设备信息（格式：U3V: 制造商名称 型号名称 (设备序列号)）
                            CbCameraList.Items.Add("U3V: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName +
                                                   " (" + usbInfo.chSerialNumber + ")");
                        }

                        break;
                    }
                }
            }

            // 选择第一项
            if (deviceList.Count != 0)
            {
                CbCameraList.SelectedIndex = 0; // 将控件CbCameraList的选中索引设置为0，即选择第一项
            }
        }

        private void SetCtrlWhenOpen()
        {
            BnOpenCamera.Enabled = false;
            BnCloseCamera.Enabled = true;
            BnStartGrab.Enabled = true;
            BnStopGrab.Enabled = false;
            RbContinuesMode.Enabled = true;
            RbContinuesMode.Checked = true;
            RbTriggerMode.Enabled = true;
            CbSoftTrigger.Enabled = false;
            BnTriggerExec.Enabled = false;
            BnGetParam.Enabled = true;
            BnSetParam.Enabled = true;
            tbPixelFormat.Enabled = false;
            BnStartCalculate.Enabled = false;
            BnStopCalculate.Enabled = false;
            BnReset.Enabled = false;
            tbCalculationInterval.Enabled = true;
            isCalculating = false;
            tbExposure.Enabled = true;
            tbGain.Enabled = true;
            tbFrameRate.Enabled = true;
            tbBayerGamma.Enabled = true;
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbOffsetX.Enabled = false;
            tbOffsetY.Enabled = false;
        }

        private void SetCtrlWhenClose()
        {
            BnOpenCamera.Enabled = true;
            BnCloseCamera.Enabled = false;
            BnStartGrab.Enabled = false;
            BnStopGrab.Enabled = false;
            RbContinuesMode.Enabled = false;
            RbTriggerMode.Enabled = false;
            CbSoftTrigger.Enabled = false;
            BnTriggerExec.Enabled = false;
            BnFrameCapture.Enabled = false;
            BnSaveBmp.Enabled = false;
            BnSaveJpg.Enabled = false;
            BnGetParam.Enabled = false;
            BnSetParam.Enabled = false;
            tbPixelFormat.Enabled = false;
            BnStartCalculate.Enabled = false;
            BnStopCalculate.Enabled = false;
            BnReset.Enabled = false;
            tbExposure.Enabled = false;
            tbGain.Enabled = false;
            tbFrameRate.Enabled = false;
            tbBayerGamma.Enabled = false;
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbOffsetX.Enabled = false;
            tbOffsetY.Enabled = false;
            tbCalculationInterval.Enabled = false;
            tbCalculationResult.Enabled = false;
            isCalculating = false;
        }

        private void SetCtrlWhenStartGrab()
        {
            BnStartGrab.Enabled = false;
            BnStopGrab.Enabled = true;

            if (RbTriggerMode.Checked && CbSoftTrigger.Checked)
            {
                BnTriggerExec.Enabled = true;
            }

            BnFrameCapture.Enabled = true;
            BnSaveBmp.Enabled = true;
            BnSaveJpg.Enabled = true;
            BnStartCalculate.Enabled = true;
            BnStopCalculate.Enabled = false;
            BnReset.Enabled = false;
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbOffsetX.Enabled = false;
            tbOffsetY.Enabled = false;
            tbCalculationInterval.Enabled = true;
            tbCalculationResult.Enabled = false;
            isCalculating = false;
        }

        private void SetCtrlWhenStopGrab()
        {
            BnStartGrab.Enabled = true;
            BnStopGrab.Enabled = false;
            BnTriggerExec.Enabled = false;
            BnSaveBmp.Enabled = false;
            BnSaveJpg.Enabled = false;
            BnFrameCapture.Enabled = false;
            BnStartCalculate.Enabled = false;
            BnStopCalculate.Enabled = false;
            BnReset.Enabled = true;
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbOffsetX.Enabled = false;
            tbOffsetY.Enabled = false;
            tbCalculationInterval.Enabled = true;
            tbCalculationResult.Enabled = false;
            isCalculating = false;
        }

        private void BnFindCamera_Click(object sender, EventArgs e)
        {
            DeviceListAcq();
        }

        private void BnOpenCamera_Click(object sender, EventArgs e)
        {
            // 检查设备列表是否为空或未选择设备
            if (deviceList.Count == 0 || CbCameraList.SelectedIndex == -1)
            {
                ErrorHelper.ShowErrorMessage("无设备，请选择", 0);
                return;
            }

            // 获取选择的设备信息
            var device = deviceList[CbCameraList.SelectedIndex];

            // 创建设备句柄并打开设备
            if (null == camera)
            {
                camera = new CCamera();
                if (null == camera)
                {
                    return;
                }
            }

            var nRet = camera.CreateHandle(ref device); // 创建设备句柄
            if (CErrorDefine.MV_OK != nRet)
            {
                return;
            }

            nRet = camera.OpenDevice(); // 打开设备
            if (CErrorDefine.MV_OK != nRet)
            {
                camera.DestroyHandle();
                ErrorHelper.ShowErrorMessage("设备打开失败！", nRet);
                return;
            }

            // 对于GigE相机，探测网络最佳包大小并设置
            if (device.nTLayerType == CSystem.MV_GIGE_DEVICE)
            {
                var nPacketSize = camera.GIGE_GetOptimalPacketSize(); // 探测网络最佳包大小
                if (nPacketSize > 0)
                {
                    nRet = camera.SetIntValue("GevCPSPacketSize", (uint)nPacketSize); // 设置包大小
                    if (nRet != CErrorDefine.MV_OK)
                    {
                        ErrorHelper.ShowErrorMessage("设置数据包大小失败！", nRet);
                    }
                }
            }

            // 控件操作：设置打开设备时的控件状态
            SetCtrlWhenOpen();
            ClearTextBox();
            deviceConnceted = true; 

            // 获取参数
            BnGetParam_Click(null, null);
        }

        private void BnCloseCamera_Click(object sender, EventArgs e)
        {
            // 使用 deviceConnceted 来判断相机是否已连接
            if (!deviceConnceted) return;
            // 取流标志位清零
            if (grabbing)
            {
                grabbing = false;
                receiveThread.Join();
            }

            if (isCalculating)
            {
                cancellationTokenSource?.Cancel();
            }

            // 关闭设备
            var nRet = camera.CloseDevice();
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("关闭相机失败！", nRet);
            }

            nRet = camera.DestroyHandle();
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("摧毁句柄失败！", nRet);
            }

            // 控件操作
            SetCtrlWhenClose();
            BnReset_Click(sender, e);
            deviceConnceted = false;
        }

        private void RbContinuesMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!RbContinuesMode.Checked) return;
            camera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
            CbSoftTrigger.Enabled = false;
            BnTriggerExec.Enabled = false;
        }

        private void RbTriggerMode_CheckedChanged(object sender, EventArgs e)
        {
            // 打开触发模式
            if (!RbTriggerMode.Checked) return;
            camera.SetEnumValue("TriggerMode", (uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);

            if (CbSoftTrigger.Checked)
            {
                camera.SetEnumValue("TriggerSource", (uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                if (grabbing)
                {
                    BnTriggerExec.Enabled = true;
                }
            }
            else
            {
                camera.SetEnumValue("TriggerSource", (uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
            }

            CbSoftTrigger.Enabled = true;
        }

        private void CbSoftTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (CbSoftTrigger.Checked)
            {
                // ch:触发源设为软触发 | en:Set trigger source as Software
                camera.SetEnumValue("TriggerSource", (uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                if (grabbing)
                {
                    BnTriggerExec.Enabled = true;
                }
            }
            else
            {
                camera.SetEnumValue("TriggerSource", (uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                BnTriggerExec.Enabled = false;
            }
        }

        private void BnTriggerExec_Click(object sender, EventArgs e)
        {
            // 触发命令
            var nRet = camera.SetCommandValue("TriggerSoftware");
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("触发软件故障！", nRet);
            }
        }

        private void GetTriggerMode()
        {
            var pcEnumValue = new CEnumValue();
            var nRet = camera.GetEnumValue("TriggerMode", ref pcEnumValue);
            if (CErrorDefine.MV_OK == nRet) return;
            // 触发模式下
            if ((uint)MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON == pcEnumValue.CurValue)
            {
                RbTriggerMode.Checked = true;
                RbContinuesMode.Checked = false;

                // 获取触发源
                nRet = camera.GetEnumValue("TriggerSource", ref pcEnumValue);
                if (CErrorDefine.MV_OK != nRet) return;
                if ((uint)MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE != pcEnumValue.CurValue) return;
                CbSoftTrigger.Checked = true;
                if (grabbing)
                {
                    BnTriggerExec.Enabled = true;
                }

                CbSoftTrigger.Enabled = true;
            }
            else
            {
                // 连续模式下
                RbTriggerMode.Checked = true;
                RbContinuesMode.Checked = false;
            }
        }

        private void ReceiveThreadProcess()
        {
            while (grabbing)
            {
                var pcFrameInfo = new CFrameout();
                var pcDisplayInfo = new CDisplayFrameInfo();
                var pcConvertParam = new CPixelConvertParam();

                var nRet = camera.GetImageBuffer(ref pcFrameInfo, 1000);
                if (nRet == CErrorDefine.MV_OK)
                {
                    lock (BufForDriverLock)
                    {
                        imgForDriver = pcFrameInfo.Image.Clone() as CImage;
                        imgSpecInfo = pcFrameInfo.FrameSpec;

                        pcConvertParam.InImage = pcFrameInfo.Image;
                        if (PixelFormat.Format8bppIndexed == pcBitmap.PixelFormat)
                        {
                            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_Mono8;
                            camera.ConvertPixelType(ref pcConvertParam);
                        }
                        else
                        {
                            pcConvertParam.OutImage.PixelType = MvGvspPixelType.PixelType_Gvsp_BGR8_Packed;
                            camera.ConvertPixelType(ref pcConvertParam);
                        }

                        // 保存Bitmap数据
                        var mPcBitmapData =
                            pcBitmap.LockBits(
                                new Rectangle(0, 0, pcConvertParam.InImage.Width, pcConvertParam.InImage.Height),
                                ImageLockMode.ReadWrite, pcBitmap.PixelFormat);
                        Marshal.Copy(pcConvertParam.OutImage.ImageData, 0, mPcBitmapData.Scan0,
                            pcConvertParam.OutImage.ImageData.Length);
                        pcBitmap.UnlockBits(mPcBitmapData);
                    }

                    pcDisplayInfo.WindowHandle = PbImageBox.Handle;
                    pcDisplayInfo.Image = pcFrameInfo.Image;
                    camera.DisplayOneFrame(ref pcDisplayInfo);
                    camera.FreeImageBuffer(ref pcFrameInfo);
                }
                else
                {
                    if (RbTriggerMode.Checked)
                    {
                        Thread.Sleep(5);
                    }
                }
            }
        }

        // 取图前的必要操作步骤
        private int NecessaryOpenBeforeGrab()
        {
            // 取图像宽
            var pcWidth = new CIntValue();
            var nRet = camera.GetIntValue("Width", ref pcWidth);
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("获取宽度信息失败！", nRet);
                return nRet;
            }

            // 取图像高
            var pcHeight = new CIntValue();
            nRet = camera.GetIntValue("Height", ref pcHeight);
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("获取高度信息失败！", nRet);
                return nRet;
            }

            // 取像素格式
            var pcPixelFormat = new CEnumValue();
            nRet = camera.GetEnumValue("PixelFormat", ref pcPixelFormat);
            if (CErrorDefine.MV_OK != nRet)
            {
                ErrorHelper.ShowErrorMessage("获取像素格式失败！", nRet);
                return nRet;
            }

            // 设置bitmap像素格式
            if ((int)MvGvspPixelType.PixelType_Gvsp_Undefined == (int)pcPixelFormat.CurValue)
            {
                ErrorHelper.ShowErrorMessage("未知的像素格式！", CErrorDefine.MV_E_UNKNOW);
                return CErrorDefine.MV_E_UNKNOW;
            }
            else if (IsMono((MvGvspPixelType)pcPixelFormat.CurValue))
            {
                bitmapPixelFormat = PixelFormat.Format8bppIndexed;
            }
            else
            {
                bitmapPixelFormat = PixelFormat.Format24bppRgb;
            }

            if (null != pcBitmap)
            {
                pcBitmap.Dispose();
                pcBitmap = null;
            }

            pcBitmap = new Bitmap((int)pcWidth.CurValue, (int)pcHeight.CurValue, bitmapPixelFormat);

            // Mono8格式，设置为标准调色板
            if (PixelFormat.Format8bppIndexed != bitmapPixelFormat) return CErrorDefine.MV_OK;
            var palette = pcBitmap.Palette;
            for (var i = 0; i < palette.Entries.Length; i++)
            {
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }

            pcBitmap.Palette = palette;

            return CErrorDefine.MV_OK;
        }

        // 像素类型是否为Mono格式
        private static bool IsMono(MvGvspPixelType enPixelType)
        {
            switch (enPixelType)
            {
                case MvGvspPixelType.PixelType_Gvsp_Mono1p:
                case MvGvspPixelType.PixelType_Gvsp_Mono2p:
                case MvGvspPixelType.PixelType_Gvsp_Mono4p:
                case MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MvGvspPixelType.PixelType_Gvsp_Mono8_Signed:
                case MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                case MvGvspPixelType.PixelType_Gvsp_Mono14:
                case MvGvspPixelType.PixelType_Gvsp_Mono16:
                    return true;
                default:
                    return false;
            }
        }

        private async Task StartGrabbingAsync()
        {
            // 前置配置
            var nRet = NecessaryOpenBeforeGrab();
            if (CErrorDefine.MV_OK != nRet)
            {
                return;
            }

            // 标志位置位true
            grabbing = true;

            receiveThread = new Thread(ReceiveThreadProcess);
            receiveThread.Start();

            // 开始采集
            nRet = await Task.Run(() => camera.StartGrabbing());
            if (CErrorDefine.MV_OK != nRet)
            {
                grabbing = false;
                receiveThread.Join();
                ErrorHelper.ShowErrorMessage("开始抓取图像失败！", nRet);
                return;
            }

            camera.SetBoolValue("AcquisitionFrameRateEnable", true); // 开启采集帧率使能
            camera.SetBoolValue("BalanceWhiteAuto", false); // 关闭自动白平衡
            tbBayerGamma.Text = @"1.0"; // 设置 tbBayerGamma 的初始值为 1

            // 控件操作
            SetCtrlWhenStartGrab();
            ClearTextBox();
        }

        private async void BnStartGrab_Click(object sender, EventArgs e)
        {
            await StartGrabbingAsync();
        }

        private void BnStopGrab_Click(object sender, EventArgs e)
        {
            if (!grabbing)
            {
                ErrorHelper.ShowErrorMessage("未开始抓取图像", 0);
                return;
            }

            if (isCalculating)
            {
                cancellationTokenSource?.Cancel();
            }

            // 标志位设为false
            grabbing = false;
            receiveThread.Join();

            // 停止采集
            var nRet = camera.StopGrabbing();
            if (nRet != CErrorDefine.MV_OK)
            {
                ErrorHelper.ShowErrorMessage("停止抓取图像失败！", nRet);
            }

            // 控件操作
            SetCtrlWhenStopGrab();
        }

        // 开始计算对焦函数
        private void BnStartCalculate_Click(object sender, EventArgs e)
        {
            if (isCalculating)
            {
                ErrorHelper.ShowErrorMessage("计算操作只能执行一次！", 0);
                return;
            }

            // 解析输入的计算间隔值
            if (!int.TryParse(tbCalculationInterval.Text, out var calculateInterval) || calculateInterval <= 0)
            {
                ErrorHelper.ShowErrorMessage("无效的计算间隔！", 0);
                return;
            }

            // 创建取消令牌
            cancellationTokenSource = new CancellationTokenSource();

            // 启动计算操作
            Task.Run(() => CalculateFocus(calculateInterval, cancellationTokenSource.Token));

            BnStopCalculate.Enabled = true;
            tbCalculationInterval.Enabled = false;
            BnReset.Enabled = true;
            isCalculating = true;
        }

        private static void ShowImageInPictureBox(Mat image, PictureBox pictureBox)
        {
            var pictureBitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(image);
            // 在PictureBox中显示图像
            pictureBox.Image = pictureBitmap;
        }

        //  CbCalculationMethod的选择事件处理程序
        private void CbCalculationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取选择的计算方式
            selectedMethod = CbCalculationMethod.SelectedItem.ToString();

            // 清空图表的数据序列
            chartResult.Series["Result"].Points.Clear();
        }

        // 清空文本框内容
        private void ClearTextBox()
        {
            tbCalculationResult.Text = string.Empty;
        }

        private void CalculateFocus(int calculateInterval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // 在定时器的回调函数中执行计算操作
                lock (BufForDriverLock)
                {
                    // 进行图像处理和计算操作
                    bayerImg = new Mat(imgForDriver.Height, imgForDriver.Width, MatType.CV_8UC1,
                        imgForDriver.ImageAddr);
                    grayImg = new Mat();
                    grayDouble = new Mat();

                    Cv2.CvtColor(bayerImg, grayImg, ColorConversionCodes.BayerRG2GRAY);
                    grayImg.ConvertTo(grayDouble, MatType.CV_64F);

                    // 显示图像到CalculateBox
                    ShowImageInPictureBox(grayImg, PbCalculateBox);

                    var m = grayDouble.Rows;
                    var n = grayDouble.Cols;

                    switch (selectedMethod)
                    {
                        case "Variance":
                            calculationResult = FocusMethod.Variance(grayDouble, m, n);
                            break;
                        case "Volt4":
                            calculationResult = FocusMethod.Volt4(grayDouble, m, n);
                            break;
                        case "TenGradient":
                            calculationResult = FocusMethod.TenGradient(grayDouble);
                            break;
                        case "GaussianFilter":
                            calculationResult = FocusMethod.GaussianFilter(grayDouble, m, n);
                            break;
                        case "Laplacian":
                            calculationResult = FocusMethod.Laplacian(grayDouble, m, n);
                            break;
                        default:
                            // 如果没有选择计算方式，则不执行计算操作
                            return;
                    }

                    // 更新UI界面的计算结果
                    BeginInvoke(new Action(() =>
                    {
                        // 更新文本框
                        tbCalculationResult.Text = calculationResult.ToString("F3");

                        // 添加计算结果到图表数据序列中
                        chartResult.Series["Result"].Points.AddY(calculationResult);
                    }));

                    // 保持数据点数量不超过100个
                    if (chartResult.Series["Result"].Points.Count >= 100)
                    {
                        // 移除最早的数据点，确保只保留最新的100个数据点
                        while (chartResult.Series["Result"].Points.Count >= 100)
                        {
                            chartResult.Series["Result"].Points.RemoveAt(0);
                        }
                    }

                    // 等待计算间隔
                    Thread.Sleep(calculateInterval);
                }
            }
        }

        private void BnStopCalculate_Click(object sender, EventArgs e)
        {
            // 取消计算操作
            cancellationTokenSource?.Cancel();

            BnStartCalculate.Enabled = true;
            BnReset.Enabled = true;
            tbCalculationInterval.Enabled = true;
            isCalculating = false;
        }

        private void BnReset_Click(object sender, EventArgs e)
        {
            // 清空图表的数据序列
            chartResult.Series["Result"].Points.Clear();

            // 释放之前的计算结果
            calculationResult = 0; // 或者根据需要的数据类型设置适当的初始值
            tbCalculationResult.Text = ""; // 清空文本框
        }

        private void TbSavePath_TextChanged(object sender, EventArgs e)
        {
            savePath = tbSavePath.Text;
        }

        private void TbSavePath_ButtonClick(object sender, EventArgs e)
        {
            var dir = "";
            if (!DirEx.SelectDirEx("选择文件夹", ref dir)) return;
            UIMessageTip.ShowOk(dir);
            tbSavePath.Text = dir;
        }

        private void BnSaveBmp_Click(object sender, EventArgs e)
        {
            lock (BufForDriverLock)
            {
                DataStorage.SaveBmp(camera, imgForDriver, imgSpecInfo, savePath);
            }

            ShowSuccessDialog("保存成功！");
        }

        private void BnSaveJpg_Click(object sender, EventArgs e)
        {
            lock (BufForDriverLock)
            {
                DataStorage.SaveJpg(camera, imgForDriver, imgSpecInfo, savePath);
            }

            ShowSuccessDialog("保存成功！");
        }

        private void BnFrameCapture_Click(object sender, EventArgs e)
        {
            startFrameCapture = true;

            // 启动一个新线程来执行连续采集每一帧方法
            var frameCaptureThread = new Thread(FrameCapture);

            frameCaptureThread.Start();
            ShowRecordingPrompt();
            frameCaptureThread.Join();
        }

        private void FrameCapture()
        {
            while (grabbing && startFrameCapture)
            {
                DataStorage.SaveBmp(camera, imgForDriver, imgSpecInfo, savePath);
            }
        }

        // 弹出提示框
        private void ShowRecordingPrompt()
        {
            using var form = new RecordForm();
            form.CaptureStart += RecordForm_CaptureStart;
            form.CaptureStop += RecordForm_CaptureStop;
            form.ShowDialog();
        }

        private void RecordForm_CaptureStart(object sender, EventArgs e)
        {
            var frameCaptureThread = new Thread(FrameCapture);
            startFrameCapture = true;
            frameCaptureThread.Start();
        }

        private void RecordForm_CaptureStop(object sender, EventArgs e)
        {
            startFrameCapture = false;
        }

        private void BnGetParam_Click(object sender, EventArgs e)
        {
            var setFloatValue = new CFloatValue();
            var setEnumValue = new CEnumValue();
            var setEntryValue = new CEnumEntry();
            var setIntValue = new CIntValue();

            // 获取触发模式
            GetTriggerMode();

            // 获取曝光时间
            var nRet = camera.GetFloatValue("ExposureTime", ref setFloatValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbExposure.Text = setFloatValue.CurValue.ToString("F1");
            }

            // 获取增益
            nRet = camera.GetFloatValue("Gain", ref setFloatValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbGain.Text = setFloatValue.CurValue.ToString("F1");
            }

            // 获取帧率
            nRet = camera.GetFloatValue("ResultingFrameRate", ref setFloatValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbFrameRate.Text = setFloatValue.CurValue.ToString("F1");
            }

            // 获取ROI宽度
            nRet = camera.GetIntValue("Width", ref setIntValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbWidth.Text = setIntValue.CurValue.ToString("F1");
            }

            // 获取ROI高度
            nRet = camera.GetIntValue("Height", ref setIntValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbHeight.Text = setIntValue.CurValue.ToString("F1");
            }

            // 获取ROI的水平方向偏移量 
            nRet = camera.GetIntValue("OffsetX", ref setIntValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbOffsetX.Text = setIntValue.CurValue.ToString("F1");
            }

            // 获取ROI的竖直方向偏移量
            nRet = camera.GetIntValue("OffsetY", ref setIntValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbOffsetY.Text = setIntValue.CurValue.ToString("F1");
            }

            // 获取像素格式
            nRet = camera.GetEnumValue("PixelFormat", ref setEnumValue);
            if (CErrorDefine.MV_OK != nRet) return;
            setEntryValue.Value = setEnumValue.CurValue;
            nRet = camera.GetEnumEntrySymbolic("PixelFormat", ref setEntryValue);
            if (CErrorDefine.MV_OK == nRet)
            {
                tbPixelFormat.Text = setEntryValue.Symbolic;
            }
        }

        private void BnSetParam_Click(object sender, EventArgs e)
        {
            var exposure = float.Parse(tbExposure.Text);
            var gain = float.Parse(tbGain.Text);
            var reacquisition = float.Parse(tbFrameRate.Text);

            // 设置BayerGamma
            int nRet;
            if (float.TryParse(tbBayerGamma.Text, out var gammaValue))
            {
                // 调用相机成员方法设置Bayer Gamma值
                nRet = camera.SetBayerGammaValue(gammaValue);
                if (nRet != CErrorDefine.MV_OK)
                {
                    ErrorHelper.ShowErrorMessage("无效的伽玛值！", nRet);
                }
            }

            camera.SetEnumValue("ExposureAuto", 0);
            nRet = camera.SetFloatValue("ExposureTime", exposure);
            if (nRet != CErrorDefine.MV_OK)
            {
                ErrorHelper.ShowErrorMessage("曝光时间设置失败！", nRet);
            }

            camera.SetEnumValue("GainAuto", 0);
            nRet = camera.SetFloatValue("Gain", gain);
            if (nRet != CErrorDefine.MV_OK)
            {
                ErrorHelper.ShowErrorMessage("增益设置失败！", nRet);
            }

            nRet = camera.SetFloatValue("AcquisitionFrameRate", reacquisition);
            if (nRet != CErrorDefine.MV_OK)
            {
                ErrorHelper.ShowErrorMessage("帧率设置失败！", nRet);
            }
        }
    }
}