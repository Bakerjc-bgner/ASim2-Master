using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{
    public class VisibleValue : VisibleObject
    {
        public bool Num = true;
        public double num { get; set; }
        public string str { get; set; }
        public VisibleValue() : base()//访问父类同时对当前类及父类赋值
        {
            this.str = string.Empty;
        }
        public VisibleValue(string s,int n) : base(s,n)
        {
            this.str = string.Empty;
        }
        public object getValue()//从当前类中获得数值、字符串
        {
            if (Num)
            {
                return num;
            }
            else
            {
                return str;
            }
        }
        public void setValue(object Value)//对当前类设置数值、字符串
        {
            try
            {
                if (Num)
                {
                    num = (double)Convert.ChangeType(Value, typeof(double));
                }
                else
                {
                    str = Value.ToString();
                    Num = false;
                }
            }
            catch { }
        }
    }
}
