/* Form1.Designer.cs */
namespace Telescope
{
    partial class Form1
    {
        private System.Windows.Forms.Button buttonLoadImage1;
        private System.Windows.Forms.Button buttonLoadImage2;
        private System.Windows.Forms.Button buttonCalculateAndPlot;
        private System.Windows.Forms.Label labelImage1Path;
        private System.Windows.Forms.Label labelImage2Path;
        private System.Windows.Forms.TextBox textBoxMinBrightness;
        private System.Windows.Forms.TextBox textBoxMinClusterSize;
        private System.Windows.Forms.TextBox textBoxCircularity;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.TextBox textBoxExposureTime;
        private System.Windows.Forms.Label labelMinBrightness;
        private System.Windows.Forms.Label labelMinClusterSize;
        private System.Windows.Forms.Label labelCircularity;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelExposureTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;

        private void InitializeComponent()
        {
            this.buttonLoadImage1 = new System.Windows.Forms.Button();
            this.buttonLoadImage2 = new System.Windows.Forms.Button();
            this.buttonCalculateAndPlot = new System.Windows.Forms.Button();
            this.labelImage1Path = new System.Windows.Forms.Label();
            this.labelImage2Path = new System.Windows.Forms.Label();
            this.textBoxMinBrightness = new System.Windows.Forms.TextBox();
            this.textBoxMinClusterSize = new System.Windows.Forms.TextBox();
            this.textBoxCircularity = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.textBoxExposureTime = new System.Windows.Forms.TextBox();
            this.labelMinBrightness = new System.Windows.Forms.Label();
            this.labelMinClusterSize = new System.Windows.Forms.Label();
            this.labelCircularity = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelExposureTime = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadImage1
            // 
            this.buttonLoadImage1.Location = new System.Drawing.Point(20, 20);
            this.buttonLoadImage1.Name = "buttonLoadImage1";
            this.buttonLoadImage1.Size = new System.Drawing.Size(200, 30);
            this.buttonLoadImage1.TabIndex = 0;
            this.buttonLoadImage1.Text = "Загрузить изображение 1";
            this.buttonLoadImage1.UseVisualStyleBackColor = true;
            // 
            // buttonLoadImage2
            // 
            this.buttonLoadImage2.Location = new System.Drawing.Point(20, 60);
            this.buttonLoadImage2.Name = "buttonLoadImage2";
            this.buttonLoadImage2.Size = new System.Drawing.Size(200, 30);
            this.buttonLoadImage2.TabIndex = 1;
            this.buttonLoadImage2.Text = "Загрузить изображение 2";
            this.buttonLoadImage2.UseVisualStyleBackColor = true;
            // 
            // buttonCalculateAndPlot
            // 
            this.buttonCalculateAndPlot.Location = new System.Drawing.Point(20, 350);
            this.buttonCalculateAndPlot.Name = "buttonCalculateAndPlot";
            this.buttonCalculateAndPlot.Size = new System.Drawing.Size(200, 30);
            this.buttonCalculateAndPlot.TabIndex = 2;
            this.buttonCalculateAndPlot.Text = "Рассчитать и построить";
            this.buttonCalculateAndPlot.UseVisualStyleBackColor = true;
            // 
            // labelImage1Path
            // 
            this.labelImage1Path.AutoSize = true;
            this.labelImage1Path.Location = new System.Drawing.Point(240, 25);
            this.labelImage1Path.Name = "labelImage1Path";
            this.labelImage1Path.Size = new System.Drawing.Size(153, 16);
            this.labelImage1Path.TabIndex = 3;
            this.labelImage1Path.Text = "Путь к изображению 1";
            // 
            // labelImage2Path
            // 
            this.labelImage2Path.AutoSize = true;
            this.labelImage2Path.Location = new System.Drawing.Point(240, 65);
            this.labelImage2Path.Name = "labelImage2Path";
            this.labelImage2Path.Size = new System.Drawing.Size(153, 16);
            this.labelImage2Path.TabIndex = 4;
            this.labelImage2Path.Text = "Путь к изображению 2";
            // 
            // textBoxMinBrightness
            // 
            this.textBoxMinBrightness.Location = new System.Drawing.Point(150, 120);
            this.textBoxMinBrightness.Name = "textBoxMinBrightness";
            this.textBoxMinBrightness.Size = new System.Drawing.Size(70, 22);
            this.textBoxMinBrightness.TabIndex = 5;
            this.textBoxMinBrightness.Text = "20";
            // 
            // textBoxMinClusterSize
            // 
            this.textBoxMinClusterSize.Location = new System.Drawing.Point(150, 160);
            this.textBoxMinClusterSize.Name = "textBoxMinClusterSize";
            this.textBoxMinClusterSize.Size = new System.Drawing.Size(70, 22);
            this.textBoxMinClusterSize.TabIndex = 6;
            this.textBoxMinClusterSize.Text = "17";
            // 
            // textBoxCircularity
            // 
            this.textBoxCircularity.Location = new System.Drawing.Point(150, 200);
            this.textBoxCircularity.Name = "textBoxCircularity";
            this.textBoxCircularity.Size = new System.Drawing.Size(70, 22);
            this.textBoxCircularity.TabIndex = 7;
            this.textBoxCircularity.Text = "0,2";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(150, 240);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(70, 22);
            this.textBoxSpeed.TabIndex = 8;
            this.textBoxSpeed.Text = "10";
            // 
            // textBoxExposureTime
            // 
            this.textBoxExposureTime.Location = new System.Drawing.Point(150, 280);
            this.textBoxExposureTime.Name = "textBoxExposureTime";
            this.textBoxExposureTime.Size = new System.Drawing.Size(70, 22);
            this.textBoxExposureTime.TabIndex = 9;
            this.textBoxExposureTime.Text = "10";
            // 
            // labelMinBrightness
            // 
            this.labelMinBrightness.AutoSize = true;
            this.labelMinBrightness.Location = new System.Drawing.Point(20, 123);
            this.labelMinBrightness.Name = "labelMinBrightness";
            this.labelMinBrightness.Size = new System.Drawing.Size(137, 16);
            this.labelMinBrightness.TabIndex = 10;
            this.labelMinBrightness.Text = "Мин. яркость (0-255):";
            // 
            // labelMinClusterSize
            // 
            this.labelMinClusterSize.AutoSize = true;
            this.labelMinClusterSize.Location = new System.Drawing.Point(20, 163);
            this.labelMinClusterSize.Name = "labelMinClusterSize";
            this.labelMinClusterSize.Size = new System.Drawing.Size(144, 16);
            this.labelMinClusterSize.TabIndex = 11;
            this.labelMinClusterSize.Text = "Мин. размер звезды:";
            // 
            // labelCircularity
            // 
            this.labelCircularity.AutoSize = true;
            this.labelCircularity.Location = new System.Drawing.Point(20, 203);
            this.labelCircularity.Name = "labelCircularity";
            this.labelCircularity.Size = new System.Drawing.Size(115, 16);
            this.labelCircularity.TabIndex = 12;
            this.labelCircularity.Text = "Округлость (0-1):";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(20, 243);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(133, 16);
            this.labelSpeed.TabIndex = 13;
            this.labelSpeed.Text = "Скорость (угл./сек):";
            // 
            // labelExposureTime
            // 
            this.labelExposureTime.AutoSize = true;
            this.labelExposureTime.Location = new System.Drawing.Point(20, 283);
            this.labelExposureTime.Name = "labelExposureTime";
            this.labelExposureTime.Size = new System.Drawing.Size(123, 16);
            this.labelExposureTime.TabIndex = 14;
            this.labelExposureTime.Text = "Экспозиция (сек):";
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(250, 100);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(500, 300);
            this.chart.TabIndex = 15;
            this.chart.Text = "chart";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoadImage1);
            this.Controls.Add(this.buttonLoadImage2);
            this.Controls.Add(this.buttonCalculateAndPlot);
            this.Controls.Add(this.labelImage1Path);
            this.Controls.Add(this.labelImage2Path);
            this.Controls.Add(this.textBoxMinBrightness);
            this.Controls.Add(this.textBoxMinClusterSize);
            this.Controls.Add(this.textBoxCircularity);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.textBoxExposureTime);
            this.Controls.Add(this.labelMinBrightness);
            this.Controls.Add(this.labelMinClusterSize);
            this.Controls.Add(this.labelCircularity);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelExposureTime);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Анализ звёздных смазываний";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}