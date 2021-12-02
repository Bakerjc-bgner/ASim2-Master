
namespace ASimFormsLibrary
{
    partial class InputView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cascadeVisibleObjectListView1 = new ASimFormsLibrary.CascadeVisibleObjectListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addnewLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletenewLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cascadeVisibleObjectListView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cascadeVisibleObjectListView1
            // 
            this.cascadeVisibleObjectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cascadeVisibleObjectListView1.CellEditUseWholeCell = false;
            this.cascadeVisibleObjectListView1.HideSelection = false;
            this.cascadeVisibleObjectListView1.Location = new System.Drawing.Point(3, 28);
            this.cascadeVisibleObjectListView1.Name = "cascadeVisibleObjectListView1";
            this.cascadeVisibleObjectListView1.ShowGroups = false;
            this.cascadeVisibleObjectListView1.Size = new System.Drawing.Size(594, 267);
            this.cascadeVisibleObjectListView1.TabIndex = 0;
            this.cascadeVisibleObjectListView1.View = System.Windows.Forms.View.Details;
            this.cascadeVisibleObjectListView1.VirtualMode = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromClipboardToolStripMenuItem,
            this.toClipboardToolStripMenuItem,
            this.addnewLineToolStripMenuItem,
            this.deletenewLineToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // fromClipboardToolStripMenuItem
            // 
            this.fromClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendToolStripMenuItem,
            this.overWriteToolStripMenuItem});
            this.fromClipboardToolStripMenuItem.Name = "fromClipboardToolStripMenuItem";
            this.fromClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fromClipboardToolStripMenuItem.Text = "FromClipboard";
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.appendToolStripMenuItem.Text = "Append";
            this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
            // 
            // overWriteToolStripMenuItem
            // 
            this.overWriteToolStripMenuItem.Name = "overWriteToolStripMenuItem";
            this.overWriteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.overWriteToolStripMenuItem.Text = "OverWrite";
            this.overWriteToolStripMenuItem.Click += new System.EventHandler(this.overWriteToolStripMenuItem_Click);
            // 
            // toClipboardToolStripMenuItem
            // 
            this.toClipboardToolStripMenuItem.Name = "toClipboardToolStripMenuItem";
            this.toClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.toClipboardToolStripMenuItem.Text = "ToClipboard";
            // 
            // addnewLineToolStripMenuItem
            // 
            this.addnewLineToolStripMenuItem.Name = "addnewLineToolStripMenuItem";
            this.addnewLineToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addnewLineToolStripMenuItem.Text = "Add(new Line)";
            // 
            // deletenewLineToolStripMenuItem
            // 
            this.deletenewLineToolStripMenuItem.Name = "deletenewLineToolStripMenuItem";
            this.deletenewLineToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deletenewLineToolStripMenuItem.Text = "Delete(new Line)";
            // 
            // InputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cascadeVisibleObjectListView1);
            this.Name = "InputView";
            this.Size = new System.Drawing.Size(600, 320);
            ((System.ComponentModel.ISupportInitialize)(this.cascadeVisibleObjectListView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CascadeVisibleObjectListView cascadeVisibleObjectListView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addnewLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletenewLineToolStripMenuItem;
    }
}
