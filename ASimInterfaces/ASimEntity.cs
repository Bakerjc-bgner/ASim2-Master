using ASimInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{
	public partial class Simulation : VisibleObject
	{
		public Simulation() : base(string.Empty,0) { }
		public Simulation(string namestring,int n) : base(namestring,n) { }
		public WindTurbine WindTurbine = new WindTurbine("WindTurbine",1);
		public Airfoil Airfoil = new Airfoil("Airfoil",152);
		public Environment Environment = new Environment("Environment",184);
		public SimulationControl SimulationControl = new SimulationControl("SimulationControl",219);
		public Outputs Outputs = new Outputs("Outputs",261);
	}
	public partial class WindTurbine : VisibleObject
	{
		public WindTurbine() : base(string.Empty,0) { }
		public WindTurbine(string namestring,int n) : base(namestring,n) { }
		public TurbineConfiguration TurbineConfiguration = new TurbineConfiguration("TurbineConfiguration",2);
		public MassInfo MassInfo = new MassInfo("MassInfo",18);
		public Blade Blade = new Blade("Blade",29);
		public Tower Tower = new Tower("Tower",75);
		public DriveTrain DriveTrain = new DriveTrain("DriveTrain",98);
		public Control Control = new Control("Control",103);
	}
	public partial class TurbineConfiguration : VisibleObject
	{
		public TurbineConfiguration() : base(string.Empty,0) { }
		public TurbineConfiguration(string namestring,int n) : base(namestring,n) { }
		public int NumBl = 0;
		public double TipRad = 0;
		public double HubRad = 0;
		public double PreCone_1 = 0;
		public double HubCM = 0;
		public double AzimB1Up = 0;
		public double OverHang = 0;
		public double ShftGagL = 0;
		public double ShftTilt = 0;
		public double NacCMxn = 0;
		public double NacCMyn = 0;
		public double NacCMzn = 0;
		public double Twr2Shft = 0;
		public double TowerHt = 0;
		public double TowerBsHt = 0;
	}
	public partial class MassInfo : VisibleObject
	{
		public MassInfo() : base(string.Empty,0) { }
		public MassInfo(string namestring,int n) : base(namestring,n) { }
		public double TipMass_1 = 0;
		public double TipMass_2 = 0;
		public double TipMass_3 = 0;
		public double HubMass = 0;
		public double HubIner = 0;
		public double GenIner = 0;
		public double NacMass = 0;
		public double NacYIner = 0;
		public double YawBrMass = 0;
		public double PtfmMass = 0;
	}
	public partial class Blade : VisibleObject
	{
		public Blade() : base(string.Empty,0) { }
		public Blade(string namestring,int n) : base(namestring,n) { }
		public int NumBlNds = 0;
		public BladeStation BladeStation = new BladeStation("BladeStation",31);
		public NonlinearKeyPoints NonlinearKeyPoints = new NonlinearKeyPoints("NonlinearKeyPoints",45);
		public NonlinearBladeInfo NonlinearBladeInfo = new NonlinearBladeInfo("NonlinearBladeInfo",50);
		public SectionMatrix SectionMatrix = new SectionMatrix("SectionMatrix",59);
		public BladeModes BladeModes = new BladeModes("BladeModes",63);
	}
	public partial class Tower : VisibleObject
	{
		public Tower() : base(string.Empty,0) { }
		public Tower(string namestring,int n) : base(namestring,n) { }
		public int TwrNodes = 0;
		public string TwrFile = string.Empty;
		public towerStation towerStation = new towerStation("towerStation",78);
		public towerModes towerModes = new towerModes("towerModes",86);
	}
	public partial class DriveTrain : VisibleObject
	{
		public DriveTrain() : base(string.Empty,0) { }
		public DriveTrain(string namestring,int n) : base(namestring,n) { }
		public double GBoxEff = 0;
		public double GBRatio = 0;
		public double DTTorSpr = 0;
		public double DTTorDmp = 0;
	}
	public partial class Control : VisibleObject
	{
		public Control() : base(string.Empty,0) { }
		public Control(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public double DT = 0;
		public pitchControl pitchControl = new pitchControl("pitchControl",106);
		public TorqueControl TorqueControl = new TorqueControl("TorqueControl",112);
		public SimpleTorqueControl SimpleTorqueControl = new SimpleTorqueControl("SimpleTorqueControl",121);
		public inductonGenerator inductonGenerator = new inductonGenerator("inductonGenerator",126);
		public HSBrake HSBrake = new HSBrake("HSBrake",128);
		public yawControl yawControl = new yawControl("yawControl",133);
		public massDamper massDamper = new massDamper("massDamper",135);
		public BladedInterface_Dll BladedInterface_Dll = new BladedInterface_Dll("BladedInterface_Dll",138);
		public BladedInterface_Torque BladedInterface_Torque = new BladedInterface_Torque("BladedInterface_Torque",143);
		public PitcActuator PitcActuator = new PitcActuator("PitcActuator",147);
		public Linearization Linearization = new Linearization("Linearization",149);
	}
	public partial class Airfoil : VisibleObject
	{
		public Airfoil() : base(string.Empty,0) { }
		public Airfoil(string namestring,int n) : base(namestring,n) { }
		public Airfoilfile Airfoilfile = new Airfoilfile("Airfoilfile",153);
		public int InterpOrd = 0;
		public AirfoilBasicSetting AirfoilBasicSetting = new AirfoilBasicSetting("AirfoilBasicSetting",170);
		public AirfoilDataInfo AirfoilDataInfo = new AirfoilDataInfo("AirfoilDataInfo",178);
	}
	public partial class Airfoilfile : VisibleObject
	{
		public Airfoilfile() : base(string.Empty,0) { }
		public Airfoilfile(string namestring,int n) : base(namestring,n) { }
		public int AFTabMod = 0;
		public int NumAFfiles = 0;
		public string AFNames = string.Empty;
		public AirfoilPerformance AirfoilPerformance = new AirfoilPerformance("AirfoilPerformance",157);
		public AirfoilShape AirfoilShape = new AirfoilShape("AirfoilShape",163);
	}
	public partial class AirfoilBasicSetting : VisibleObject
	{
		public AirfoilBasicSetting() : base(string.Empty,0) { }
		public AirfoilBasicSetting(string namestring,int n) : base(namestring,n) { }
		public double NonDimArea = 0;
		public int NumCoords = 0;
		public string BL_file = string.Empty;
		public int NumTabs = 0;
		public double Re = 0;
		public double UserProp = 0;
		public bool InclUAdata = false;
	}
	public partial class AirfoilDataInfo : VisibleObject
	{
		public AirfoilDataInfo() : base(string.Empty,0) { }
		public AirfoilDataInfo(string namestring,int n) : base(namestring,n) { }
		public double alpha0 = 0;
		public double alpha1 = 0;
		public double alpha2 = 0;
		public double eta_e = 0;
		public double C_nalpha = 0;
	}
	public partial class EnvironmentalConditions : VisibleObject
	{
		public EnvironmentalConditions() : base(string.Empty,0) { }
		public EnvironmentalConditions(string namestring,int n) : base(namestring,n) { }
		public double AirDens = 0;
		public double KinVisc = 0;
		public double FluidDepth = 0;
		public double Gravity = 0;
	}
	public partial class WindCondition : VisibleObject
	{
		public WindCondition() : base(string.Empty,0) { }
		public WindCondition(string namestring,int n) : base(namestring,n) { }
		public WindBasicInfo WindBasicInfo = new WindBasicInfo("WindBasicInfo",191);
		public SteadyWind SteadyWind = new SteadyWind("SteadyWind",199);
		public Uniformwind Uniformwind = new Uniformwind("Uniformwind",203);
		public string BinFileName = string.Empty;
		public string BladedWindFileRoot = string.Empty;
		public bool TowerFile = false;
		public HawcWindFile HawcWindFile = new HawcWindFile("HawcWindFile",210);
		public ScalingParameters ScalingParameters = new ScalingParameters("ScalingParameters",212);
		public MeanWindProfoile MeanWindProfoile = new MeanWindProfoile("MeanWindProfoile",214);
	}
	public partial class BasicControl : VisibleObject
	{
		public BasicControl() : base(string.Empty,0) { }
		public BasicControl(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public int TMAX = 0;
		public double DT = 0;
	}
	public partial class SimulationFlags : VisibleObject
	{
		public SimulationFlags() : base(string.Empty,0) { }
		public SimulationFlags(string namestring,int n) : base(namestring,n) { }
		public int CompElast = 0;
	}
	public partial class InputFiles : VisibleObject
	{
		public InputFiles() : base(string.Empty,0) { }
		public InputFiles(string namestring,int n) : base(namestring,n) { }
		public string EDFile = string.Empty;
	}
	public partial class AerodynamicControl : VisibleObject
	{
		public AerodynamicControl() : base(string.Empty,0) { }
		public AerodynamicControl(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public string AA_InputFile = string.Empty;
		public BEM_Options BEM_Options = new BEM_Options("BEM_Options",231);
		public string OLAFInputFileName = string.Empty;
		public DynamicStall DynamicStall = new DynamicStall("DynamicStall",234);
		public bool UseBlCm = false;
		public string ADBlFile_1 = string.Empty;
	}
	public partial class StructureSimulationControl : VisibleObject
	{
		public StructureSimulationControl() : base(string.Empty,0) { }
		public StructureSimulationControl(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public int Method = 0;
		public double DT = 0;
		public DOF DOF = new DOF("DOF",243);
		public InitialConditions InitialConditions = new InitialConditions("InitialConditions",245);
		public string BldFile_1 = string.Empty;
	}
	public partial class NonLinearSimulationControl : VisibleObject
	{
		public NonLinearSimulationControl() : base(string.Empty,0) { }
		public NonLinearSimulationControl(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public bool QuasiStaticInit = false;
	}
	public partial class GeneralOutputSetting : VisibleObject
	{
		public GeneralOutputSetting() : base(string.Empty,0) { }
		public GeneralOutputSetting(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
	}
	public partial class Viualization : VisibleObject
	{
		public Viualization() : base(string.Empty,0) { }
		public Viualization(string namestring,int n) : base(namestring,n) { }
		public int WrVTK = 0;
	}
	public partial class AerodynamicOutputs : VisibleObject
	{
		public AerodynamicOutputs() : base(string.Empty,0) { }
		public AerodynamicOutputs(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
		public int NBlOuts = 0;
		public int BlOutNd = 0;
		public int NTwOuts = 0;
		public int TwOutNd = 0;
		public string OutList = string.Empty;
	}
	public partial class StructureDynamicOutputs : VisibleObject
	{
		public StructureDynamicOutputs() : base(string.Empty,0) { }
		public StructureDynamicOutputs(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
	}
	public partial class windOutputs : VisibleObject
	{
		public windOutputs() : base(string.Empty,0) { }
		public windOutputs(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
		public string OutList = string.Empty;
	}
	public partial class NonlinearOutputs : VisibleObject
	{
		public NonlinearOutputs() : base(string.Empty,0) { }
		public NonlinearOutputs(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
		public string OutFmt = string.Empty;
	}
	public partial class ControlOutputs : VisibleObject
	{
		public ControlOutputs() : base(string.Empty,0) { }
		public ControlOutputs(string namestring,int n) : base(namestring,n) { }
		public bool SumPrint = false;
	}
	public partial class BladeStation : VisibleObject
	{
		public BladeStation() : base(string.Empty,0) { }
		public BladeStation(string namestring,int n) : base(namestring,n) { }
		public double BlFract = 0;
		public double PitchAxis = 0;
		public double BMassDen = 0;
		public double FlpStff = 0;
		public double EdgStff = 0;
		public double BlSpn = 0;
		public double BlCrvAC = 0;
		public double BlSwpAC = 0;
		public double BlCrvAng = 0;
		public double BlTwist = 0;
		public double BlChord = 0;
		public int BlAFID = 0;
		public double BIThickness = 0;
	}
    public partial class NonlinearKeyPoints : VisibleObject
	{
		public NonlinearKeyPoints() : base(string.Empty,0) { }
		public NonlinearKeyPoints(string namestring,int n) : base(namestring,n) { }
		public double kp_xr = 0;
		public double kp_yr = 0;
		public double kp_zr = 0;
		public double initial_twist = 0;
	}
	public partial class NonlinearBladeInfo : VisibleObject
	{
		public NonlinearBladeInfo() : base(string.Empty,0) { }
		public NonlinearBladeInfo(string namestring,int n) : base(namestring,n) { }
		public int member_total = 0;
		public int kp_total = 0;
		public int member_number = 0;
			public int order_elem = 0;
		public string BldFile = string.Empty;
		public int station_total = 0;
		public int damp_type = 0;
		public double dampings = 0;
	}
	public partial class SectionMatrix : VisibleObject
	{
		public SectionMatrix() : base(string.Empty,0) { }
		public SectionMatrix(string namestring,int n) : base(namestring,n) { }
		public double location = 0;
/*		public VisibleMatrix Stiffnessmatrix = new VisibleMatrix("Stiffnessmatrix",61);
		public VisibleMatrix Massmatrix = new VisibleMatrix("Massmatrix",62);*/
	}
	public partial class BladeModes : VisibleObject
	{
		public BladeModes() : base(string.Empty,0) { }
		public BladeModes(string namestring,int n) : base(namestring,n) { }
		public double dampings = 0;
		public double frequency = 0;
		public int NBlInpSt = 0;
		public double FlStTunr = 0;
		public double R = 0;
		public double Factor_Deflection_x = 0;
		public double Factor_Deflection_y = 0;
		public double Factor_Deflection_z = 0;
		public double Factor_Rotate_x = 0;
		public double Factor_Rotate_y = 0;
		public double Factor_Rotate_z = 0;
	}
	public partial class towerStation : VisibleObject
	{
		public towerStation() : base(string.Empty,0) { }
		public towerStation(string namestring,int n) : base(namestring,n) { }
		public double TwrElev = 0;
		public double TwrDiam = 0;
		public double TwrCd = 0;
		public double HtFract = 0;
		public double TMassDen = 0;
		public double TwFAStif = 0;
		public double TwSSStif = 0;
	}
	public partial class towerModes : VisibleObject
	{
		public towerModes() : base(string.Empty,0) { }
		public towerModes(string namestring,int n) : base(namestring,n) { }
		public double dampings = 0;
		public double frequency = 0;
		public int NTwInpSt = 0;
		public double Tunr = 0;
		public double R = 0;
		public double Factor_Deflection_x1 = 0;
		public double Factor_Deflection_x2 = 0;
		public double Factor_Deflection_y1 = 0;
		public double Factor_Deflection_y2 = 0;
		public double Factor_Rotate_x = 0;
		public double Factor_Rotate_y = 0;
	}
	public partial class pitchControl : VisibleObject
	{
		public pitchControl() : base(string.Empty,0) { }
		public pitchControl(string namestring,int n) : base(namestring,n) { }
		public int PCMode = 0;
		public double TPCOn = 0;
		public double TPitManS_1 = 0;
		public double PitManRat_1 = 0;
		public double BlPitchF_1 = 0;
	}
	public partial class TorqueControl : VisibleObject
	{
		public TorqueControl() : base(string.Empty,0) { }
		public TorqueControl(string namestring,int n) : base(namestring,n) { }
		public int VSContrl = 0;
		public int GenModel = 0;
		public double GenEff = 0;
		public bool GenTiStr = false;
		public bool GenTiStp = false;
		public double SpdGenOn = 0;
		public double TimGenOn = 0;
		public double TimGenOf = 0;
	}
	public partial class SimpleTorqueControl : VisibleObject
	{
		public SimpleTorqueControl() : base(string.Empty,0) { }
		public SimpleTorqueControl(string namestring,int n) : base(namestring,n) { }
		public double VS_RtGnSp = 0;
		public double VS_RtTq = 0;
		public double VS_Rgn2K = 0;
		public double VS_SlPc = 0;
	}
	public partial class inductonGenerator : VisibleObject
	{
		public inductonGenerator() : base(string.Empty,0) { }
		public inductonGenerator(string namestring,int n) : base(namestring,n) { }
		public double TEC_Freq = 0;
	}
	public partial class HSBrake : VisibleObject
	{
		public HSBrake() : base(string.Empty,0) { }
		public HSBrake(string namestring,int n) : base(namestring,n) { }
		public int HSSBrMode = 0;
		public double THSSBrDp = 0;
		public double HSSBrDT = 0;
		public double HSSBrTqF = 0;
	}
	public partial class yawControl : VisibleObject
	{
		public yawControl() : base(string.Empty,0) { }
		public yawControl(string namestring,int n) : base(namestring,n) { }
		public int YCMode = 0;
	}
	public partial class massDamper : VisibleObject
	{
		public massDamper() : base(string.Empty,0) { }
		public massDamper(string namestring,int n) : base(namestring,n) { }
		public bool CompNTMD = false;
		public string NTMDfile = string.Empty;
	}
	public partial class BladedInterface_Dll : VisibleObject
	{
		public BladedInterface_Dll() : base(string.Empty,0) { }
		public BladedInterface_Dll(string namestring,int n) : base(namestring,n) { }
		public string DLL_FileName = string.Empty;
		public string DLL_InFile = string.Empty;
		public string DLL_ProcName = string.Empty;
		public double DLL_DT = 0;
	}
	public partial class BladedInterface_Torque : VisibleObject
	{
		public BladedInterface_Torque() : base(string.Empty,0) { }
		public BladedInterface_Torque(string namestring,int n) : base(namestring,n) { }
		public int DLL_NumTrq = 0;
		public double GenSpd_TLU = 0;
		public double GenTrq_TLU = 0;
	}
	public partial class PitcActuator : VisibleObject
	{
		public PitcActuator() : base(string.Empty,0) { }
		public PitcActuator(string namestring,int n) : base(namestring,n) { }
		public bool UsePitchAct = false;
	}
	public partial class Linearization : VisibleObject
	{
		public Linearization() : base(string.Empty,0) { }
		public Linearization(string namestring,int n) : base(namestring,n) { }
		public bool Linearize = false;
		public bool CalcSteady = false;
	}
	public partial class AirfoilPerformance : VisibleObject
	{
		public AirfoilPerformance() : base(string.Empty,0) { }
		public AirfoilPerformance(string namestring,int n) : base(namestring,n) { }
		public int NumAlf = 0;
		public double Alpha = 0;
		public double Cl = 0;
		public double Cd = 0;
		public double Cm = 0;
	}
	public partial class AirfoilShape : VisibleObject
	{
		public AirfoilShape() : base(string.Empty,0) { }
		public AirfoilShape(string namestring,int n) : base(namestring,n) { }
		public int NumCoords = 0;
		public double x2c_0 = 0;
		public double y2c_0 = 0;
		public double x2c = 0;
		public double y2c = 0;
	}
	public partial class Environment : VisibleObject
	{
		public Environment() : base(string.Empty,0) { }
		public Environment(string namestring,int n) : base(namestring,n) { }
		public EnvironmentalConditions EnvironmentalConditions = new EnvironmentalConditions("EnvironmentalConditions",185);
		public WindCondition WindCondition = new WindCondition("WindCondition",190);
	}
	public partial class WindBasicInfo : VisibleObject
	{
		public WindBasicInfo() : base(string.Empty,0) { }
		public WindBasicInfo(string namestring,int n) : base(namestring,n) { }
		public bool Echo = false;
		public int WindType = 0;
		public double PropagationDir = 0;
		public int NWindVel = 0;
		public double WindVxiList = 0;
		public double WindVyiList = 0;
		public double WindVziList = 0;
	}
	public partial class SteadyWind : VisibleObject
	{
		public SteadyWind() : base(string.Empty,0) { }
		public SteadyWind(string namestring,int n) : base(namestring,n) { }
		public double HWindSpeed = 0;
		public double RefHt = 0;
		public double PLexp = 0;
	}
	public partial class Uniformwind : VisibleObject
	{
		public Uniformwind() : base(string.Empty,0) { }
		public Uniformwind(string namestring,int n) : base(namestring,n) { }
		public string Filename = string.Empty;
		public double RefHt = 0;
		public double RefLength = 0;
	}
	public partial class HawcWindFile : VisibleObject
	{
		public HawcWindFile() : base(string.Empty,0) { }
		public HawcWindFile(string namestring,int n) : base(namestring,n) { }
		public string FileName_u = string.Empty;
	}
	public partial class ScalingParameters : VisibleObject
	{
		public ScalingParameters() : base(string.Empty,0) { }
		public ScalingParameters(string namestring,int n) : base(namestring,n) { }
		public int ScaleMethod = 0;
	}
	public partial class MeanWindProfoile : VisibleObject
	{
		public MeanWindProfoile() : base(string.Empty,0) { }
		public MeanWindProfoile(string namestring,int n) : base(namestring,n) { }
		public double URef = 0;
		public int WindProfile = 0;
		public double PLExp = 0;
		public double Z0 = 0;
	}
	public partial class SimulationControl : VisibleObject
	{
		public SimulationControl() : base(string.Empty,0) { }
		public SimulationControl(string namestring,int n) : base(namestring,n) { }
		public BasicControl BasicControl = new BasicControl("BasicControl",220);
		public SimulationFlags SimulationFlags = new SimulationFlags("SimulationFlags",224);
		public InputFiles InputFiles = new InputFiles("InputFiles",226);
		public AerodynamicControl AerodynamicControl = new AerodynamicControl("AerodynamicControl",228);
		public StructureSimulationControl StructureSimulationControl = new StructureSimulationControl("StructureSimulationControl",239);
		public NonLinearSimulationControl NonLinearSimulationControl = new NonLinearSimulationControl("NonLinearSimulationControl",258);
	}
	public partial class BEM_Options : VisibleObject
	{
		public BEM_Options() : base(string.Empty,0) { }
		public BEM_Options(string namestring,int n) : base(namestring,n) { }
		public int SkewMod = 0;
	}
	public partial class DynamicStall : VisibleObject
	{
		public DynamicStall() : base(string.Empty,0) { }
		public DynamicStall(string namestring,int n) : base(namestring,n) { }
		public int UAMod = 0;
		public bool Flookup = false;
	}
	public partial class DOF : VisibleObject
	{
		public DOF() : base(string.Empty,0) { }
		public DOF(string namestring,int n) : base(namestring,n) { }
		public bool DOFOrder = false;
	}
	public partial class InitialConditions : VisibleObject
	{
		public InitialConditions() : base(string.Empty,0) { }
		public InitialConditions(string namestring,int n) : base(namestring,n) { }
		public double OoPDefl = 0;
		public double IPDefl = 0;
		public double BlPitch_1 = 0;
		public double BlPitch_2 = 0;
		public double BlPitch_3 = 0;
		public double TeetDefl = 0;
		public double Azimuth = 0;
		public double RotSpeed = 0;
		public double NacYaw = 0;
		public double TTDspFA = 0;
		public double TTDspSS = 0;
	}
	public partial class Outputs : VisibleObject
	{
		public Outputs() : base(string.Empty,0) { }
		public Outputs(string namestring,int n) : base(namestring,n) { }
		public GeneralOutputSetting GeneralOutputSetting = new GeneralOutputSetting("GeneralOutputSetting",262);
		public Viualization Viualization = new Viualization("Viualization",264);
		public AerodynamicOutputs AerodynamicOutputs = new AerodynamicOutputs("AerodynamicOutputs",266);
		public StructureDynamicOutputs StructureDynamicOutputs = new StructureDynamicOutputs("StructureDynamicOutputs",273);
		public windOutputs windOutputs = new windOutputs("windOutputs",275);
		public NonlinearOutputs NonlinearOutputs = new NonlinearOutputs("NonlinearOutputs",278);
		public ControlOutputs ControlOutputs = new ControlOutputs("ControlOutputs",281);
	}
}
