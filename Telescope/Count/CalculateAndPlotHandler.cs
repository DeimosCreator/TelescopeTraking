using System;
using System.Windows.Forms;
using Telescope.Result;
using Telescope.Vars;

namespace Telescope.Count
{
    internal class CalculateAndPlotHandler
    {
        public void Count(object sender, EventArgs e)
        {
            if (Initialize.Instance.img1 == null || Initialize.Instance.img2 == null)
            {
                MessageBox.Show("Необходимо загрузить оба изображения.");
                return;
            }

            if (!double.TryParse(Initialize.Instance.textBoxMinBrightness.Text, out double minBrightness) || minBrightness < 0 || minBrightness > 255)
            {
                MessageBox.Show("Введите корректное значение минимальной яркости (0-255).");
                return;
            }

            if (!int.TryParse(Initialize.Instance.textBoxMinClusterSize.Text, out int minClusterSize) || minClusterSize <= 0)
            {
                MessageBox.Show("Введите корректное значение минимального размера звезды (пиксели).");
                return;
            }

            if (!double.TryParse(Initialize.Instance.textBoxCircularity.Text, out double circularityThreshold) || circularityThreshold <= 0 || circularityThreshold > 1)
            {
                MessageBox.Show("Введите корректное значение порога округлости (0-1).");
                return;
            }

            var detector = new Count.StarTrailDetection();

            // Обработка изображений и подсчёт звёзд
            var stars1 = detector.CalculateStars(Initialize.Instance.img1, minBrightness, minClusterSize, circularityThreshold);
            var stars2 = detector.CalculateStars(Initialize.Instance.img2, minBrightness, minClusterSize, circularityThreshold);

            // Подсвечиваем звёзды
            var highlightedImg1 = detector.HighlightStars(Initialize.Instance.img1, stars1);
            var highlightedImg2 = detector.HighlightStars(Initialize.Instance.img2, stars2);

            // Отображаем изображения с подсветкой звёзд
            new ShowImageInWindow().Show(highlightedImg1, "Изображение 1 с подсветкой звёзд", true);
            new ShowImageInWindow().Show(highlightedImg2, "Изображение 2 с подсветкой звёзд", false);

            MessageBox.Show($"Количество звёзд на изображении 1: {stars1.Count}\nКоличество звёзд на изображении 2: {stars2.Count}");

            // Проверка скорости
            if (!double.TryParse(Initialize.Instance.textBoxSpeed.Text, out double trackingSpeed))
            {
                MessageBox.Show("Введите корректное значение скорости.");
                return;
            }

            double averageBlur1 = detector.CalculateAverageBlurLength(stars1);
            double averageBlur2 = detector.CalculateAverageBlurLength(stars2);

            //Проверка выдержки
            if (!double.TryParse(Initialize.Instance.textBoxExposureTime.Text, out double exposureTime) || exposureTime <= 0)
            {
                MessageBox.Show("Введите корректное значение выдержки.");
                return;
            }

            double optimalSpeed = detector.CalculateOptimalSpeed((averageBlur1 + averageBlur2) / 2, exposureTime, trackingSpeed);
            MessageBox.Show($"Оптимальная скорость: {optimalSpeed:F2} угл. секунд/сек.");

            // Построение графика
            new PlotGraph().Plot(trackingSpeed, optimalSpeed, averageBlur1, averageBlur2);
        }
    }
}
