using MapCreator.gui;
using MapCreator.GUI.WorldTree;
using MapCreator.Map;
using MapCreator.maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MapCreator.PromptGUI.PromptTwoValue;

namespace MapCreator
{
    public partial class MainForm : Form
    {
        public static int ConvertMouseLocationToImageLocation(int loc)
        {
            return (loc / 32) * 32;
        }

        private SpriteSheetHandler handler;

        private WorldDataTable table = new WorldDataTable("MapsTable");

        private Vector2 mouseLocation = new Vector2(0, 0);

        private int layer = 0;

        public MainForm()
        {
            AllocConsole();
            InitializeComponent();

            // Attempt to load in data.
            handler = new SpriteSheetHandler();

            this.AutoSize = true;
            this.springLabel.Spring = true;
            this.mapDetailsLabel.Text = "Layer: 0 (0, 0)";

            CreatePictureBox();
            CreateMapPictureBox();
            treeView.AddMapCollection(table.CreateDataRow("Map #0"));
        }

        #region Create Boxes

        private void CreatePictureBox()
        {
            /* Add Panel */
            Panel panPic = new Panel();
            panPic.Padding = new Padding(25, 0, 0, 0);
            panPic.Size = new Size(300, 512);
            panPic.AutoSize = false;
            panPic.AutoScroll = true;
            panPic.Dock = DockStyle.None;

            /* Add Picture Box */
            sheetBox = new PictureBox();
            sheetBox.MouseClick += SpriteHolder_Click;
            sheetBox.Paint += SpriteHolder_Paint;
            sheetBox.SizeMode = PictureBoxSizeMode.AutoSize;
            sheetBox.Location = new Point(0, 0);

            panPic.Controls.Add(sheetBox);
            windowContainer.Panel1.Controls.Add(panPic);

            sheetBox.ImageLocation = handler.GetPath(0);
        }

        private void CreateMapPictureBox()
        {
            Panel panPic = new Panel();
            panPic.Dock = DockStyle.Fill;
            panPic.AutoSize = true;
            panPic.AutoScroll = true;

            tileScreenImage = new PictureBox();
            tileScreenImage.MouseClick += HandleCreationMap_Click;
            tileScreenImage.Paint += Map_Paint;
            tileScreenImage.SizeMode = PictureBoxSizeMode.AutoSize;
            tileScreenImage.Location = new Point(0, 0);

            panPic.Controls.Add(tileScreenImage);
            windowContainer.Panel2.Controls.Add(panPic);

            tileScreenImage.Image = new Bitmap(512, 512);
            using (Graphics g = Graphics.FromImage(tileScreenImage.Image))
            {
                Rectangle imageSize = new Rectangle(0, 0, 512, 512);
                g.FillRectangle(Brushes.White, imageSize);
            }
            tileScreenImage.Refresh();
        }
        #endregion

        #region Paint Methods
        private void SpriteHolder_Paint(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile(sheetBox.ImageLocation);

            Graphics g = Graphics.FromImage(image);

            // Draw the current rectangle;
            Rectangle rect = new Rectangle(mouseLocation.X, mouseLocation.Y, 32, 32);
            g.DrawRectangle(new Pen(Color.DarkRed), rect);

            g.Dispose();

            e.Graphics.DrawImage(image, new PointF(0, 0));
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            // Check for any updates required
            table.CurrentMap.UpdateMapDataImages();

            for (int i = 0; i < table.CurrentMap.MapDataImage.Length; i++)
            {
                e.Graphics.DrawImage(table.CurrentMap.MapDataImage[i], 0, 0);
            }
        }
        #endregion

        #region MouseClick Methods
        private void SpriteHolder_Click(object sender, MouseEventArgs e)
        {
            mouseLocation.X = ConvertMouseLocationToImageLocation(e.X);
            mouseLocation.Y = ConvertMouseLocationToImageLocation(e.Y);

            mapDetailsLabel.Text = "Layer : " + layer + " (" + mouseLocation.X + ", " + mouseLocation.Y + ")";

            sheetBox.Refresh();
        }

        private void HandleCreationMap_Click(object sender, MouseEventArgs e)
        {
            int x = ConvertMouseLocationToImageLocation(e.X);
            int y = ConvertMouseLocationToImageLocation(e.Y);

            int currentX = mouseLocation.X / 32;
            int currentY = mouseLocation.Y / 32;

            int index = 0;
            if (currentY > 0)
            {
                while (currentY > 0)
                {
                    index += 16;
                    currentY--;
                }
            }
            index += currentX;

            Sprite spr = handler.GetSheetByIndex(0)[index];

            table.CurrentMap.Add(layer, new StaticObject(0, new Vector2(x, y), spr)); 

            tileScreenImage.Refresh();
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Values values = PromptGUI.PromptTwoValue.ShowDialog("Change the size of the current map to:", "Resize Map", tileScreenImage.Width, tileScreenImage.Height);

            // Justdouble the size for now
            Bitmap newMap = new Bitmap((int)values.Width, (int)values.Height);
            using (Graphics g = Graphics.FromImage(newMap))
            {
                Rectangle imageSize = new Rectangle(0, 0, newMap.Width, newMap.Height);
                g.FillRectangle(Brushes.White, imageSize);
            }

            using (Graphics g = Graphics.FromImage(newMap))
            {
                g.DrawImage(tileScreenImage.Image, 0, 0);
            }

            tileScreenImage.Image = newMap;
            tileScreenImage.Refresh();
        }

        private void selectedTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentX = mouseLocation.X / 32;
            int currentY = mouseLocation.Y / 32;

            int index = 0;
            if (currentY > 0)
            {
                while (currentY > 0)
                {
                    index += 16;
                    currentY--;
                }
            }
            index += currentX;

            Image image = handler.GetSheetByIndex(0)[index].Image;

            int x = 0, y = 0;
            using (Graphics g = Graphics.FromImage(tileScreenImage.Image))
            {
                for (x = 0; x < tileScreenImage.Width; x += 32)
                    for (y = 0; y < tileScreenImage.Height; y += 32)
                        g.DrawImage(image, x, y);
            }

            tileScreenImage.Refresh();
        }

        private void AddNewLayer_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in layerToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            int index2 = layerToolStripMenuItem.DropDownItems.IndexOf(sender as ToolStripMenuItem);
            ToolStripItem layerSender = layerToolStripMenuItem.DropDownItems[index2];
            layerToolStripMenuItem.DropDownItems.RemoveAt(index2);

            ToolStripItem newLayer = new ToolStripMenuItem("Layer #" + ++layer);
            newLayer.Click += ChangeLayer_Click;

            layerToolStripMenuItem.DropDownItems.Add(newLayer);
            layerToolStripMenuItem.DropDownItems.Add(layerSender);

            (layerToolStripMenuItem.DropDownItems[index2] as ToolStripMenuItem).Checked = true;

            table.CurrentMap.Add(layer, new List<IMapEntity>());
        }

        private void ChangeLayer_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem items in layerToolStripMenuItem.DropDownItems)
                items.Checked = false;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            int index = layerToolStripMenuItem.DropDownItems.IndexOf(item);

            layer = index;
            item.Checked = true;

            mapDetailsLabel.Text = "Layer : " + layer + " (" + mouseLocation.X + ", " + mouseLocation.Y + ")";
        }
        #endregion

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();

        private void TreeNode_Click(object sender, TreeNodeMouseClickEventArgs e)
        {

        }
    }
}
