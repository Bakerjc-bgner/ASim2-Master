using System.Text;
using DataLibrary;
using System.IO;
using System;
using System.Linq;
namespace ASim2
{
    public class WriteFst
    {
        public Simulation_0 sim1 = new Simulation_0();
        public string workDir1 = @".\Resources\IEA-15-240-RWT-Monopile";
        public string workDir2 = @".\Resources\IEA-15-240-RWT";
        public WriteFst(Simulation_0 sim)
        {
            this.sim1 = sim;
            Directory.CreateDirectory(workDir1);
            Directory.CreateDirectory(workDir2);
            Directory.CreateDirectory(workDir2 + @"\Wind");
            Directory.CreateDirectory(workDir2 + @"\Airfoils");
            Directory.CreateDirectory(workDir1 + @"\ServoData");
            Copy_dll();
            //System.Threading.Thread.Sleep(100);
            Write_IEA_15_240_Monopile();
            Write_IEA_15_240_ElastoDyn();
            Write_IEA_15_240_BeamDyn();
            Write_IEA_15_240_BeamDyn_blade();
            Write_IEA_15_240_ElastoDyn_tower();
            Write_IEA_15_240_Inflowfile();
            Write_IEA_15_240_AeroDyn15();
            Write_IEA_15_240_AeroDyn15_Blade();
            for (int i = 0; i < 50; i++)
            {
                Write_IEA_15_240_AeroDyn_Polar(i);
                Write_IEA_15_240_Polar_Coords(i);
            }
            Write_IEA_15_240_ServoDyn();



        }
        public void Write_IEA_15_240_Monopile()
        {
            FileStream fs = new FileStream(workDir1+@"\IEA-15-240-RWT-Monopile.fst", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            const string head = "------- OpenFAST INPUT FILE -------------------------------------------\n" +
            "IEA 15 MW offshore reference model monopile configuration\n";
            sw.Write(head);
            sw.WriteLine("---------------------- SIMULATION CONTROL --------------------------------------！固定格式，不要随意增减行数，不同版本输入文件格式有可能不一样");
            sw.WriteLine(sim1.SimulationControl.BasicControl.Echo.value + "\t Echo\t- Echo input data to <RootName>.ech (flag)！生成一个同样类型的主文件，显示怎么设置的主文件");
            sw.WriteLine("\"FATAL\"\tAbortLevel\t - Error level when simulation should abort(string) {\"WARNING\", \"SEVERE\", \"FATAL\"}！报错等级");
            sw.Write(sim1.SimulationControl.BasicControl.TMAX.value + "\tTMax\t- Total run time (s)！代码运行的总时长\n");
            sw.Write(
                sim1.SimulationControl.BasicControl.DT.value + "\tDT\t - Recommended module time step (s)!设置的太大容易发散，预测校正的时间步进法，固定步长数值积分方案的时间步长，每隔多少s计算一次\n" +
                "1\tInterpOrder \t- Interpolation order for input/output time history (-) {1=linear, 2=quadratic}！根据输出时间步长和计算时间步长做插值，不一定每个时间步长都输出\n" +
                "0\tNumCrctn\t- Number of correction iterations (-) {0=explicit calculation, i.e., no corrections}！在最初的几个时间步中FAST增加了修正步为解决BeamDyn初始化问题，一般为0\n" +
                "99999.0\tT_UJac \t- Time between calls to get Jacobians (s)！一般设置成很大\n" +
                "1000000.0\t UJacSclFact\t- Scaling factor used in Jacobians (-)\n" +
                "---------------------- FEATURE SWITCHES AND FLAGS ------------------------------！设置模块\n");
            sw.Write(
                sim1.SimulationControl.SimulationFlags.CompElast[0].value + "\tCompElast\t- Compute structural dynamics (switch) {1=ElastoDyn; 2=ElastoDyn + BeamDyn for blades}\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[1].value + "\tCompInflow\t- Compute inflow wind velocities (switch) {0=still air; 1=InflowWind; 2=external from OpenFOAM}\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[2].value + "\tCompAero\t- Compute aerodynamic loads (switch) {0=None; 1=AeroDyn v14; 2=AeroDyn v15}\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[3].value + "\tCompServo\t- Compute control and electrical-drive dynamics (switch) {0=None; 1=ServoDyn}\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[4].value + "\tCompHydro\t- Compute hydrodynamic loads (switch) {0=None; 1=HydroDyn}\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[5].value + "\tCompSub\t- Compute sub-structural dynamics (switch) {0=None; 1=SubDyn; 2=External Platform MCKF}！下部基础结构，如不调用相当于全约束固定\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[6].value + "\tCompMooring\t- Compute mooring system (switch) {0=None; 1=MAP++（准静态）; 2=FEAMooring（有限元法）; 3=MoorDyn（集中质量法）; 4=OrcaFlex}！系泊模块\n" +
                sim1.SimulationControl.SimulationFlags.CompElast[7].value + "\tCompIce\t- Compute ice loads (switch) {0=None; 1=IceFloe; 2=IceDyn}\n" +
                "---------------------- INPUT FILES ---------------------------------------------\n");

            if (sim1.SimulationControl.SimulationFlags.CompElast[0].value.Equals(1) || sim1.SimulationControl.SimulationFlags.CompElast[0].value.Equals(2))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[0].value+ "\"" + "\tEDFile\t- Name of file containing ElastoDyn input parameters (quoted string)\n");
            }
            else sw.Write("\"unused\"\tEDFile\t- Name of file containing ElastoDyn input parameters (quoted string)\n");
            if (sim1.SimulationControl.SimulationFlags.CompElast[1].value.Equals(1)|| sim1.SimulationControl.SimulationFlags.CompElast[1].value.Equals(2))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[1].value+ "\"" + "\tBDBldFile(1)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n" +
                   "\""+sim1.SimulationControl.InputFiles.EDFile[2].value+ "\"" + "\tBDBldFile(2)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n" +
                  "\""+sim1.SimulationControl.InputFiles.EDFile[3].value+ "\"" + "\tBDBldFile(3)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n");
            }
            else
            {
                sw.Write("\"unused\"" + "\tBDBldFile(1)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n" +
                   "\"unused\"" + "\tBDBldFile(2)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n" +
                  "\"unused\"" + "\tBDBldFile(3)\t- Name of file containing BeamDyn input parameters for blade 1 (quoted string)\n");
            }
            if (!sim1.SimulationControl.SimulationFlags.CompElast[1].value.Equals(0))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[4].value+ "\"" + "\tInflowFile\t- Name of file containing inflow wind input parameters (quoted string)\n");
            }
            else sw.Write("\"unused\"\t EDFile\tInflowFile\t- Name of file containing inflow wind input parameters (quoted string)\n");
            if (!sim1.SimulationControl.SimulationFlags.CompElast[2].value.Equals(0))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[5].value+ "\"" + "\tAeroFile\t- Name of file containing aerodynamic input parameters (quoted string)\n");
            }
            else sw.Write("\"unused\" \t HydroFile   - Name of file containing hydrodynamic input parameters (quoted string)\n");
            if (!sim1.SimulationControl.SimulationFlags.CompElast[3].value.Equals(0))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[6].value+ "\"" + "\tServoFile\t- Name of file containing control and electrical-drive input parameters (quoted string)\n");
            }
            else sw.Write("\"unused\" \tServoFile\t- Name of file containing control and electrical-drive input parameters (quoted string)\n");
            if (!sim1.SimulationControl.SimulationFlags.CompElast[4].value.Equals(0))
            {
                sw.Write("\""+sim1.SimulationControl.InputFiles.EDFile[7].value+ "\"" + "\t HydroFile   - Name of file containing hydrodynamic input parameters (quoted string)\n");
            }
            else sw.Write("\"unused\" \t HydroFile   - Name of file containing hydrodynamic input parameters (quoted string)\n");
            sw.Write("\"unused\"\tSubFile - Name of file containing sub - structural input parameters(quoted string)\n" +
                "\"unused\"\t MooringFile - Name of file containing mooring system input parameters(quoted string)\n" +
                "\"unused\"\tIceFile - Name of file containing ice input parameters(quoted string)\n" +
               "---------------------- OUTPUT --------------------------------------------------\n");
            sw.Write(sim1.Outputs.GeneralOutputSetting.SumPrint.value+"\n" +
                "1.0\tSttsTim\t- Amount of time between screen status messages (s)\n" +
                "99999.0\tChkptTime\t- Amount of time between creating checkpoint files for potential restart (s) !，一般用不到，设置的比仿真时间大即可（TMAX）\n" +
                "1\tDT_Ou\t- Time step for tabular output (s) (or \"default\") ！每多少s输出一个数据\n" +
                "0.0\tTStart\t- Time to begin tabular output (s)！什么时候开始输出数据\n" +
                "1\tOutFileFmt\t- Format for tabular (time-marching) output file (switch) {1: text file [<RootName>.out], 2: binary file [<RootName>.outb], 3: both}！输出文件的格式，如果输出二进制文件需要用后处理软件来读取\n" +
                "True\tTabDelim    - Use tab delimiters in text tabular output file? (flag) {uses spaces if false}！使用制表符而不是固定宽度的列来分隔表格输出数据，设置为真。制表符分隔的文件更容易导入到电子表格中，固定列文件更适合用文本编辑器查看或打印\n" +
                "\"ES10.3E2\"\tOutFmt\t- Format used for text tabular output, excluding the time channel.  Resulting field should be 10 characters. (quoted string)！使用此字符串作为浮点值输出的数字格式说明符，不得超过20个字符，用撇号或双引号括起，不能指定空字符串，使用E、EN或ES说明符保证不会因为数字太大而溢出字段\n");
            sw.Write("---------------------- LINEARIZATION -------------------------------------------！线性质量，线性刚度的分布，来求解不同的自由度的固有频率" +
                sim1.WindTurbine.Control.Linearization.Linearize.value + "\tLinearize   - Linearization analysis (flag)\n" +
                sim1.WindTurbine.Control.Linearization.CalcSteady.value + "\tCalcSteady  - Calculate a steady-state periodic operating point before linearization? [unused if Linearize=False] (flag)\n" +
                "3\tTrimCase\t- Controller parameter to be trimmed {1:yaw; 2:torque; 3:pitch} [used only if CalcSteady=True] (-)\n" +
                "0.001\tTrimTol\t- Tolerance for the rotational speed convergence [used only if CalcSteady=True] (-)\n" +
                "0.01\tTrimGain\t- Proportional gain for the rotational speed error (>0) [used only if CalcSteady=True] (rad/(rad/s) for yaw or pitch; Nm/(rad/s) for torque)\n" +
                "0\tTwr_Kdmp\t- Damping factor for the tower [used only if CalcSteady=True] (N/(m/s))\n" +
                "0\tBld_Kdmp\t- Damping factor for the blades [used only if CalcSteady=True] (N/(m/s))\n" +
                "2\tNLinTimes\t- Number of times to linearize (-) [>=1] [unused if Linearize=False]\n" +
                "30.000000,\t60.000000\tLinTimes\t- List of times at which to linearize (s) [1 to NLinTimes] [used only when Linearize=True and CalcSteady=False]\n" +
                "1\tLinInputs\t- Inputs included in linearization (switch) {0=none; 1=standard; 2=all module inputs (debug)} [unused if Linearize=False]\n" +
                "1\tLinOutputs\t- Outputs included in linearization (switch) {0=none; 1=from OutList(s); 2=all module outputs (debug)} [unused if Linearize=False]\n" +
                "False\tLinOutJac\t- Include full Jacobians in linearization output (for debug) (flag) [unused if Linearize=False; used only if LinInputs=LinOutputs=2]\n" +
                "False\tLinOutMod\t- Write module-level linearization output files in addition to output for full system? (flag) [unused if Linearize=False]\n");
            sw.Write("---------------------- VISUALIZATION ------------------------------------------！可视化，用paraview软件来读取vtk文件\n" +
               sim1.Outputs.Viualization.WrVTK.value + "\tWrVTK\t- VTK visualization data output: (switch) {0=none; 1=initialization data only; 2=animation}\n" +
               "3\tVTK_type\t - Type of VTK visualization data: (switch) {1=surfaces; 2=basic meshes (lines/points); 3=all meshes (debug)} [unused if WrVTK=0]\n" +
               "False\tVTK_fields\t- Write mesh fields to VTK data files? (flag) {true/false} [unused if WrVTK=0]\n" +
               "15.0\tVTK_fps\t- Frame rate for VTK output (frames per second){will use closest integer multiple of DT} [used only if WrVTK=2]\n");
            sw.Close();
            fs.Close();
        }
        public void Write_IEA_15_240_ElastoDyn()
        {
            FileStream fs = new FileStream(workDir1 + @"\IEA-15-240-RWT-Monopile_ElastoDyn.dat", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            const string head = "------- ELASTODYN v1.03.* INPUT FILE -------------------------------------------\n" +
            "IEA 15 MW offshore reference model monopile configuration\n";
            sw.Write(head);
            sw.Write("---------------------- SIMULATION CONTROL --------------------------------------！模态；受结构质量和刚度影响的振动特性 模态振型：结构振动的形式 模态频率：结构振动的频率 模态阻尼：结构振动衰减的速度 整个结构的变形以一阶为主，因为刚度是乘以模态的平方的得到的，二阶的模态振型又比一阶大，所以刚度比一阶大，对应自由度就要小。阶数越高，所需激发能量越大。最后将一阶，二阶模态结果线性叠加，得到整体的位移\n" +
                sim1.SimulationControl.StructureSimulationControl.Echo.value + "True \tEcho\t - Echo input data to \" < RootName >.ech\" (flag)\n" +
                sim1.SimulationControl.StructureSimulationControl.Method.value + "\tMethod \t- Integration method: {1: RK4, 2: AB4, or 3: ABM4} (-) ！3：2步  预测加校正 1：4步，效率低一些\n");
            if (sim1.SimulationControl.StructureSimulationControl.DT.value.Equals(sim1.SimulationControl.BasicControl.DT.value))
            {
                sw.WriteLine("\"default\"\tDT\tIntegration time step (s) ！设置为default表示遵从.fst中的时间步长");
            }
            else sw.WriteLine(sim1.SimulationControl.StructureSimulationControl.DT.value + "DT\tIntegration time step (s) ！设置为default表示遵从.fst中的时间步长");
            sw.Write("---------------------- ENVIRONMENTAL CONDITION --------------------------------- \n" +
              "！轮毂和机舱属于刚体，弹性力与势能与广义坐标（变形量）有关，势能是刚度和广义坐标相结合的，刚度又是模态振型的函数，叶片和塔架振动是假定的这几阶模态的线性的叠加" +
              sim1.Environment.EnvironmentalConditions.Gravity.value + "\t Gravity\t- Gravitational acceleration (m/s^2)\n" +
              "---------------------- DEGREES OF FREEDOM --------------------------------------" +
              "！自由度  叶片：一阶，二阶挥舞，一阶摆振，共9个自由度，每个叶片3个自由度叶片：一阶，二阶挥舞，一阶摆振，共9个自由度，每个叶片3个自由度 塔架：一阶、二阶fore-aft纵向（前后），一阶、二阶side to side侧向（左右），共四个自由度 平台：surge，sway，heave，roll，pitch，yaw共6个自由度  传动轴：旋转，扭转2个自由度  机舱：偏航（绕塔架中心轴旋转），俯仰（上下）2个自由度\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[0].value + "\tFlapDOF1 \t- First flapwise blade mode DOF (flag) ！叶片一阶挥舞自由度\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[1].value + "\tFlapDOF2\t- Second flapwise blade mode DOF (flag)！叶片二阶挥舞自由度\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[2].value + "\tEdgeDOF\t- First edgewise blade mode DOF (flag) ! 叶片一阶摆振自由度\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[3].value + "\tTeetDOF\t- Rotor-teeter DOF (flag) [unused for 3 blades] ！针对小型风力机的，用来对风的\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[4].value + "\tDrTrDOF\t- Drivetrain rotational-flexibility DOF (flag) ！传动轴的旋转的自由度，传动轴有扭转刚度，是会发生扭转变形的\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[5].value + "\tGenDOF \t- Generator DOF (flag) !发电机自由度，如果关了，则风轮不会旋转\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[6].value + "\tYawDOF\t- Yaw DOF (flag) ！风轮绕着塔架中心轴旋转\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[7].value + "\tTwFADOF1\t- First fore-aft tower bending-mode DOF (flag)\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[8].value + "\tTwFADOF2\t- Second fore-aft tower bending-mode DOF (flag)\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[9].value + "\t TwSSDOF1    - First side-to-side tower bending-mode DOF (flag)\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[10].value + "\t TwSSDOF2    - Second side-to-side tower bending-mode DOF (flag)\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[11].value + "\t PtfmSgDOF   - Platform horizontal surge translation DOF (flag) ！纵荡\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[12].value + "\tPtfmSwDOF   - Platform horizontal sway translation DOF (flag)  ！横荡\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[13].value + "\tPtfmHvDOF   - Platform vertical heave translation DOF (flag)    ！垂荡\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[14].value + "\tPtfmRDOF    - Platform roll tilt rotation DOF (flag)           ! 横摇\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[15].value + "\tPtfmPDOF    - Platform pitch tilt rotation DOF (flag)          ！纵摇\n" +
              sim1.SimulationControl.StructureSimulationControl.DOF.DOFOrder[16].value + "\tPtfmYDOF    - Platform yaw rotation DOF (flag)                 ！手摇\n");
            sw.Write("---------------------- INITIAL CONDITIONS --------------------------------------！ 初始状态，停机时桨距角为90°\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.OoPDefl.value + "\tOoPDefl     - Initial out-of-plane blade-tip displacement (meters) ！有时风速过大时可能会报错，可能需要调一下，当与Simulink接口时，必须为0\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.IPDefl.value + "\tIPDefl      - Initial in-plane blade-tip deflection (meters)       ！有时风速过大时可能会报错，可能需要调一下，当与Simulink接口时，必须为0\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.BlPitch_1.value + "\tBlPitch(1)  - Blade 1 initial pitch (degrees)！初始桨距角，有时风速过大应设置初始桨距角，20m/s的风建议设置10度以上，三个叶片一样\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.BlPitch_2.value + "\tBlPitch(2)  - Blade 2 initial pitch (degrees)！初始桨距角，有时风速过大应设置初始桨距角，20m/s的风建议设置10度以上，三个叶片一样\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.BlPitch_3.value + "\tBlPitch(3)  - Blade 3 initial pitch (degrees) [unused for 2 blades]！初始桨距角，有时风速过大应设置初始桨距角，20m/s的风建议设置10度以上，三个叶片一样\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.TeetDefl.value + "\tTeetDefl    - Initial or fixed teeter angle (degrees) [unused for 3 blades]\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.Azimuth.value + "\tAzimuth     - Initial azimuth angle for blade 1 (degrees) ！叶片1初始方位角，叶片3在叶片2前，叶片2在叶片1前\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.RotSpeed.value + "\tRotSpeed    - Initial or fixed rotor speed (rpm)！如果初始转速不设置为0，刚开始就会有一个比较大的扰动，所以刚开始可能会不稳定。当从下风向看去时，风轮顺时针旋转（这个还不确定）\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.NacYaw.value + "\tNacYaw      - Initial or fixed nacelle-yaw angle (degrees)！初始或安装机舱偏航角，俯视风机时，逆时针为正\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.TTDspFA.value + "\tTTDspFA     - Initial fore-aft tower-top displacement (meters)！下风向为正（不确定),当与Simulink接口时，必须为0\n" +
                sim1.SimulationControl.StructureSimulationControl.InitialConditions.TTDspSS.value + "\tTTDspSS     - Initial side-to-side tower-top displacement (meters)!当从上风向看去时，向右为正（不确定），当与Simulink接口时，必须为0\n" +
                "0.0\tPtfmSurge   - Initial or fixed horizontal surge translational displacement of platform (meters)\n" +
                "0.0\tPtfmSway    - Initial or fixed horizontal sway translational displacement of platform (meters)\n" +
                "-0.00177\tPtfmHeave   - Initial or fixed vertical heave translational displacement of platform (meters)\n" +
                "0.0\tPtfmRoll    - Initial or fixed roll tilt rotational displacement of platform (degrees)\n" +
                "0.0\tPtfmPitch   - Initial or fixed pitch tilt rotational displacement of platform (degrees)\n" +
                "0.0\tPtfmYaw     - Initial or fixed yaw rotational displacement of platform (degrees)\n");
            sw.Write("---------------------- TURBINE CONFIGURATION -----------------------------------！FAST手册17页的图" +
                sim1.WindTurbine.TurbineConfiguration.NumBl.value + "\tNumBl       - Number of blades (-)\n" +
                sim1.WindTurbine.TurbineConfiguration.TipRad.value + "\tTipRad      - The distance from the rotor apex to the blade tip (meters) ！风轮半径 （风轮半径减去轮毂半径可得到叶片长度）\n" +
                sim1.WindTurbine.TurbineConfiguration.HubRad.value + "\tHubRad      - The distance from the rotor apex to the blade root (meters)！轮毂半径\n" +
                sim1.WindTurbine.TurbineConfiguration.PreCone_1.value + "\tPreCone(1)  - Blade 1 cone angle (degrees) ！锥角（叶片与风轮旋转平面的夹角）\n" +
                sim1.WindTurbine.TurbineConfiguration.PreCone_1.value + "\tPreCone(2)  - Blade 2 cone angle (degrees)\n" +
                sim1.WindTurbine.TurbineConfiguration.PreCone_1.value + "\tPreCone(3)  - Blade 3 cone angle (degrees) [unused for 2 blades]\n" +
                sim1.WindTurbine.TurbineConfiguration.HubCM.value + "\t HubCM       - Distance from rotor apex to hub mass [positive downwind] (meters) ！轮毂质心到风轮平面与转子轴线相交的点的距离\n" +
                "0.0\tUndSling    - Undersling length [distance from teeter pin to the rotor apex] (meters) [unused for 3 blades] ！针对两叶片的\n" +
                "0.0\tDelta3      - Delta-3 angle for teetering rotors (degrees) [unused for 3 blades] ！针对两叶片的\n" +
                sim1.WindTurbine.TurbineConfiguration.AzimB1Up.value + "\tAzimB1Up    - Azimuth value to use for I/O when blade 1 points up (degrees) !所有输入和输出方位角都是针对于这个值测量的\n" +
                sim1.WindTurbine.TurbineConfiguration.OverHang.value + "\tOverHang    - Distance from yaw axis to rotor apex [3 blades] or teeter pin [2 blades] (meters) ！悬垂距离：轮毂中心点到塔架中心点（偏航位置）的距离，一般为负，轮毂的高度通过overhang，ShftTilt和主轴长度来计算\n" +
                sim1.WindTurbine.TurbineConfiguration.ShftGagL.value + "\tOverHang    - Distance from yaw axis to rotor apex [3 blades] or teeter pin [2 blades] (meters) ！悬垂距离：轮毂中心点到塔架中心点（偏航位置）的距离，一般为负，轮毂的高度通过overhang，ShftTilt和主轴长度来计算\n" +
                sim1.WindTurbine.TurbineConfiguration.ShftTilt.value + "\tShftTilt    - Rotor shaft tilt angle (degrees)！主轴的仰角，与平行于地面的面的夹角\n" +
                sim1.WindTurbine.TurbineConfiguration.NacCMxn.value + "\tNacCMxn     - Downwind distance from the tower-top to the nacelle CM (meters)！机舱质心到塔架轴线的垂直距离\n" +
                sim1.WindTurbine.TurbineConfiguration.NacCMyn.value + "\t NacCMyn     - Lateral  distance from the tower-top to the nacelle CM (meters)\n" +
                sim1.WindTurbine.TurbineConfiguration.NacCMzn.value + "\tNacCMzn     - Vertical distance from the tower-top to the nacelle CM (meters)！机舱质心到机舱底部（塔顶）距离\n" +
                "-4.985\tNcIMUxn     - Downwind distance from the tower-top to the nacelle IMU (meters)！机舱惯性测量装置到塔架轴线的垂直距离\n" +
                "0.0\tNcIMUyn     - Lateral  distance from the tower-top to the nacelle IMU (meters)\n" +
                "4.358\tNcIMUzn     - Vertical distance from the tower-top to the nacelle IMU (meters)！机舱惯性测量装置到机舱底部（塔顶）距离\n" +
                sim1.WindTurbine.TurbineConfiguration.Twr2Shft.value + "\tTwr2Shft    - Vertical distance from the tower-top to the rotor shaft (meters)！机舱中心到机舱底部（塔顶）的距离\n" +
                sim1.WindTurbine.TurbineConfiguration.TowerHt.value + "\tTowerHt     - Height of tower above ground level [onshore] or MSL [offshore] (meters)！塔顶到水平面的距离，如果是陆上，TowerHt就是塔架高度\n" +
                sim1.WindTurbine.TurbineConfiguration.TowerBsHt.value + "\tTowerBsHt   - Height of tower base above ground level [onshore] or MSL [offshore] (meters)！TowerHt减去TowerBsHt为塔架高度。如果是陆上，这里应该是0\n" +
                "0.0\tPtfmCMxt    - Downwind distance from the ground level [onshore] or MSL [offshore] to the platform CM (meters)\n" +
                "0.0\tPtfmCMyt    - Lateral distance from the ground level [onshore] or MSL [offshore] to the platform CM (meters)\n" +
                "0.0\tPtfmCMzt    - Vertical distance from the ground level [onshore] or MSL [offshore] to the platform CM (meters)\n" +
                "0.0\tPtfmRefzt   - Vertical distance from the ground level [onshore] or MSL [offshore] to the platform reference point (meters)\n");
            sw.Write("---------------------- MASS AND INERTIA ----------------------------------------\n" +
                sim1.WindTurbine.MassInfo.TipMass_1.value + "\tTipMass(1)  - Tip-brake mass, blade 1 (kg)\n" +
                sim1.WindTurbine.MassInfo.TipMass_2.value + "\tTipMass(2)  - Tip-brake mass, blade 2 (kg)\n" +
                sim1.WindTurbine.MassInfo.TipMass_3.value + "\tTipMass(3)  - Tip-brake mass, blade 3 (kg)\n" +
                sim1.WindTurbine.MassInfo.HubMass.value + "\tHubMass     - Hub mass (kg)！轮毂质量\n" +
                sim1.WindTurbine.MassInfo.HubIner.value + "\tHubIner     - Hub inertia about rotor axis [3 blades] or teeter axis [2 blades] (kg m^2)！轮毂关于转子轴的惯性矩\n" +
                sim1.WindTurbine.MassInfo.GenIner.value + "\tGenIner     - Generator inertia about HSS (kg m^2)！发电机转轴的惯性矩\n" +
                sim1.WindTurbine.MassInfo.NacMass.value + "\tNacMass     - Nacelle mass (kg)！机舱质量\n" +
                sim1.WindTurbine.MassInfo.NacYIner.value + "\t NacYIner    - Nacelle inertia about yaw axis (kg m^2)！机舱关于偏航轴的惯性矩，该值必须＞NacMass•( NacCMxn的平方 + NacCMyn的平方 )\n" +
                sim1.WindTurbine.MassInfo.YawBrMass.value + "\tYawBrMass   - Yaw bearing mass (kg)！偏航轴承质量\n" +
                sim1.WindTurbine.MassInfo.PtfmMass.value + "\tPtfmMass    - Platform mass (kg)\n" +
                "0.0\tPtfmRIner   - Platform inertia for roll tilt rotation about the platform CM (kg m^2)\n" +
                "0.0\tPtfmPIner   - Platform inertia for pitch tilt rotation about the platform CM (kg m^2)\n" +
                "13548889.3\t PtfmYIner   - Platform inertia for yaw rotation about the platform CM (kg m^2)\n");
            sw.Write("---------------------- BLADE ---------------------------------------------------\n" +
                sim1.WindTurbine.Blade.BladeModes[0].NBlInpSt.value + "\tBldNodes    - Number of blade nodes (per blade) used for analysis (-)!用来分析的叶片节点\n");
            for (int i = 0; i < 3; i++)
            {
                sw.WriteLine("\"" + sim1.SimulationControl.StructureSimulationControl.BldFile_1.value + string.Format("\"BldFile{0:D1}", i + 1) + string.Format("\t- Name of file containing properties for blade {0:D1} (quoted string)", i + 1));
            }
            sw.Write("---------------------- ROTOR-TEETER --------------------------------------------！三叶片风力机用不到\n" +
                "0\tTeetMod     - Rotor-teeter spring/damper model {0: none, 1: standard, 2: user-defined from routine UserTeet} (switch) [unused for 3 blades]\n" +
                "0.0\tTeetDmpP    - Rotor-teeter damper position (degrees) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetDmp     - Rotor-teeter damping constant (N-m/(rad/s)) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetCDmp    - Rotor-teeter rate-independent Coulomb-damping moment (N-m) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetSStP    - Rotor-teeter soft-stop position (degrees) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetHStP    - Rotor-teeter hard-stop position (degrees) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetSSSp    - Rotor-teeter soft-stop linear-spring constant (N-m/rad) [used only for 2 blades and when TeetMod=1]\n" +
                "0.0\tTeetHSSp    - Rotor-teeter hard-stop linear-spring constant (N-m/rad) [used only for 2 blades and when TeetMod=1]\n");
            sw.Write("---------------------- DRIVETRAIN ----------------------------------------------\n" +
                sim1.WindTurbine.DriveTrain.GBoxEff.value + "\tGBoxEff     - Gearbox efficiency (%)！变速箱效率=输出轴与输入轴功率的比值\n" +
                sim1.WindTurbine.DriveTrain.GBRatio.value + "\tGBRatio     - Gearbox ratio (-)！高速轴与低速轴比值，直接驱动涡轮机该值为1\n" +
                sim1.WindTurbine.DriveTrain.DTTorSpr.value + "\t DTTorSpr    - Drivetrain torsional spring (N-m/rad)！等效驱动轴扭转弹簧常数\n" +
                sim1.WindTurbine.DriveTrain.DTTorDmp.value + "\t DTTorDmp    - Drivetrain torsional damper (N-m/(rad/s))！等效驱动轴扭转阻尼常数\n" +
                "---------------------- FURLING -------------------------------------------------\n" +
                "False                  Furling     - Read in additional model properties for furling turbine (flag) [must currently be FALSE)\n" +
                "\"unused\"               FurlFile    - Name of file containing furling properties (quoted string) [unused when Furling=False]");
            sw.Write("---------------------- TOWER ---------------------------------------------------\n" +
                sim1.WindTurbine.Tower.TwrNodes.value + "\tTwrNodes    - Number of tower nodes used for analysis (-)！用来分析的塔架节点\n" +
                sim1.WindTurbine.Tower.TwrNodes.value + " TwrFile     - Name of file containing tower properties (quoted string)\n" +
                "---------------------- OUTPUT --------------------------------------------------\n" +
                sim1.Outputs.StructureDynamicOutputs.SumPrint.value + "\tSumPrint    - Print summary data to \" < RootName >.sum\" (flag)\n" +
                "1\tOutFile     - Switch to determine where output will be placed: {1: in module output file only; 2: in glue code output file only; 3: both} (currently unused)\n" +
                "True\tTabDelim    - Use tab delimiters in text tabular output file? (flag) (currently unused)\n" +
                "\"ES10.3E2\"\tOutFmt      - Format used for text tabular output (except time).  Resulting field should be 10 characters. (quoted string) (currently unused)\n" +
                "0.0\tTStart      - Time to begin tabular output (s) (currently unused)\n" +
                "1\tDecFact     - Decimation factor for tabular output {1: output every time step} (-) (currently unused)\n" +
                "1\tNTwGages    - Number of tower nodes that have strain gages for output [0 to 9] (-)！输出的塔架gNd    - List of tower nodes that have strain gages [1 to TwrNodes] (-) [unused if NTwGages=0] TwrGag的节点，最多9个\n" +
                "1 4 6 8 10 12 15 18 20   TwrGaNd    - List of tower nodes that have strain gages [1 to TwrNodes] (-) [unused if NTwGages=0]\n" +
                "9 \tNBlGages    - Number of blade nodes that have strain gages for output [0 to 9] (-)！输出的叶片的节点，最多9个\n" +
                "1 6 11 20 30 38 43 47 50    BldGagNd    - List of blade nodes that have strain gages [1 to BldNodes] (-) [unused if NBlGages=0]\n" +
                "                  OutList             - The next line(s) contains a list of output parameters.  See OutListParameters.xlsx for a listing of available output channels, (-)\n");
            sw.Write("\"BldPitch1\"\n" +
                 "\"GenSpeed\"\n" +
                "\"RotThrust\"\n" +
                "\"TipDyb1\"\n" +
                "\"RootFxb1\"\n" +
                "\"RootFzb1\"\n" +
                "\"RootMyb1\"\n" +
                "\"Spn1TDxb1\"\n" +
                "\"Spn1TDzb1\"\n" +
                "\"Spn2TDyb1\"\n" +
                "\"Spn3TDxb1\"\n" +
                "\"Spn3TDzb1\"\n" +
                "\"Spn4TDyb1\"\n" +
                "\"Spn5TDxb1\"\n" +
                "\"Spn5TDzb1\"\n" +
                "\"Spn6TDyb1\"\n" +
                "\"Spn7TDxb1\"\n" +
                "\"Spn7TDzb1\"\n" +
                "\"Spn8TDyb1\"\n" +
                "\"Spn9TDxb1\"\n" +
                "\"Spn9TDzb1\"\n" +
                "\"YawBrTDyp\"\n" +
                "\"YawBrTDxt\"\n" +
                "\"YawBrTDzt\"\n" +
                "\"TwHt1TDyt\"\n" +
                "\"TwHt2TDxt\"\n" +
                "\"TwHt2TDzt\"\n" +
                "\"TwHt3TDyt\"\n" +
                "\"TwHt4TDxt\"\n" +
                "\"TwHt4TDzt\"\n" +
                "\"TwHt5TDyt\"\n" +
                "\"TwHt6TDxt\"\n" +
                "\"TwHt6TDzt\"\n" +
                "\"TwHt7TDyt\"\n" +
                "\"TwHt8TDxt\"\n" +
                "\"TwHt8TDzt\"\n" +
                "\"TwHt9TDyt\"\n" +
                "\"Spn1MLxb1\"\n" +
                "\"Spn1MLzb1\"\n" +
                "\"Spn2MLyb1\"\n" +
                "\"Spn3MLxb1\"\n" +
                "\"Spn3MLzb1\"\n" +
                "\"Spn4MLyb1\"\n" +
                "\"Spn5MLxb1\"\n" +
                "\"Spn5MLzb1\"\n" +
                "\"Spn6MLyb1\"\n" +
                "\"Spn7MLxb1\"\n" +
                "\"Spn7MLzb1\"\n" +
                "\"Spn8MLyb1\"\n" +
                "\"Spn9MLxb1\"\n" +
                "\"Spn9MLzb1\"\n" +
                "\"Spn1FLyb1\"\n" +
                "\"Spn2FLxb1\"\n" +
                "\"Spn2FLzb1\"\n" +
                "\"Spn3FLyb1\"\n" +
                "\"Spn4FLxb1\"\n" +
                "\"Spn4FLzb1\"\n" +
                "\"Spn5FLyb1\"\n" +
                "\"Spn6FLxb1\"\n" +
                "\"Spn6FLzb1\"\n" +
                "\"Spn7FLyb1\"\n" +
                "\"Spn8FLxb1\"\n" +
                "\"Spn8FLzb1\"\n" +
                "\"Spn9FLyb1\"\n" +
                "\"TwrBsFxt\"\n" +
                "\"TwrBsFzt\"\n" +
                "\"TwrBsMyt\"\n" +
                "\"TwHt1MLxt\"\n" +
                "\"TwHt1MLzt\"\n" +
                "\"TwHt2MLyt\"\n" +
                "\"TwHt3MLxt\"\n" +
                "\"TwHt3MLzt\"\n" +
                "\"TwHt4MLyt\"\n" +
                "\"TwHt5MLxt\"\n" +
                "\"TwHt5MLzt\"\n" +
                "\"TwHt6MLyt\"\n" +
                "\"TwHt7MLxt\"\n" +
                "\"TwHt7MLzt\"\n" +
                "\"TwHt8MLyt\"\n" +
                "\"TwHt9MLxt\"\n" +
                "\"TwHt9MLzt\"\n" +
                "\"TwHt1FLyt\"\n" +
                "\"TwHt2FLxt\"\n" +
                "\"TwHt2FLzt\"\n" +
                "\"TwHt3FLyt\"\n" +
                "\"TwHt4FLxt\"\n" +
                "\"TwHt4FLzt\"\n" +
                "\"TwHt5FLyt\"\n" +
                "\"TwHt6FLxt\"\n" +
                "\"TwHt6FLzt\"\n" +
                "\"TwHt7FLyt\"\n" +
                "\"TwHt8FLxt\"\n" +
                "\"TwHt8FLzt\"\n" +
                "\"TwHt9FLyt\"\n" +
                "END of input file (the word \"END\" must appear in the first 3 columns of this last OutList line)\n" +
                "---------------------------------------------------------------------------------------");
            sw.Close();
            fs.Close();
        }
        public void Write_IEA_15_240_ElastoDyn_tower()
        {
            FileStream fs = new FileStream(workDir1 + @"\IEA-15-240-RWT-Monopile_ElastoDyn_tower.dat", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            const string head = "------- ELASTODYN V1.00.* TOWER INPUT FILE -------------------------------------\n" +
            "IEA 15 MW offshore reference model monopile configuration\n";
            sw.Write(head);
            sw.Write("---------------------- TOWER PARAMETERS ----------------------------------------\n" +
                sim1.WindTurbine.Tower.towerModes[0].NTwInpSt.value + "\tNTwInpSt    - Number of input stations to specify tower geometry！输入的塔架节点的数量\n" +
                sim1.WindTurbine.Tower.towerModes[0].dampings[0].value + "\tTwrFADmp(1) - Tower 1st fore-aft mode structural damping ratio (%)！塔架一阶前后模态结构阻尼参数\n" +
                sim1.WindTurbine.Tower.towerModes[0].dampings[1].value + "\tTwrFADmp(2) - Tower 2nd fore-aft mode structural damping ratio (%)！塔架二阶前后模态结构阻尼参数\n" +
                sim1.WindTurbine.Tower.towerModes[0].dampings[2].value + "\t TwrSSDmp(1) - Tower 1st side-to-side mode structural damping ratio (%)！塔架一阶左右模态结构阻尼参数\n" +
                sim1.WindTurbine.Tower.towerModes[0].dampings[3].value + "\t TwrSSDmp(2) - Tower 2nd side-to-side mode structural damping ratio (%)！塔架二阶左右模态结构阻尼参数\n" +
                "---------------------- TOWER ADJUSTMUNT FACTORS --------------------------------！可参考ED_blade输入文件\n" +
                sim1.WindTurbine.Tower.towerModes[0].Tunr[0].value + "\tFAStTunr(1) - Tower fore-aft modal stiffness tuner, 1st mode (-)\n" +
                sim1.WindTurbine.Tower.towerModes[0].Tunr[1].value + "\tFAStTunr(2) - Tower fore-aft modal stiffness tuner, 2nd mode (-)\n" +
                sim1.WindTurbine.Tower.towerModes[0].Tunr[2].value + "\tSSStTunr(1) - Tower side-to-side stiffness tuner, 1st mode (-)\n" +
                sim1.WindTurbine.Tower.towerModes[0].Tunr[3].value + "\tSSStTunr(2) - Tower side-to-side stiffness tuner, 2nd mode (-)\n" +
                "1.0\tAdjTwMa     - Factor to adjust tower mass density (-)\n" +
                "1.0\tAdjFASt     - Factor to adjust tower fore-aft stiffness (-)\n" +
                "1.0\tAdjSSSt     - Factor to adjust tower side-to-side stiffness (-)\n");
            
            sw.Write("---------------------- DISTRIBUTED TOWER PROPERTIES ----------------------------！可参考ED_blade输入文件，一般塔架挥舞，摆振刚度相同，因为对称结构\n" +
                "      HtFract\t TMassDe\t TwFAStif\t TwSSStif\n" +
                "      (-)\t (kg/m)\t (Nm^2)\t (Nm^2)\n");
            for (int i = 0; i < sim1.WindTurbine.Tower.towerModes[0].NTwInpSt.value; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerStation[i].HtFract.value + "\t " + sim1.WindTurbine.Tower.towerStation[i].TMassDen.value + "\t " + sim1.WindTurbine.Tower.towerStation[i].TwFAStif.value + "\t " + sim1.WindTurbine.Tower.towerStation[i].TwSSStif.value);
            }
            sw.Write("---------------------- TOWER FORE-AFT MODE SHAPES ------------------------------！可参考ED_blade输入文件，一阶前后应该是Bmodes算出第二阶模态，二阶前后应该是bmodes算出第四阶模态\n");
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerModes[0].Factor_Deflection_x1[i].value + string.Format("\tTwFAM1Sh({0:D1}) - Mode 1, coefficient of x^{1:D1} term", i + 2, i + 2));
            }
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerModes[0].Factor_Deflection_x2[i].value + string.Format("\tTwFAM2Sh({0:D1}) - Mode 2, coefficient of x^{1:D1} term", i + 2, i + 2));
            }
            sw.WriteLine("---------------------- TOWER SIDE-TO-SIDE MODE SHAPES --------------------------！一阶side to side应该是Bmodes算出的第一阶模态，二阶side to side应该是bmodes算出第五阶模态");
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerModes[0].Factor_Deflection_y1[i].value + string.Format("\tTwSSM1Sh({0:D1}) - Mode 1, coefficient of x^{1:D1} term", i + 2, i + 2));

            }
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerModes[0].Factor_Deflection_y2[i].value + string.Format("\tTwSSM2Sh({0:D1}) - Mode 2, coefficient of x^{1:D1} term", i + 2, i + 2));

            }
            sw.Close();
            fs.Close();
        }
        public void Write_IEA_15_240_AeroDyn_Polar(int air_Index)
        {
            FileStream fs = new FileStream(string.Format(workDir2 + @"\Airfoils\IEA-15-240-RWT_AeroDyn15_Polar_{0:D2}.dat", air_Index),FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            const string head = "!------------AirfoilInfo v1.01.x Input File ----------------------------------\n" +
                "!AeroElasticSE FAST driver\n" +
                "!line\n" +
                "! line\n" +
                "!------------------------------------------------------------------------------\n";
            sw.Write(head);
            sw.Write(sim1.Airfoil[air_Index].InterpOrd.value + "\t InterpOrd   ! Interpolation order to use for quasi-steady table lookup {1=linear; 3=cubic spline; \"default\"} [default=3]！\n");
            sw.Write(sim1.Airfoil[air_Index].AirfoilBasicSetting.NonDimArea.value + "\tNonDimArea  ! The non-dimensional area of the airfoil (area/chord^2) (set to 1.0 if unsure or unneeded)！这个现在还用不到\n" +
                "@\""+ sim1.Airfoil[air_Index].AirfoilBasicSetting.NumCoords.value + "\"" + "\tNumCoords   !\n"+
                sim1.Airfoil[air_Index].AirfoilBasicSetting.BL_file.value + "\tBL_file     ! The file name including the boundary layer characteristics of the profile. Ignored if the aeroacoustic module is not called.\n"+
                sim1.Airfoil[air_Index].AirfoilBasicSetting.NumTabs.value + "\t NumTabs     ! Number of airfoil tables in this file.  Each table must have lines for Re and Ctrl.！定义了几个雷诺数，不同雷诺数下翼型升阻力系数不一样\n"+
                "! ------------------------------------------------------------------------------\n" +
                "! data for table 1\n" +
                "!------------------------------------------------------------------------------\n");
            sw.Write(sim1.Airfoil[air_Index].AirfoilBasicSetting.Re.value + "\t Re          ! Reynolds number in millions！雷诺数（百万级）\n"+
                sim1.Airfoil[air_Index].AirfoilBasicSetting.UserProp.value + "\t UserProp    ! User property (control) setting\n"+
                sim1.Airfoil[air_Index].AirfoilBasicSetting.InclUAdata.value + "\t InclUAdata  ! Is unsteady aerodynamics data included in this table? If TRUE, then include 30 UA coefficients below this line\n" +
                "!........................................\n"+
                sim1.Airfoil[air_Index].AirfoilDataInfo.alpha0.value + "\t alpha0      ! 0-lift angle of attack, depends on airfoil.！0升力攻角\n"+
                sim1.Airfoil[air_Index].AirfoilDataInfo.alpha1.value+ "\talpha1      ! Angle of attack at f=0.7, (approximately the stall angle) for AOA>alpha0. (deg)\n"+
                sim1.Airfoil[air_Index].AirfoilDataInfo.alpha2.value+ "\talpha2      ! Angle of attack at f=0.7, (approximately the stall angle) for AOA<alpha0. (deg)\n"+
                sim1.Airfoil[air_Index].AirfoilDataInfo.eta_e.value+"\teta_e       ! Recovery factor in the range [0.85 - 0.95] used only for UAMOD=1, it is set to 1 in the code when flookup=True. (-)！修正系数\n"+
                sim1.Airfoil[air_Index].AirfoilDataInfo.C_nalpha.value + "\t C_nalpha    ! Slope of the 2D normal force coefficient curve. (1/rad)！线性区域中2D法向力系数曲线的斜率\n" +
                "3                  T_f0        ! Initial value of the time constant associated with Df in the expression of Df and f. [default = 3]\n" +
                "6                  T_V0        ! Initial value of the time constant associated with the vortex lift decay process; it is used in the expression of Cvn. It depends on Re,M, and airfoil class. [default = 6]\n" +
                "1.7                  T_p         ! Boundary-layer,leading edge pressure gradient time constant in the expression of Dp. It should be tuned based on airfoil experimental data. [default = 1.7]\n" +
                "11                  T_VL        ! Initial value of the time constant associated with the vortex advection process; it represents the non-dimensional time in semi-chords, needed for a vortex to travel from LE to trailing edge (TE); it is used in the expression of Cvn. It depends on Re, M (weakly), and airfoil. [valid range = 6 - 13, default = 11]\n" +
                "0.14                  b1          ! Constant in the expression of phi_alpha^c and phi_q^c.  This value is relatively insensitive for thin airfoils, but may be different for turbine airfoils. [from experimental results, defaults to 0.14]\n" +
                "0.53                  b2          ! Constant in the expression of phi_alpha^c and phi_q^c.  This value is relatively insensitive for thin airfoils, but may be different for turbine airfoils. [from experimental results, defaults to 0.53]\n" +
                "5                  b5          ! Constant in the expression of K'''_q,Cm_q^nc, and k_m,q.  [from  experimental results, defaults to 5]\n" +
                "0.3                  A1          ! Constant in the expression of phi_alpha^c and phi_q^c.  This value is relatively insensitive for thin airfoils, but may be different for turbine airfoils. [from experimental results, defaults to 0.3]\n" +
                "0.7                  A2          ! Constant in the expression of phi_alpha^c and phi_q^c.  This value is relatively insensitive for thin airfoils, but may be different for turbine airfoils. [from experimental results, defaults to 0.7]\n" +
                "1                  A5          ! Constant in the expression of K'''_q,Cm_q^nc, and k_m,q. [from experimental results, defaults to 1]\n" +
                "0.000000   S1          ! Constant in the f curve best-fit for alpha0<=AOA<=alpha1; by definition it depends on the airfoil. [ignored if UAMod<>1]\n" +
                "0.000000   S2          ! Constant in the f curve best-fit for         AOA> alpha1; by definition it depends on the airfoil. [ignored if UAMod<>1]\n" +
                "0.000000   S3          ! Constant in the f curve best-fit for alpha2<=AOA< alpha0; by definition it depends on the airfoil. [ignored if UAMod<>1]\n" +
                " 0.000000   S4          ! Constant in the f curve best-fit for         AOA< alpha2; by definition it depends on the airfoil. [ignored if UAMod<>1]\n" +
                "0.000000   Cn1         ! Critical value of C0n at leading edge separation. It should be extracted from airfoil data at a given Mach and Reynolds number. It can be calculated from the static value of Cn at either the break in the pitching moment or the loss of chord force at the onset of stall. It is close to the condition of maximum lift of the airfoil at low Mach numbers.\n" +
                "0.000000   Cn2         ! As Cn1 for negative AOAs.\n" +
                "0.19                  St_sh       ! Strouhal's shedding frequency constant.  [default = 0.19]\n" +
                "0.350000   Cd0         ! 2D drag coefficient value at 0-lift.\n" +
                "-0.000100   Cm0         ! 2D pitching moment coefficient about 1/4-chord location, at 0-lift, positive if nose up. [If the aerodynamics coefficients table does not include a column for Cm, this needs to be set to 0.0]\n" +
                "0.000000   k0          ! Constant in the \\hat(x)_cp curve best-fit; = (\\hat(x)_AC-0.25).  [ignored if UAMod<>1]\n" +
                "0.000000   k1          ! Constant in the \\hat(x)_cp curve best-fit.  [ignored if UAMod<>1]\n" +
                "0.000000   k2          ! Constant in the \\hat(x)_cp curve best-fit.  [ignored if UAMod<>1]\n"+
                "0.000000   k3          ! Constant in the \\hat(x)_cp curve best-fit.  [ignored if UAMod<>1]\n" +
                "0.000000   k1_hat      ! Constant in the expression of Cc due to leading edge vortex effects.  [ignored if UAMod<>1]\n" +
                "0.2                  x_cp_bar    ! Constant in the expression of \\hat(x)_cp^v. [ignored if UAMod<>1, default = 0.2]\n" +
                "45                   UACutout    ! Angle of attack above which unsteady aerodynamics are disabled (deg). [Specifying the string \"Default\" sets UACutout to 45 degrees]\n" +
                "20                   filtCutOff  ! Cut-off frequency (-3 dB corner frequency) for low-pass filtering the AoA input to UA, as well as the 1st and 2nd derivatives (Hz) [default = 20]\n" +
                "!........................................\n" +
                "! Table of aerodynamics coefficients\n" +
                sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance[air_Index].NumAlf.value+"\tNumAlf      ! Number of data lines in the following table\n" +
                "!    Alpha      Cl      Cd        Cm\n" +
                "!    (deg)      (-)     (-)       (-)\n");
            for (int i = 0; i < sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance.Count; i++)
            {
                sw.WriteLine(sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance[air_Index].Alpha[i].value +" "+ sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance[air_Index].Cl[i].value + " "+ sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance[air_Index].Cd[i].value + " "+sim1.Airfoil[air_Index].Airfoilfile.AirfoilPerformance[air_Index].Cm[i].value);
            }
            sw.Close();
            fs.Close();

        }

        public void Write_IEA_15_240_AeroDyn15()
        {
            FileStream fs = new FileStream(workDir2 + @"\IEA-15-240-RWT_AeroDyn15.dat", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            const string head = "------- AERODYN v15.03.* INPUT FILE ------------------------------------------------\n" +
            "IEA 15 MW Offshore Reference Turbine\n";
            sw.Write(head);
            sw.Write("======  General Options  ============================================================================\n" +
                sim1.SimulationControl.AerodynamicControl.Echo.value + "\tEcho        - Echo the input to \" < rootname >.AD.ech\"?  (flag)\n" +
                sim1.SimulationControl.BasicControl.DT.value + "\t DTAero      - Time interval for aerodynamic calculations {or \"default\"} (s)！气动计算的时间步长，设置成default表示遵从FAST规定的时间步长\n" +
                "1 \t WakeMod     - Type of wake/induction model (switch) {0=none, 1=BEMT}！指定尾流模型\n" +
                "2\t AFAeroMod   - Type of blade airfoil aerodynamics model (switch) {1=steady model, 2=Beddoes-Leishman unsteady model} [must be 1 when linearizing]\n" +
                "1\t TwrPotent   - Type tower influence on wind based on potential flow around the tower (switch) {0=none, 1=baseline potential flow, 2=potential flow with Bak correction}\n" +
                "False\t TwrShadow   - Calculate tower influence on wind based on downstream tower shadow? (flag)！塔影效应，针对上风向（风先经过塔架，再经过风轮会发生一个扩张）\n" +
                "False\tTwrAero     - Calculate tower aerodynamic loads? (flag)\n" +
                "False \tFrozenWake  - Assume frozen wake during linearization? (flag) [used only when WakeMod=1 and when linearizing]\n" +
                "False\tCavitCheck  - Perform cavitation check? (flag) TRUE will turn off unsteady aerodynamics\n" +
                "False\tCavitCheck  - Perform cavitation check? (flag) TRUE will turn off unsteady aerodynamics\n" +
                "False\tCompAA      - Flag to compute AeroAcoustics calculation [only used when WakeMod=1 or 2]\n" +
                "\"" + sim1.SimulationControl.AerodynamicControl.AA_InputFile.value + "\"" + "\tAA_InputFile - Aeroacoustics input file\n");
            sw.Write("======  Environmental Conditions  ===================================================================\n" +
                sim1.Environment.EnvironmentalConditions.AirDens.value + "\tAirDen- Air density (kg/m^3)！空气密度\n" +
                sim1.Environment.EnvironmentalConditions.KinVisc.value + "\tKinVisc     - Kinematic air viscosity (m^2/s)！动力粘度\n" +
                "3.350000000000000e+02 SpdSound    - Speed of sound (m/s)！声速\n" +
                "1.035000000000000e+05 Patm        - Atmospheric pressure (Pa) [used only when CavitCheck=True]！大气压强\n" +
                "1.700000000000000e+03 Pvap        - Vapour pressure of fluid (Pa) [used only when CavitCheck=True]！流体蒸汽压\n" +
                sim1.Environment.EnvironmentalConditions.FluidDepth.value + "\t FluidDepth  - Water depth above mid-hub height (m) [used only when CavitCheck=True]！轮毂中部高度以上的水深\n");
            sw.Write("======  Blade-Element/Momentum Theory Options  ====================================================== [used only when WakeMod=1]！准静态过程\n" +
                sim1.SimulationControl.AerodynamicControl.BEM_Options.SkewMod.value + "\t SkewMod     - Type of skewed-wake correction model (switch) {1=uncoupled, 2=Pitt/Peters, 3=coupled} [used only when WakeMod=1]\n" +
                "15/32*pi              SkewModFactor - Constant used in Pitt/Peters skewed wake model {or \"default\" is 15/32*pi} (-) [used only when SkewMod=2; unused when WakeMod=0]\n" +
                "True                   TipLoss     - Use the Prandtl tip-loss model? (flag) [used only when WakeMod=1]\n" +
                "True                   HubLoss     - Use the Prandtl hub-loss model? (flag) [used only when WakeMod=1]\n" +
                "True                   TanInd      - Include tangential induction in BEMT calculations? (flag) [used only when WakeMod=1]\n" +
                "True                   AIDrag      - Include the drag term in the axial-induction calculation? (flag) [used only when WakeMod=1]！轴向诱导计算中包含阻力项\n" +
                "True                   TIDrag      - Include the drag term in the tangential-induction calculation? (flag) [used only when WakeMod=1 and TanInd=TRUE]！切向诱导计算中包含阻力项\n" +
                "5E-10              IndToler    - Convergence tolerance for BEMT nonlinear solve residual equation {or \"default\"} (-) [used only when WakeMod=1]!BEMT非线性求解残差方程的收敛容差\n" +
                "500                    MaxIter     - Maximum number of iteration steps (-) [used only when WakeMod=1]！BEM求解中迭代步骤的最大数\n");
            sw.Write("======  Dynamic Blade-Element/Momentum Theory Options  ====================================================== [used only when WakeMod=1]\n" +
                "2\tDBEMT_Mod   - Type of dynamic BEMT (DBEMT) model {1=constant tau1, 2=time-dependent tau1} (-) [used only when WakeMod=2]\n" +
                "2\ttau1_const  - Time constant for DBEMT (s) [used only when WakeMod=2 and DBEMT_Mod=1]\n" +
                "======  OLAF -- cOnvecting LAgrangian Filaments (Free Vortex Wake) Theory Options  ================== [used only when WakeMod=3]\n" +
                "\"unused\"               OLAFInputFileName - Input file for OLAF [used only when WakeMod=3]\n" +
                "======  Beddoes-Leishman Unsteady Airfoil Aerodynamics Options  ===================================== [used only when AFAeroMod=2]！半经验动态失速模型\n" +
                sim1.SimulationControl.AerodynamicControl.DynamicStall.UAMod.value + "\t Unsteady Aero Model Switch (switch) {1=Baseline model (Original), 2=Gonzalez's variant (changes in Cn,Cc,Cm), 3=Minemma/Pierce variant (changes in Cc and Cm)} [used only when AFAeroMod=2]\n" +
                sim1.SimulationControl.AerodynamicControl.DynamicStall.Flookup.value + "\t FLookup     Flag to indicate whether a lookup for f' will be calculated (TRUE) or whether best-fit exponential equations will be used (FALSE); if FALSE S1-S4 must be provided in airfoil input files (flag) [used only when AFAeroMod=2]\n");
            sw.Write("======  Airfoil Information =========================================================================\n" +
                sim1.Airfoil[0].Airfoilfile.AFTabMod.value + "\tAFTabMod\t- Interpolation method for multiple airfoil tables {1=1D interpolation on AoA (first table only); 2=2D interpolation on AoA and Re; 3=2D interpolation on AoA and UserProp} (-)！设置为1只使用每个文件中的第一个翼型表\n" +
                "1\tInCol_Alfa  - The column in the airfoil tables that contains the angle of attack (-) ！表示翼型表中攻角是第一列\n" +
                "2\tInCol_Cl    - The column in the airfoil tables that contains the lift coefficient (-)！表示翼型表中cl是第二列\n" +
                "3\tInCol_Cd    - The column in the airfoil tables that contains the drag coefficient (-)！表示翼型表中cd是第三列\n" +
                "4\tInCol_Cm    - The column in the airfoil tables that contains the pitching-moment coefficient; use zero if there is no Cm column (-)！表示翼型表中cm是第四列\n" +
                "0\tInCol_Cpmin - The column in the airfoil tables that contains the Cpmin coefficient; use zero if there is no Cpmin column (-)！设置为0表示翼型表中无Cpmin\n" +
                sim1.Airfoil[0].Airfoilfile.NumAFfiles.value + "\tNumAFfiles  - Number of airfoil files used (-)！翼型文件数量\n");
            for (int i = 0; i < sim1.Airfoil[0].Airfoilfile.NumAFfiles.value; i++)
            {
                sw.WriteLine(string.Format("\"Airfoils/IEA-15-240-RWT_AeroDyn15_Polar_{0,D2}.dat",i) + "\"");
            }
            sw.Write("======  Rotor/Blade Properties  =====================================================================\n" +
                sim1.SimulationControl.AerodynamicControl.UseBlCm.value + "\t UseBlCm     - Include aerodynamic pitching moment in calculations?  (flag)\n");
            for (int i = 0; i < 3; i++)
            {
                if (sim1.WindTurbine.TurbineConfiguration.NumBl.value < i + 1)
                {
                    sw.WriteLine("\"unused\"" + string.Format("\tADBlFile({0:D1}) -Name of file containing distributed aerodynamic properties for Blade #{0:D1} (-)", i + 1, i + 1));
                }
                else sw.WriteLine("\"" + sim1.SimulationControl.AerodynamicControl.ADBlFile_1.value + "\"" + string.Format("\tADBlFile({0:D1}) - Name of file containing distributed aerodynamic properties for Blade #{0:D1} (-)", i + 1, i + 1));
            }
            sw.Write("======  Tower Influence and Aerodynamics ============================================================= [used only when TwrPotent/=0, TwrShadow=True, or TwrAero=True]\n" +
                sim1.WindTurbine.Tower.towerModes[0].NTwInpSt.value + "\tNumTwrNds   - Number of tower nodes used in the analysis  (-) [used only when TwrPotent/=0, TwrShadow=True, or TwrAero=True]！用来分析的塔筒节点数量\n" +
                "TwrElev\t TwrDiam\t TwrCd \t！TwrElev：塔架节点高出地面多高 TwrDiam：局部塔素的直径 TwrCd:局部塔的阻力系数\n" +
                "(m)\t (m)\t (-)");
            for (int i = 0; i < sim1.WindTurbine.Tower.towerStation.Count; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Tower.towerStation[i].TwrElev.value + "\t " + sim1.WindTurbine.Tower.towerStation[i].TwrDiam.value+ "\t " + sim1.WindTurbine.Tower.towerStation[i].TwrCd.value);
            }
            sw.Write("======  Tower Influence and Aerodynamics ============================================================= [used only when TwrPotent/=0, TwrShadow=True, or TwrAero=True]\n" +
                sim1.Outputs.AerodynamicOutputs.SumPrint.value + "\t SumPrint    - Generate a summary file listing input options and interpolated properties to \" < rootname >.AD.sum\"?  (flag)\n" +
                sim1.Outputs.AerodynamicOutputs.NBlOuts.value + "\tNBlOuts     - Number of blade node outputs [0 - 9] (-) ！输出的叶片节点，最多九个，可指定特定位置\n");
            for (int i = 0; i < sim1.Outputs.AerodynamicOutputs.NBlOuts.value; i++)
            {
                sw.Write(sim1.Outputs.AerodynamicOutputs.BlOutNd[i].value + ",");
            }
            sw.Write("\tBlOutNd     - Blade nodes whose values will be output  (-)！具体点的位置，这几个数对应的是ED_bladed中定义的节点数\n" +
                sim1.Outputs.AerodynamicOutputs.NTwOuts.value + "\tNTwOuts     - Number of tower node outputs [0 - 9]  (-)！塔筒同理叶片\n");
            for (int i = 0; i < sim1.Outputs.AerodynamicOutputs.NTwOuts.value; i++)
            {
                sw.Write(sim1.Outputs.AerodynamicOutputs.TwOutNd[i].value + ",");
            }
            sw.Write("\tTwOutNd     - Tower nodes whose values will be output  (-)\n" +
                "OutList             - The next line(s) contains a list of output parameters.  See OutListParameters.xlsx for a listing of available output channels, (-)\n");
            sw.Write("\"RtAeroCp\"\n" +
                "\"RtTSR\"\n" +
                "\"RtAeroFxh\"\n" +
                "\"RtAeroFzh\"\n" +
                "\"RtAeroMyh\"\n" +
                "\"TwN1Re\"\n" +
                "\"TwN3Re\"\n" +
                "\"TwN5Re\"\n" +
                "\"TwN7Re\"\n" +
                "\"TwN9Re\"\n" +
                "\"TwN2M\"\n" +
                "\"TwN4M\"\n" +
                "\"TwN6M\"\n" +
                "\"TwN8M\"\n" +
                "\"B1N1Re\"\n" +
                "\"B1N3Re\"\n" +
                "\"B1N5Re\"\n" +
                "\"B1N7Re\"\n" +
                "\"B1N9Re\"\n" +
                "\"B1N2M\"\n" +
                "\"B1N4M\"\n" +
                "\"B1N6M\"\n" +
                "\"B1N8M\"\n" +
                "\"B1N1Alpha\"\n" +
                "\"B1N3Alpha\"\n" +
                "\"B1N5Alpha\"\n" +
                "\"B1N7Alpha\"\n" +
                "\"B1N9Alpha\"\n" +
                "\"B1N2Phi\"\n" +
                "\"B1N4Phi\"\n" +
                "\"B1N6Phi\"\n" +
                "\"B1N8Phi\"\n" +
                "\"B1N1Cl\"\n" +
                "\"B1N3Cl\"\n" +
                "\"B1N5Cl\"\n" +
                "\"B1N7Cl\"\n" +
                "\"B1N9Cl\"\n" +
                "\"B1N2Cd\"\n" +
                "\"B1N4Cd\"\n" +
                "\"B1N6Cd\"\n" +
                "\"B1N8Cd\"\n" +
                "\"B1N1Cm\"\n" +
                "\"B1N3Cm\"\n" +
                "\"B1N5Cm\"\n" +
                "\"B1N7Cm\"\n" +
                "\"B1N9Cm\"\n" +
                "\"B1N2Fl\"\n" +
                "\"B1N4Fl\"\n" +
                "\"B1N6Fl\"\n" +
                "\"B1N8Fl\"\n" +
                "\"B1N1Fd\"\n" +
                "\"B1N3Fd\"\n" +
                "\"B1N5Fd\"\n" +
                "\"B1N7Fd\"\n" +
                "\"B1N9Fd\"\n" +
                "\"B1N2Mm\"\n" +
                "\"B1N4Mm\"\n" +
                "\"B1N6Mm\"\n" +
                "\"B1N8Mm\"\n" +
                "\"B1N1Clrnc\"\n" +
                "\"B1N3Clrnc\"\n" +
                "\"B1N5Clrnc\"\n" +
                "\"B1N7Clrnc\"\n" +
                "\"B1N9Clrn\"\n" +
                "END of input file (the word \"END\" must appear in the first 3 columns of this last OutList line)\n" +
                "--------------------------------------------------------------------------------------- ");
            sw.Close();
            fs.Close();
        }
        public void Write_IEA_15_240_ServoDyn()
        {
            StreamWriter sw = new StreamWriter(workDir1 + @"\IEA-15-240-RWT-Monopile_ServoDyn.dat", false, Encoding.UTF8);/*创建fst文件，实参修改路径*/
            const string head = "------- SERVODYN v1.05.* INPUT FILE --------------------------------------------\n" +
            "IEA 15 MW offshore reference model monopile configuration\n";
            sw.Write(head);
            sw.Write("---------------------- SIMULATION CONTROL --------------------------------------\n" +
                sim1.WindTurbine.Control.Echo.value + "\t Echo        - Echo input data to <RootName>.ech (flag)\n" +
                "\"default\" \tDT          - Communication interval for controllers (s) (or \"default\")" +
                "---------------------- PITCH CONTROL -------------------------------------------\n" +
                sim1.WindTurbine.Control.pitchControl.PCMode.value + "\tPCMode      - Pitch control mode {0: none, 3: user-defined from routine PitchCntrl, 4: user-defined from Simulink/Labview, 5: user-defined from Bladed-style DLL} (switch)！桨距角的控制模式，一般是5\n" +
                sim1.WindTurbine.Control.pitchControl.TPCOn.value + "\tTPCOn       - Time to enable active pitch control (s) [unused when PCMode=0]\n" +
                sim1.WindTurbine.Control.pitchControl.TPitManS_1[0].value + "\t  TPitManS(1) - Time to start override pitch maneuver for blade 1 and end standard pitch control (s)！以下这几行都是强制变桨，一般用不到，除非是停机工况和紧急停机工况，停机工况要保持叶片顺桨（桨距角维持到90度），并且设置为0s，一旦设置之后无论外界控制器怎么设定，都是遵从这里的设定\n" +
                sim1.WindTurbine.Control.pitchControl.TPitManS_1[1].value + "\tTPitManS(2) - Time to start override pitch maneuver for blade 2 and end standard pitch control (s)！\n" +
                sim1.WindTurbine.Control.pitchControl.TPitManS_1[2].value + "\t TPitManS(3)\n" +
                sim1.WindTurbine.Control.pitchControl.PitManRat_1[0].value + "\tPitManRat(1) - Pitch rate at which override pitch maneuver heads toward final pitch angle for blade 1 (deg/s)！变桨的速度是多少，一般是8到10\n" +
                sim1.WindTurbine.Control.pitchControl.PitManRat_1[1].value + "\tPitManRat(2) - Pitch rate at which override pitch maneuver heads toward final pitch angle for blade 2 (deg/s)\n" +
                sim1.WindTurbine.Control.pitchControl.PitManRat_1[2].value + "\tPitManRat(3) - Pitch rate at which override pitch maneuver heads toward final pitch angle for blade 3 (deg/s) [unused for 2 blades]\n" +
                sim1.WindTurbine.Control.pitchControl.BlPitchF_1[0].value + "\tBlPitchF(1) - Blade 1 final pitch for pitch maneuvers (degrees)！\n" +
                sim1.WindTurbine.Control.pitchControl.BlPitchF_1[1].value + "\tBlPitchF(2) - Blade 2 final pitch for pitch maneuvers (degrees)\n" +
                sim1.WindTurbine.Control.pitchControl.BlPitchF_1[2].value + "\tBlPitchF(3) - Blade 3 final pitch for pitch maneuvers (degrees) [unused for 2 blades]\n");
            sw.Write("---------------------- GENERATOR AND TORQUE CONTROL ----------------------------\n" +
                sim1.WindTurbine.Control.TorqueControl.VSContrl.value + "\tVSContrl    - Variable-speed control mode {0: none, 1: simple VS, 3: user-defined from routine UserVSCont, 4: user-defined from Simulink/Labview, 5: user-defined from Bladed-style DLL} (switch)！一般是5\n" +
                sim1.WindTurbine.Control.TorqueControl.GenModel.value + "\tGenModel    - Generator model {1: simple, 2: Thevenin, 3: user-defined from routine UserGen} (switch) [used only when VSContrl=0]\n" +
                sim1.WindTurbine.Control.TorqueControl.GenEff.value + "\t GenEff      - Generator efficiency [ignored by the Thevenin and user-defined generator models] (%)\n" +
                sim1.WindTurbine.Control.TorqueControl.GenTiStr.value + "\t GenTiStr    - Method to start the generator {T: timed using TimGenOn, F: generator speed using SpdGenOn} (flag)\n" +
                sim1.WindTurbine.Control.TorqueControl.GenTiStp.value + "\t GenTiStp    - Method to stop the generator {T: timed using TimGenOf, F: when generator power = 0} (flag)\n" +
                sim1.WindTurbine.Control.TorqueControl.SpdGenOn.value + "\t  SpdGenOn    - Generator speed to turn on the generator for a startup (HSS speed) (rpm) [used only when GenTiStr=False]\n" +
                sim1.WindTurbine.Control.TorqueControl.TimGenOn.value + "\t TimGenOn    - Time to turn on the generator for a startup (s) [used only when GenTiStr=True]！什么时候打开发电机，如果是停机工况，就设置的很大\n" +
                sim1.WindTurbine.Control.TorqueControl.TimGenOf.value + "\t TimGenOf    - Time to turn off the generator (s) [used only when GenTiStp=True]！\n");
            sw.Write("---------------------- SIMPLE VARIABLE-SPEED TORQUE CONTROL --------------------！简单变桨需要用到，一般用不到\n" +
                sim1.WindTurbine.Control.SimpleTorqueControl.VS_RtGnSp.value + "\tVS_RtGnSp   - Rated generator speed for simple variable-speed generator control (HSS side) (rpm) [used only when VSContrl=1]\n" +
                sim1.WindTurbine.Control.SimpleTorqueControl.VS_RtTq.value + "\tVS_RtTq     - Rated generator torque/constant generator torque in Region 3 for simple variable-speed generator control (HSS side) (N-m) [used only when VSContrl=1]\n" +
                sim1.WindTurbine.Control.SimpleTorqueControl.VS_Rgn2K.value + "\t VS_Rgn2K    - Generator torque constant in Region 2 for simple variable-speed generator control (HSS side) (N-m/rpm^2) [used only when VSContrl=1]\n" +
                sim1.WindTurbine.Control.SimpleTorqueControl.VS_SlPc.value + "\tVS_SlPc     - Rated generator slip percentage in Region 2 1/2 for simple variable-speed generator control (%) [used only when VSContrl=1]\n");
            sw.Write("---------------------- SIMPLE INDUCTION GENERATOR ------------------------------！简单变桨需要用到，一般用不到\n" +
                "9999.9                 SIG_SlPc    - Rated generator slip percentage (%) [used only when VSContrl=0 and GenModel=1]\n" +
                "9999.9                 SIG_SySp    - Synchronous (zero-torque) generator speed (rpm) [used only when VSContrl=0 and GenModel=1]\n" +
                "9999.9                 SIG_RtTq    - Rated torque (N-m) [used only when VSContrl=0 and GenModel=1]\n" +
                "9999.9                 SIG_PORt    - Pull-out ratio (Tpullout/Trated) (-) [used only when VSContrl=0 and GenModel=1]\n");
            sw.Write("---------------------- THEVENIN-EQUIVALENT INDUCTION GENERATOR -----------------！简单变桨需要用到，一般用不到\n" +
                sim1.WindTurbine.Control.inductonGenerator.TEC_Freq.value + "\tTEC_Freq    - Line frequency [50 or 60] (Hz) [used only when VSContrl=0 and GenModel=2]\n" +
                "9998                   TEC_NPol    - Number of poles [even integer > 0] (-) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_SRes    - Stator resistance (ohms) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_RRes    - Rotor resistance (ohms) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_VLL     - Line-to-line RMS voltage (volts) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_SLR     - Stator leakage reactance (ohms) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_RLR     - Rotor leakage reactance (ohms) [used only when VSContrl=0 and GenModel=2]\n" +
                "9999.9                 TEC_MR      - Magnetizing reactance (ohms) [used only when VSContrl=0 and GenModel=2]\n");
            sw.Write("---------------------- HIGH-SPEED SHAFT BRAKE ----------------------------------！高速轴刹车\n" +
                sim1.WindTurbine.Control.HSBrake.HSSBrMode.value + "\tHSSBrMode   - HSS brake model {0: none, 1: simple, 3: user-defined from routine UserHSSBr, 4: user-defined from Simulink/Labview, 5: user-defined from Bladed-style DLL} (switch)\n" +
                sim1.WindTurbine.Control.HSBrake.THSSBrDp.value + "\tTHSSBrDp    - Time to initiate deployment of the HSS brake (s)\n" +
                sim1.WindTurbine.Control.HSBrake.HSSBrDT.value + "\t HSSBrDT     - Time for HSS-brake to reach full deployment once initiated (sec) [used only when HSSBrMode=1]\n" +
                sim1.WindTurbine.Control.HSBrake.HSSBrTqF.value + "\tHSSBrTqF    - Fully deployed HSS-brake torque (N-m)\n");
            sw.Write("---------------------- NACELLE-YAW CONTROL -------------------------------------！机舱偏航控制，一般不偏航，因为响应足够慢，一般不会造成大的极端载荷或疲劳损伤\n" +
                sim1.WindTurbine.Control.yawControl.YCMode.value + "\tYCMode      - Yaw control mode {0: none, 3: user-defined from routine UserYawCont, 4: user-defined from Simulink/Labview, 5: user-defined from Bladed-style DLL} (switch)\n" +
                "9999.9                 TYCOn       - Time to enable active yaw control (s) [unused when YCMode=0]\n" +
                "0.0                    YawNeut     - Neutral yaw position--yaw spring force is zero at this yaw (degrees)\n" +
                "4.6273E+10             YawSpr      - Nacelle-yaw spring constant (N-m/rad)\n" +
                "3.9088E+07             YawDamp     - Nacelle-yaw damping constant (N-m/(rad/s))\n" +
                "9999.9                 TYawManS    - Time to start override yaw maneuver and end standard yaw control (s)\n" +
                "2.0                    YawManRat   - Yaw maneuver rate (in absolute value) (deg/s)\n" +
                "0.0                    NacYawF     - Final yaw angle for override yaw maneuvers (degrees)\n");
            sw.Write("---------------------- TUNED MASS DAMPER ---------------------------------------！调谐阻尼器控制\n"+
                sim1.WindTurbine.Control.massDamper.CompNTMD.value + "\tCompNTMD    - Compute nacelle tuned mass damper {true/false} (flag)\n");
            if (sim1.WindTurbine.Control.massDamper.CompNTMD.value)
            {
                sw.WriteLine(sim1.WindTurbine.Control.massDamper.CompNTMD.value + "\t NTMDfile    - Name of the file for nacelle tuned mass damper (quoted string) [unused when CompNTMD is false]\n");
            }
            else sw.WriteLine("\"unused\"\tNTMDfile    - Name of the file for nacelle tuned mass damper (quoted string) [unused when CompNTMD is false]");
            sw.Write("False\tCompTTMD    - Compute tower tuned mass damper {true/false} (flag)\n"+
                "\"unused\"\tTTMDfile    - Name of the file for tower tuned mass damper (quoted string) [unused when CompTTMD is false]\n"+
                "---------------------- BLADED INTERFACE ---------------------------------------- [used only with Bladed Interface]！最重要的地方\n"+
                "\""+sim1.WindTurbine.Control.BladedInterface_Dll.DLL_FileName.value+"\"" + "\tDLL_FileName - Name/location of the dynamic library {.dll [Windows] or .so [Linux]} in the Bladed-DLL format (-) [used only with Bladed Interface]！dll的文件名和位置\n"+
                "\""+sim1.WindTurbine.Control.BladedInterface_Dll.DLL_InFile.value+ "\"" + "\tDLL_InFile  - Name of input file sent to the DLL (-) [used only with Bladed Interface]！dll的输入文件，NREL控制器需要修改源代码重新编译出dll，ROSCO控制器可以在输入文件中改\n"+
                "\""+sim1.WindTurbine.Control.BladedInterface_Dll.DLL_ProcName.value+ "\"" + "\t DLL_ProcName - Name of procedure in DLL to be called (-) [case sensitive; used only with DLL Interface]！\n"+
                sim1.WindTurbine.Control.BladedInterface_Dll.DLL_DT.value + "\tDLL_DT      - Communication interval for dynamic library (s) (or \"default\") [used only with Bladed Interface]\n"+
                "True                   DLL_Ramp    - Whether a linear ramp should be used between DLL_DT time steps [introduces time shift when true] (flag) [used only with Bladed Interface]\n"+
                "9999.9                 BPCutoff    - Cuttoff frequency for low-pass filter on blade pitch from DLL (Hz) [used only with Bladed Interface]\n"+
                "0.0                    NacYaw_North - Reference yaw angle of the nacelle when the upwind end points due North (deg) [used only with Bladed Interface]\n"+
                "0                      Ptch_Cntrl  - Record 28: Use individual pitch control {0: collective pitch; 1: individual pitch control} (switch) [used only with Bladed Interface]\n"+
                "0.0                    Ptch_SetPnt - Record  5: Below-rated pitch angle set-point (deg) [used only with Bladed Interface]\n"+
                "0.0                    Ptch_Min    - Record  6: Minimum pitch angle (deg) [used only with Bladed Interface]\n"+
                "0.0                    Ptch_Max    - Record  7: Maximum pitch angle (deg) [used only with Bladed Interface]\n"+
                "0.0                    PtchRate_Min - Record  8: Minimum pitch rate (most negative value allowed) (deg/s) [used only with Bladed Interface]\n"+
                "0.0                    PtchRate_Max - Record  9: Maximum pitch rate  (deg/s) [used only with Bladed Interface]\n"+
                "0.0                    Gain_OM     - Record 16: Optimal mode gain (Nm/(rad/s)^2) [used only with Bladed Interface]\n"+
                "0.0                    GenSpd_MinOM - Record 17: Minimum generator speed (rpm) [used only with Bladed Interface]\n"+
                "0.0                    GenSpd_MaxOM - Record 18: Optimal mode maximum speed (rpm) [used only with Bladed Interface]\n"+
                "0.0                    GenSpd_Dem  - Record 19: Demanded generator speed above rated (rpm) [used only with Bladed Interface]\n"+
                "0.0                    GenTrq_Dem  - Record 22: Demanded generator torque above rated (Nm) [used only with Bladed Interface]\n"+
                "0.0                    GenPwr_Dem  - Record 13: Demanded power (W) [used only with Bladed Interface]\n");
            sw.Write("---------------------- BLADED INTERFACE TORQUE-SPEED LOOK-UP TABLE -------------\n"+
                sim1.WindTurbine.Control.BladedInterface_Torque.DLL_NumTrq.value + "\t0                      DLL_NumTrq  - Record 26: No. of points in torque-speed look-up table {0 = none and use the optimal mode parameters; nonzero = ignore the optimal mode PARAMETERs by setting Record 16 to 0.0} (-) [used only with Bladed Interface]\n"+
                "GenSpd_TLU            	GenTrq_TLU\n"+
                "(rpm)                 	(Nm)");
            for (int i = 0; i < sim1.WindTurbine.Control.BladedInterface_Torque.GenSpd_TLU.Count; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Control.BladedInterface_Torque.GenSpd_TLU[i].value +"\t "+ sim1.WindTurbine.Control.BladedInterface_Torque.GenTrq_TLU[i].value);
            }
            sw.Write("---------------------- OUTPUT --------------------------------------------------\n" +
                sim1.Outputs.ControlOutputs.SumPrint.value + "\tSumPrint    - Print summary data to <RootName>.sum (flag) (currently unused)\n"+
                "1\tOutFile\t- Switch to determine where output will be placed: {1: in module output file only; 2: in glue code output file only; 3: both} (currently unused)\n"+
                "True                   TabDelim    - Use tab delimiters in text tabular output file? (flag) (currently unused)\n"+
                "\"ES10.3E2\"             OutFmt      - Format used for text tabular output (except time).  Resulting field should be 10 characters. (quoted string) (currently unused)\n"+
                "30.0                   TStart      - Time to begin tabular output (s) (currently unused)\n"+
                "   OutList      - The next line(s) contains a list of output parameters.  See OutListParameters.xlsx for a listing of available output channels, (-)\n"+
                "\"GenPwr\""+
                "\"GenTq\""+
                "\"BlPitchC1\""+
                "\"BlPitchC2\""+
                "\"BlPitchC3\""+
                "\"HSSBrTqC\""+
                "\"YawMomCom\""+
                "END of input file (the word \"END\" must appear in the first 3 columns of this last OutList line)\n"+
                "---------------------------------------------------------------------------------------");
            sw.Close();
        } 
        public void Write_IEA_15_240_AeroDyn15_Blade()
        {
            StreamWriter sw = new StreamWriter(workDir2 + @"\IEA-15-240-RWT_AeroDyn15_Blade.dat", false, Encoding.UTF8);/*创建fst文件，实参修改路径*/
            const string head = "------- AERODYN v15.00.* BLADE DEFINITION INPUT FILE -------------------------------------\n" +
            "IEA 15 MW Offshore Reference TurbineIEA 15 MW Offshore Reference Turbine\n";
            sw.Write(head);
            sw.Write("======  Blade Properties =================================================================！θ=桨距角+扭角  入流角=θ+攻角  入流角为相对风速与旋转方向夹角 攻角为相对风速与翼型弦线夹角\n"+
                sim1.WindTurbine.Blade.NumBlNds.value + "\tNumBlNds    - Number of blade nodes used in the analysis (-)\n"+
                "BlSpn\t BlCrvAC\t BlSwpAC\t BlCrvAng\t BlTwist\t BlChord\t BlAFID  \n");
            for (int i = 0; i < sim1.WindTurbine.Blade.NumBlNds.value; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.BladeStation[i].BlSpn.value+"\t "+ sim1.WindTurbine.Blade.BladeStation[i].BlCrvAC.value+"\t" + sim1.WindTurbine.Blade.BladeStation[i].BlSwpAC.value+"\t "+ sim1.WindTurbine.Blade.BladeStation[i].BlCrvAng.value+"\t"+ sim1.WindTurbine.Blade.BladeStation[i].BlTwist.value+"\t"+ sim1.WindTurbine.Blade.BladeStation[i].BlChord.value+"\t "+ sim1.WindTurbine.Blade.BladeStation[i].BlAFID.value);
            }
            sw.Close();
        }
        public void Write_IEA_15_240_BeamDyn()
        {
            StreamWriter sw = new StreamWriter(workDir1 + @"\IEA-15-240-RWT_BeamDyn.dat", false, Encoding.UTF8);/*创建fst文件，实参修改路径*/
            const string head = "--------- BEAMDYN with OpenFAST INPUT FILE -------------------------------------------\n" +
            "IEA 15MW Offshore Reference Turbine, with taped chord tip design blade\n";
            sw.Write(head);
            sw.Write("---------------------- SIMULATION CONTROL --------------------------------------\n"+
                sim1.SimulationControl.NonLinearSimulationControl.Echo.value + "\tEcho            - Echo input data to \" < RootName >.ech\" (flag)\n"+
                sim1.SimulationControl.NonLinearSimulationControl.QuasiStaticInit.value + "\tQuasiStaticInit - Use quasistatic pre-conditioning with centripetal accelerations in initialization (flag) [dynamic solve only]！\n"+
                "0            rhoinf          - Numerical damping parameter for generalized-alpha integrator！指定了数值阻尼参数（放大矩阵的谱半径），范围为0到1，用于BD中执行的广义α时间积分器来实现动态分析。设为1则不引入数值阻尼；设为0则引入最大数值阻尼，数值阻尼有利于产生数值稳定的解\n"+
                "2            quadrature      - Quadrature method: 1=Gaussian; 2=Trapezoidal (switch)！\n"+
                "2            refine          - Refinement factor for trapezoidal quadrature (-). DEFAULT = 1 [used only when quadrature=2]！\n"+
                "5             n_fact          - Factorization frequency (-). DEFAULT = 5！ \n" +
                "DEFAULT       DTBeam          - Time step size (s).！\n" +
                "20            load_retries    - Number of factored load retries before quitting the aimulation !\n" +
                "10            NRMax           - Max number of iterations in Newton-Ralphson algorithm (-). DEFAULT = 10 ！\n" +
                "1E-04         stop_tol        - Tolerance for stopping criterion (-) ！\n" +
                "False         tngt_stf_fd     - Flag to use finite differenced tangent stiffness matrix (-) ！\n" +
                "False         tngt_stf_comp   - Flag to compare analytical finite differenced tangent stiffness matrix  (-) ！\n" +
                "1E-05         tngt_stf_pert   - perturbation size for finite differencing (-) ！\n" +
                "1             tngt_stf_difftol- Maximum allowable relative difference between analytical and fd tangent stiffness (-) ！\n" +
                "True          RotStates       - Orient states in the rotating frame during linearization? (flag) [used only when linearizing]\n " +
                "---------------------- GEOMETRY PARAMETER --------------------------------------\n");
            sw.Write(sim1.WindTurbine.Blade.NonlinearBladeInfo.member_total.value+ "\tmember_total    - Total number of members (-) ！\n"+
                sim1.WindTurbine.Blade.NonlinearBladeInfo.kp_total.value + "\tkp_total        - Total number of key points (-) [must be at least 3] ！\n"+
                sim1.WindTurbine.Blade.NonlinearBladeInfo.member_total.value + ","+sim1.WindTurbine.Blade.NonlinearBladeInfo.kp_total.value + "- Member number; Number of key points in this member\n"+
                " kp_xr\t kp_yr\t kp_zr\t initial_twist \n"+
                "(m)\t (m)\t (m)\t (deg)\n");
            for (int i = 0; i < sim1.WindTurbine.Blade.NonlinearBladeInfo.kp_total.value; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.NonlinearKeyPoints[i].kp_xr.value + "\t " + sim1.WindTurbine.Blade.NonlinearKeyPoints[i].kp_yr.value + "\t" + sim1.WindTurbine.Blade.NonlinearKeyPoints[i].kp_zr.value + "\t" + sim1.WindTurbine.Blade.NonlinearKeyPoints[i].initial_twist.value);
            }
            sw.Write("---------------------- MESH PARAMETER ------------------------------------------ kp_total与FE_nodes数量和station_total无关，station_total与FE_nodes数量无关\n"+
                sim1.WindTurbine.Blade.NonlinearBladeInfo.order_elem.value + "\torder_elem     - Order of interpolation (basis) function (-) ！\n" +
                "---------------------- MATERIAL PARAMETER --------------------------------------\n"+
                "\""+sim1.WindTurbine.Blade.NonlinearBladeInfo.BldFile.value+"\"" + "\tBldFile - Name of file containing properties for blade (quoted string)\n"+
                "---------------------- PITCH ACTUATOR PARAMETERS -------------------------------\n"+
                sim1.WindTurbine.Control.PitcActuator.UsePitchAct.value + "\tUsePitchAct - Whether a pitch actuator should be used (flag)\n" +
                "200   PitchJ      - Pitch actuator inertia (kg-m^2) [used only when UsePitchAct is true]\n" +
                "2E+07   PitchK      - Pitch actuator stiffness (kg-m^2/s^2) [used only when UsePitchAct is true]\n" +
                "500000   PitchC      - Pitch actuator damping (kg-m^2/s) [used only when UsePitchAct is true]\n" +
                "---------------------- OUTPUTS -------------------------------------------------\n");
            sw.Write(sim1.Outputs.NonlinearOutputs.SumPrint.value + "\tSumPrint       - Print summary data to\" < RootName >.sum\" (flag)\n"+
                "\""+sim1.Outputs.NonlinearOutputs.OutFmt.value+"\""+ "\tOutFmt         - Format used for text tabular output, excluding the time channel.\n"+
                "9   NNodeOuts      - Number of nodes to output to file [0 - 9] (-)\n" +
                "1,     6,    11,   15,  20,   25,   30,   35,  41 OutNd          - Nodes whose values will be output  (-)\n"+
                "OutList            - The next line(s) contains a list of output parameters. See OutListParameters.xlsx for a listing of available output channels, (-)\n");
            sw.Write("\"N1Fyl\"\n" +
                "\"N2Fxl\"\n" +
                "\"N2Fzl\"\n" +
                "\"N3Fyl\"\n" +
                "\"N4Fxl\"\n" +
                "\"N4Fzl\"\n" +
                "\"N5Fyl\"\n" +
                "\"N6Fxl\"\n" +
                "\"N6Fzl\"\n" +
                "\"N7Fyl\"\n" +
                "\"N8Fxl\"\n" +
                "\"N8Fzl\"\n" +
                "\"N9Fyl\"\n" +
                "\"N1Mxl\"\n" +
                "\"N1Mzl\"\n" +
                "\"N2Myl\"\n" +
                "\"N3Mxl\"\n" +
                "\"N3Mzl\"\n" +
                "\"N4Myl\"\n" +
                "\"N5Mxl\"\n" +
                "\"N5Mzl\"\n" +
                "\"N6Myl\"\n" +
                "\"N7Mxl\"\n" +
                "\"N7Mzl\"\n" +
                "\"N8Myl\"\n" +
                "\"N9Mxl\"\n" +
                "\"N9Mzl\"\n" +
                "\"N1TDyr\"\n" +
                "\"N2TDxr\"\n" +
                "\"N2TDzr\"\n" +
                "\"N3TDyr\"\n" +
                "\"N4TDxr\"\n" +
                "\"N4TDzr\"\n" +
                "\"N5TDyr\"\n" +
                "\"N6TDxr\"\n" +
                "\"N6TDzr\"\n" +
                "\"N7TDyr\"\n" +
                "\"N8TDxr\"\n" +
                "\"N8TDzr\"\n" +
                "\"N9TDyr\"\n" +
                "\"N1RDxr\"\n" +
                "\"N1RDzr\"\n" +
                "\"N2RDyr\"\n" +
                "\"N3RDxr\"\n" +
                "\"N3RDzr\"\n" +
                "\"N4RDyr\"\n" +
                "\"N5RDxr\"\n" +
                "\"N5RDzr\"\n" +
                "\"N6RDyr\"\n" +
                "\"N7RDxr\"\n" +
                "\"N7RDzr\"\n" +
                "\"N8RDyr\"\n" +
                "\"N9RDxr\"\n" +
                "\"N9RDzr\"\n" +
                "\"N1TVyg\"\n" +
                "\"N2TVxg\"\n" +
                "\"N2TVzg\"\n" +
                "\"N3TVyg\"\n" +
                "\"N4TVxg\"\n" +
                "\"N4TVzg\"\n" +
                "\"N5TVyg\"\n" +
                "\"N6TVxg\"\n" +
                "\"N6TVzg\"\n" +
                "\"N7TVyg\"\n" +
                "\"N8TVxg\"\n" +
                "\"N8TVzg\"\n" +
                "\"N9TVyg\"\n" +
                "\"N1RVxg\"\n" +
                "\"N1RVzg\"\n" +
                "\"N2RVyg\"\n" +
                "\"N3RVxg\"\n" +
                "\"N3RVzg\"\n" +
                "\"N4RVyg\"\n" +
                "\"N5RVxg\"\n" +
                "\"N5RVzg\"\n" +
                "\"N6RVyg\"\n" +
                "\"N7RVxg\"\n" +
                "\"N7RVzg\"\n" +
                "\"N8RVyg\"\n" +
                "\"N9RVxg\"\n" +
                "\"N9RVzg\"\n" +
                "\"N1PFyl\"\n" +
                "\"N2PFxl\"\n" +
                "\"N2PFzl\"\n" +
                "\"N3PFyl\"\n" +
                "\"N4PFxl\"\n" +
                "\"N4PFzl\"\n" +
                "\"N5PFyl\"\n" +
                "\"N6PFxl\"\n" +
                "\"N6PFzl\"\n" +
                "\"N7PFyl\"\n" +
                "\"N8PFxl\"\n" +
                "\"N8PFzl\"\n" +
                "\"N9PFyl\"\n" +
                "\"N1PMxl\"\n" +
                "\"N1PMzl\"\n" +
                "\"N2PMyl\"\n" +
                "\"N3PMxl\"\n" +
                "\"N3PMzl\"\n" +
                "\"N4PMyl\"\n" +
                "\"N5PMxl\"\n" +
                "\"N5PMzl\"\n" +
                "\"N6PMyl\"\n" +
                "\"N7PMxl\"\n" +
                "\"N7PMzl\"\n" +
                "\"N8PMyl\"\n" +
                "\"N9PMxl\"\n" +
                "\"N9PMzl\"\n" +
                "\"N1DFyl\"\n" +
                "\"N2DFxl\"\n" +
                "\"N2DFzl\"\n" +
                "\"N3DFyl\"\n" +
                "\"N4DFxl\"\n" +
                "\"N4DFzl\"\n" +
                "\"N5DFyl\"\n" +
                "\"N6DFxl\"\n" +
                "\"N6DFzl\"\n" +
                "\"N7DFyl\"\n" +
                "\"N8DFxl\"\n" +
                "\"N8DFzl\"\n" +
                "\"N9DFyl\"\n" +
                "\"N1DMxl\"\n" +
                "\"N1DMzl\"\n" +
                "\"N2DMyl\"\n" +
                "\"N3DMxl\"\n" +
                "\"N3DMzl\"\n" +
                "\"N4DMyl\"\n" +
                "\"N5DMxl\"\n" +
                "\"N5DMzl\"\n" +
                "\"N6DMyl\"\n" +
                "\"N7DMxl\"\n" +
                "\"N7DMzl\"\n" +
                "\"N8DMyl\"\n" +
                "\"N9DMxl\"\n" +
                "\"N9DMzl\"\n" +
                "\"PAngAct\"\n" +
                "\"PAccAc\"\n" +
                "END of input file (the word \"END\" must appear in the first 3 columns of this last OutList line)\n" +
                "---------------------------------------------------------------------------------------");
            sw.Close();
        }   
        public void Write_IEA_15_240_BeamDyn_blade()
        {
            StreamWriter sw = new StreamWriter(workDir1 + @"\IEA-15-240-RWT_BeamDyn_Blade_VABS.dat", false, Encoding.UTF8);/*创建fst文件，实参修改路径*/
            const string head = "------- BEAMDYN V1.00.* INDIVIDUAL BLADE INPUT FILE --------------------------\n" +
            "IEA 15MW Offshore Reference Turbine, with taped chord tip design blade. Generated with Sonata/VABS (includes initial twist and curvature) by Roland Feil et al (A Cross-Sectional Aeroelastic Analysis and Structural Optimization Tool for Slender Composite Structures)\n";
            sw.Write(head);
            sw.Write(" ---------------------- BLADE PARAMETERS -------------------------------------\n"+
                sim1.WindTurbine.Blade.NonlinearBladeInfo.station_total.value + "\tstation_total    - Number of blade input stations (-)\n"+
                sim1.WindTurbine.Blade.NonlinearBladeInfo.damp_type.value + "\tdamp_type        - Damping type: 0: no damping; 1: damped\n" +
                " ---------------------- DAMPING COEFFICIENT------------------------------------\n" +
                "mu1\t mu2\t mu3\t mu4\t mu5\t mu6\n" +
                "(-)\t(-)\t (-)\t(-)\t (-)\t (-)\n");
            for (int i = 0; i < sim1.WindTurbine.Blade.NonlinearBladeInfo.dampings.Count; i++)
            {
                sw.Write(sim1.WindTurbine.Blade.NonlinearBladeInfo.dampings[i].value+"\t");
            }
            sw.Write("\n"+ " ---------------------- DISTRIBUTED PROPERTIES---------------------------------\n");
            for (int i = 0; i < sim1.WindTurbine.Blade.NonlinearBladeInfo.station_total.value; i++)
            {
                sw.Write(sim1.WindTurbine.Blade.SectionMatrix[i].location.value+"\n");
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        sw.Write(sim1.WindTurbine.Blade.SectionMatrix[i].Stiffness_matrix.value[j,k]);
                    }
                    sw.Write("\n");
                }
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        sw.WriteLine(sim1.WindTurbine.Blade.SectionMatrix[i].Mass_matrix.value[j, k]);
                    }
                    sw.Write("\n");
                }
            }
            sw.Close();
        } 
        public void Write_IEA_15_240_Inflowfile()
        {
            StreamWriter sw = new StreamWriter(workDir1 + @"\IEA-15-240-RWT_InflowFile.dat", false, Encoding.UTF8);/*创建fst文件，实参修改路径*/
            const string head = "------- InflowWind v3.01.* INPUT FILE -------------------------------------------------------------------------\n" +
            "IEA 15 MW Offshore Reference Turbine\n" +
            "---------------------------------------------------------------------------------------------------------------\n";
            sw.Write(head);
            sw.Write(sim1.Environment.WindCondition.WindBasicInfo.Echo.value + "\t Echo        - Echo input data to <RootName>.ech (flag)\n" +
                sim1.Environment.WindCondition.WindBasicInfo.WindType.value + "\tWindType    - switch for wind file type (1=steady; 2=uniform; 3=binary TurbSim FF; 4=binary Bladed-style FF; 5=HAWC format; 6=User defined)！\n"+
                sim1.Environment.WindCondition.WindBasicInfo.PropagationDir.value + "\t PropagationDir - Direction of wind propagation (meteoroligical rotation from aligned with X (positive rotates towards -Y) -- degrees)\n"+
                sim1.Environment.WindCondition.WindBasicInfo.NWindVel.value + "\tNWindVel    - Number of points to output the wind velocity    (0 to 9)！\n");
            for (int i = 0; i < sim1.Environment.WindCondition.WindBasicInfo.NWindVel.value; i++)
            {
                sw.Write(sim1.Environment.WindCondition.WindBasicInfo.WindVxiList[i].value+ " ");
            }
            sw.Write("\n");
            for (int i = 0; i < sim1.Environment.WindCondition.WindBasicInfo.NWindVel.value; i++)
            {
                sw.Write(sim1.Environment.WindCondition.WindBasicInfo.WindVyiList[i].value + " ");
            }
            sw.Write("\n");
            for (int i = 0; i < sim1.Environment.WindCondition.WindBasicInfo.NWindVel.value; i++)
            {
                sw.Write(sim1.Environment.WindCondition.WindBasicInfo.WindVziList[i].value + " ");
            }
            sw.Write("\n" +
                "================== Parameters for Steady Wind Conditions [used only for WindType = 1] =========================\n");
            sw.Write(sim1.Environment.WindCondition.SteadyWind.HWindSpeed.value + "\tHWindSpeed  - Horizontal windspeed(m/s)\n"+
                sim1.Environment.WindCondition.SteadyWind.RefHt.value + "\tRefHt       - Reference height for horizontal wind speed      (m)  ！一般为轮毂中心处高度\n"+
                sim1.Environment.WindCondition.SteadyWind.PLexp.value + "\tPLexp       - Power law exponent                              (-)  ！风切变剖面的幂律指数\n"+
                "================== Parameters for Uniform wind file   [used only for WindType = 2] ============================\n"+
                "\""+sim1.Environment.WindCondition.Uniformwind.Filename.value+"\""+ "\tFilename    - Filename of time series data for uniform wind field.      (-)\n"+
                sim1.Environment.WindCondition.Uniformwind.RefHt.value + "\t RefHt       - Reference height for horizontal wind speed                (m)  ！一般为轮毂中心处高度\n"+
                sim1.Environment.WindCondition.Uniformwind.RefLength.value + "\tRefLength   - Reference length for linear horizontal and vertical sheer (-)  ！以前的版本中一般为转子直径\n" +
                "================== Parameters for Binary TurbSim Full-Field files   [used only for WindType = 3] ==============\n" +
                "\""+sim1.Environment.WindCondition.BinFileName.value+"\""+ "\tFilename    - Name of the Full field wind file to use (.bts)\n" +
                "================== Parameters for Binary Bladed-style Full-Field files   [used only for WindType = 4] ========= ！.wnd文件 还需要.sum文件 两个放在一起配套使用\n" +
                "\""+sim1.Environment.WindCondition.BladedWindFileRoot.value+"\""+ "\tFilenameRoot - Rootname of the full-field wind file to use (.wnd, .sum)\n"+
                "\""+sim1.Environment.WindCondition.TowerFile.value+"\"" + "\tTowerFile   - Have tower file (.twr) (flag)\n"+
                "================== Parameters for HAWC-format binary files  [Only used with WindType = 5] =====================\n"+
                "\""+sim1.Environment.WindCondition.HawcWindFile.FileName_u.value +"\""+ "  FileName_u  - name of the file containing the u-component fluctuating wind (.bin)\n" +
                "\"wasp / Output / basic_5v.bin\" FileName_v  - name of the file containing the v-component fluctuating wind (.bin)\n" +
                "\"wasp / Output / basic_5w.bin\" FileName_w  - name of the file containing the w-component fluctuating wind (.bin)\n"+
                "64                     nx          - number of grids in the x direction (in the 3 files above) (-)\n" +
                "32                     ny          - number of grids in the y direction (in the 3 files above) (-)\n" +
                "32                     nz          - number of grids in the z direction (in the 3 files above) (-)\n" +
                "16.0                   dx          - distance (in meters) between points in the x direction    (m)\n" +
                "3.0                    dy          - distance (in meters) between points in the y direction    (m)\n" +
                "3.0                    dz          - distance (in meters) between points in the z direction    (m)\n" +
                "150.0                  RefHt       - reference height; the height (in meters) of the vertical center of the grid (m)\n" +
                "-------------   Scaling parameters for turbulence   ---------------------------------------------------------\n");
            sw.Write(sim1.Environment.WindCondition.ScalingParameters.ScaleMethod.value + "\tScaleMethod - Turbulence scaling method   [0 = none, 1 = direct scaling, 2 = calculate scaling factor based on a desired standard deviation]\n" +
                "1.0                    SFx         - Turbulence scaling factor for the x direction (-)   [ScaleMethod=1]\n" +
                "1.0                    SFy         - Turbulence scaling factor for the y direction (-)   [ScaleMethod=1]\n" +
                "1.0                    SFz         - Turbulence scaling factor for the z direction (-)   [ScaleMethod=1]\n" +
                "1.2                    SigmaFx     - Turbulence standard deviation to calculate scaling from in x direction (m/s)    [ScaleMethod=2]\n" +
                "0.8                    SigmaFy     - Turbulence standard deviation to calculate scaling from in y direction (m/s)    [ScaleMethod=2]\n" +
                "0.2                    SigmaFz     - Turbulence standard deviation to calculate scaling from in z direction (m/s)    [ScaleMethod=2]\n" +
                "-------------   Mean wind profile parameters (added to HAWC-format files)   ---------------------------------\n" +
                sim1.Environment.WindCondition.MeanWindProfoile.URef.value + "\tURef        - Mean u-component wind speed at the reference height (m/s)\n"+
                sim1.Environment.WindCondition.MeanWindProfoile.WindProfile.value +"\tWindProfile - Wind profile type (0=constant;1=logarithmic,2=power law)\n"+
                sim1.Environment.WindCondition.MeanWindProfoile.PLExp.value + "\t PLExp       - Power law exponent (-) (used for PL wind profile type only)\n"+
                sim1.Environment.WindCondition.MeanWindProfoile.Z0.value + "\t Z0          - Surface roughness length (m) (used for LG wind profile type only)\n");
            sw.Write("====================== OUTPUT ==================================================\n" +
                sim1.Outputs.windOutputs.SumPrint.value + "\tSumPrint    - Print summary data to <RootName>.IfW.sum (flag)\n"+
                "OutList      - The next line(s) contains a list of output parameters.  See OutListParameters.xlsx for a listing of available output channels, (-)\n" +
                "\"Wind1Vel\"\n" +
                "\"Wind2Vel\"\n" +
                "\"Wind2Vel\"\n" +
                "\"Wind3Vel\"\n" +
                "\"Wind4Vel\"\n" +
                "\"Wind4Vel\"\n" +
                "\"Wind5Vel\"\n" +
                "\"Wind6Vel\"\n" +
                "\"Wind6Vel\"\n" +
                "\"Wind7Vel\"\n" +
                "\"Wind8Vel\"\n" +
                "\"Wind8Vel\"\n" +
                "\"Wind9Vel\"\n" +
                "END of input file (the word \"END\" must appear in the first 3 columns of this last OutList line)\n" +
                "---------------------------------------------------------------------------------------");
            sw.Flush();
            sw.Close();

        } 
        public void Write_IEA_15_240_Polar_Coords(int air_Index)
        {
            StreamWriter sw = new StreamWriter(string.Format(workDir2 + @"\Airfoils\IEA-15-240-RWT_AeroDyn15_Polar_{0:D2}_Coords.txt", air_Index), false, Encoding.UTF8);
            sw.Write(sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.NumCoords.value + "\tNumCoords\n" +
                "! ......... x-y coordinates are next if NumCoords > 0 .............\n" +
                "! x-y coordinate of airfoil reference\n" +
                "!  x/c        y/c\n" +
                sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.x2c_0.value + "\t" + sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.y2c_0.value +"\n" +
                "! coordinates of airfoil shape\n" +
                "! interpolation to 200 points\n" +
                "!  x/c        y/c\n");
            for (int i = 0; i < sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.x2c.Count; i++)
            {
                sw.WriteLine(sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.x2c[i].value + " " + sim1.Airfoil[air_Index].Airfoilfile.AirfoilShape.y2c[i].value);
            }
            sw.Close();
        } 

        public void Write_IEA_15_240_ElastoDyn_blade()
        {
            StreamWriter sw = new StreamWriter(string.Format(workDir2 + @"\Airfoil\IEA-15-240-RWT_ElastoDyn_blade.dat"), false, Encoding.UTF8);
            const string head = "------- ELASTODYN V1.00.* INDIVIDUAL BLADE INPUT FILE --------------------------\n" +
           "IEA 15 MW Offshore Reference Turbine\n";
            sw.Write(head);
            sw.Write(sim1.WindTurbine.Blade.BladeModes[0].NBlInpSt.value + "\tNBlInpSt    - Number of blade input stations (-)！输入的叶片节点的数量\n"+
                sim1.WindTurbine.Blade.BladeModes[0].dampings[0].value + "\tBldFlDmp1   - Blade flap mode #1 structural damping in percent of critical (%)！叶片一阶挥舞结构阻尼参数，可在叶片设计手册中查找\n"+
                sim1.WindTurbine.Blade.BladeModes[0].dampings[1].value + "\tBldFlDmp2   - Blade flap mode #2 structural damping in percent of critical (%)！叶片二阶挥舞结构阻尼参数，可在叶片设计手册中查找\n"+
                sim1.WindTurbine.Blade.BladeModes[0].dampings[3].value + "\tBldEdDmp1   - Blade edge mode #1 structural damping in percent of critical (%)！\n"+
                "---------------------- BLADE ADJUSTMENT FACTORS --------------------------------\n"+
                sim1.WindTurbine.Blade.BladeModes[0].FlStTunr[0].value + "\tFlStTunr1   - Blade flapwise modal stiffness tuner, 1st mode (-)\n"+
                sim1.WindTurbine.Blade.BladeModes[0].FlStTunr[1].value+ "\tFlStTunr2   - Blade flapwise modal stiffness tuner, 2nd mode (-)\n"+
                "1.0                    AdjBlMs     - Factor to adjust blade mass density (-) ！调整叶片质量密度的因子\n" +
                "1.0                    AdjFlSt     - Factor to adjust blade flap stiffness (-)！调整叶片挥舞刚度的因子\n" +
                "1.0                    AdjEdSt     - Factor to adjust blade edge stiffness (-)！调整叶片摆振刚度的因子\n" +
                "---------------------- DISTRIBUTED BLADE PROPERTIES ----------------------------！BlFract：沿叶片桨距轴距离（百分数），做了归一化，从0到1（叶跟到叶尖），如果这里的点与AD-blade的不一样，FAST将会对这里线性插值，以在AD输入文件中指定位置产生相应的值 PitchAxis：若CompElast为1，CompAero为2，则这里的PitchAxis没用，因为AD15中气动中心的设定代替了这里 StrcTwst：结构扭角，指定了主轴（principal axis\n" +
                "    BlFract      PitchAxis      StrcTwst       BMassDen        FlpStff        EdgStff" +
                "      (-)           (-)          (deg)          (kg/m)         (Nm^2)         (Nm^2)");
            for (int i = 0; i < sim1.WindTurbine.Blade.BladeModes[0].NBlInpSt.value; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.BladeStation[i].BlFract.value+"\t"+ sim1.WindTurbine.Blade.BladeStation[i].PitchAxis.value + "\t"+sim1.WindTurbine.Blade.BladeStation[i].BlTwist.value +"\t"+ sim1.WindTurbine.Blade.BladeStation[i].BMassDen.value+"\t"+ sim1.WindTurbine.Blade.BladeStation[i].FlpStff.value+"\t"+ sim1.WindTurbine.Blade.BladeStation[i].EdgStff.value);
            }
            sw.Write("---------------------- BLADE MODE SHAPES ---------------------------------------！形函数来表示模态振型，六阶的多项式方程（一般是7个参数，从0到6，0阶和一阶影响比较小，所以一般忽略掉），由Bmodes计算出后到表格里进行一个归一化的拟合，每一阶模态的5个系数加起来必须=1\n" );
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.BladeModes[0].Factor_Deflection_x[i].value+ "\t- Flap mode 1\n");
            }
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.BladeModes[0].Factor_Deflection_y[i].value + "\t- Flap mode 2\n");
            }
            for (int i = 0; i < 5; i++)
            {
                sw.WriteLine(sim1.WindTurbine.Blade.BladeModes[0].Factor_Deflection_z[i].value + "\t- Edge mode 1\n");
            }
        }
        public void Copy_dll()
        {
            //复制Cp_Ct_Cq_IEA15MW.txt
            string vs = Properties.Resources.Cp_Ct_Cq_IEA15MW;
            StreamWriter sw = new StreamWriter(workDir1+@"\Cp_Ct_Cq.IEA15MW.txt", false,Encoding.UTF8);
            sw.Write(vs, 0, vs.Length);
            sw.Close();
            string vs1 = Properties.Resources.Cp_Ct_Cq_IEA15MW;
            StreamWriter sw1 = new StreamWriter(@".\Resources\Cp_Ct_Cq.IEA15MW.txt", false, Encoding.UTF8);
            sw1.Write(vs, 0, vs.Length);
            sw1.Close();
            string vs2 = Properties.Resources.Cp_Ct_Cq_IEA15MW;
            StreamWriter sw2 = new StreamWriter(workDir2 + @"\Cp_Ct_Cq.IEA15MW.txt", false, Encoding.UTF8);
            sw2.Write(vs, 0, vs.Length);
            sw2.Close();

            //复制15MW.bts
            Byte[] bts = Properties.Resources._15MW.ToArray<Byte>();
            FileStream fs = new FileStream(workDir2+@"\Wind\15MW.bts",FileMode.Create);
            fs.Write(bts,0,bts.Length);
            fs.Close();

            //复制15MW.hh
            Byte[] hh = Properties.Resources._15MW1.ToArray<Byte>();
            FileStream HHfs = new FileStream(workDir2 + @"\Wind\15MW.hh", FileMode.Create);
            HHfs.Write(hh, 0, hh.Length);
            HHfs.Close();

            //复制DISCON.dll
            Byte[] DISC = Properties.Resources.DISCON.ToArray<Byte>();
            FileStream DISCfs = new FileStream(workDir1 + @"\ServoData\DISCON.dll", FileMode.Create);
            DISCfs.Write(DISC, 0, DISC.Length);
            DISCfs.Close();

            //复制DISCON-Monopile.IN
            Byte[] DisconIN = Properties.Resources.DISCON_Monopile.ToArray<Byte>();
            FileStream DisconINfs = new FileStream(workDir1 + @"\DISCON-Monopile.IN",FileMode.Create);
            DisconINfs.Write(DisconIN, 0, DisconIN.Length);
            DisconINfs.Close();

        }
    }
}
