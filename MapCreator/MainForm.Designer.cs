namespace MapCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sheetWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinationTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.springLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapDetailsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.windowContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowContainer)).BeginInit();
            this.windowContainer.Panel1.SuspendLayout();
            this.windowContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.extraToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(824, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripSeparator1,
            this.fillToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(103, 6);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedTileToolStripMenuItem,
            this.combinationTilesToolStripMenuItem});
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.fillToolStripMenuItem.Text = "Fill ";
            // 
            // selectedTileToolStripMenuItem
            // 
            this.selectedTileToolStripMenuItem.Name = "selectedTileToolStripMenuItem";
            this.selectedTileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.selectedTileToolStripMenuItem.Text = "Selected Tile";
            this.selectedTileToolStripMenuItem.Click += new System.EventHandler(this.selectedTileToolStripMenuItem_Click);
            // 
            // combinationTilesToolStripMenuItem
            // 
            this.combinationTilesToolStripMenuItem.Name = "combinationTilesToolStripMenuItem";
            this.combinationTilesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.combinationTilesToolStripMenuItem.Text = "Combination Tiles";
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.springLabel,
            this.mapDetailsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(824, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // springLabel
            // 
            this.springLabel.Name = "springLabel";
            this.springLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // mapDetailsLabel
            // 
            this.mapDetailsLabel.Name = "mapDetailsLabel";
            this.mapDetailsLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mapDetailsLabel.Size = new System.Drawing.Size(69, 17);
            this.mapDetailsLabel.Text = "Layer : (x, y)";
            // 
            // windowContainer
            // 
            this.windowContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.windowContainer.IsSplitterFixed = true;
            this.windowContainer.Location = new System.Drawing.Point(0, 24);
            this.windowContainer.Name = "windowContainer";
            // 
            // windowContainer.Panel1
            // 
            this.windowContainer.Panel1.Controls.Add(this.treeView);
            // 
            // windowContainer.Panel2
            // 
            this.windowContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.windowContainer.Size = new System.Drawing.Size(824, 447);
            this.windowContainer.SplitterDistance = 256;
            this.windowContainer.SplitterWidth = 1;
            this.windowContainer.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(3, 222);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(250, 222);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 493);
            this.Controls.Add(this.windowContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.windowContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowContainer)).EndInit();
            this.windowContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker sheetWorker;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mapDetailsLabel;
        private System.Windows.Forms.ToolStripStatusLabel springLabel;
        private System.Windows.Forms.SplitContainer windowContainer;
        private System.Windows.Forms.PictureBox sheetBox;
        private System.Windows.Forms.PictureBox tileScreenImage;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinationTilesToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView;
    }
}

