using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class RotorOutputs : VisiableObject
    {
        public RotorOutputs()
        {
        }

        public RotorOutputs(string name) : base(name)
        {
        }

        public VisiableOutput RtSpeed = new VisiableOutput("风轮转速"); 
        public VisiableOutput RtTSR = new VisiableOutput("风轮叶尖速比"); 
        public VisiableVector6 RtVAvg = new VisiableVector6("轮毂相对风速"); 
        public VisiableOutput RtSkew = new VisiableOutput("轮毂入流偏角"); 
        public VisiableForce6 rotorAeroload = new VisiableForce6("风轮总气动载荷"); 
        public VisiableOutput RtAeroPwr = new VisiableOutput("气动功率"); 
        public VisiableOutput RtArea = new VisiableOutput("风轮后掠面积"); 
        public VisiableOutput RtAeroCp = new VisiableOutput("风轮气动功率系数"); 
        public VisiableOutput RtAeroCq = new VisiableOutput("风轮气动转矩系数"); 
        public VisiableOutput RtAeroCt = new VisiableOutput("风轮气动推力系数"); 
    }
}
