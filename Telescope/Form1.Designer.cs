using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Telescope.Vars;

namespace Telescope
{
    public partial class Form1 : Form
    {
        private void InitializeComponent()
        {
            Initialize.Instance.buttonLoadImage1 = new System.Windows.Forms.Button();
            Initialize.Instance.buttonLoadImage2 = new System.Windows.Forms.Button();
            Initialize.Instance.buttonCalculateAndPlot = new System.Windows.Forms.Button();
            Initialize.Instance.labelImage1Path = new System.Windows.Forms.Label();
            Initialize.Instance.labelImage2Path = new System.Windows.Forms.Label();
            Initialize.Instance.textBoxMinBrightness = new System.Windows.Forms.TextBox();
            Initialize.Instance.textBoxMinClusterSize = new System.Windows.Forms.TextBox();
            Initialize.Instance.textBoxCircularity = new System.Windows.Forms.TextBox();
            Initialize.Instance.textBoxSpeed = new System.Windows.Forms.TextBox();
            Initialize.Instance.labelMinBrightness = new System.Windows.Forms.Label();
            Initialize.Instance.labelMinClusterSize = new System.Windows.Forms.Label();
            Initialize.Instance.labelCircularity = new System.Windows.Forms.Label();
            Initialize.Instance.labelSpeed = new System.Windows.Forms.Label();
            Initialize.Instance.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(Initialize.Instance.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadImage1
            // 
            Initialize.Instance.buttonLoadImage1.Location = new System.Drawing.Point(20, 20);
            Initialize.Instance.buttonLoadImage1.Name = "buttonLoadImage1";
            Initialize.Instance.buttonLoadImage1.Size = new System.Drawing.Size(200, 30);
            Initialize.Instance.buttonLoadImage1.TabIndex = 0;
            Initialize.Instance.buttonLoadImage1.Text = "Загрузить изображение 1";
            Initialize.Instance.buttonLoadImage1.UseVisualStyleBackColor = true;
            // 
            // buttonLoadImage2
            // 
            Initialize.Instance.buttonLoadImage2.Location = new System.Drawing.Point(20, 60);
            Initialize.Instance.buttonLoadImage2.Name = "buttonLoadImage2";
            Initialize.Instance.buttonLoadImage2.Size = new System.Drawing.Size(200, 30);
            Initialize.Instance.buttonLoadImage2.TabIndex = 1;
            Initialize.Instance.buttonLoadImage2.Text = "Загрузить изображение 2";
            Initialize.Instance.buttonLoadImage2.UseVisualStyleBackColor = true;
            // 
            // buttonCalculateAndPlot
            // 
            Initialize.Instance.buttonCalculateAndPlot.Location = new System.Drawing.Point(20, 350);
            Initialize.Instance.buttonCalculateAndPlot.Name = "buttonCalculateAndPlot";
            Initialize.Instance.buttonCalculateAndPlot.Size = new System.Drawing.Size(200, 30);
            Initialize.Instance.buttonCalculateAndPlot.TabIndex = 2;
            Initialize.Instance.buttonCalculateAndPlot.Text = "Рассчитать и построить";
            Initialize.Instance.buttonCalculateAndPlot.UseVisualStyleBackColor = true;
            // 
            // labelImage1Path
            // 
            Initialize.Instance.labelImage1Path.AutoSize = true;
            Initialize.Instance.labelImage1Path.Location = new System.Drawing.Point(240, 25);
            Initialize.Instance.labelImage1Path.Name = "labelImage1Path";
            Initialize.Instance.labelImage1Path.Size = new System.Drawing.Size(153, 16);
            Initialize.Instance.labelImage1Path.TabIndex = 3;
            Initialize.Instance.labelImage1Path.Text = "Путь к изображению 1";
            // 
            // labelImage2Path
            // 
            Initialize.Instance.labelImage2Path.AutoSize = true;
            Initialize.Instance.labelImage2Path.Location = new System.Drawing.Point(240, 65);
            Initialize.Instance.labelImage2Path.Name = "labelImage2Path";
            Initialize.Instance.labelImage2Path.Size = new System.Drawing.Size(153, 16);
            Initialize.Instance.labelImage2Path.TabIndex = 4;
            Initialize.Instance.labelImage2Path.Text = "Путь к изображению 2";
            // 
            // textBoxMinBrightness
            // 
            Initialize.Instance.textBoxMinBrightness.Location = new System.Drawing.Point(150, 120);
            Initialize.Instance.textBoxMinBrightness.Name = "textBoxMinBrightness";
            Initialize.Instance.textBoxMinBrightness.Size = new System.Drawing.Size(70, 22);
            Initialize.Instance.textBoxMinBrightness.TabIndex = 5;
            Initialize.Instance.textBoxMinBrightness.Text = "20";
            // 
            // textBoxMinClusterSize
            // 
            Initialize.Instance.textBoxMinClusterSize.Location = new System.Drawing.Point(150, 160);
            Initialize.Instance.textBoxMinClusterSize.Name = "textBoxMinClusterSize";
            Initialize.Instance.textBoxMinClusterSize.Size = new System.Drawing.Size(70, 22);
            Initialize.Instance.textBoxMinClusterSize.TabIndex = 6;
            Initialize.Instance.textBoxMinClusterSize.Text = "17";
            // 
            // textBoxCircularity
            // 
            Initialize.Instance.textBoxCircularity.Location = new System.Drawing.Point(150, 200);
            Initialize.Instance.textBoxCircularity.Name = "textBoxCircularity";
            Initialize.Instance.textBoxCircularity.Size = new System.Drawing.Size(70, 22);
            Initialize.Instance.textBoxCircularity.TabIndex = 7;
            Initialize.Instance.textBoxCircularity.Text = "0,2";
            // 
            // textBoxSpeed
            // 
            Initialize.Instance.textBoxSpeed.Location = new System.Drawing.Point(150, 240);
            Initialize.Instance.textBoxSpeed.Name = "textBoxSpeed";
            Initialize.Instance.textBoxSpeed.Size = new System.Drawing.Size(70, 22);
            Initialize.Instance.textBoxSpeed.TabIndex = 8;
            Initialize.Instance.textBoxSpeed.Text = "10";
            // 
            // labelMinBrightness
            // 
            Initialize.Instance.labelMinBrightness.AutoSize = true;
            Initialize.Instance.labelMinBrightness.Location = new System.Drawing.Point(20, 123);
            Initialize.Instance.labelMinBrightness.Name = "labelMinBrightness";
            Initialize.Instance.labelMinBrightness.Size = new System.Drawing.Size(137, 16);
            Initialize.Instance.labelMinBrightness.TabIndex = 9;
            Initialize.Instance.labelMinBrightness.Text = "Мин. яркость (0-255):";
            // 
            // labelMinClusterSize
            // 
            Initialize.Instance.labelMinClusterSize.AutoSize = true;
            Initialize.Instance.labelMinClusterSize.Location = new System.Drawing.Point(20, 163);
            Initialize.Instance.labelMinClusterSize.Name = "labelMinClusterSize";
            Initialize.Instance.labelMinClusterSize.Size = new System.Drawing.Size(144, 16);
            Initialize.Instance.labelMinClusterSize.TabIndex = 10;
            Initialize.Instance.labelMinClusterSize.Text = "Мин. размер звезды:";
            // 
            // labelCircularity
            // 
            Initialize.Instance.labelCircularity.AutoSize = true;
            Initialize.Instance.labelCircularity.Location = new System.Drawing.Point(20, 203);
            Initialize.Instance.labelCircularity.Name = "labelCircularity";
            Initialize.Instance.labelCircularity.Size = new System.Drawing.Size(115, 16);
            Initialize.Instance.labelCircularity.TabIndex = 11;
            Initialize.Instance.labelCircularity.Text = "Округлость (0-1):";
            // 
            // labelSpeed
            // 
            Initialize.Instance.labelSpeed.AutoSize = true;
            Initialize.Instance.labelSpeed.Location = new System.Drawing.Point(20, 243);
            Initialize.Instance.labelSpeed.Name = "labelSpeed";
            Initialize.Instance.labelSpeed.Size = new System.Drawing.Size(133, 16);
            Initialize.Instance.labelSpeed.TabIndex = 12;
            Initialize.Instance.labelSpeed.Text = "Скорость (угл./сек):";
            // textBoxExposureTime
            Initialize.Instance.textBoxExposureTime = new System.Windows.Forms.TextBox();
            Initialize.Instance.textBoxExposureTime.Location = new System.Drawing.Point(150, 280);
            Initialize.Instance.textBoxExposureTime.Name = "textBoxExposureTime";
            Initialize.Instance.textBoxExposureTime.Size = new System.Drawing.Size(70, 22);
            Initialize.Instance.textBoxExposureTime.TabIndex = 9;
            Initialize.Instance.textBoxExposureTime.Text = "10";

            // labelExposureTime
            Initialize.Instance.labelExposureTime = new System.Windows.Forms.Label();
            Initialize.Instance.labelExposureTime.AutoSize = true;
            Initialize.Instance.labelExposureTime.Location = new System.Drawing.Point(20, 283);
            Initialize.Instance.labelExposureTime.Name = "labelExposureTime";
            Initialize.Instance.labelExposureTime.Size = new System.Drawing.Size(123, 16);
            Initialize.Instance.labelExposureTime.TabIndex = 13;
            Initialize.Instance.labelExposureTime.Text = "Экспозиция (сек):";
            // 
            // chart
            // 
            Initialize.Instance.chart.Location = new System.Drawing.Point(250, 100);
            Initialize.Instance.chart.Name = "chart";
            Initialize.Instance.chart.Size = new System.Drawing.Size(500, 300);
            Initialize.Instance.chart.TabIndex = 0;
            Initialize.Instance.chart.Text = "chart";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(Initialize.Instance.buttonLoadImage1);
            this.Controls.Add(Initialize.Instance.buttonLoadImage2);
            this.Controls.Add(Initialize.Instance.buttonCalculateAndPlot);
            this.Controls.Add(Initialize.Instance.labelImage1Path);
            this.Controls.Add(Initialize.Instance.labelImage2Path);
            this.Controls.Add(Initialize.Instance.textBoxMinBrightness);
            this.Controls.Add(Initialize.Instance.textBoxMinClusterSize);
            this.Controls.Add(Initialize.Instance.textBoxCircularity);
            this.Controls.Add(Initialize.Instance.textBoxSpeed);
            this.Controls.Add(Initialize.Instance.labelMinBrightness);
            this.Controls.Add(Initialize.Instance.labelMinClusterSize);
            this.Controls.Add(Initialize.Instance.labelCircularity);
            this.Controls.Add(Initialize.Instance.labelSpeed);
            this.Controls.Add(Initialize.Instance.textBoxExposureTime);
            this.Controls.Add(Initialize.Instance.labelExposureTime);
            this.Controls.Add(Initialize.Instance.chart);

            this.Text = "Анализ звёздных смазываний";
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = new System.Drawing.Icon("C:\\Program Files\\TelescopeTracking\\icon.ico");
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
