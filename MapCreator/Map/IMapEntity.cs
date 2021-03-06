﻿using MapCreator.gui;
using MapCreator.maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.Map
{
    public abstract class IMapEntity
    {
        public int Layer { get; set; }

        public Vector2 Position { get; set; }

        public Sprite Sprite { get; set; }

        public IMapEntity(int layer, Vector2 position, Sprite spr)
        {
            Layer = layer;
            Position = position;
            Sprite = spr;
        }

        public abstract EntityType GetEntityType();
    }
}
