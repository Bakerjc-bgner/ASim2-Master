using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class NacelleIMUMotions : VisiableObject
    {
        public NacelleIMUMotions()
        {
        }

        public NacelleIMUMotions(string name) : base(name)
        {
        }

        public VisiableVector6 nacelleVelocity = new VisiableVector6("机舱惯性测量装置速度");
        public VisiableVector6 nacelleAcceleration = new VisiableVector6("机舱惯性测量装置加速度");

    }
}
