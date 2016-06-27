using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.gui
{
    public class SpriteSheetHandler
    {
        public static List<Sprite> LoadResources(string name)
        {
            Image mainResource = Image.FromFile(name);

            int width = mainResource.Width;
            int height = mainResource.Height;

            List<Sprite> returnValue = new List<Sprite>((width / 32) * (height / 32));

            // Attempt to resolve the image to a list.
            Graphics g = Graphics.FromImage(mainResource);

            Brush transparentRbrush = new SolidBrush(Color.Transparent);
            Pen pen = new Pen(transparentRbrush, 1);

            int index = 0;
            for (int x = 0; x < mainResource.Height; x += 32, index++)
            {
                for (int y = 0; y < mainResource.Width; y+= 32)
                {
                    Rectangle r = new Rectangle(y, x, 32, 32);
                    g.DrawRectangle(pen, r);
                    returnValue.Add(new Sprite(index, CropImage(mainResource, r), x, y));
                }
            }
            g.Dispose();

            return returnValue;
        }

        private static Image CropImage(Image image, Rectangle cropArea)
        {
            Bitmap bmp = new Bitmap(image);
            Bitmap bmpCorp = bmp.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
            return (Image)(bmpCorp);
        }

        public Dictionary<string, List<Sprite>> SpriteSheets { get; set; } = new Dictionary<string, List<Sprite>>();

        private string[] sheetNames;

        private string[] fullPaths;

        public SpriteSheetHandler()
        {
            string[] spritesheets = Directory.GetFiles("./data/sheets/");
            sheetNames = new string[spritesheets.Length];
            fullPaths = new string[spritesheets.Length];

            int index = 0;
            foreach (string s in spritesheets)
            {
                string name = Path.GetFileNameWithoutExtension(s);
                SpriteSheets.Add(name, LoadResources(s));
                sheetNames[index] = name;
                fullPaths[index++] = s;
            }
        }

        public string GetPath(int index)
        {
            return fullPaths[index];
        }

        public List<Sprite> GetSheetByIndex(int index)
        {
            return SpriteSheets[sheetNames[index]];
        }
    }
}
