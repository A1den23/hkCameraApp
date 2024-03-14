using OpenCvSharp;
using System;

namespace hkCameraApp
{
    internal abstract class FocusMethod
    {
        public static double Variance(Mat grayImg, int m, int n)
        {
            var reshapedImg = grayImg.Reshape(1); // Reshape to a single row
            var muG = Cv2.Mean(reshapedImg).Val0;

            Mat diff = reshapedImg - muG;
            Mat squaredDiff = diff.Mul(diff);

            var sumSquaredDiff = Cv2.Sum(squaredDiff).Val0;

            var varMeasure = sumSquaredDiff / (m * n * muG);

            return varMeasure;
        }

        public static double Volt4(Mat grayImg, int m, int n)
        {
            var upperImg = grayImg.SubMat(new Rect(0, 0, n, m - 1));
            var lowerImg = grayImg.SubMat(new Rect(0, 1, n, m - 1));

            var sum1 = Cv2.Sum(upperImg.Mul(lowerImg)).Val0;

            var upperImg2 = grayImg.SubMat(new Rect(0, 0, n, m - 2));
            var lowerImg2 = grayImg.SubMat(new Rect(0, 2, n, m - 2));

            var sum2 = Cv2.Sum(upperImg2.Mul(lowerImg2)).Val0;

            var volt4Measure = sum1 - sum2;
            var volt4Normalized = volt4Measure / (m * n);

            return volt4Normalized;
        }

        public static double TenGradient(Mat grayImg)
        {
            // 定义Lobes核
            var s1 = new Mat(3, 3, MatType.CV_32F, new float[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 });
            var s2 = s1.T();

            // 进行Lobes滤波
            var lobesGx = new Mat();
            Cv2.Filter2D(grayImg, lobesGx, -1, s1);

            var lobesGy = new Mat();
            Cv2.Filter2D(grayImg, lobesGy, -1, s2);

            var squaredLobes = new Mat();
            Cv2.Pow(lobesGx, 2, squaredLobes);
            Cv2.Pow(lobesGy, 2, lobesGy); // 注意此处提供了输出矩阵 lobesGy

            Cv2.Add(squaredLobes, lobesGy, squaredLobes);

            var tenNormalized = Cv2.Mean(squaredLobes).Val0;

            return tenNormalized;
        }
        public static double GaussianFilter(Mat grayImg, int m, int n)
        {

            var sigma = 3.45 / (2 * Math.Sqrt(3));
            var size = (int)Math.Round(3 * sigma) | 1;

            // 计算高斯滤波器在X和Y方向上的一阶导数
            var gm = new Mat();
            var gn = new Mat();
            Cv2.Sobel(grayImg, gm, MatType.CV_64F, 1, 0, size, scale: 1, delta: 0);
            Cv2.Sobel(grayImg, gn, MatType.CV_64F, 0, 1, size, scale: 1, delta: 0);

            // 计算梯度的幅值
            var magnitude = new Mat();
            Cv2.Magnitude(gm, gn, magnitude);

            // 计算F_GF，作为由图像面积（M * N）归一化的平方幅度之和。
            var sumOfSquares = Cv2.Sum(magnitude.Mul(magnitude)); // 逐元素相乘并求和
            var fGf = sumOfSquares[0] / (m * n);

            // 标准化 F_GF - 假设标准化范围为 [0, 1]
            // 此步骤取决于标准化的上下文。这里使用简单的最小-最大值归一化。
            var fGfNormalized = (fGf - 0) / (1 - 0); // 根据实际的最小-最大值进行调整
            return fGfNormalized;
        }

        public static double Laplacian(Mat grayImg, int m, int n)
        {
            var laplacian = new Mat();

            // 计算Lap算子
            Cv2.Laplacian(grayImg, laplacian, MatType.CV_64F, ksize: 1, scale: 1, delta: 0);

            // 将结果平方
            Cv2.Pow(laplacian, 2, laplacian);

            // 计算所有元素的和
            var lapSum = Cv2.Sum(laplacian);

            // 释放Mat资源
            laplacian.Dispose();

            // 由于LAP是一个Scalar，它可以包含多达4个值（对于不同的通道），但在这种情况下，我们只关心第一个值
            var lapNormalized = lapSum[0] / (m * n);
            return lapNormalized;
        }
    }
}