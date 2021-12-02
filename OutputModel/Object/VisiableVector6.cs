using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class VisiableVector6 : VisiableObject
    {
        public VisiableOutput V1 = new VisiableOutput();
        public VisiableOutput V2 = new VisiableOutput();
        public VisiableOutput V3 = new VisiableOutput();
        public VisiableOutput V4 = new VisiableOutput();
        public VisiableOutput V5 = new VisiableOutput();
        public VisiableOutput V6 = new VisiableOutput();

        public VisiableVector6()
        {
        }

        public VisiableVector6(string _showName) : base(_showName)
        {
        }

        public VisiableVector6(string _showName, int _arrayNum) : base(_showName, _arrayNum)
        {
        }
    }
}
