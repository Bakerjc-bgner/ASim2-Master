using ASimInterfaces;
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class InputView : UserControl
    {
        public InputView()
        {
            InitializeComponent();
        }
        private WaterDrop waterDrop = new WaterDrop();
        private VisibleObject nowVisiableObject;
        private void cascadeVisibleObjectListView1_AnaEnd(int count)
        {
            this.toolStripStatusLabel1.Text = "空闲";
            this.toolStripStatusLabel2.Text = "共" + count.ToString() + "项";
            this.statusStrip1.Refresh();
        }

        private void cascadeVisibleObjectListView1_AnaBegin()
        {
            this.toolStripStatusLabel1.Text = "分析中";
            this.statusStrip1.Refresh();
        }
        public void SetVObj(VisibleObject VObj)
        {
            this.nowVisiableObject = VObj;
            this.cascadeVisibleObjectListView1.SetVisibleObject(VObj);
        }
        private void FromClipboard(bool isOverWrite)
        {
            if (this.nowVisiableObject == null) return;
            if (!waterDrop.Detect(this.nowVisiableObject))
            {
                MessageBox.Show("包含超过2个数组的对象不支持批量导入");
                return;
            }
            VisibleArray array = waterDrop.FindFirstArray(this.nowVisiableObject);
            string data = Clipboard.GetText();
            try
            {
                string[] allLines = data.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                string[][] allData = allLines.Select(x => x.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
                if (isOverWrite)
                {
                    array.Clear();
                }

                for (int i = 0; i < allLines.Length; i++)
                {
                    array.Add(Activator.CreateInstance(array.GetElementType(), array.namestring + i.ToString()) as VisibleObject);
                }
                for (int r = this.cascadeVisibleObjectListView1.Items.Count - allLines.Length; r < this.cascadeVisibleObjectListView1.Items.Count; r++)
                {

                    var item = this.cascadeVisibleObjectListView1.Items[r] as OLVListItem;
                    var rowObject = item.RowObject as Dictionary<string, VisibleObject>;
                    if (item != null)
                    {
                        for (int c = 1; c < item.SubItems.Count; c++)
                        {
                            var valueObj = (rowObject.First(x => x.Key.IndexOf(this.cascadeVisibleObjectListView1.AllColumns[c].Text) != -1).Value as VisibleValue);
                            valueObj.setValue(allData[r][c - 1]);
                        }
                    }
                }
                this.SetVObj(this.nowVisiableObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show("因为" + ex.Message + "导入失败");
            }
        }

        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FromClipboard(false);
        }

        private void overWriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FromClipboard(true);
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder data = new StringBuilder();
            for (int r = 0; r < this.cascadeVisibleObjectListView1.Items.Count; r++)
            {
                var item = this.cascadeVisibleObjectListView1.Items[r];
                if (item != null)
                {
                    for (int c = 1; c < item.SubItems.Count; c++)
                    {
                        data.Append(item.SubItems[c].Text + "\t");
                    }
                }
                data.Append("\r\n");
            }
            string content = data.ToString();
            if (!string.IsNullOrEmpty(content))
            {
                Clipboard.SetText(content);
            }
        }
    }
}
