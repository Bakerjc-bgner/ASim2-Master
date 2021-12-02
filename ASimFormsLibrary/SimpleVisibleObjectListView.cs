using ASimFormsLibrary;
using ASimInterfaces;
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class SimpleVisibleObjectListView : ObjectListView
    {
        public SimpleVisibleObjectListView() : base()
        {
            this.ShowGroups = false;
            this.FullRowSelect = true;
            this.CellEditActivation = ObjectListView.CellEditActivateMode.SingleClick;
            this.CellEditStarting += new CellEditEventHandler(SimpleVisiableObjectListView_CellEditStarting);
        }

        void SimpleVisiableObjectListView_CellEditStarting(object sender, CellEditEventArgs e)//新建或者获取输入表单
        {
            VisibleValue rowObj = e.RowObject as VisibleValue;

            e.Control = rowObj.Num ? e.Control : new TextBox() { Location = e.Control.Location, Text = rowObj.getValue().ToString() };
        }

        private static readonly BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
        public void ChangeModel(VisibleObject vobj)//修改当前输入页面的可视化表单
        {
            this.AllColumns.Clear();
            this.Columns.Clear();
            IEnumerable<VisibleValue> visiableValue = vobj.GetType().GetFields(flags).Where(x => x.FieldType == typeof(VisibleValue)).Select(x => x.GetValue(vobj) as VisibleValue);
            OLVColumn namecol = new OLVColumn("Name", "Name");
            OLVColumn valuecol = new OLVColumn();
            valuecol.Text = "Value";
            valuecol.AspectGetter = model => (model as VisibleValue).getValue();
            valuecol.AspectPutter = (model, value) => (model as VisibleValue).setValue(value);
            namecol.Width = 200;
            valuecol.Width = 200;
            this.AllColumns.AddRange(new OLVColumn[] { namecol, valuecol });
            this.Columns.AddRange(new ColumnHeader[] { namecol, valuecol });
            this.Objects = visiableValue;

            this.Refresh();
        }
        public SimpleVisibleObjectListView(IContainer container)
        {
            container.Add((IComponent)this);

            InitializeComponent();
        }
    }
}
