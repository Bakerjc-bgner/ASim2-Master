using System;
using System.Collections.Generic;
using System.Text;

namespace OutputModel
{
    public class Outputs_oneTimeStep : VisiableObject
    {
        public Outputs_oneTimeStep()
        {
        }

        public Outputs_oneTimeStep(string name) : this()
        {
            this.name = name;
        }

        public BladeOutputs BladeOutputs_0 = new BladeOutputs("叶片输出_0");
        public BladeOutputs BladeOutputs_1 = new BladeOutputs("叶片输出_1");
        public BladeOutputs BladeOutputs_2 = new BladeOutputs("叶片输出_2");
        public RotorOutputs RotorOutputs = new RotorOutputs("风轮输出");
        public ShaftMotion ShaftMotion = new ShaftMotion("轴输出");
        public NacelleIMUMotions NacelleIMUMotions = new NacelleIMUMotions("机舱惯性测量装置");
        public NacelleYawMotions NacelleYawMotions = new NacelleYawMotions("机舱偏航输出");
        public YawBearingOutputs YawBearingOutputs = new YawBearingOutputs("偏航轴承输出");
        public TowerOutputs TowerOutputs = new TowerOutputs("塔架输出");
        public LSSOutputs LSSOutputs = new LSSOutputs("低速轴输出");
        public HSSOutputs HSSOutputs = new HSSOutputs("高速轴输出");
        public ServoOutputs ServoOutputs = new ServoOutputs("控制输出");
        public PitchOutputs PitchOutputs = new PitchOutputs("桨距输出");    //待定
        public WindMotions WindMotions = new WindMotions("风输出信息");

    }
}
