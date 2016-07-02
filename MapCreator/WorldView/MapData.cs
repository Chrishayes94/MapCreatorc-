using MapCreator.Map;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCreator.WorldView
{
    public class MapData
    {
        #region Static Methods
        /// <summary>
        /// Attempts to create one singular image form any objects that are present on a new bitmap,
        /// which will be used for the game engine.
        /// </summary>
        /// <param name="data">The list of Entities that will be drawn on to thebackground screen.</param>
        /// <param name="srcImage">The source image (used if the map is being updated)</param>
        /// <param name="newImage">The output image, will be used to display on to the screen</param>
        public static void GenerateImageData(List<IMapEntity> data, Image srcImage, out Image newImage)
        {
            // If there is no src image present or the data count is empty, then create a fresh screen.
            if (srcImage == null || data.Count == 0)
            {
                Bitmap blankImage = new Bitmap(512, 512);

                Graphics g2 = Graphics.FromImage(blankImage);
                g2.DrawRectangle(Pens.White, new Rectangle(0, 0, blankImage.Width, blankImage.Height));
                g2.Dispose();

                newImage = blankImage;
                return;
            }
            Bitmap bmp = new Bitmap(srcImage.Width, srcImage.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (IMapEntity img in data)
                {
                    g.DrawImage(img.Sprite.Image, img.Position.X, img.Position.Y);
                }
            }

            newImage = bmp;
        }

        public static T ExpandCurrentArray<T>(int newSize, T array)
        {
            if (newSize > (array as Array).Length)
            {
                if (typeof(T).IsArray)
                {
                    Type elementType = typeof(T).GetElementType();
                    Array newArray = Array.CreateInstance(elementType, newSize);
                    (array as Array).CopyTo(newArray, 0);
                    T obj = (T)(object)newArray;
                    return obj;
                }
            }
            return array;
        }
        #endregion

        private Dictionary<int, List<IMapEntity>> entities = new Dictionary<int, List<IMapEntity>>();

        public Image[] MapDataImage { get; set; } = null;

        public bool[] NeedsImageRecreation { get; set; } = null;

        public MapData() { }

        public MapData(int layer, params IMapEntity[] data)
        {
            if (data != null)
            {
                entities.Add(layer, data.ToList());

                MapDataImage = new Image[entities.Count];
                NeedsImageRecreation = new bool[entities.Count];
            }
            else
            {
                entities.Add(layer, new List<IMapEntity>());
                MapDataImage = new Image[1];
                NeedsImageRecreation = new bool[1] { true };
            }
        }

        public void UpdateMapDataImages()
        {
            for (int index = 0; index < NeedsImageRecreation.Length; index++)
            {
                if (NeedsImageRecreation[index])
                {
                    GenerateImageData(entities[index], MapDataImage[index], out MapDataImage[index]);
                    NeedsImageRecreation[index] = true;
                }
            }
        }

        public bool Add(int layer, IMapEntity data)
        {
            List<IMapEntity> list = entities[layer];
            if (list != null)
            {
                // Check if the location of new object is in use.
                foreach (IMapEntity entity in list)
                {
                    if (entity.Position.X == data.Position.X && entity.Position.Y == data.Position.Y)
                    {
                        list[list.IndexOf(entity)] = data;
                        return true;
                    }
                }

                list.Add(data);
                entities[layer] = list;
                NeedsImageRecreation[layer] = true;
            }
            return false;
        }

        public bool Add(int layer, List<IMapEntity> listData)
        {
            if (entities.Count - 1 < layer)
            {
                entities.Add(layer, listData);
                MapDataImage = ExpandCurrentArray(entities.Count, MapDataImage);
                NeedsImageRecreation = ExpandCurrentArray(entities.Count, NeedsImageRecreation);
                NeedsImageRecreation[layer] = true;
                return true;
            }
            return false;
        }
    }
}
