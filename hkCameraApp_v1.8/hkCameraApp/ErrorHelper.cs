using MvCamCtrl.NET;
using Sunny.UI;

namespace hkCameraApp
{
    internal abstract class ErrorHelper
    {
        private static string GetErrorMessage(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + $"{nErrorNum:X}";
            }

            switch (nErrorNum)
            {
                case CErrorDefine.MV_E_HANDLE:
                    errorMsg += " 错误或无效的句柄 ";
                    break;
                case CErrorDefine.MV_E_SUPPORT:
                    errorMsg += " 不支持此功能 ";
                    break;
                case CErrorDefine.MV_E_BUFOVER:
                    errorMsg += " 缓存已满 ";
                    break;
                case CErrorDefine.MV_E_CALLORDER:
                    errorMsg += " 函数调用顺序错误 ";
                    break;
                case CErrorDefine.MV_E_PARAMETER:
                    errorMsg += " 参数错误 ";
                    break;
                case CErrorDefine.MV_E_RESOURCE:
                    errorMsg += " 应用资源失败 ";
                    break;
                case CErrorDefine.MV_E_NODATA:
                    errorMsg += " 没有数据 ";
                    break;
                case CErrorDefine.MV_E_PRECONDITION:
                    errorMsg += " 前提条件错误，或运行环境发生变化 ";
                    break;
                case CErrorDefine.MV_E_VERSION:
                    errorMsg += " 版本不匹配 ";
                    break;
                case CErrorDefine.MV_E_NOENOUGH_BUF:
                    errorMsg += " 内存不足 ";
                    break;
                case CErrorDefine.MV_E_UNKNOW:
                    errorMsg += " 未知错误 ";
                    break;
                case CErrorDefine.MV_E_GC_GENERIC:
                    errorMsg += " 常规错误 ";
                    break;
                case CErrorDefine.MV_E_GC_ACCESS:
                    errorMsg += " 节点访问条件错误 ";
                    break;
                case CErrorDefine.MV_E_ACCESS_DENIED:
                    errorMsg += " 无权限 ";
                    break;
                case CErrorDefine.MV_E_BUSY:
                    errorMsg += " 设备忙碌，或网络断开连接 ";
                    break;
                case CErrorDefine.MV_E_NETER:
                    errorMsg += " 网络错误 ";
                    break;
            }

            return errorMsg;
        }

        public static void ShowErrorMessage(string csMessage, int nErrorNum)
        {
            var msgForm = new UIForm();
            var errorMsg = GetErrorMessage(csMessage, nErrorNum);
            msgForm.ShowErrorDialog(errorMsg);
        }
    }
}
