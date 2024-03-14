using MvCamCtrl.NET;
using System.IO;

namespace hkCameraApp
{
    internal abstract class DataStorage
    {
        public static void SaveBmp(CCamera camera, CImage image, CFrameSpecInfo frameSpecInfo, string outputPath)
        {
            if (image.FrameLen == 0)
            {
                ErrorHelper.ShowErrorMessage("保存BMP图片失败！", 0);
                return;
            }

            var stSaveFileParam = new CSaveImgToFileParam
            {
                ImageType = MV_SAVE_IAMGE_TYPE.MV_IMAGE_BMP,
                Image = image,
                Quality = 99,
                MethodValue = 2,
                ImagePath = Path.Combine(outputPath, "Frame_" + frameSpecInfo.FrameNum + ".bmp")
            };

            var nRet = camera.SaveImageToFile(ref stSaveFileParam);
            if (CErrorDefine.MV_OK == nRet) return;
            ErrorHelper.ShowErrorMessage("保存BMP图片失败！", nRet);
        }

        public static void SaveJpg(CCamera camera, CImage image, CFrameSpecInfo frameSpecInfo, string outputPath)
        {
            if (image.FrameLen == 0)
            {
                ErrorHelper.ShowErrorMessage("保存JPG图片失败！", 0);
                return;
            }

            var stSaveFileParam = new CSaveImgToFileParam
            {
                ImageType = MV_SAVE_IAMGE_TYPE.MV_IMAGE_JPEG,
                Image = image,
                Quality = 99,
                MethodValue = 2,
                ImagePath = Path.Combine(outputPath, "Image_" + frameSpecInfo.FrameNum + ".jpg")
            };

            var nRet = camera.SaveImageToFile(ref stSaveFileParam);
            if (CErrorDefine.MV_OK == nRet) return;
            ErrorHelper.ShowErrorMessage("保存JPG图片失败！", nRet);
        }

        public void RecordVideo(CCamera camera, CImage image, CFrameSpecInfo frameSpecInfo, string outputPath)
        {
            if (image.FrameLen == 0)
            {  
                ErrorHelper.ShowErrorMessage("Recording Video Failed!", 0);
                return;
            }
            
                        // 获取帧率
                        var getFloatValue = new CFloatValue();
            camera.GetFloatValue("ResultingFrameRate", ref getFloatValue);

            var stRecordParam = new CRecordParam
            {
                Image = image,
                RecordFmtType = MV_RECORD_FORMAT_TYPE.MV_FORMAT_TYPE_AVI,
                BitRate = 16000,
                FrameRate = getFloatValue.CurValue,
                FilePath = Path.Combine(outputPath, "Video_" + frameSpecInfo.FrameNum + ".avi")
            };

            var nRet = camera.StartRecord(ref stRecordParam);
            if (nRet != CErrorDefine.MV_OK)
            {
                ErrorHelper.ShowErrorMessage("Recording Video Failed!", nRet);
            }
        }
    }
}