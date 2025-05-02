using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telescope.Result
{
    internal class ShowImageInWindow// : Form
    {
        public void Show(Bitmap image, string title, bool isTopWindow)
        {
            // Получаем размеры экрана
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Размер окна (1/2 экрана)
            var windowWidth = screenWidth / 2;
            var windowHeight = screenHeight / 2;

            // Позиция окна (правый верхний или правый нижний угол)
            int windowLeft = screenWidth - windowWidth;
            int windowTop = isTopWindow ? 0 : screenHeight - windowHeight;

            // Создаем окно
            Form imageForm = new Form
            {
                Text = title,
                Size = new Size(windowWidth, windowHeight),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(windowLeft, windowTop),
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                BackColor = Color.Black
            };

            // Вычисляем начальный масштаб для подгонки изображения под окно
            float scaleX = (float)windowWidth / image.Width;
            float scaleY = (float)windowHeight / image.Height;
            float initialScale = Math.Min(scaleX, scaleY);

            int initialWidth = (int)(image.Width * initialScale);
            int initialHeight = (int)(image.Height * initialScale);

            // Создаем PictureBox для отображения изображения
            PictureBox pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(initialWidth, initialHeight),
                Location = new Point(
                    (windowWidth - initialWidth) / 2,
                    (windowHeight - initialHeight) / 2
                )
            };

            // Добавляем метку масштаба
            Label scaleLabel = new Label
            {
                Text = $"Масштаб: {initialScale * 100:F1}%",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(windowWidth - 120, 10)
            };

            float currentScale = initialScale;

            imageForm.Controls.Add(pictureBox);
            imageForm.Controls.Add(scaleLabel);

            // Перемещение изображения с помощью правой кнопки мыши
            Point mouseDownLocation = Point.Empty;
            Point dragOffset = Point.Empty;
            bool isDragging = false;

            pictureBox.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    isDragging = true;
                    mouseDownLocation = e.Location; // Позиция мыши относительно PictureBox
                }
            };

            pictureBox.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    int dx = e.X - mouseDownLocation.X;
                    int dy = e.Y - mouseDownLocation.Y;

                    dragOffset = new Point(
                        pictureBox.Location.X + dx,
                        pictureBox.Location.Y + dy
                    );

                    pictureBox.Location = dragOffset;
                }
            };

            pictureBox.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    isDragging = false;
                }
            };

            // Управление масштабом с помощью Ctrl + колесо мыши
            imageForm.MouseWheel += (s, e) =>
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    float oldScale = currentScale;

                    if (e.Delta > 0)
                        currentScale *= 1.1f; // Увеличить масштаб
                    else if (e.Delta < 0)
                        currentScale /= 1.1f; // Уменьшить масштаб

                    // Ограничиваем масштаб, чтобы изображение не исчезало
                    currentScale = Math.Max(0.1f, Math.Min(5.0f, currentScale)); // Ограничение масштаба

                    // Сохраняем позицию курсора относительно изображения
                    Point cursorPositionInImage = pictureBox.PointToClient(Control.MousePosition);

                    // Пересчитываем размеры PictureBox
                    int newWidth = (int)(image.Width * currentScale);
                    int newHeight = (int)(image.Height * currentScale);

                    // Проверка на минимальный размер изображения
                    newWidth = Math.Max(newWidth, windowWidth);
                    newHeight = Math.Max(newHeight, windowHeight);

                    // При изменении масштаба, корректируем положение изображения с учетом курсора
                    float scaleFactor = currentScale / oldScale;

                    // Центрируем изображение, корректируя смещение
                    pictureBox.Size = new Size(newWidth, newHeight);

                    pictureBox.Location = new Point(
                        pictureBox.Location.X - (int)((cursorPositionInImage.X) * (scaleFactor - 1)),
                        pictureBox.Location.Y - (int)((cursorPositionInImage.Y) * (scaleFactor - 1))
                    );

                    // Обновляем метку масштаба
                    scaleLabel.Text = $"Масштаб: {currentScale * 100:F1}%";
                }
            };

            imageForm.Controls.SetChildIndex(scaleLabel, 0); // Гарантируем, что метка сверху
            imageForm.Show();
        }
    }
}
