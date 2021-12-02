using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ASimInterfaces
{
    public class WaterDrop
    {
        public VisibleArray FindFirstArray(VisibleObject vObj)
        {
            VisibleArray array = null;
            ConcurrentBag<VisibleObject> next = new ConcurrentBag<VisibleObject>();
            Type inputType = vObj.GetType();
            if ((array = vObj as VisibleArray) != null)
            {
                return array;
            }
            else
                if (inputType.BaseType == typeof(VisibleObject))
            {
                next.Add(vObj);
            }
            else
            {
                //impossiable
                return null;
            }
            VisibleObject suitArray = null;
            while (next.Count != 0)
            {
                ConcurrentBag<VisibleObject> fields = new ConcurrentBag<VisibleObject>();
                next.AsParallel()
                    .Select(x => x.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).AsParallel().Select(f => f.GetValue(x) as VisibleObject))
                    .ForAll(x => x.ForAll(e => fields.Add(e)));
                next = new ConcurrentBag<VisibleObject>();
                if ((suitArray = fields.FirstOrDefault(x => x is VisibleArray)) != null)
                {
                    return suitArray as VisibleArray;
                }
            }
            return null;
        }
        public bool Detect(VisibleObject vObj)
        {
            int count = 0;
            ConcurrentBag<Type> next = new ConcurrentBag<Type>();
            Type inputType = vObj.GetType();
            if (inputType.BaseType == typeof(VisibleArray))
            {
                count++;
                next.Add(inputType.GetGenericArguments()[0]);
            }
            else
                if (inputType.BaseType == typeof(VisibleObject))
            {
                next.Add(vObj.GetType());
            }
            else
            {
                //impossiable
                return true;
            }

            while (next.Count != 0 && count < 2)
            {
                ConcurrentBag<FieldInfo> fieldInfos = new ConcurrentBag<FieldInfo>();

                next.AsParallel()
                    .Select(x => x.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
                    .ForAll(x => x.AsParallel().ForAll(e => fieldInfos.Add(e)));
                next = new ConcurrentBag<Type>();
                foreach (var fieldInfo in fieldInfos)
                {
                    if (fieldInfo.FieldType.BaseType == typeof(VisibleArray))
                    {
                        next.Add(fieldInfo.FieldType.GetGenericArguments()[0]);
                        count++;
                    }
                    else
                    {
                        if (fieldInfo.FieldType != typeof(VisibleValue))
                        {
                            next.Add(fieldInfo.FieldType);
                        }
                    }
                }
            }
            if (count >= 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
