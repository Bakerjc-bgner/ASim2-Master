using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class YawBearingOutputs : VisiableObject
    {
        public YawBearingOutputs()
        {
        }

        public YawBearingOutputs(string name) : base(name)
        {
        }

        public VisiableVector6 yawDeflection = new VisiableVector6("偏航轴承（塔顶）位移");
        public VisiableVector6 yawVelocity = new VisiableVector6("偏航轴承（塔顶）角速度");
        public VisiableVector6 yawAcceleration = new VisiableVector6("偏航轴承（塔顶）角加速度");
        public VisiableForce6 yawLoads_n = new VisiableForce6("偏航轴承（塔顶）载荷_n");
        public VisiableForce6 yawLoads_p = new VisiableForce6("偏航轴承（塔顶）载荷_p");

    }
}
