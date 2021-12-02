using ASimInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class ParameterView : UserControl
    {
        public ParameterView()
        {
            InitializeComponent();
        }
        public void ChangeSimulation(Simulation world)
        {
            this.parameterTreeListView1.Roots = world.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Select(x => x.GetValue(world)).Where(x => x is VisibleObject);
            this.parameterTreeListView1.RebuildAll(false);
        }
        public event Action<VisibleObject> SelectObjectChanged;

        private void parameterTreeListView1_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Item != null)
            {
                if (this.SelectObjectChanged != null)
                {
                    this.SelectObjectChanged(e.Item.RowObject as VisibleObject);
                }
            }
        }
    }
}
