using System;
using System.Collections;
using System.Text;

namespace OutputModel
{
    public class VisiableOutput : VisiableObject
    {
        public string units { get; set; }
        public ArrayList data { get; set; }


        public VisiableOutput()
        {
            this.units = "INVALID";
        }

        public VisiableOutput(string _showName) : this()
        {
            this.showName = _showName;
        }

        public VisiableOutput(string _showName, int _arrayNum) : this()
        {
            this.showName = _showName;
            this.isArray = true;
            this.arrayNum = _arrayNum;
        }

        public VisiableOutput(string _name, string _units)
        {
            this.name = _name;
            this.units = _units;
        }

    }
}
