using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.maths
{
    public class Vector2
    {
        // A public integer used to store and recieve the X-coordinate of the position.
        public int X { get; set; }

        // A public integer used to store and recieve the Y-coordinate of the position.
        public int Y { get; set; }
        
        /// <summary>
        /// Default constructor for the Vector2 classes, used to initialise the class with two params.
        /// </summary>
        /// <param name="x">Passes in an integer which represents the X-coordinate.</param>
        /// <param name="y">Passes in an integer which represents the Y-coordinate.</param>
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
