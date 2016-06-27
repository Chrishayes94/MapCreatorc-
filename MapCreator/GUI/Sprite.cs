using MapCreator.maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.gui
{
    public class Sprite
    {
        public int Index { get; set; }

        public Vector2 Position { get; set; }

        public Image Image { get; set; }

        public Sprite() : this(-1)
        { }

        public Sprite(int id) : this(-1, null, 0, 0)
        { }

        public Sprite(int id, Image image) : this(id, image, 0, 0)
        { }

        public Sprite(int id, Image image, int x, int y)
        {
            this.Index = id;
            this.Position = new Vector2(x, y);
            this.Image = image;
        }
    }
}
