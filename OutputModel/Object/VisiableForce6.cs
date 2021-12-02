using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class VisiableForce6 : VisiableObject
    {
        public VisiableOutput F1 = new VisiableOutput();
        public VisiableOutput F2 = new VisiableOutput();
        public VisiableOutput F3 = new VisiableOutput();
        public VisiableOutput F4 = new VisiableOutput();
        public VisiableOutput F5 = new VisiableOutput();
        public VisiableOutput F6 = new VisiableOutput();

        public VisiableForce6()
        {
        }

        public VisiableForce6(string _showName) : base(_showName)
        {
        }

        public VisiableForce6(string _showName, int _arrayNum) : base(_showName, _arrayNum)
        {
        }
    }
}
