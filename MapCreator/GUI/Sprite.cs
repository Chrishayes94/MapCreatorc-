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
        // Gets and Sets the index of the sprite in the spritesheet.
        public int Index { get; set; }

        // Gets and Sets the position of the sprite on the spritesheet.
        public Vector2 Position { get; set; }

        // Gets and Sets the image cropped from the spritesheet image.
        public Image Image { get; set; }

        /// <summary>
        /// Default constructor for the Sprite class, takes no arguments and returns nothing.
        /// </summary>
        public Sprite() : this(-1)
        { }

        /// <summary>
        /// Constructor for the sprtie class, which takes in only the id. This is used to create an empty sprite class,
        /// used for later use.
        /// </summary>
        /// <param name="id">Passes in an integer that identifies the index of the sprite on the relative spritesheet.</param>
        public Sprite(int id) : this(-1, null, 0, 0)
        { }

        /// <summary>
        /// Constructor for the sprite class, which takes in both id and the image for the sprite. This then calls the 
        /// main constructor passing in the two parameters and a position of {0, 0}.
        /// </summary>
        /// <param name="id">Passes in an integer that identifies the index of the sprite on the relative spritesheet.</param>
        /// <param name="image">Passes in the cropped out image for the sprite.</param>
        public Sprite(int id, Image image) : this(id, image, 0, 0)
        { }

        /// <summary>
        /// Main constructor for the sprite class, takes in four parameters used to setup the class.
        /// </summary>
        /// <param name="id">Passes in an integer that identifies the index of the sprite on the relative spritesheet.</param>
        /// <param name="image">Passes in the cropped out image for the sprite.</param>
        /// <param name="x">Passes in the x-coordinate of the sprite on the spritesheet.</param>
        /// <param name="y">Passes in the y-coordinate of the sprite on the spritesheet.</param>
        public Sprite(int id, Image image, int x, int y)
        {
            this.Index = id;
            this.Position = new Vector2(x, y);
            this.Image = image;
        }
    }
}
