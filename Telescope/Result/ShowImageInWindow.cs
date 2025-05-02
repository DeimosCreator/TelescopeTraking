using System;
using System.Drawing;
using System.Windows.Forms;

namespace Telescope.Result
{
    public class ZoomablePictureBox : Control
    {
        public Bitmap ImageBitmap { get; set; }

        private float imageScale = 1f;  // масштаб для вписывания
        private float userScale = 1f;   // пользовательский зум (1 = 100%)
        private PointF offset;

        private Point lastMouse;
        private bool isPanning;

        public ZoomablePictureBox()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (ImageBitmap == null) return;

            imageScale = Math.Min((float)Width / ImageBitmap.Width, (float)Height / ImageBitmap.Height);
            var dispW = ImageBitmap.Width * imageScale * userScale;
            var dispH = ImageBitmap.Height * imageScale * userScale;
            offset = new PointF(
                (Width - dispW) / 2f,
                (Height - dispH) / 2f);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ImageBitmap == null) return;

            float drawScale = imageScale * userScale;

            e.Graphics.TranslateTransform(offset.X, offset.Y);
            e.Graphics.ScaleTransform(drawScale, drawScale);
            e.Graphics.DrawImage(ImageBitmap, 0, 0);

            e.Graphics.ResetTransform();
            string text = $"{userScale * 100:F0}%";
            var font = new Font("Arial", 10, FontStyle.Bold);
            var brush = new SolidBrush(Color.White);
            e.Graphics.DrawString(text, font, brush, new PointF(5, 5));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control) return;

            float drawScale = imageScale * userScale;
            var px = (e.X - offset.X) / drawScale;
            var py = (e.Y - offset.Y) / drawScale;

            userScale *= e.Delta > 0 ? 1.1f : 1f / 1.1f;
            userScale = Math.Max(0.1f, Math.Min(10000f, userScale));

            float newDraw = imageScale * userScale;
            offset.X = e.X - px * newDraw;
            offset.Y = e.Y - py * newDraw;

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                isPanning = true;
                lastMouse = e.Location;
                Cursor = Cursors.SizeAll;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isPanning)
            {
                offset.X += e.X - lastMouse.X;
                offset.Y += e.Y - lastMouse.Y;
                lastMouse = e.Location;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Right)
            {
                isPanning = false;
                Cursor = Cursors.Default;
            }
        }
    }

    internal class ShowImageInWindow
    {
        public void Show(Bitmap image, string title, bool isTopWindow)
        {
            var screen = Screen.PrimaryScreen.Bounds;
            int wW = screen.Width / 2;
            int wH = screen.Height / 2;
            int wL = screen.Width - wW;
            int wT = isTopWindow ? 0 : screen.Height - wH;

            var frm = new Form
            {
                Text = title,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(wL, wT),
                Size = new Size(wW, wH)
            };

            var zoomBox = new ZoomablePictureBox
            {
                Dock = DockStyle.Fill,
                ImageBitmap = image
            };
            frm.Controls.Add(zoomBox);
            frm.Show();
        }
    }
}
