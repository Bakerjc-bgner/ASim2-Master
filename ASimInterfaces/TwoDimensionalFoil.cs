using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Concurrent;
using System.Threading.Tasks;
namespace ASimInterfaces
{

    public class TwoDimensionalFoil
    {
        public TwoDimensionalFoil(int maxLevel)
        {
            this.maxLevel = maxLevel;
        }

        private int maxLevel;
        private List<Dictionary<string, VisibleObject>> result;
        private DistinctComparer comparer = new DistinctComparer();
        public List<Dictionary<string, VisibleObject>> DimensionAttack(VisibleObject target)//返回数值对列表
        {
            int total = this.maxLevel; ;
            while (total != -1)
            {
                Init(target);
                total = DoIt(total);
            }
            Filter();
            Distinct();

            return result;
        }

        private void Filter()//筛选掉不可访问数值
        {
            this.result.AsParallel().ForAll(RemoveUnVisiable);
        }
        private void RemoveUnVisiable(Dictionary<string, VisibleObject> element)//查找数值对列表中不可访问数值
        {
            var unVisiables = element.Where(x => !(x.Value is VisibleValue)).ToArray();
            foreach (var unVisiable in unVisiables)
            {
                element.Remove(unVisiable.Key);
            }
        }
        private int DoIt(int maxLevel)
        {
            int count = 0;
            try
            {
                for (count = 0; !(count >= maxLevel || this.IsDone()); count++)
                {
                    while (ForArray()) { }
                    while (ForValue()) { }
                    while (ForObject()) { }
                }

            }
            catch (OutOfMemoryException)
            {
                return count;
            }
            return -1;
        }

        private void Distinct()
        {
            this.result.Distinct(this.comparer);
        }


        private void Init(VisibleObject target)
        {
            this.result = new List<Dictionary<string, VisibleObject>>();
            Dictionary<string, VisibleObject> begin = new Dictionary<string, VisibleObject>();
            begin.Add(target.namestring, target);
            this.result.Add(begin);
        }
        private bool ForArray()
        {
            bool research = false;
            var firstElement = this.result.First();
            var keys = firstElement.Keys.ToList();
            foreach (var key in keys)
            {
                var field = firstElement[key];
                VisibleArray array = null;
                if ((array = field as VisibleArray) != null)
                {
                    if (array.Children.Count() == 0)
                    {
                        this.result.AsParallel().ForAll(x => x.Remove(key));
                    }
                    else
                    {
                        List<Dictionary<string, VisibleObject>> temp = new List<Dictionary<string, VisibleObject>>();
                        foreach (var x in this.result)
                        {
                            var myarray = x[key] as VisibleArray;
                            foreach (var child in myarray.Children)
                            {
                                Dictionary<string, VisibleObject> newElement = new Dictionary<string, VisibleObject>(x);
                                newElement.Remove(key);
                                newElement.Add(key, child);
                                temp.Add(newElement);
                            }
                        }
                        this.result.Clear();
                        this.result.AddRange(temp);
                    }
                    research = true;
                    break;

                }
            }
            return research;
        }

        private bool ForObject()
        {
            bool research = false;
            var firstElement = this.result.First();
            foreach (var field in firstElement)
            {
                if (!(field.Value is VisibleArray) && !(field.Value is VisibleValue) && (field.Value is VisibleObject))
                {
                    foreach (var oldElement in this.result)
                    {
                        var myfieldvalue = oldElement[field.Key];
                        oldElement.Remove(field.Key);
                        foreach (var objectField in field.Value.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(x => x.GetValue(myfieldvalue)).Cast<VisibleObject>())
                        {
                            oldElement.Add(field.Key + "_" + objectField.namestring, objectField);
                        }
                    }
                    research = true;
                }
                if (research)
                {
                    break;
                }
            }
            return research;
        }

        private bool ForValue()
        {
            return false;
            //do nothing here
        }

        private bool IsDone()
        {
            var firstElement = this.result.First();
            return firstElement.All(x => x.Value is VisibleValue);
        }
        class DistinctComparer : IEqualityComparer<Dictionary<string, VisibleObject>>
        {
            public bool Equals(Dictionary<string, VisibleObject> x, Dictionary<string, VisibleObject> y)
            {
                if (x.Keys.Count != y.Keys.Count)
                {
                    return false;
                }
                foreach (string key in x.Keys)
                {
                    if (y.Keys.Contains(key))
                    {
                        if (x[key] != y[key])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(Dictionary<string, VisibleObject> obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
