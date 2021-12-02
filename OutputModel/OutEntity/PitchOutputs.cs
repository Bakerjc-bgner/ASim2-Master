using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class PitchOutputs : VisiableObject
    {
        public PitchOutputs()
        {
        }

        public PitchOutputs(string name) : base(name)
        {
        }

        public VisiableOutput pitchAngle = new VisiableOutput("桨距角[]", 3);
        public VisiableOutput PAngInp = new VisiableOutput("输入的桨距角[]", 1);
        public VisiableOutput PAngAct = new VisiableOutput("实际桨距角[]", 1);
        public VisiableOutput PRatAct = new VisiableOutput("实际变桨速率[]", 1);
        public VisiableOutput PAccAct = new VisiableOutput("实际变桨加速度[]", 1);
    }
}
