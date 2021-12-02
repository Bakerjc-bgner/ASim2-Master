using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class NacelleYawMotions : VisiableObject
    {
        public NacelleYawMotions()
        {
        }

        public NacelleYawMotions(string _name) : base(_name)
        {
        }

        public yawMotion yawMotion = new yawMotion("机舱偏航运动");

    }

    public class yawMotion : VisiableObject
    {
        public yawMotion()
        {
        }

        public yawMotion(string _name) : base(_name)
        {
        }

        public VisiableOutput YawPzn = new VisiableOutput("偏航角");
        public VisiableOutput YawVzn = new VisiableOutput("偏航角速度");
        public VisiableOutput YawAzn = new VisiableOutput("偏航角加速度");
    }

}
