using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class HSSOutputs : VisiableObject
    {
        public HSSOutputs()
        {
        }

        public HSSOutputs(string name) : base(name)
        {
        }

        public VisiableOutput HSShftTq = new VisiableOutput("高速轴转矩");
        public VisiableOutput HSSBrTq = new VisiableOutput("高速轴刹车转矩");
        public VisiableOutput HSShftPwr = new VisiableOutput("高速轴功率");
    }
}
