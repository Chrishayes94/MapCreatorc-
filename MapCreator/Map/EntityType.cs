using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.Map
{
    public class EntityType
    {
        public static EntityType STATIC_OBJECT = new EntityType(0);

        public static EntityType OBJCET = new EntityType(1);

        public static EntityType PLAYER = new EntityType(2);

        public static EntityType NPC = new EntityType(3);

        public static EntityType PROJECTILE = new EntityType(4);

        public int ID { get; private set; }

        private EntityType(int id)
        {
            this.ID = id;
        }
    }
}
