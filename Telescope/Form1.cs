using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Telescope.Count;
using Telescope.Vars;

namespace Telescope
{
    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();
            var I = Telescope.Vars.Initialize.Instance;
            I.buttonLoadImage1 = this.buttonLoadImage1;
            I.buttonLoadImage2 = this.buttonLoadImage2;
            I.buttonCalculateAndPlot = this.buttonCalculateAndPlot;
            I.labelImage1Path = this.labelImage1Path;
            I.labelImage2Path = this.labelImage2Path;
            I.textBoxMinBrightness = this.textBoxMinBrightness;
            I.textBoxMinClusterSize = this.textBoxMinClusterSize;
            I.textBoxCircularity = this.textBoxCircularity;
            I.textBoxSpeed = this.textBoxSpeed;
            I.textBoxExposureTime = this.textBoxExposureTime;
            I.labelMinBrightness = this.labelMinBrightness;
            I.labelMinClusterSize = this.labelMinClusterSize;
            I.labelCircularity = this.labelCircularity;
            I.labelSpeed = this.labelSpeed;
            I.labelExposureTime = this.labelExposureTime;
            I.chart = this.chart;

            // Подключение обработчиков событий
            Initialize.Instance.buttonLoadImage1.Click += LoadImage1Handler;
            Initialize.Instance.buttonLoadImage2.Click += LoadImage2Handler;
            Initialize.Instance.buttonCalculateAndPlot.Click += new CalculateAndPlotHandler().Count;
        }

        private void LoadImage1Handler(object sender, EventArgs e)
        {
            Initialize.Instance.img1 = Telescope.Load.Instance.LoadImage(out string imagePath);
            if (Initialize.Instance.img1 != null)
                Initialize.Instance.labelImage1Path.Text = $"Путь к изображению 1: {imagePath}";
        }

        private void LoadImage2Handler(object sender, EventArgs e)
        {
            Initialize.Instance.img2 = Telescope.Load.Instance.LoadImage(out string imagePath);
            if (Initialize.Instance.img2 != null)
                Initialize.Instance.labelImage2Path.Text = $"Путь к изображению 2: {imagePath}";
        }
    }
}
