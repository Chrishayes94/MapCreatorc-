using MapCreator.maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.Map
{
    public class StaticObject : IMapEntity
    {
        public int Layer { get; set; }
        public Vector2 Location { get; set; }

        public StaticObject() : this(-1, new Vector2(0, 0))
        { }

        public StaticObject(int layer, Vector2 location)
        {
            this.Layer = layer;
            this.Location = location;
        }

        public EntityType GetEntityType()
        {
            return EntityType.STATIC_OBJECT;
        }
    }
}
