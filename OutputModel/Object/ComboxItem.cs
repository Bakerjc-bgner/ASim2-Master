using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputModel
{
    public class ComboxItem
    {
        public string Text { get; set; } = "";
        public string Value { get; set; } = "";
        public string Type { get; set; } = "";

        public object ob;

        public ComboxItem(string _Text, string _Value)
        {
            Text = _Text;
            Value = _Value;
        }

        public ComboxItem(string _Text, string _Value, string _Type, object _ob)
        {
            Text = _Text;
            Value = _Value;
            Type = _Type;
            ob = _ob;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
