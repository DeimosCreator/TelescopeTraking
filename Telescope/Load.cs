using System.Drawing;
using Telescope.Loading;

namespace Telescope
{
    public partial class Load
    {
        public static Load Instance { get; private set; } = new Load();

        public Bitmap LoadImage(out string imagePath) => new LoadImage().Load(out imagePath);

    }
}
