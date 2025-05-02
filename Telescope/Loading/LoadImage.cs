using System;
using System.Drawing;
using System.Windows.Forms;

namespace Telescope.Loading
{
    public partial class LoadImage
    {
        public Bitmap Load(out string imagePath)
        {
            imagePath = string.Empty;

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Устанавливаем фильтр для файлов
                    openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.bmp;*.tiff;*.CR2)|*.png;*.jpg;*.jpeg;*.bmp;*.tiff;*.CR2";

                    // Показываем диалоговое окно выбора файла
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imagePath = openFileDialog.FileName;

                        // Проверка файла перед загрузкой
                        if (string.IsNullOrEmpty(imagePath) || !System.IO.File.Exists(imagePath))
                        {
                            throw new ArgumentException("Указанный файл не существует.");
                        }

                        // Попытка загрузить изображение
                        using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            return new Bitmap(stream);
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show($"Файл не найден: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Файл не является поддерживаемым форматом изображения или повреждён.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
    }
}
