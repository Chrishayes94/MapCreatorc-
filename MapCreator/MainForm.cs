using MapCreator.gui;
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

        private Vector2 mouseLocation = new Vector2(0, 0);

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
            CreateBasicTreeView();
        }

        #region TreeView Handlers
        public ToolStripMenuItem[] CreateMainNodeItems()
        {
            ToolStripMenuItem oneNode = new ToolStripMenuItem("Add Map Node");
            oneNode.MouseDown += AddMapNode_Click;

            return new ToolStripMenuItem[] { oneNode };
        }

        public ToolStripMenuItem[] CreateMapNodeItems()
        {
            ToolStripMenuItem oneNode = new ToolStripMenuItem("Add Layer Node");
            ToolStripMenuItem secondNode = new ToolStripMenuItem("Delete Map Node");
            oneNode.MouseDown += AddLayerNode_Click;
            secondNode.MouseDown += DeleteMapNode_Click;

            return new ToolStripMenuItem[] { oneNode, secondNode };
        }
        #endregion

        #region Create Boxes
        private void CreateBasicTreeView()
        {
            treeView.Dock = DockStyle.Bottom;
            treeView.LabelEdit = true;

            TreeNode treeNode = new TreeNode("World Map");
            treeNode.ContextMenuStrip = new ContextMenuStrip();
            treeNode.ContextMenuStrip.Items.AddRange(CreateMainNodeItems());
            treeView.Nodes.Add(treeNode);

            TreeNode[] nodes = new TreeNode[] { new TreeNode("Layer #0") };

            treeNode = new TreeNode("Map #0", nodes);
            treeNode.ContextMenuStrip = new ContextMenuStrip();
            treeNode.ContextMenuStrip.Items.AddRange(CreateMapNodeItems());
            treeView.Nodes.Add(treeNode);

            windowContainer.Panel1.Controls.Add(treeView);
        }

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
        #endregion

        #region MouseClick Methods
        private void SpriteHolder_Click(object sender, MouseEventArgs e)
        {
            mouseLocation.X = ConvertMouseLocationToImageLocation(e.X);
            mouseLocation.Y = ConvertMouseLocationToImageLocation(e.Y);

            mapDetailsLabel.Text = "Layer : 0 (" + mouseLocation.X + ", " + mouseLocation.Y + ")";

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

            Image image = handler.GetSheetByIndex(0)[index].Image;

            using (Graphics g = Graphics.FromImage(tileScreenImage.Image))
            {
                g.DrawImage(image,  new Point(x, y));
            }
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

        private void TreeNode_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
                return;
            e.Node.BeginEdit();
        }

        private void AddMapNode_Click(object sender, MouseEventArgs e)
        {

        }

        private void AddLayerNode_Click(object sender, MouseEventArgs e)
        {
        }

        private void DeleteMapNode_Click(object sender, MouseEventArgs e)
        {
            treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y + 5);
            if (treeView.SelectedNode != null)
            {
                treeView.SelectedNode.Remove();
            }
        }
        #endregion

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();
    }
}
