using MapCreator.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MapCreator.Map
{
    public class GameMap : ICollection<Sprite>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Count { get { return this.} }

        private ArrayList mapDataList = new ArrayList();

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public GameMap() : this(0, 0)
        { }

        public GameMap(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Add(Sprite item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Sprite item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Sprite[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Sprite item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Sprite> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
