using System;
using System.Collections.Generic;
using System.Text;

namespace ASimInterfaces
{/*
    //整合所有主类文件
    public partial class World : VisibleValue
    {
        public World() : base(string.Empty) { }
        public World(string name) : base(name) { }
        public Monopile Monopile = new Monopile("Monopile");
        public ElastoDyn_blade ElastoDyn_blade = new ElastoDyn_blade("ElastoDyn_blade");
        public AeroDyn15_blade AeroDyn15_blade = new AeroDyn15_blade("AeroDyn15_blade");
        public AeroDyn15 AeroDyn15 = new AeroDyn15("AeroDyn15");
        public Monopile_ElastoDyn Monopile_ElastoDyn = new Monopile_ElastoDyn("Monopile_ElastoDyn");
        public Monopile_ElastoDyn_tower Monopile_ElastoDyn_tower = new Monopile_ElastoDyn_tower("Monopile_ElastoDyn_tower");
        public AeroDyn15_Polar_00 AeroDyn15_Polar_00 = new AeroDyn15_Polar_00("AeroDyn15_Polar_00");
        public AeroDyn15_Polar_00_Coords AeroDyn15_Polar_00_Coords = new AeroDyn15_Polar_00_Coords("AeroDyn15_Polar_00_Coords");
        public InflowFile InflowFile = new InflowFile("InflowFile");
        public Monopile_ServoDyn Monopile_ServoDyn = new Monopile_ServoDyn("Monopile_ServoDyn");
        public BeamDyn BeamDyn = new BeamDyn("BeamDyn");
        public BeamDyn_blade BeamDyn_blade = new BeamDyn_blade("BeamDyn_blade");
    }
    //主输入文件（IEA-15-240-RWT-Monopile.fst）	
    //			
    public partial class Monopile : VisibleValue
    {
        public Monopile() : base(string.Empty) { }
        public Monopile(string namestring) : base(namestring) { }
        public bool Echo = false;
        public VisibleValue AbortLevel = new VisibleValue("AbortLevel");
        public VisibleValue TMAX = new VisibleValue("TMAX");
        public VisibleValue DT = new VisibleValue("DT");
        public VisibleValue InterpOrder = new VisibleValue("InterpOrder");
        public VisibleValue NumCrctn = new VisibleValue("NumCrctn");
        public VisibleValue DT_UJac = new VisibleValue("DT_UJac");
        public VisibleValue UJacSclFact = new VisibleValue("UJacSclFact");
        public VisibleValue CompElast = new VisibleValue("CompElast");
        public VisibleValue CompInflow = new VisibleValue("CompInflow");
        public VisibleValue CompAero = new VisibleValue("CompAero");
        public VisibleValue CompServo = new VisibleValue("CompServo");
        public VisibleValue CompHydro = new VisibleValue("CompHydro");
        public VisibleValue CompSub = new VisibleValue("CompSub");
        public VisibleValue CompMooring = new VisibleValue("CompMooring");
        public VisibleValue CompIce = new VisibleValue("CompIce");
        public VisibleValue EDFile = new VisibleValue("EDFile");
        public VisibleValue BDBldFile1 = new VisibleValue("BDBldFile(1)");
        public VisibleValue BDBldFile2 = new VisibleValue("BDBldFile(2)");
        public VisibleValue BDBldFile3 = new VisibleValue("BDBldFile(3)");
        public VisibleValue InflowFile = new VisibleValue("InflowFile");
        public VisibleValue AeroFile = new VisibleValue("AeroFile");
        public VisibleValue ServoFile = new VisibleValue("ServoFile");
        public VisibleValue HydroFile = new VisibleValue("HydroFile");
        public VisibleValue SubFile = new VisibleValue("SubFile");
        public VisibleValue MooringFile = new VisibleValue("MooringFile");
        public VisibleValue IceFile = new VisibleValue("IceFile");
        public bool SumPrint = false;
        public VisibleValue SttsTime = new VisibleValue("SttsTime");
        public VisibleValue ChkptTime = new VisibleValue("ChkptTime");
        public VisibleValue DT_Out = new VisibleValue("DT_Out");
        public VisibleValue TStart = new VisibleValue("TStart");
        public VisibleValue OutFileFmt = new VisibleValue("OutFileFmt");
        public bool TabDelim = true;
        public VisibleValue OutFmt = new VisibleValue("OutFmt");
        public bool Linearize = false;
        public bool CalcSteady = false;
        public VisibleValue TrimCase = new VisibleValue("TrimCase");
        public VisibleValue TrimTol = new VisibleValue("TrimTol");
        public VisibleValue TrimGain = new VisibleValue("TrimGain");
        public VisibleValue Twr_Kdmp = new VisibleValue("Twr_Kdmp");
        public VisibleValue Bld_Kdmp = new VisibleValue("Bld_Kdmp");
        public VisibleValue NLinTimes = new VisibleValue("NLinTimes");
        public VisibleValue LinTimes = new VisibleValue("LinTimes");
        public VisibleValue LinInputs = new VisibleValue("LinInputs");
        public VisibleValue LinOutputs = new VisibleValue("LinOutputs");
        public bool LinOutJac = false;
        public bool LinOutMod = false;
        public VisibleValue WrVTK = new VisibleValue("WrVTK");
        public VisibleValue VTK_type = new VisibleValue("VTK_type");
        public bool VTK_fields = false;
        public VisibleValue VTK_fps = new VisibleValue("VTK_fps");
    }

    //叶片几何及结构属性输入文件（IEA-15-240-RWT_ElastoDyn_blade.dat）		
    //			
    public partial class ElastoDyn_blade : VisibleValue
    {
        public ElastoDyn_blade() : base(string.Empty) { }
        public ElastoDyn_blade(string namestring) : base(namestring) { }
        public VisibleValue NBlInpSt = new VisibleValue("NBlInpSt");
        public VisibleValue BldFlDmp1 = new VisibleValue("BldFlDmp1");
        public VisibleValue BldFlDmp2 = new VisibleValue("BldFlDmp2");
        public VisibleValue BldEdDmp1 = new VisibleValue("BldEdDmp1");
        public VisibleValue FlStTunr1 = new VisibleValue("FlStTunr1");
        public VisibleValue FlStTunr2 = new VisibleValue("FlStTunr2");
        public VisibleValue AdjBlMs = new VisibleValue("AdjBlMs");
        public VisibleValue AdjFlSt = new VisibleValue("AdjFlSt");
        public VisibleValue AdjEdSt = new VisibleValue("AdjEdSt");
        // public VisibleMatrix BlFract = new VisibleMatrix("BlFract");
        // public VisibleMatrix PitchAxis = new VisibleMatrix("PitchAxis");
        // public VisibleMatrix StrcTwst = new VisibleMatrix("StrcTwst");
        // public VisibleMatrix BMassDen = new VisibleMatrix("BMassDen");
        // public VisibleMatrix FlpStff = new VisibleMatrix("FlpStff");
        // public VisibleMatrix EdgStff = new VisibleMatrix("EdgStff");
        // public VisibleMatrix BldFl1Sh = new VisibleMatrix("BldFl1Sh(2-6)");
        // public VisibleMatrix BldFl2Sh = new VisibleMatrix("BldFl2Sh(2-6)");
        // public VisibleMatrix BldEdgSh = new VisibleMatrix("BldEdgSh(2-6)");
    }

    //叶片气动信息输入文件（IEA-15-240-RWT_AeroDyn15_blade.dat）		
    //			
    public partial class AeroDyn15_blade : VisibleValue
    {
        public AeroDyn15_blade() : base(string.Empty) { }
        public AeroDyn15_blade(string namestring) : base(namestring) { }
        // public VisibleMatrix NumBlNds = new VisibleMatrix("NumBlNds");
        // public VisibleMatrix BlSpn = new VisibleMatrix("BlSpn");
        // public VisibleMatrix BlCrvAC = new VisibleMatrix("BlCrvAC");
        // public VisibleMatrix BlSwpAC = new VisibleMatrix("BlSwpAC");
        // public VisibleMatrix BlCrvAng = new VisibleMatrix("BlCrvAng");
        // public VisibleMatrix BlTwist = new VisibleMatrix("BlTwist");
        // public VisibleMatrix BlChord = new VisibleMatrix("BlChord");
        // public VisibleMatrix BlAFID = new VisibleMatrix("BlAFID");
    }

    //气动信息输入文件（IEA-15-240-RWT_AeroDyn15.dat）					

    public partial class AeroDyn15 : VisibleValue
    {
        public AeroDyn15() : base(string.Empty) { }
        public AeroDyn15(string namestring) : base(namestring) { }
        public bool Echo = false;
        public VisibleValue DTAero = new VisibleValue("DTAero");
        public VisibleValue WakeMod = new VisibleValue("WakeMod");
        public VisibleValue AFAeroMod = new VisibleValue("AFAeroMod");
        public VisibleValue TwrPotent = new VisibleValue("TwrPotent");
        public bool TwrShadow = false;
        public bool TwrAero = false;
        public bool FrozenWake = false;
        public bool CavitCheck = false;
        public bool CompAA = false;
        public VisibleValue AA_InputFile = new VisibleValue("AA_InputFile");
        public VisibleValue AirDens = new VisibleValue("AirDens");
        public VisibleValue KinVisc = new VisibleValue("KinVisc");
        public VisibleValue SpdSound = new VisibleValue("SpdSound");
        public VisibleValue Patm = new VisibleValue("Patm");
        public VisibleValue Pvap = new VisibleValue("Pvap");
        public VisibleValue FluidDepth = new VisibleValue("FluidDepth");
        public VisibleValue SkewMod = new VisibleValue("SkewMod");
        public VisibleValue SkewModFactor = new VisibleValue("SkewModFactor");
        public bool TipLoss = true;
        public bool HubLoss = true;
        public bool TanInd = true;
        public bool AIDrag = true;
        public bool TIDrag = true;
        public VisibleValue IndToler = new VisibleValue("IndToler");
        public VisibleValue MaxIter = new VisibleValue("MaxIter");
        public VisibleValue DBEMT_Mod = new VisibleValue("DBEMT_Mod");
        public VisibleValue tau1_const = new VisibleValue("tau1_const");
        public VisibleValue OLAFInputFileName = new VisibleValue("OLAFInputFileName");
        public VisibleValue UAMod = new VisibleValue("UAMod");
        public bool Flookup = true;
        public VisibleValue AFTabMod = new VisibleValue("AFTabMod");
        public VisibleValue InCol_Alfa = new VisibleValue("InCol_Alfa");
        public VisibleValue InCol_Cl = new VisibleValue("InCol_Cl");
        public VisibleValue InCol_Cd = new VisibleValue("InCol_Cd");
        public VisibleValue InCol_Cm = new VisibleValue("InCol_Cm");
        public VisibleValue InCol_Cpmin = new VisibleValue("InCol_Cpmin");
        public VisibleValue NumAFfiles = new VisibleValue("NumAFfiles");
        // public VisibleMatrix AFNames = new VisibleMatrix("AFNames");
        public bool UseBlCm = true;
        public VisibleValue ADBlFile1 = new VisibleValue("ADBlFile(1)");
        public VisibleValue ADBlFile2 = new VisibleValue("ADBlFile(2)");
        public VisibleValue ADBlFile3 = new VisibleValue("ADBlFile(3)");
        public VisibleValue NumTwrNds = new VisibleValue("NumTwrNds");
        // public VisibleMatrix TwrElev = new VisibleMatrix("TwrElev");
        // public VisibleMatrix TwrDiam = new VisibleMatrix("TwrDiam");
        // public VisibleMatrix TwrCd = new VisibleMatrix("TwrCd");
        public bool SumPrint = false;
        public VisibleValue NBlOuts = new VisibleValue("NBlOuts");
        // public VisibleMatrix BlOutNd = new VisibleMatrix("BlOutNd");
        public VisibleValue NTwOuts = new VisibleValue("NTwOuts");
        // public VisibleMatrix TwOutNd = new VisibleMatrix("TwOutNd");
        // public VisibleMatrix OutList = new VisibleMatrix("OutList");

    }

    //结构动力学（整机）输入文件（IEA-15-240-RWT-Monopile_ElastoDyn.dat）					

    public partial class Monopile_ElastoDyn : VisibleValue
    {
        public Monopile_ElastoDyn() : base(string.Empty) { }
        public Monopile_ElastoDyn(string namestring) : base(namestring) { }
        public bool Echo = false;
        public VisibleValue Method = new VisibleValue("Method");
        public VisibleValue DT = new VisibleValue("DT");
        public VisibleValue Gravity = new VisibleValue("Gravity");
        public bool FlapDOF1 = true;
        public bool FlapDOF2 = true;
        public bool EdgeDOF = true;
        public bool TeetDOF = false;
        public bool DrTrDOF = false;
        public bool GenDOF = true;
        public bool YawDOF = false;
        public bool TwFADOF1 = false;
        public bool TwFADOF2 = false;
        public bool TwSSDOF1 = false;
        public bool TwSSDOF2 = false;
        public bool PtfmSgDOF = false;
        public bool PtfmSwDOF = false;
        public bool PtfmHvDOF = false;
        public bool PtfmRDOF = false;
        public bool PtfmPDOF = false;
        public bool PtfmYDOF = false;
        public VisibleValue OoPDefl = new VisibleValue("OoPDefl");
        public VisibleValue IPDefl = new VisibleValue("IPDefl");
        public VisibleValue BlPitch1 = new VisibleValue("BlPitch(1)");
        public VisibleValue BlPitch2 = new VisibleValue("BlPitch(2)");
        public VisibleValue BlPitch3 = new VisibleValue("BlPitch(3)");
        public VisibleValue TeetDefl = new VisibleValue("TeetDefl");
        public VisibleValue Azimuth = new VisibleValue("Azimuth");
        public VisibleValue RotSpeed = new VisibleValue("RotSpeed");
        public VisibleValue NacYaw = new VisibleValue("NacYaw");
        public VisibleValue TTDspFA = new VisibleValue("TTDspFA");
        public VisibleValue TTDspSS = new VisibleValue("TTDspSS");
        public VisibleValue PtfmSurge = new VisibleValue("PtfmSurge");
        public VisibleValue PtfmSway = new VisibleValue("PtfmSway");
        public VisibleValue PtfmHeave = new VisibleValue("PtfmHeave");
        public VisibleValue PtfmRoll = new VisibleValue("PtfmRoll");
        public VisibleValue PtfmPitch = new VisibleValue("PtfmPitch");
        public VisibleValue PtfmYaw = new VisibleValue("PtfmYaw");
        public VisibleValue NumBl = new VisibleValue("NumBl");
        public VisibleValue TipRad = new VisibleValue("TipRad");
        public VisibleValue HubRad = new VisibleValue("HubRad");
        public VisibleValue PreCone1 = new VisibleValue("PreCone(1)");
        public VisibleValue PreCone2 = new VisibleValue("PreCone(2)");
        public VisibleValue PreCone3 = new VisibleValue("PreCone(3)");
        public VisibleValue HubCM = new VisibleValue("HubCM");
        public VisibleValue UndSling = new VisibleValue("UndSling");
        public VisibleValue Delta3 = new VisibleValue("Delta3");
        public VisibleValue AzimB1Up = new VisibleValue("AzimB1Up");
        public VisibleValue OverHang = new VisibleValue("OverHang");
        public VisibleValue ShftGagL = new VisibleValue("ShftGagL");
        public VisibleValue ShftTilt = new VisibleValue("ShftTilt");
        public VisibleValue NacCMxn = new VisibleValue("NacCMxn");
        public VisibleValue NacCMyn = new VisibleValue("NacCMyn");
        public VisibleValue NacCMzn = new VisibleValue("NacCMzn");
        public VisibleValue NcIMUxn = new VisibleValue("NcIMUxn");
        public VisibleValue NcIMUyn = new VisibleValue("NcIMUyn");
        public VisibleValue NcIMUzn = new VisibleValue("NcIMUzn");
        public VisibleValue Twr2Shft = new VisibleValue("Twr2Shft");
        public VisibleValue TowerHt = new VisibleValue("TowerHt");
        public VisibleValue TowerBsHt = new VisibleValue("TowerBsHt");
        public VisibleValue PtfmCMxt = new VisibleValue("PtfmCMxt");
        public VisibleValue PtfmCMyt = new VisibleValue("PtfmCMyt");
        public VisibleValue PtfmCMzt = new VisibleValue("PtfmCMzt");
        public VisibleValue PtfmRefzt = new VisibleValue("PtfmRefzt");
        public VisibleValue TipMass1 = new VisibleValue("TipMass(1)");
        public VisibleValue TipMass2 = new VisibleValue("TipMass(2)");
        public VisibleValue TipMass3 = new VisibleValue("TipMass(3)");
        public VisibleValue HubMass = new VisibleValue("HubMass");
        public VisibleValue HubIner = new VisibleValue("HubIner");
        public VisibleValue GenIner = new VisibleValue("GenIner");
        public VisibleValue NacMass = new VisibleValue("NacMass");
        public VisibleValue NacYIner = new VisibleValue("NacYIner");
        public VisibleValue YawBrMass = new VisibleValue("YawBrMass");
        public VisibleValue PtfmMass = new VisibleValue("PtfmMass");
        public VisibleValue PtfmRIner = new VisibleValue("PtfmRIner");
        public VisibleValue PtfmPIner = new VisibleValue("PtfmPIner");
        public VisibleValue PtfmYIner = new VisibleValue("PtfmYIner");
        public VisibleValue BldNodes = new VisibleValue("BldNodes");
        public VisibleValue BldFile1 = new VisibleValue("BldFile1");
        public VisibleValue BldFile2 = new VisibleValue("BldFile2");
        public VisibleValue BldFile3 = new VisibleValue("BldFile3");
        public VisibleValue TeetMod = new VisibleValue("TeetMod");
        public VisibleValue TeetDmpP = new VisibleValue("TeetDmpP");
        public VisibleValue TeetDmp = new VisibleValue("TeetDmp");
        public VisibleValue TeetCDmp = new VisibleValue("TeetCDmp");
        public VisibleValue TeetSStP = new VisibleValue("TeetSStP");
        public VisibleValue TeetHStP = new VisibleValue("TeetHStP");
        public VisibleValue TeetSSSp = new VisibleValue("TeetSSSp");
        public VisibleValue TeetHSSp = new VisibleValue("TeetHSSp");
        public VisibleValue GBoxEff = new VisibleValue("GBoxEff");
        public VisibleValue GBRatio = new VisibleValue("GBRatio");
        public VisibleValue DTTorSpr = new VisibleValue("DTTorSpr");
        public VisibleValue DTTorDmp = new VisibleValue("DTTorDmp");
        public bool Furling = false;
        public VisibleValue FurlFile = new VisibleValue("FurlFile");
        public VisibleValue TwrNodes = new VisibleValue("TwrNodes");
        public VisibleValue TwrFile = new VisibleValue("TwrFile");
        public bool SumPrint = false;
        public VisibleValue OutFile = new VisibleValue("OutFile");
        public bool TabDelim = true;
        public VisibleValue OutFmt = new VisibleValue("OutFmt");
        public VisibleValue TStart = new VisibleValue("TStart");
        public VisibleValue DecFact = new VisibleValue("DecFact");
        public VisibleValue NTwGages = new VisibleValue("NTwGages");
        // public VisibleMatrix TwrGagNd = new VisibleMatrix("TwrGagNd");
        public VisibleValue NBlGages = new VisibleValue("NBlGages");
        // public VisibleMatrix BldGagNd = new VisibleMatrix("BldGagNd");
        // public VisibleMatrix OutList = new VisibleMatrix("OutList");
    }

    //塔筒信息输入文件（IEA-15-240-RWT-Monopile_ElastoDyn_tower.dat）					

    public partial class Monopile_ElastoDyn_tower : VisibleValue
    {
        public Monopile_ElastoDyn_tower() : base(string.Empty) { }
        public Monopile_ElastoDyn_tower(string namestring) : base(namestring) { }
        public VisibleValue NTwInpSt = new VisibleValue("NTwInpSt");
        public VisibleValue TwrFADmp1 = new VisibleValue("TwrFADmp(1)");
        public VisibleValue TwrFADmp2 = new VisibleValue("TwrFADmp(2)");
        public VisibleValue TwrSSDmp1 = new VisibleValue("TwrSSDmp(1)");
        public VisibleValue TwrSSDmp2 = new VisibleValue("TwrSSDmp(2)");
        public VisibleValue FAStTunr1 = new VisibleValue("FAStTunr(1)");
        public VisibleValue FAStTunr2 = new VisibleValue("FAStTunr(2)");
        public VisibleValue SSStTunr1 = new VisibleValue("SSStTunr(1)");
        public VisibleValue SSStTunr2 = new VisibleValue("SSStTunr(2)");
        public VisibleValue AdjTwMa = new VisibleValue("AdjTwMa");
        public VisibleValue AdjFASt = new VisibleValue("AdjFASt");
        public VisibleValue AdjSSSt = new VisibleValue("AdjSSSt");
        // public VisibleMatrix HtFract = new VisibleMatrix("HtFract");
        // public VisibleMatrix TMassDen = new VisibleMatrix("TMassDen");
        // public VisibleMatrix TwFAStif = new VisibleMatrix("TwFAStif");
        // public VisibleMatrix TwSSStif = new VisibleMatrix("TwSSStif");
        // public VisibleMatrix TwFAM1Sh = new VisibleMatrix("TwFAM1Sh(2-6)");
        // public VisibleMatrix TwFAM2Sh = new VisibleMatrix("TwFAM2Sh(2-6)");
        // public VisibleMatrix TwSSM1Sh = new VisibleMatrix("TwSSM1Sh(2-6)");
        // public VisibleMatrix TwSSM2Sh = new VisibleMatrix("TwSSM2Sh(2-6)");
    }

    //翼型信息输入文件（IEA-15-240-RWT_AeroDyn15_Polar_00.dat)

    public partial class AeroDyn15_Polar_00 : VisibleValue
    {
        public AeroDyn15_Polar_00() : base(string.Empty) { }
        public AeroDyn15_Polar_00(string namestring) : base(namestring) { }
        public VisibleValue InterpOrd = new VisibleValue("InterpOrd");
        public VisibleValue NonDimArea = new VisibleValue("NonDimArea");
        public VisibleValue NumCoords = new VisibleValue("NumCoords");
        public VisibleValue BL_file = new VisibleValue("BL_file");
        public VisibleValue NumTabs = new VisibleValue("NumTabs");
        public VisibleValue Re = new VisibleValue("Re");
        public VisibleValue UserProp = new VisibleValue("UserProp");
        public bool InclUAdata = true;
        public VisibleValue alpha0 = new VisibleValue("alpha0");
        public VisibleValue alpha1 = new VisibleValue("alpha1");
        public VisibleValue alpha2 = new VisibleValue("alpha2");
        public VisibleValue eta_e = new VisibleValue("eta_e");
        public VisibleValue C_nalpha = new VisibleValue("C_nalpha");
        public VisibleValue T_f0 = new VisibleValue("T_f0");
        public VisibleValue T_V0 = new VisibleValue("T_V0");
        public VisibleValue T_p = new VisibleValue("T_p");
        public VisibleValue T_VL = new VisibleValue("T_VL");
        public VisibleValue b1 = new VisibleValue("b1");
        public VisibleValue b2 = new VisibleValue("b2");
        public VisibleValue b5 = new VisibleValue("b5");
        public VisibleValue A1 = new VisibleValue("A1");
        public VisibleValue A2 = new VisibleValue("A2");
        public VisibleValue A5 = new VisibleValue("A5");
        public VisibleValue S1 = new VisibleValue("S1");
        public VisibleValue S2 = new VisibleValue("S2");
        public VisibleValue S3 = new VisibleValue("S3");
        public VisibleValue S4 = new VisibleValue("S4");
        public VisibleValue Cn1 = new VisibleValue("Cn1");
        public VisibleValue Cn2 = new VisibleValue("Cn2");
        public VisibleValue St_sh = new VisibleValue("St_sh");
        public VisibleValue Cd0 = new VisibleValue("Cd0");
        public VisibleValue Cm0 = new VisibleValue("Cm0");
        public VisibleValue k0 = new VisibleValue("k0");
        public VisibleValue k1 = new VisibleValue("k1");
        public VisibleValue k2 = new VisibleValue("k2");
        public VisibleValue k3 = new VisibleValue("k3");
        public VisibleValue k1_hat = new VisibleValue("k1_hat");
        public VisibleValue x_cp_bar = new VisibleValue("x_cp_bar");
        public VisibleValue UACutout = new VisibleValue("UACutout");
        public VisibleValue filtCutOff = new VisibleValue("filtCutOff");
        public VisibleValue NumAlf = new VisibleValue("NumAlf");
        public VisibleValue Alpha = new VisibleValue("Alpha");
        // public VisibleMatrix Cl = new VisibleMatrix("Cl");
        // public VisibleMatrix Cd = new VisibleMatrix("Cd");
        // public VisibleMatrix Cm = new VisibleMatrix("Cm");
    }

    //翼型外型信息输入文件（IEA-15-240-RWT_AeroDyn15_Polar_00_Coords.txt）
    //					
    public partial class AeroDyn15_Polar_00_Coords : VisibleValue
    {
        public AeroDyn15_Polar_00_Coords() : base(string.Empty) { }
        public AeroDyn15_Polar_00_Coords(string name) : base(name) { }
        public VisibleValue NumCooeds = new VisibleValue("NumCoords");
        public VisibleValue x1 = new VisibleValue("x1");//由于变量重名问题，直接命名x1，x2
        public VisibleValue y1 = new VisibleValue("y1");
        // public VisibleMatrix x2 = new VisibleMatrix("x2");
        // public VisibleMatrix y2 = new VisibleMatrix("y2");
    }

    //风输入文件（IEA-15-240-RWT_InflowFile.dat）					

    public partial class InflowFile : VisibleValue
    {
        public InflowFile() : base(string.Empty) { }
        public InflowFile(string name) : base(name) { }
        public bool Echo = false;
        public VisibleValue WindType = new VisibleValue("WindType");
        public VisibleValue PropagationDir = new VisibleValue("PropagationDir");
        public VisibleValue NWindVel = new VisibleValue("NWindVel");
        // public VisibleMatrix WindVxiList = new VisibleMatrix("WindVxiList");
        // public VisibleMatrix WindVyiList = new VisibleMatrix("WindVyiList");
        // public VisibleMatrix WindVziList = new VisibleMatrix("WindVziList");
        public VisibleValue HWindSpeed = new VisibleValue("HWindSpeed");
        public VisibleValue RefHt1 = new VisibleValue("RefHt");
        public VisibleValue PLexp = new VisibleValue("PLexp");
        public VisibleValue Filename1 = new VisibleValue("Filename");
        public VisibleValue RefHt2 = new VisibleValue("RefHt");
        public VisibleValue RefLength = new VisibleValue("RefLength");
        public VisibleValue Filename2 = new VisibleValue("Filename");
        public VisibleValue FilenameRoot = new VisibleValue("FilenameRoot");
        public bool TowerFile = false;
        public VisibleValue FileName_u = new VisibleValue("FileName_u");
        public VisibleValue FileName_v = new VisibleValue("FileName_v");
        public VisibleValue FileName_w = new VisibleValue("FileName_w");
        public VisibleValue nx = new VisibleValue("nx");
        public VisibleValue ny = new VisibleValue("ny");
        public VisibleValue nz = new VisibleValue("nz");
        public VisibleValue dx = new VisibleValue("dx");
        public VisibleValue dy = new VisibleValue("dy");
        public VisibleValue dz = new VisibleValue("dz");
        public VisibleValue RefHt = new VisibleValue("RefHt");
        public VisibleValue ScaleMethod = new VisibleValue("ScaleMethod");
        public VisibleValue SFx = new VisibleValue("SFx");
        public VisibleValue SFy = new VisibleValue("SFy");
        public VisibleValue SFz = new VisibleValue("SFz");
        public VisibleValue SigmaFx = new VisibleValue("SigmaFx");
        public VisibleValue SigmaFy = new VisibleValue("SigmaFy");
        public VisibleValue SigmaFz = new VisibleValue("SigmaFz");
        public VisibleValue URef = new VisibleValue("URef");
        public VisibleValue WindProfile = new VisibleValue("WindProfile");
        public VisibleValue PLExp = new VisibleValue("PLExp");
        public VisibleValue Z0 = new VisibleValue("Z0");
        public bool SumPrint = false;
        // public VisibleMatrix OutList = new VisibleMatrix("OutList");
    }

    //控制模块（IEA-15-240-RWT-Monopile_ServoDyn.dat）					

    public partial class Monopile_ServoDyn : VisibleValue
    {
        public Monopile_ServoDyn() : base(string.Empty) { }
        public Monopile_ServoDyn(string namestring) : base(namestring) { }
        public bool Echo = false;
        public VisibleValue DT = new VisibleValue("DT");
        public VisibleValue PCMode = new VisibleValue("PCMode");
        public VisibleValue TPCOn = new VisibleValue("TPCOn");
        public VisibleValue TPitManS1 = new VisibleValue("TPitManS(1)");
        public VisibleValue TPitManS2 = new VisibleValue("TPitManS(2)");
        public VisibleValue TPitManS3 = new VisibleValue("TPitManS(3)");
        public VisibleValue PitManRat1 = new VisibleValue("PitManRat(1)");
        public VisibleValue PitManRat2 = new VisibleValue("PitManRat(2)");
        public VisibleValue PitManRat3 = new VisibleValue("PitManRat(3)");
        public VisibleValue BlPitchF1 = new VisibleValue("BlPitchF(1)");
        public VisibleValue BlPitchF2 = new VisibleValue("BlPitchF(2)");
        public VisibleValue BlPitchF3 = new VisibleValue("BlPitchF(3)");
        public VisibleValue VSContrl = new VisibleValue("VSContrl");
        public VisibleValue GenModel = new VisibleValue("GenModel");
        public VisibleValue GenEff = new VisibleValue("GenEff");
        public bool GenTiStr = false;
        public bool GenTiStp = false;
        public VisibleValue SpdGenOn = new VisibleValue("SpdGenOn");
        public VisibleValue TimGenOn = new VisibleValue("TimGenOn");
        public VisibleValue TimGenOf = new VisibleValue("TimGenOf");
        public VisibleValue VS_RtGnSp = new VisibleValue("VS_RtGnSp");
        public VisibleValue VS_RtTq = new VisibleValue("VS_RtTq");
        public VisibleValue VS_Rgn2K = new VisibleValue("VS_Rgn2K");
        public VisibleValue VS_SlPc = new VisibleValue("VS_SlPc");
        public VisibleValue SIG_SlPc = new VisibleValue("SIG_SlPc");
        public VisibleValue SIG_SySp = new VisibleValue("SIG_SySp");
        public VisibleValue SIG_RtTq = new VisibleValue("SIG_RtTq");
        public VisibleValue SIG_PORt = new VisibleValue("SIG_PORt");
        public VisibleValue TEC_Freq = new VisibleValue("TEC_Freq");
        public VisibleValue TEC_NPol = new VisibleValue("TEC_NPol");
        public VisibleValue TEC_SRes = new VisibleValue("TEC_SRes");
        public VisibleValue TEC_RRes = new VisibleValue("TEC_RRes");
        public VisibleValue TEC_VLL = new VisibleValue("TEC_VLL");
        public VisibleValue TEC_SLR = new VisibleValue("TEC_SLR");
        public VisibleValue TEC_RLR = new VisibleValue("TEC_RLR");
        public VisibleValue TEC_MR = new VisibleValue("TEC_MR");
        public VisibleValue HSSBrMode = new VisibleValue("HSSBrMode");
        public VisibleValue THSSBrDp = new VisibleValue("THSSBrDp");
        public VisibleValue HSSBrDT = new VisibleValue("HSSBrDT");
        public VisibleValue HSSBrTqF = new VisibleValue("HSSBrTqF");
        public VisibleValue YCMode = new VisibleValue("YCMode");
        public VisibleValue TYCOn = new VisibleValue("TYCOn");
        public VisibleValue YawNeut = new VisibleValue("YawNeut");
        public VisibleValue YawSpr = new VisibleValue("YawSpr");
        public VisibleValue YawDamp = new VisibleValue("YawDamp");
        public VisibleValue TYawManS = new VisibleValue("TYawManS");
        public VisibleValue YawManRat = new VisibleValue("YawManRat");
        public VisibleValue NacYawF = new VisibleValue("NacYawF");
        public bool CompNTMD = false;
        public VisibleValue NTMDfile = new VisibleValue("NTMDfile");
        public bool CompTTMD = false;
        public VisibleValue TTMDfile = new VisibleValue("TTMDfile");
        public VisibleValue DLL_FileName = new VisibleValue("DLL_FileName");
        public VisibleValue DLL_InFile = new VisibleValue("DLL_InFile");
        public VisibleValue DLL_ProcName = new VisibleValue("DLL_ProcName");
        public VisibleValue DLL_DT = new VisibleValue("DLL_DT");
        public bool DLL_Ramp = false;
        public VisibleValue BPCutoff = new VisibleValue("BPCutoff");
        public VisibleValue NacYaw_North = new VisibleValue("NacYaw_North");
        public VisibleValue Ptch_Cntrl = new VisibleValue("Ptch_Cntrl");
        public VisibleValue Ptch_SetPnt = new VisibleValue("Ptch_SetPnt");
        public VisibleValue Ptch_Min = new VisibleValue("Ptch_Min");
        public VisibleValue Ptch_Max = new VisibleValue("Ptch_Max");
        public VisibleValue PtchRate_Min = new VisibleValue("PtchRate_Min");
        public VisibleValue PtchRate_Max = new VisibleValue("PtchRate_Max");
        public VisibleValue Gain_OM = new VisibleValue("Gain_OM");
        public VisibleValue GenSpd_MinOM = new VisibleValue("GenSpd_MinOM");
        public VisibleValue GenSpd_MaxOM = new VisibleValue("GenSpd_MaxOM");
        public VisibleValue GenSpd_Dem = new VisibleValue("GenSpd_Dem");
        public VisibleValue GenTrq_Dem = new VisibleValue("GenTrq_Dem");
        public VisibleValue GenPwr_Dem = new VisibleValue("GenPwr_Dem");
        public VisibleValue DLL_NumTrq = new VisibleValue("DLL_NumTrq");
        // public VisibleMatrix GenSpd_TLU = new VisibleMatrix("GenSpd_TLU");
        // public VisibleMatrix GenTrq_TLU = new VisibleMatrix("GenTrq_TLU");
        public bool SumPrint = false;
        public VisibleValue OutFile = new VisibleValue("OutFile");
        public bool TabDelim = false;
        public VisibleValue OutFmt = new VisibleValue("OutFmt");
        public VisibleValue TStart = new VisibleValue("TStart");
        // public VisibleMatrix OutList = new VisibleMatrix("OutList");
    }

    //非线性输入文件（IEA-15-240-RWT_BeamDyn.dat）					

    public partial class BeamDyn : VisibleValue
    {
        public BeamDyn() : base(string.Empty) { }
        public BeamDyn(string namestring) : base(namestring) { }
        public bool Echo = false;
        public bool QuasiStaticInit = false;
        public VisibleValue rhoinf = new VisibleValue("rhoinf");
        public VisibleValue quadrature = new VisibleValue("quadrature");
        public VisibleValue refine = new VisibleValue("refine");
        public VisibleValue n_fact = new VisibleValue("n_fact");
        public VisibleValue DTBeam = new VisibleValue("DTBeam");
        public VisibleValue load_retries = new VisibleValue("load_retries");
        public VisibleValue NRMax = new VisibleValue("NRMax");
        public VisibleValue stop_tol = new VisibleValue("stop_tol");
        public bool tngt_stf_fd = false;
        public bool tngt_stf_comp = false;
        public VisibleValue tngt_stf_pert = new VisibleValue("tngt_stf_pert");
        public VisibleValue tngt_stf_difftol = new VisibleValue("tngt_stf_difftol");
        public bool RotStates = false;
        public VisibleValue member_total = new VisibleValue("member_total");
        public VisibleValue kp_total = new VisibleValue("kp_total");
        // public VisibleMatrix kp_xr = new VisibleMatrix("kp_xr");
        // public VisibleMatrix kp_yr = new VisibleMatrix("kp_yr");
        // public VisibleMatrix kp_zr = new VisibleMatrix("kp_zr");
        // public VisibleMatrix initial_twist = new VisibleMatrix("initial_twist");
        public VisibleValue order_elem = new VisibleValue("order_elem");
        public VisibleValue BldFile = new VisibleValue("BldFile");
        public bool UsePitchAct = false;
        public VisibleValue PitchJ = new VisibleValue("PitchJ");
        public VisibleValue PitchK = new VisibleValue("PitchK");
        public VisibleValue PitchC = new VisibleValue("PitchC");
        public bool SumPrint = false;
        public VisibleValue OutFmt = new VisibleValue("OutFmt");
        public VisibleValue NNodeOuts = new VisibleValue("NNodeOuts");
        public VisibleValue OutNd = new VisibleValue("OutNd");
        // public VisibleMatrix OutList = new VisibleMatrix("OutList");
    }

    //非线性叶片信息输入文件（IEA-15-240-RWT_BeamDyn_blade.dat）					

    public partial class BeamDyn_blade : VisibleValue
    {
        public BeamDyn_blade() : base(string.Empty) { }
        public BeamDyn_blade(string namestring) : base(namestring) { }
        public VisibleValue station_total = new VisibleValue("station_total");
        public VisibleValue damp_type = new VisibleValue("damp_type");
        public VisibleValue mu1 = new VisibleValue("mu1");
        public VisibleValue mu2 = new VisibleValue("mu2");
        public VisibleValue mu3 = new VisibleValue("mu3");
        public VisibleValue mu4 = new VisibleValue("mu4");
        public VisibleValue mu5 = new VisibleValue("mu5");
        public VisibleValue mu6 = new VisibleValue("mu6");
        // public VisibleMatrix location = new VisibleMatrix("location");
        // public VisibleMatrix Stiffness_matrix = new VisibleMatrix("Stiffness_matrix");
        // public VisibleMatrix Mass_matrix = new VisibleMatrix("Mass_matrix");
    }

    //固定值

    public partial class Constan : VisibleValue
    {
        public Constan() : base(string.Empty) { }
        public Constan(string name) : base(name) { }
        public VisibleValue g = new VisibleValue("g");
        public VisibleValue MiuAir = new VisibleValue("MiuAir");
        public VisibleValue rhoAir = new VisibleValue("rhoAir");
    }*/
}
