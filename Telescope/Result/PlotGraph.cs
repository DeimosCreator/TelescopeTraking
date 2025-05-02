using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Telescope.Vars;

namespace Telescope.Result
{
    internal class PlotGraph
    {
        public void Plot(double trackingSpeed, double optimalSpeed, double blurWithout, double blurWith)
        {
            // Очищаем предыдущие данные
            Initialize.Instance.chart.Series.Clear();

            // Убедимся, что область графика существует
            if (Initialize.Instance.chart.ChartAreas.Count == 0)
            {
                Initialize.Instance.chart.ChartAreas.Add(new ChartArea("Default"));
            }

            // Устанавливаем параметры для графика
            var chartArea = Initialize.Instance.chart.ChartAreas[0];
            chartArea.AxisX.Title = "Tracking Speed (arcsec/s)";
            chartArea.AxisY.Title = "Blur Length (pixels)";
            chartArea.AxisX.Minimum = 0; // Устанавливаем минимум на оси X
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chartArea.AxisY.Minimum = 0; // Устанавливаем минимум на оси Y
            chartArea.AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;

            // Создаём серию
            var series = new Series
            {
                Name = "Blur Shift",
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 2
            };

            // Добавляем точки данных
            series.Points.AddXY(0, blurWithout);           // Размытие без трекинга
            series.Points.AddXY(trackingSpeed, blurWith);  // Размытие с текущей скоростью трекинга
            series.Points.AddXY(optimalSpeed, 0);          // Нулевая длина размытия при оптимальной скорости

            Initialize.Instance.chart.Series.Add(series);

            // Добавляем точку для визуализации оптимальной скорости
            var markerSeries = new Series
            {
                Name = "Optimal Speed",
                ChartType = SeriesChartType.Point,
                Color = Color.Red,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };
            markerSeries.Points.AddXY(optimalSpeed, 0);
            Initialize.Instance.chart.Series.Add(markerSeries);

            // Обновляем график
            Initialize.Instance.chart.Invalidate();
        }
    }
}
