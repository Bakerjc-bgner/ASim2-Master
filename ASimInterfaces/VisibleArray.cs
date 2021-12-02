using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{
    abstract public class VisibleArray : VisibleObject
    {
        public VisibleArray() : base() { }
        public VisibleArray(string name,int n) : base(name,n) { }

        abstract public Type GetElementType();

        abstract public void Add(VisibleObject vArrE);

        abstract public IEnumerable<VisibleObject> Children { get; }

        abstract public void RemoveLast();

        abstract public void Clear();

        abstract public List<VisibleObject> GetList();

    }
    public class VisibleArray<T> : VisibleArray where T : VisibleObject
    {
        public VisibleArray() : base() { }
        public VisibleArray(string name,int n) : base(name,n) { }
        private List<T> elements = new List<T>();
        public List<T> Elements { get { return elements; } }
        public override Type GetElementType()
        {
            return typeof(T);
        }
        public override void Add(VisibleObject vObj)
        {
            this.elements.Add(vObj as T);
        }

        public override IEnumerable<VisibleObject> Children
        {
            get { return this.elements; }
        }
        public override List<VisibleObject> GetList()
        {
            List<VisibleObject> list = new List<VisibleObject>();
            foreach(VisibleObject obj in elements)
            {
                list.Add(obj);
            }
            return list;
        }
        public override void RemoveLast()
        {
            if (this.elements.Count == 0)
            {
                return;
            }
            this.elements.RemoveAt(this.elements.Count - 1);
        }

        public override void Clear()
        {
            this.elements.Clear();
        }

    }
}
