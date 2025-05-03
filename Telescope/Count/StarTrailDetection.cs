using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Emgu.CV.Util;

namespace Telescope.Count
{
    public class StarTrailDetection
    {
        // Метод для подсчёта звёзд на изображении
        public List<StarInfo> CalculateStars(Bitmap image, double minBrightness, int minClusterSize = 5, double circularityThreshold = 0.6)
        {
            if (image == null) throw new ArgumentException("Image is null.");

            // Убираем засветку
            Bitmap correctedImage = RemoveGlare(image);

            // Конвертируем изображение в серый формат
            Mat inputMat = BitmapToMat(correctedImage);
            Mat grayMat = new Mat();
            CvInvoke.CvtColor(inputMat, grayMat, ColorConversion.Bgr2Gray);

            // Бинаризация изображения
            Mat binaryMat = new Mat();
            CvInvoke.Threshold(grayMat, binaryMat, minBrightness, 255, ThresholdType.Binary);

            // Удаление мелких шумов
            Mat cleanMat = new Mat();
            Mat kernel = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.MorphologyEx(binaryMat, cleanMat, MorphOp.Open, kernel, new Point(-1, -1), 1, BorderType.Default, default(MCvScalar));

            // Поиск контуров
            var contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(cleanMat, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            // Список звёзд
            List<StarInfo> stars = new List<StarInfo>();

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];

                // Вычисление площади, периметра и центра масс
                double area = CvInvoke.ContourArea(contour);
                if (area < minClusterSize) continue; // Игнорируем мелкие шумы

                double perimeter = CvInvoke.ArcLength(contour, true);
                double circularity = 4 * Math.PI * area / (perimeter * perimeter);

                if (circularity < circularityThreshold) continue; // Проверяем округлость

                // Нахождение центра масс
                var moments = CvInvoke.Moments(contour);
                if (moments.M00 == 0) continue;
                double centerX = moments.M10 / moments.M00;
                double centerY = moments.M01 / moments.M00;

                // Вычисляем длину размытия
                (var blurLength, var angle) = CalculateBlurLength(contour, new PointF((float)centerX, (float)centerY));

                stars.Add(new StarInfo
                {
                    Center = new PointF((float)centerX, (float)centerY),
                    Area = area,
                    Perimeter = perimeter,
                    Circularity = circularity,
                    BlurLength = blurLength,
                    Angle = angle
                });

            }

            return stars;
        }

        // Метод для удаления засветки с изображения
        public Bitmap RemoveGlare(Bitmap image)
        {
            Mat mat = BitmapToMat(image);

            // Преобразуем изображение в оттенки серого
            Mat grayMat = new Mat();
            CvInvoke.CvtColor(mat, grayMat, ColorConversion.Bgr2Gray);

            // Применяем размытие для сглаживания больших засветок
            Mat blurredMat = new Mat();
            CvInvoke.GaussianBlur(grayMat, blurredMat, new Size(51, 51), 0);

            // Вычитаем размытую версию из оригинального изображения
            Mat correctedMat = new Mat();
            CvInvoke.Subtract(grayMat, blurredMat, correctedMat);

            // Нормализуем значения яркости
            CvInvoke.Normalize(correctedMat, correctedMat, 0, 255, NormType.MinMax);

            // Конвертируем обратно в RGB
            Mat resultMat = new Mat();
            CvInvoke.CvtColor(correctedMat, resultMat, ColorConversion.Gray2Bgr);

            return MatToBitmap(resultMat);
        }

        // Метод для вычисления длины размытия
        private (double blurLength, double angle) CalculateBlurLength(VectorOfPoint contour, PointF center)
        {
            var points = contour.ToArray();

            double sumX = 0, sumY = 0, sumXX = 0, sumYY = 0, sumXY = 0;
            int n = points.Length;

            foreach (var point in points)
            {
                double dx = point.X - center.X;
                double dy = point.Y - center.Y;

                sumX += dx;
                sumY += dy;
                sumXX += dx * dx;
                sumYY += dy * dy;
                sumXY += dx * dy;
            }

            double meanX = sumX / n;
            double meanY = sumY / n;
            double varXX = sumXX / n - meanX * meanX;
            double varYY = sumYY / n - meanY * meanY;
            double varXY = sumXY / n - meanX * meanY;

            double trace = varXX + varYY;
            double det = varXX * varYY - varXY * varXY;
            double delta = trace * trace / 4 - det;
            if (delta < 0) delta = 0;
            double eigenvalue1 = trace / 2 + Math.Sqrt(delta);
            double eigenvalue2 = trace / 2 - Math.Sqrt(delta);


            double angle = 0;
            if (varXY != 0)
                angle = 0.5 * Math.Atan2(2 * varXY, varXX - varYY);

            double majorAxisLength = 2 * Math.Sqrt(eigenvalue1);
            double minorAxisLength = 2 * Math.Sqrt(eigenvalue2);
            double blurLength = majorAxisLength - minorAxisLength;

            return (blurLength, angle);
        }

        // Метод для подсчёта средней длины размытия
        public double CalculateAverageBlurLength(List<StarInfo> stars)
        {
            if (stars == null || stars.Count == 0) return 0;
            return stars.Average(s => s.BlurLength);
        }

        public Bitmap HighlightStars(Bitmap image, List<StarInfo> stars)
        {
            Bitmap result = new Bitmap(image);
            using (Graphics g = Graphics.FromImage(result))
            {
                foreach (var star in stars)
                {
                    double halfLength = star.BlurLength / 2;
                    double dx = halfLength * Math.Cos(star.Angle);
                    double dy = halfLength * Math.Sin(star.Angle);

                    PointF start = new PointF((float)(star.Center.X - dx), (float)(star.Center.Y - dy));
                    PointF end = new PointF((float)(star.Center.X + dx), (float)(star.Center.Y + dy));

                    g.DrawLine(Pens.Red, start, end);
                }
            }
            return result;
        }


        public double CalculateOptimalSpeed(double averageBlurLength, double exposureTime, double currentSpeed)
        {
            if (exposureTime <= 0)
                throw new ArgumentException("Exposure time must be greater than zero.");
            if (averageBlurLength < 0)
                throw new ArgumentException("Average blur length must be non-negative.");
            if (currentSpeed < 0)
                throw new ArgumentException("Current speed must be non-negative.");

            // Оптимальная скорость трекинга
            double optimalSpeed = currentSpeed - (averageBlurLength / exposureTime);

            // Логирование для отладки
            Console.WriteLine($"Average Blur Length: {averageBlurLength}");
            Console.WriteLine($"Exposure Time: {exposureTime}");
            Console.WriteLine($"Calculated Optimal Speed: {optimalSpeed}");
            Console.WriteLine($"Current Speed: {currentSpeed}");

            // Предупреждение, если разница слишком велика
            double speedDifference = Math.Abs(optimalSpeed - currentSpeed);
            Console.WriteLine($"Speed Difference: {speedDifference}");

            const double warningThreshold = 0.2; // 20% допустимое отклонение
            if (speedDifference / currentSpeed > warningThreshold)
            {
                Console.WriteLine("Warning: Optimal speed significantly deviates from the current speed.");
                Console.WriteLine("Consider adjusting the tracking parameters.");
            }

            return optimalSpeed;
        }


        // Вспомогательные методы для конвертации изображений
        private Mat BitmapToMat(Bitmap bitmap)
        {
            Mat mat = new Mat();
            using (Image<Bgr, Byte> img = bitmap.ToImage<Bgr, Byte>())
            {
                mat = img.Mat.Clone();
            }
            return mat;
        }

        public Bitmap MatToBitmap(Mat mat)
        {
            using (Image<Bgr, byte> img = mat.ToImage<Bgr, byte>())
            {
                return img.ToBitmap();
            }
        }

        // Структура для хранения информации о звезде
        public class StarInfo
        {
            public PointF Center { get; set; }
            public double Area { get; set; }
            public double Perimeter { get; set; }
            public double Circularity { get; set; }
            public double BlurLength { get; set; }
            public double Angle { get; set; }
        }
    }
}
