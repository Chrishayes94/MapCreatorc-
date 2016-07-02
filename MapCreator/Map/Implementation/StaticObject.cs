using MapCreator.gui;
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
        public StaticObject() : this(-1, new Vector2(0, 0), null)
        { }

        public StaticObject(int layer, Vector2 location, Sprite spr) : base(layer, location, spr)
        { }

        public override EntityType GetEntityType()
        {
            return EntityType.STATIC_OBJECT;
        }
    }
}
