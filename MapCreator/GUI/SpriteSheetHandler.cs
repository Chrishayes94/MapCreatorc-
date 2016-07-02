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
        /// <summary>
        /// Creates an list of sprites from any spritesheet that has been passed in, the limits however
        /// are that it will create the list if the sprites are 32x32. Improvements are required.
        /// </summary>
        /// <param name="name">Passes in the location of the spritesheet on the Computer.</param>
        /// <returns>Returns a newly created list of sprites for the passed in spritesheet.</returns>
        public static List<Sprite> LoadResources(string name)
        {
            Image mainResource = Image.FromFile(name);

            int width = mainResource.Width;
            int height = mainResource.Height;

            List<Sprite> returnValue = new List<Sprite>((width / 32) * (height / 32));

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

        /// <summary>
        /// The static method is used to create a smaller cropped image of the passed in image. This method is mainly 
        /// used for the initial creation of all the sprites used for the map maker. However may be used elsewhere.
        /// </summary>
        /// <param name="image">Passes in the main spritesheet image to be cropped</param>
        /// <param name="cropArea">The rectangle used to create the sprite. Rectangle holds the position and size.</param>
        /// <returns>Returns a newly created bitmap from the rectangle area on the spritesheet image.</returns>
        private static Image CropImage(Image image, Rectangle cropArea)
        {
            Bitmap bmp = new Bitmap(image);
            Bitmap bmpCorp = bmp.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
            return (Image)(bmpCorp);
        }

        // Holds all the spritesheets, key used is a string. The string is the file name that has been trimmed down.
        public Dictionary<string, List<Sprite>> SpriteSheets { get; set; } = new Dictionary<string, List<Sprite>>();

        // Holds all the trimmed down filenames for spritesheets.
        private string[] sheetNames;

        // Holds the full paths of all spritesheets.
        private string[] fullPaths;

        /// <summary>
        /// The Default constructor, no params are passed in however the constructor will gather all the needed
        /// spritesheet locations and attempt to resolve them into the private Dictionary.
        /// </summary>
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

        /// <summary>
        /// A custom get method that is called outside of the SpriteSheetHandler class.
        /// </summary>
        /// <param name="index">Passes in an integer used to identify the String to be returned.</param>
        /// <returns>Returns the full path from the passed in index.</returns>
        public string GetPath(int index)
        {
            return fullPaths[index];
        }

        /// <summary>
        /// Returns all the sprites from the requested spritesheet.
        /// </summary>
        /// <param name="index">Passes in an integer to identify the spritesheet sprites to be returned.</param>
        /// <returns>Returns a list of sprites for the required spritesheet.</returns>
        public List<Sprite> GetSheetByIndex(int index)
        {
            return SpriteSheets[sheetNames[index]];
        }
    }
}
