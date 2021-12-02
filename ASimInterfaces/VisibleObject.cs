using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{
    public class VisibleObject
    {
        public string namestring;//存储类名
        public int ID = 0;
        public VisibleObject() { }//保留默认构造方法
        public VisibleObject(string s,int n)
        {
            this.namestring = s;//自定义构造方法，将类名赋值给该类。
            this.ID = n;
        }
    }
}
