using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class WindMotions : VisiableObject
    {
        public WindMotions()
        {
        }

        public WindMotions(string name) : this()
        {
            this.showName = name;
        }

        public VisiableVector6 windVel = new VisiableVector6("风速",9);
    }
}
