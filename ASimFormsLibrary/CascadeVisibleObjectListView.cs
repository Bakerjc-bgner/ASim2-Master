using ASimInterfaces;
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ASimFormsLibrary
{
    /// <summary>
    /// 输入界面
    /// </summary>
    public partial class CascadeVisibleObjectListView : VirtualObjectListView
    {
        public CascadeVisibleObjectListView() : base()
        {
            this.ShowGroups = false;
            this.SetColumnsDelegate = this.SetColumns;
        }
        private Thread renewThread;
        private volatile VisibleObject vObj;
        private volatile List<Dictionary<string, VisibleObject>> data;

        private Action<List<OLVColumn>> SetColumnsDelegate;
        public event Action AnaBegin;
        public event Action<int> AnaEnd;
        public void SetVisibleObject(VisibleObject vObj)//将需要输入的变量传入View里
        {
            if (this.AnaBegin != null)
            {
                this.AnaBegin();
            }
            if (this.renewThread != null)
            {
                this.renewThread.Abort();
                GC.Collect();
            }
            this.vObj = vObj;
            this.renewThread = new Thread(this.PrepareColumns);
            this.renewThread.IsBackground = true;
            this.Cursor = Cursors.WaitCursor;
            this.renewThread.Start();

        }

        private void SetColumns(List<OLVColumn> columns)//设置总列数
        {
            this.AllColumns.Clear();
            this.Columns.Clear();
            foreach (var column in columns)
            {
                this.AllColumns.Add(column);
                this.Columns.Add(column);
            }
            this.VirtualListDataSource = new VirtualDataSource(this, this.data);

            this.Cursor = Cursors.Default;
            if (this.AnaEnd != null)
            {
                this.AnaEnd(this.data.Count);
            }
        }
        private void PrepareColumns()//设置表格的名称
        {
            this.data = new TwoDimensionalFoil(int.MaxValue).DimensionAttack(this.vObj);
            List<OLVColumn> columns = new List<OLVColumn>();
            var firstElement = this.data.First();
            columns.Add(new OLVColumn() { Text = string.Empty, Width = 1 });
            foreach (var key in firstElement.Keys)
            {
                if (this.data.AsParallel().All(x => x[key] is VisibleValue))
                {
                    int index = firstElement.Keys.ToList().IndexOf(key);
                    OLVColumn column = new OLVColumn();
                    column.Sortable = false;
                    column.Text = key.Substring(key.IndexOf("_") + 1);
                    column.AspectGetter = model => ((model as Dictionary<string, VisibleObject>)[firstElement.Keys.ElementAt(index)] as VisibleValue).num;
                    column.AspectPutter = (model, value) => ((model as Dictionary<string, VisibleObject>)[firstElement.Keys.ElementAt(index)] as VisibleValue).num = (double)value;
                    column.Width = column.Text.Length * 8;
                    columns.Add(column);
                }
            }
            this.Invoke(this.SetColumnsDelegate, columns);
        }
        public class VirtualDataSource : AbstractVirtualListDataSource
        {
            public VirtualDataSource(VirtualObjectListView listView, List<Dictionary<string, VisibleObject>> objectList) :
                base(listView)
            {
                this.Objects = objectList;
            }

            public override int GetObjectIndex(object model)//获取当前格子的下标
            {
                return this.Objects.IndexOf((Dictionary<string, VisibleObject>)model);
            }

            public override object GetNthObject(int n)//返回第n个下标的数值
            {
                return this.Objects[n];
            }

            public override int GetObjectCount()//返回物品总数
            {
                return this.Objects.Count;
            }

            public override void Sort(OLVColumn column, SortOrder order)
            {
                // donothing
            }

            public override int SearchText(string value, int first, int last, OLVColumn column)//查找当前行，并返回数值，用于反射
            {
                return DefaultSearchText(value, first, last, column, this);
            }

            List<Dictionary<string, VisibleObject>> Objects;
        }
    }
}
