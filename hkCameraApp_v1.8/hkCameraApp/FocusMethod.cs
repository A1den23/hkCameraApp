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

        public static double TenGradient(Mat grayImg, int m, int n)
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
            var kernelSize = (int)(3 * sigma);

            var kernelGm = Cv2.GetGaussianKernel(kernelSize, sigma)?.Reshape(1);
            var kernelGn = Cv2.GetGaussianKernel(kernelSize, sigma)?.Reshape(1);

            var convGm = new Mat();
            if (kernelGm != null) Cv2.Filter2D(grayImg, convGm, MatType.CV_64F, kernelGm);

            var convGn = new Mat();
            if (kernelGn != null) Cv2.Filter2D(grayImg, convGn, MatType.CV_64F, kernelGn);

            var squaredGm = new Mat();
            Cv2.Pow(convGm, 2, squaredGm);

            var squaredGn = new Mat();
            Cv2.Pow(convGn, 2, squaredGn);

            var sumSquared = Cv2.Sum(squaredGm + squaredGn).Val0;

            var gaussianFilterNormalized = sumSquared / (m * n);

            return gaussianFilterNormalized;
        }

        public static double Laplacian(Mat grayImg, int m, int n)
        {
            double fLap = 0;

            for (var dx = 1; dx < m - 1; dx++)
            {
                for (var dy = 1; dy < n - 1; dy++)
                {
                    var lap = grayImg.At<double>(dx - 1, dy) + grayImg.At<double>(dx + 1, dy) +
                              grayImg.At<double>(dx, dy - 1) + grayImg.At<double>(dx, dy + 1) -
                              4 * grayImg.At<double>(dx, dy);

                    fLap += lap * lap;
                }
            }

            var lapNormalized = fLap / (m * n);

            return lapNormalized;
        }
    }
}