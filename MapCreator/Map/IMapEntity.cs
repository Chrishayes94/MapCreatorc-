using MapCreator.gui;
using MapCreator.maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.Map
{
    public interface IMapEntity
    {
        EntityType GetEntityType();
    }
}
