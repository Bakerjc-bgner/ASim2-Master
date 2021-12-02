using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class ShaftMotion : VisiableObject
    {
        public ShaftMotion()
        {
        }

        public ShaftMotion(string name) : base(name)
        {
        }

        public VisiableOutput LSSTipPxa = new VisiableOutput("转子方位角");
        public VisiableOutput LSSTipVxa = new VisiableOutput("转子方位角速度");
        public VisiableOutput LSSTipAxa = new VisiableOutput("转子方位角加速度");
        public VisiableOutput LSSGagPxa = new VisiableOutput("低速轴应变计方位角");
        public VisiableOutput LSSGagVxa = new VisiableOutput("低速轴应变计方位角速度");
        public VisiableOutput LSSGagAxa = new VisiableOutput("低速轴应变计方位角加速度");
        public VisiableOutput HSShftV = new VisiableOutput("高速轴和发电机角速度");
        public VisiableOutput HSShftA = new VisiableOutput("高速轴和发电机角加速度");
        








    }
}
