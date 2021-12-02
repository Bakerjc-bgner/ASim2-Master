using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class ServoOutputs : VisiableObject
    {
        public ServoOutputs()
        {
        }

        public ServoOutputs(string name) : this()
        {
            this.showName = name;
        }

        public VisiableOutput pitchAngleCommand = new VisiableOutput("需要的桨距角[]",3);
        
        public VisiableOutput GenTq = new VisiableOutput("发电机扭矩");
        public VisiableOutput GenPwr = new VisiableOutput("发电机功率");
        public VisiableOutput HSSBrTqC = new VisiableOutput("需要的高速轴刹车转矩");
        public VisiableOutput YawMomCom = new VisiableOutput("需要的机舱偏航力矩");

    }
}
