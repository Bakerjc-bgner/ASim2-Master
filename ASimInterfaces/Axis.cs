using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASimInterfaces
{
    public partial class Axis : VisibleValue//坐标轴
    {
        public VisibleValue X = new VisibleValue("X",0);
        public VisibleValue Y = new VisibleValue("Y",0);
        public VisibleValue Z = new VisibleValue("Z",0);
    }
}
