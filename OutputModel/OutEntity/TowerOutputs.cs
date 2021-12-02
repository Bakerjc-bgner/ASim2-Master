using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class TowerOutputs : VisiableObject
    {
        public TowerOutputs()
        {
        }

        public TowerOutputs(string name) : base(name)
        {
        }

        public TowerSectionSTRUOutputs TowerSectionSTRUOutputs = new TowerSectionSTRUOutputs("塔架截面结构动力学信息[]",9);
        public TowerSectionAeroInfo TowerSectionAeroInfo = new TowerSectionAeroInfo("塔架截面气动信息[]",9);
    }


    public class TowerSectionSTRUOutputs : VisiableObject
    {
        public TowerSectionSTRUOutputs()
        {
        }

        public TowerSectionSTRUOutputs(string name) : base(name)
        {
        }
        public TowerSectionSTRUOutputs(string name, int num) : base(name,num)
        {
        }

        public VisiableVector6 sectionDeflection = new VisiableVector6("截面位移");
        public VisiableVector6 sectionVelocity = new VisiableVector6("截面速度");
        public VisiableVector6 sectionAcceleration = new VisiableVector6("截面加速度");
        public VisiableForce6 sectionLoads = new VisiableForce6("截面力");

    }

    public class TowerSectionAeroInfo : VisiableObject
    {
        public TowerSectionAeroInfo()
        {
        }

        public TowerSectionAeroInfo(string name) : base(name)
        {
        }
        public TowerSectionAeroInfo(string name,int num) : base(name,num)
        {
        }

        public VisiableVector6 undisturbedV = new VisiableVector6("点风速");
        public VisiableVector6 translationalV = new VisiableVector6("结构平移风速");
        public VisiableOutput relativeV = new VisiableOutput("相对风速");
        public VisiableOutput dynamicPressure = new VisiableOutput("动压");
        public VisiableOutput Re = new VisiableOutput("雷诺数");
        public VisiableOutput Mach = new VisiableOutput("马赫数");
        public VisiableForce6 dragForce = new VisiableForce6("单位长度阻力");
        
    }
}
