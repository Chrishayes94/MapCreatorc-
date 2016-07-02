using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapCreator.GUI.WorldTree
{
    public class WorldDataTree : TreeView
    {
        public enum NodeType
        {
            ROOT_NODE,

            MAP_COLLECTION,

            MAP
        }

        public delegate void ItemSelectEventHandler(object sender, ItemSelectEventArgs e);

        public class ItemSelectEventArgs : EventArgs
        {
            public NodeType Type;
            public DataRow ItemData;
        }

        public event ItemSelectEventHandler MapSelect;
        public event ItemSelectEventHandler MapCollectionSelect;
        public event ItemSelectEventHandler RootNodeSelect;

        private TreeNode nodeRoot = new TreeNode("World Map", 0, 0);
        private TreeNode initialMap = new TreeNode("Map #0", 1, 1);

        public WorldDataTree() : base()
        {
            base.Nodes.Add(nodeRoot);
            //base.Nodes.Add(initialMap);
        }

        public void AddMapCollection(DataRow mapCollection)
        {
            TreeNode nodeNew = new TreeNode(mapCollection["Name"].ToString(), 2, 3);
            nodeNew.Tag = mapCollection;
            nodeRoot.Nodes.Add(nodeNew);
        }

        public void AddMap(DataRow map, int index)
        {
            TreeNode newMap = new TreeNode(map["Name"].ToString(), 2, 3);
            newMap.Tag = map;
            nodeRoot.Nodes[index].Nodes.Add(newMap);
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);

            ItemSelectEventArgs arg = new ItemSelectEventArgs();
            arg.ItemData = (DataRow)e.Node.Tag;

            if (arg.Type == NodeType.MAP_COLLECTION)
            {

            }
            else
            {

            }
        }
    }
}
