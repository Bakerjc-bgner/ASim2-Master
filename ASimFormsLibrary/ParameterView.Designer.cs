
namespace ASimFormsLibrary
{
    partial class ParameterView
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
            this.components = new System.ComponentModel.Container();
            this.parameterTreeListView1 = new ASimFormsLibrary.ParameterTreeListView();
            ((System.ComponentModel.ISupportInitialize)(this.parameterTreeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // parameterTreeListView1
            // 
            this.parameterTreeListView1.CellEditUseWholeCell = false;
            this.parameterTreeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterTreeListView1.FullRowSelect = true;
            this.parameterTreeListView1.HideSelection = false;
            this.parameterTreeListView1.Location = new System.Drawing.Point(0, 0);
            this.parameterTreeListView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.parameterTreeListView1.Name = "parameterTreeListView1";
            this.parameterTreeListView1.ShowGroups = false;
            this.parameterTreeListView1.Size = new System.Drawing.Size(139, 409);
            this.parameterTreeListView1.TabIndex = 0;
            this.parameterTreeListView1.View = System.Windows.Forms.View.Details;
            this.parameterTreeListView1.VirtualMode = true;
            this.parameterTreeListView1.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.parameterTreeListView1_CellClick);
            this.parameterTreeListView1.CellDoubleClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.parameterTreeListView1_CellClick);
            // 
            // ParameterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.parameterTreeListView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ParameterView";
            this.Size = new System.Drawing.Size(139, 409);
            ((System.ComponentModel.ISupportInitialize)(this.parameterTreeListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ParameterTreeListView parameterTreeListView1;
    }
}
