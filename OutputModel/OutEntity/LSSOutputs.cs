using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class LSSOutputs : VisiableObject
    {
        public LSSOutputs()
        {
        }

        public LSSOutputs(string name) : base(name)
        {
        }

        public VisiableForce6 fixLSSLoads = new VisiableForce6("固定低速轴载荷"); 
        public VisiableForce6 rotateLSSLoads = new VisiableForce6("旋转低速轴载荷");
        public VisiableOutput LSShftPwr = new VisiableOutput("低速轴功率");

    }
}
