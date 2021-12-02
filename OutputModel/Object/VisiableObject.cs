using System;
using System.Collections;
using System.Text;

namespace OutputModel
{
    public class VisiableObject
    {
        public string name { get; set; } = "";
        public string showName { get; set; } = "";
        public bool isArray { get; set; } = false;
        public int arrayNum { get; set; } = 1;

        public VisiableObject() { }

        public VisiableObject(string _showName)
        {
            this.showName = _showName;
        }

        public VisiableObject(string _showName, int _arrayNum)
        {
            this.showName = _showName;
            this.isArray = true;
            this.arrayNum = _arrayNum;
        }

    }
}
