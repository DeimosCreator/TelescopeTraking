using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Telescope.Vars
{
     public class Initialize
     {
        public bool Enabled { get; set; }

        public Button buttonLoadImage1;
        public Button buttonLoadImage2;
        public Label labelImage1Path;
        public Label labelImage2Path;
        public Label labelSpeed;
        public TextBox textBoxSpeed;
        public Button buttonCalculateAndPlot;
        public Chart chart;
        public Label labelObservationTime;
        public TextBox textBoxObservationTime;
        public Label labelPixelSize;
        public TextBox textBoxPixelSize;
        public Label labelFocalLength;
        public TextBox textBoxFocalLength;
        public TextBox textBoxMinBrightness;
        public Label labelMinBrightness;
        public TextBox textBoxMinClusterSize;
        public TextBox textBoxCircularity;
        public Label labelMinClusterSize;
        public Label labelCircularity;
        public TextBox textBoxExposureTime;
        public Label labelExposureTime;

        public Bitmap img1;
        public Bitmap img2;

        public static Initialize Instance = new Initialize();
    }
}
