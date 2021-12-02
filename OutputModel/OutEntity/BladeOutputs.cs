using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class BladeOutputs : VisiableObject
    {
        public BladeOutputs()
        {
        }

        public BladeOutputs(string name) : base(name)
        {
        }

        public BladeSectionSTRUOutputs BladeSectionSTRUOutputs = new BladeSectionSTRUOutputs("叶片截面结构动力学信息[]",9);
        public BladeSectionAeroInfo BladeSectionAeroInfo = new BladeSectionAeroInfo("叶片截面气动信息[]",9);

        public VisiableOutput tip2towerClearance = new VisiableOutput("叶尖到塔距离");
        public VisiableOutput azimuthAngle = new VisiableOutput("方位角");
        public VisiableOutput pitchAngle = new VisiableOutput("桨距角");


    }

    public class BladeSectionSTRUOutputs : VisiableObject
    {
        public BladeSectionSTRUOutputs() { }

        public BladeSectionSTRUOutputs(string name) : base(name) { }

        public BladeSectionSTRUOutputs(string name, int num) : base(name,num) { }

        public VisiableVector6 sectionDeflection = new VisiableVector6("截面位移");   //线性||非线性
        public VisiableVector6 sectionVelocity = new VisiableVector6("截面速度");
        public VisiableVector6 sectionAcceleration = new VisiableVector6("截面加速度");
        public VisiableForce6 sectionLoads = new VisiableForce6("截面力");          //线性||非线性
        public VisiableForce6 appliedPointLoads = new VisiableForce6("施加的点力");
        public VisiableForce6 appliedDistributedForces = new VisiableForce6("施加的分布力");
    }

    public class BladeSectionAeroInfo : VisiableObject
    {
        public BladeSectionAeroInfo() { }

        public BladeSectionAeroInfo(string name) : base(name) { }

        public BladeSectionAeroInfo(string name,int num) : base(name,num) { }

        public VisiableVector6 undisturbedV = new VisiableVector6("点风速");
        public VisiableVector6 disturbedV = new VisiableVector6("分布风速");
        public VisiableVector6 structuralTranslationalV = new VisiableVector6("结构平移速度");
        public VisiableOutput relvativeV = new VisiableOutput("相对风速");
        public VisiableOutput dynamicPressure = new VisiableOutput("动压");
        public VisiableOutput Re = new VisiableOutput("雷诺数");
        public VisiableOutput Mach = new VisiableOutput("马赫数");
        public VisiableOutput axialInducedV = new VisiableOutput("轴向诱导速度");
        public VisiableOutput tangentialInducedV = new VisiableOutput("切向诱导速度");
        public VisiableOutput axialInductionFactor = new VisiableOutput("轴向诱导因子");
        public VisiableOutput tangentialInductionFactor = new VisiableOutput("切向诱导因子");
        public VisiableOutput AOA = new VisiableOutput("攻角");
        public VisiableOutput pitchPlusTwist = new VisiableOutput("桨距角+扭角");
        public VisiableOutput inflowAngle = new VisiableOutput("入流角");
        public VisiableOutput curvatureAngle = new VisiableOutput("弯曲角");
        public VisiableOutput Cl = new VisiableOutput("升力系数");
        public VisiableOutput Cd = new VisiableOutput("阻力系数");
        public VisiableOutput Cm = new VisiableOutput("俯仰力矩系数");
        public VisiableOutput Fn_coefficient = new VisiableOutput("平面方向法向力系数");
        public VisiableOutput Ft_coefficient = new VisiableOutput("平面方向切向力系数");
        public VisiableOutput Ff_coefficient = new VisiableOutput("弦向法向力系数");
        public VisiableOutput Fe_coefficient = new VisiableOutput("弦向切向力系数");
        public VisiableOutput liftPerLength = new VisiableOutput("单位长度升力");
        public VisiableOutput dragPerLength = new VisiableOutput("单位长度阻力");
        public VisiableOutput momentPerLength = new VisiableOutput("单位长度俯仰力矩");
        public VisiableOutput Fn_PerLength = new VisiableOutput("单位长度平面方向法向力");
        public VisiableOutput Ft_PerLength = new VisiableOutput("单位长度平面方向切向力");
        public VisiableOutput Ff_PerLength = new VisiableOutput("单位长度弦向法向力");
        public VisiableOutput Fe_PerLength = new VisiableOutput("单位长度弦向切向力");
        public VisiableOutput towerClearance = new VisiableOutput("塔架间隙");
    }

}
