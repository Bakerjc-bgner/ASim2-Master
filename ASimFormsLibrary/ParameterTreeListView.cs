using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;
using System.Reflection;
using ASimInterfaces;

namespace ASimFormsLibrary
{
    public partial class ParameterTreeListViewForm : TreeListView
    {
        public ParameterTreeListViewForm()
        {

            OLVColumn olvColumn1 = new OLVColumn();
            olvColumn1.Text = "Parameter";
            olvColumn1.Width = 191;
            this.Columns.Add(olvColumn1);
            this.AllColumns.Add(olvColumn1);
            this.FullRowSelect = true;
            this.CanExpandGetter = this.MyCanExpandGetter;
            this.ChildrenGetter = this.MyChildrenGetter;
            olvColumn1.AspectGetter = this.AspectGetter;
        }
        private static readonly BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
        private bool MyCanExpandGetter(object model)//询问树形结构是否可以继续增加子节点
        {
            if (model is VisibleMatrix)
            {
                return false;
            }
            else if (model is VisibleArray)
            {
                return (model as VisibleArray).Children.Count() > 0;
            }
            else
            {
                return model.GetType().GetFields(flags).Where(x => (x.FieldType != typeof(int) && x.FieldType != typeof(double) && x.FieldType != typeof(bool) && x.FieldType != typeof(string))).Count() > 0;
                //return model.GetType().GetFields(flags).Where(x => x.FieldType == typeof(VisibleObject)).Count() > 0;
            }
        }
        private IEnumerable MyChildrenGetter(object model)//获取子节点信息
        {
            if (model is VisibleMatrix)
            {
                return (model as VisibleMatrix).Children;
            }
            else if (model is VisibleArray)
            {
                return (model as VisibleArray).Children;
            }
            else
            {
                return model.GetType().GetFields(flags).Where(x => (x.FieldType != typeof(int) && x.FieldType != typeof(double) && x.FieldType != typeof(bool) && x.FieldType != typeof(string))).Select(x => x.GetValue(model));
            }
        }
        private object AspectGetter(object rowObject)//设置树形结构节点名称
        {
            VisibleObject vObj = rowObject as VisibleObject;
            if (string.IsNullOrEmpty(vObj.namestring))
            {
                return string.Empty;
            }
            else
            {
                return vObj.namestring;
            }
        }
    }
}
