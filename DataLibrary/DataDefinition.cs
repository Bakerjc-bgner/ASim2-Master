using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Simulation_0
    {
        public Simulation_0()
        {
            for(int i = 0; i < 50; i++)
            {
                Airfoil.Add(new Airfoil_152());
            }
        }
        public WindTurbine_1 WindTurbine = new WindTurbine_1();
        public List<Airfoil_152> Airfoil = new List<Airfoil_152>();
        public Environment_184 Environment = new Environment_184();
        public SimulationControl_219 SimulationControl = new SimulationControl_219();
        public Outputs_261 Outputs = new Outputs_261();
    }
    public class WindTurbine_1
    {
        public TurbineConfiguration_2 TurbineConfiguration = new TurbineConfiguration_2();
        public MassInfo_18 MassInfo = new MassInfo_18();
        public Blade_29 Blade = new Blade_29();
        public Tower_75 Tower = new Tower_75();
        public DriveTrain_98 DriveTrain = new DriveTrain_98();
        public Control_103 Control = new Control_103();
    }
    public class TurbineConfiguration_2
    {
        public void setValue(List<object> obj)
        {
            NumBl.value = int.Parse((string)obj[0]);
            TipRad.value = double.Parse((string)obj[1]);
            HubRad.value = double.Parse((string)obj[2]);
            PreCone_1.value = double.Parse((string)obj[3]);
            HubCM.value = double.Parse((string)obj[4]);
            AzimB1Up.value = double.Parse((string)obj[5]);
            OverHang.value = double.Parse((string)obj[6]);
            ShftGagL.value = double.Parse((string)obj[7]);
            ShftTilt.value = double.Parse((string)obj[8]);
            NacCMxn.value = double.Parse((string)obj[9]);
            NacCMyn.value = double.Parse((string)obj[10]);
            NacCMzn.value = double.Parse((string)obj[11]);
            Twr2Shft.value = double.Parse((string)obj[12]);
            TowerHt.value = double.Parse((string)obj[13]);
            TowerBsHt.value = double.Parse((string)obj[14]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(NumBl.value));
            obj.Add(Convert.ToString(TipRad.value));
            obj.Add(Convert.ToString(HubRad.value));
            obj.Add(Convert.ToString(PreCone_1.value));
            obj.Add(Convert.ToString(HubCM.value));
            obj.Add(Convert.ToString(AzimB1Up.value));
            obj.Add(Convert.ToString(OverHang.value));
            obj.Add(Convert.ToString(ShftGagL.value));
            obj.Add(Convert.ToString(ShftTilt.value));
            obj.Add(Convert.ToString(NacCMxn.value));
            obj.Add(Convert.ToString(NacCMyn.value));
            obj.Add(Convert.ToString(NacCMzn.value));
            obj.Add(Convert.ToString(Twr2Shft.value));
            obj.Add(Convert.ToString(TowerHt.value));
            obj.Add(Convert.ToString(TowerBsHt.value));
            return obj;
        }
        public NumBl_3 NumBl = new NumBl_3();
        public TipRad_4 TipRad = new TipRad_4();
        public HubRad_5 HubRad = new HubRad_5();
        public PreCone_1_6 PreCone_1 = new PreCone_1_6();
        public HubCM_7 HubCM = new HubCM_7();
        public AzimB1Up_8 AzimB1Up = new AzimB1Up_8();
        public OverHang_9 OverHang = new OverHang_9();
        public ShftGagL_10 ShftGagL = new ShftGagL_10();
        public ShftTilt_11 ShftTilt = new ShftTilt_11();
        public NacCMxn_12 NacCMxn = new NacCMxn_12();
        public NacCMyn_13 NacCMyn = new NacCMyn_13();
        public NacCMzn_14 NacCMzn = new NacCMzn_14();
        public Twr2Shft_15 Twr2Shft = new Twr2Shft_15();
        public TowerHt_16 TowerHt = new TowerHt_16();
        public TowerBsHt_17 TowerBsHt = new TowerBsHt_17();
    }
    public class NumBl_3
    {
        public int value = 3;
    }
    public class TipRad_4
    {
        public double value = new double();
    }
    public class HubRad_5
    {
        public double value = new double();
    }
    public class PreCone_1_6
    {
        public double value = new double();
    }
    public class HubCM_7
    {
        public double value = new double();
    }
    public class AzimB1Up_8
    {
        public double value = new double();
    }
    public class OverHang_9
    {
        public double value = new double();
    }
    public class ShftGagL_10
    {
        public double value = new double();
    }
    public class ShftTilt_11
    {
        public double value = new double();
    }
    public class NacCMxn_12
    {
        public double value = new double();
    }
    public class NacCMyn_13
    {
        public double value = new double();
    }
    public class NacCMzn_14
    {
        public double value = new double();
    }
    public class Twr2Shft_15
    {
        public double value = new double();
    }
    public class TowerHt_16
    {
        public double value = new double();
    }
    public class TowerBsHt_17
    {
        public double value = new double();
    }
    public class MassInfo_18
    {
        public void setValue(List<object> obj)
        {
            TipMass_1.value = double.Parse((string)obj[0]);
            TipMass_2.value = double.Parse((string)obj[1]);
            TipMass_3.value = double.Parse((string)obj[2]);
            HubMass.value = double.Parse((string)obj[3]);
            HubIner.value = double.Parse((string)obj[4]);
            GenIner.value = double.Parse((string)obj[5]);
            NacMass.value = double.Parse((string)obj[6]);
            NacYIner.value = double.Parse((string)obj[7]);
            YawBrMass.value = double.Parse((string)obj[8]);
            PtfmMass.value = double.Parse((string)obj[9]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(TipMass_1.value));
            obj.Add(Convert.ToString(TipMass_2.value));
            obj.Add(Convert.ToString(TipMass_3.value));
            obj.Add(Convert.ToString(HubMass.value));
            obj.Add(Convert.ToString(HubIner.value));
            obj.Add(Convert.ToString(GenIner.value));
            obj.Add(Convert.ToString(NacMass.value));
            obj.Add(Convert.ToString(NacYIner.value));
            obj.Add(Convert.ToString(YawBrMass.value));
            obj.Add(Convert.ToString(PtfmMass.value));
            return obj;
        }
        public TipMass_1_19 TipMass_1 = new TipMass_1_19();
        public TipMass_2_20 TipMass_2 = new TipMass_2_20();
        public TipMass_3_21 TipMass_3 = new TipMass_3_21();
        public HubMass_22 HubMass = new HubMass_22();
        public HubIner_23 HubIner = new HubIner_23();
        public GenIner_24 GenIner = new GenIner_24();
        public NacMass_25 NacMass = new NacMass_25();
        public NacYIner_26 NacYIner = new NacYIner_26();
        public YawBrMass_27 YawBrMass = new YawBrMass_27();
        public PtfmMass_28 PtfmMass = new PtfmMass_28();
    }
    public class TipMass_1_19
    {
        public double value = new double();
    }
    public class TipMass_2_20
    {
        public double value = new double();
    }
    public class TipMass_3_21
    {
        public double value = new double();
    }
    public class HubMass_22
    {
        public double value = new double();
    }
    public class HubIner_23
    {
        public double value = new double();
    }
    public class GenIner_24
    {
        public double value = new double();
    }
    public class NacMass_25
    {
        public double value = new double();
    }
    public class NacYIner_26
    {
        public double value = new double();
    }
    public class YawBrMass_27
    {
        public double value = new double();
    }
    public class PtfmMass_28
    {
        public double value = new double();
    }
    public class Blade_29
    {
        public Blade_29()
        {
            BladeStation.Add(new BladeStation_31());
            NonlinearKeyPoints.Add(new NonlinearKeyPoints_45());
            BladeModes.Add(new BladeModes_63());
        }
        public void setValue(List<object> obj)
        {
            NumBlNds.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(NumBlNds.value));
            return obj;
        }
        public NumBlNds_30 NumBlNds = new NumBlNds_30();
        public List<BladeStation_31> BladeStation = new List<BladeStation_31>();
        public List<NonlinearKeyPoints_45> NonlinearKeyPoints = new List<NonlinearKeyPoints_45>();
        public NonlinearBladeInfo_50 NonlinearBladeInfo = new NonlinearBladeInfo_50();
        public List<SectionMatrix_59> SectionMatrix = new List<SectionMatrix_59>();
        public List<BladeModes_63> BladeModes = new List<BladeModes_63>();
    }
    public class NumBlNds_30
    {
        public int value = new int();
    }
    public class BladeStation_31
    {
        public void setValue(List<object> obj)
        {
            BlFract.value = double.Parse((string)obj[0]);
            PitchAxis.value = double.Parse((string)obj[1]);
            BMassDen.value = double.Parse((string)obj[2]);
            FlpStff.value = double.Parse((string)obj[3]);
            EdgStff.value = double.Parse((string)obj[4]);
            BlSpn.value = double.Parse((string)obj[5]);
            BlCrvAC.value = double.Parse((string)obj[6]);
            BlSwpAC.value = double.Parse((string)obj[7]);
            BlCrvAng.value = double.Parse((string)obj[8]);
            BlTwist.value = double.Parse((string)obj[9]);
            BlChord.value = double.Parse((string)obj[10]);
            BlAFID.value = int.Parse((string)obj[11]);
            BIThickness.value = double.Parse((string)obj[12]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(BlFract.value));
            obj.Add(Convert.ToString(PitchAxis.value));
            obj.Add(Convert.ToString(BMassDen.value));
            obj.Add(Convert.ToString(FlpStff.value));
            obj.Add(Convert.ToString(EdgStff.value));
            obj.Add(Convert.ToString(BlSpn.value));
            obj.Add(Convert.ToString(BlCrvAC.value));
            obj.Add(Convert.ToString(BlSwpAC.value));
            obj.Add(Convert.ToString(BlCrvAng.value));
            obj.Add(Convert.ToString(BlTwist.value));
            obj.Add(Convert.ToString(BlChord.value));
            obj.Add(Convert.ToString(BlAFID.value));
            obj.Add(Convert.ToString(BIThickness.value));
            return obj;
        }
        public BlFract_32 BlFract = new BlFract_32();
        public PitchAxis_33 PitchAxis = new PitchAxis_33();
        public BMassDen_34 BMassDen = new BMassDen_34();
        public FlpStff_35 FlpStff = new FlpStff_35();
        public EdgStff_36 EdgStff = new EdgStff_36();
        public BlSpn_37 BlSpn = new BlSpn_37();
        public BlCrvAC_38 BlCrvAC = new BlCrvAC_38();
        public BlSwpAC_39 BlSwpAC = new BlSwpAC_39();
        public BlCrvAng_40 BlCrvAng = new BlCrvAng_40();
        public BlTwist_41 BlTwist = new BlTwist_41();
        public BlChord_42 BlChord = new BlChord_42();
        public BlAFID_43 BlAFID = new BlAFID_43();
        public BIThickness_44 BIThickness = new BIThickness_44();
    }
    public class BlFract_32
    {
        public double value = new double();
    }
    public class PitchAxis_33
    {
        public double value = new double();
    }
    public class BMassDen_34
    {
        public double value = new double();
    }
    public class FlpStff_35
    {
        public double value = new double();
    }
    public class EdgStff_36
    {
        public double value = new double();
    }
    public class BlSpn_37
    {
        public double value = new double();
    }
    public class BlCrvAC_38
    {
        public double value = new double();
    }
    public class BlSwpAC_39
    {
        public double value = new double();
    }
    public class BlCrvAng_40
    {
        public double value = new double();
    }
    public class BlTwist_41
    {
        public double value = new double();
    }
    public class BlChord_42
    {
        public double value = new double();
    }
    public class BlAFID_43
    {
        public int value = new int();
    }
    public class BIThickness_44
    {
        public double value = new double();
    }
    public class NonlinearKeyPoints_45
    {
        public void setValue(List<object> obj)
        {
            kp_xr.value = double.Parse((string)obj[0]);
            kp_yr.value = double.Parse((string)obj[1]);
            kp_zr.value = double.Parse((string)obj[2]);
            initial_twist.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(kp_xr.value));
            obj.Add(Convert.ToString(kp_yr.value));
            obj.Add(Convert.ToString(kp_zr.value));
            obj.Add(Convert.ToString(initial_twist.value));
            return obj;
        }
        public kp_xr_46 kp_xr = new kp_xr_46();
        public kp_yr_47 kp_yr = new kp_yr_47();
        public kp_zr_48 kp_zr = new kp_zr_48();
        public initial_twist_49 initial_twist = new initial_twist_49();
    }
    public class kp_xr_46
    {
        public double value = new double();
    }
    public class kp_yr_47
    {
        public double value = new double();
    }
    public class kp_zr_48
    {
        public double value = new double();
    }
    public class initial_twist_49
    {
        public double value = new double();
    }
    public class NonlinearBladeInfo_50
    {
        public NonlinearBladeInfo_50()
        {
            
            double[] dam = { 0.01, 0.01, 0.01, 0.01, 0.01, 0.01, 0.01 };
            for (int i = 0; i < 2; i++)
            {
                member_number[i] = new member_number_53();
            }
            for (int i = 0; i < 6; i++)
            {
                dampings.Add(new dampings_58());
                dampings[i].value = dam[i];
            }
        }
        public void setValue(List<object> obj)
        {
            member_total.value = int.Parse((string)obj[0]);
            kp_total.value = int.Parse((string)obj[1]);
            List<string> str1 = (List<string>)obj[2];
            for (int i = 0; i < 2; i++)
            {
                member_number[i].value = int.Parse(str1[i]);
            }
            order_elem.value = int.Parse((string)obj[3]);
            BldFile.value = (string)obj[4];
            station_total.value = int.Parse((string)obj[5]);
            damp_type.value = int.Parse((string)obj[6]);
            List<string> str2 = (List<string>)obj[7];
            for (int i = 0; i < str2.Count(); i++)
            {
                dampings_58 t = new dampings_58();
                t.value = double.Parse(str2[i]);
                dampings.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(member_total.value));
            obj.Add(Convert.ToString(kp_total.value));
            List<string> str1 = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                str1.Add(Convert.ToString(member_number[i].value));
            }
            obj.Add(str1);
            obj.Add(Convert.ToString(order_elem.value));
            obj.Add(Convert.ToString(BldFile.value));
            obj.Add(Convert.ToString(station_total.value));
            obj.Add(Convert.ToString(damp_type.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < dampings.Count(); i++)
            {
                str2.Add(Convert.ToString(dampings[i].value));
            }
            obj.Add(str2);
            return obj;
        }
        public member_total_51 member_total = new member_total_51();
        public kp_total_52 kp_total = new kp_total_52();
        public member_number_53[] member_number = new member_number_53[2];
        public order_elem_54 order_elem = new order_elem_54();
        public BldFile_55 BldFile = new BldFile_55();
        public station_total_56 station_total = new station_total_56();
        public damp_type_57 damp_type = new damp_type_57();
        public List<dampings_58> dampings = new List<dampings_58>();
    }
    public class member_total_51
    {
        public int value = 1;
    }
    public class kp_total_52
    {
        public int value = new int();
    }
    public class member_number_53
    {
        public int value = new int();
    }
    public class order_elem_54
    {
        public int value = 5;
    }
    public class BldFile_55
    {
        public string value = "IEA-15-240-RWT_BeamDyn_blade_VABS.dat";
    }
    public class station_total_56
    {
        public int value = 21;
    }
    public class damp_type_57
    {
        public int value = 1;
    }
    public class dampings_58
    {
        public double value = new double();
    }
    public class SectionMatrix_59
    {
        public void setValue(List<object> obj)
        {
            location.value = double.Parse((string)obj[0]);
            double[,] d1 = new double[6, 6];
            string[,] str1 = (string[,])obj[1];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    d1[i, j] = double.Parse(str1[i,j]);
                }
            }
            Stiffness_matrix.value = d1;
            double[,] d2 = new double[6, 6];
            string[,] str2 = (string[,])obj[2];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    d2[i, j] = double.Parse(str2[i,j]);
                }
            }
            Mass_matrix.value = d2;
        }
        public string[,] getMatrix()
        {
            string[,] str = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    str[i, j] = Convert.ToString(Stiffness_matrix.value[i, j]);
                }
            }
            return str;
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(location.value));
            string[,] d1 = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    d1[i, j] = Convert.ToString(Stiffness_matrix.value[i, j]);
                }
            }
            string[,] d2 = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    d2[i, j] = Convert.ToString(Mass_matrix.value[i, j]);
                }
            }
            obj.Add(d1);
            obj.Add(d2);
            return obj;
        }
        public location_60 location = new location_60();
        public Stiffness_matrix_61 Stiffness_matrix = new Stiffness_matrix_61();
        public Mass_matrix_62 Mass_matrix = new Mass_matrix_62();
    }
    public class location_60
    {
        public double value = new double();
    }
    public class Stiffness_matrix_61
    {
        public double[,] value = new double[6, 6];
    }
    public class Mass_matrix_62
    {
        public double[,] value = new double[6, 6];
    }
    public class BladeModes_63
    {
        public BladeModes_63()
        {
            R.Add(new R_68());
            double[] Default_dampings = { 3, 3, 3 };
            double[] Default_tunr = { 1, 1 };
            for(int i = 0; i < 3; i++)
            {
                dampings[i] = new dampings_64();
                dampings[i].value = Default_dampings[i];
            }
            for (int i = 0; i < 2; i++)
            {
                FlStTunr[i] = new FlStTunr_67();
                FlStTunr[i].value = Default_tunr[i];
            }
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_x[i] = new Factor_Deflection_x_69();
                Factor_Deflection_y[i] = new Factor_Deflection_y_70();
                Factor_Deflection_z[i] = new Factor_Deflection_z_71();
            }
            Factor_Rotate_x.Add(new Factor_Rotate_x_72());
            Factor_Rotate_y.Add(new Factor_Rotate_y_73());
            Factor_Rotate_z.Add(new Factor_Rotate_z_74());

        }
        public void setValue(List<object> obj)
        {
            List<string> str0 = (List<string>)obj[0];
            for (int i = 0; i < 3; i++)
            {
                dampings[i].value = double.Parse(str0[i]);
            }
            frequency.value = double.Parse((string)obj[1]);
            NBlInpSt.value = int.Parse((string)obj[2]);
            List<string> str11 = (List<string>)obj[3];
            for (int i = 0; i < 2; i++)
            {
                FlStTunr[i].value = double.Parse(str11[i]);
            }
            List<string> str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                R_68 t = new R_68();
                t.value = double.Parse(str2[i]);
                R.Add(t);
            }
            List<string> str1 = (List<string>)obj[5];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_x[i].value = double.Parse(str1[i]);
            }
            str1 = (List<string>)obj[6];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_y[i].value = double.Parse(str1[i]);
            }

            str1 = (List<string>)obj[7];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_z[i].value = double.Parse(str1[i]);
            }

            str2 = (List<string>)obj[8];
            for (int i = 0; i < str2.Count(); i++)
            {
                Factor_Rotate_x_72 t = new Factor_Rotate_x_72();
                t.value = double.Parse(str2[i]);
                Factor_Rotate_x.Add(t);
            }
            str2 = (List<string>)obj[9];
            for (int i = 0; i < str2.Count(); i++)
            {
                Factor_Rotate_y_73 t = new Factor_Rotate_y_73();
                t.value = double.Parse(str2[i]);
                Factor_Rotate_y.Add(t);
            }
            str2 = (List<string>)obj[10];
            for (int i = 0; i < str2.Count(); i++)
            {
                Factor_Rotate_z_74 t = new Factor_Rotate_z_74();
                t.value = double.Parse(str2[i]);
                Factor_Rotate_z.Add(t);
            }

        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            List<string> str30= new List<string>();
            for (int i = 0; i < 3; i++)
            {
                str30.Add(Convert.ToString(dampings[i].value));
            }
            obj.Add(str30);
            obj.Add(Convert.ToString(frequency.value));
            obj.Add(Convert.ToString(NBlInpSt.value));
            List<string> str31 = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                str31.Add(Convert.ToString(FlStTunr[i].value));
            }
            obj.Add(str31);
            List<string> str2 = new List<string>();
            for (int i = 0; i < R.Count(); i++)
            {
                str2.Add(Convert.ToString(R[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str3.Add(Convert.ToString(Factor_Deflection_x[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str4.Add(Convert.ToString(Factor_Deflection_y[i].value));
            }
            obj.Add(str4);
            List<string> str5 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str5.Add(Convert.ToString(Factor_Deflection_z[i].value));
            }
            obj.Add(str5);

            List<string> str6 = new List<string>();
            for (int i = 0; i < Factor_Rotate_x.Count(); i++)
            {
                str6.Add(Convert.ToString(Factor_Rotate_x[i].value));
            }
            obj.Add(str6);
            List<string> str7 = new List<string>();
            for (int i = 0; i < Factor_Rotate_y.Count(); i++)
            {
                str7.Add(Convert.ToString(Factor_Rotate_y[i].value));
            }
            obj.Add(str7);
            List<string> str8 = new List<string>();
            for (int i = 0; i < Factor_Rotate_z.Count(); i++)
            {
                str8.Add(Convert.ToString(Factor_Rotate_z[i].value));
            }
            obj.Add(str8);
            return obj;
        }
        public dampings_64[] dampings = new dampings_64[3]; //obj[0]
        public frequency_65 frequency = new frequency_65(); //obj[1]
        public NBlInpSt_66 NBlInpSt = new NBlInpSt_66(); //obj[2]
        public FlStTunr_67[] FlStTunr = new FlStTunr_67[2]; //obj[3]
        public List<R_68> R = new List<R_68>(); //obj[4]
        public Factor_Deflection_x_69[] Factor_Deflection_x = new Factor_Deflection_x_69[5]; // obj[5]
        public Factor_Deflection_y_70[] Factor_Deflection_y = new Factor_Deflection_y_70[5];
        public Factor_Deflection_z_71[] Factor_Deflection_z = new Factor_Deflection_z_71[5];
        public List<Factor_Rotate_x_72> Factor_Rotate_x = new List<Factor_Rotate_x_72>();
        public List<Factor_Rotate_y_73> Factor_Rotate_y = new List<Factor_Rotate_y_73>();
        public List<Factor_Rotate_z_74> Factor_Rotate_z = new List<Factor_Rotate_z_74>();
    }
    public class dampings_64
    {
        public double value = new double();
    }
    public class frequency_65
    {
        public double value = new double();
    }
    public class NBlInpSt_66
    {
        public int value = new int();
    }
    public class FlStTunr_67
    {
        public double value = new double();
    }
    public class R_68
    {
        public double value = new double();
    }
    public class Factor_Deflection_x_69
    {
        public double value = new double();
    }
    public class Factor_Deflection_y_70
    {
        public double value = new double();
    }
    public class Factor_Deflection_z_71
    {
        public double value = new double();
    }
    public class Factor_Rotate_x_72
    {
        public double value = new double();
    }
    public class Factor_Rotate_y_73
    {
        public double value = new double();
    }
    public class Factor_Rotate_z_74
    {
        public double value = new double();
    }
    public class Tower_75
    {
        public Tower_75()
        {
            towerStation.Add(new towerStation_78());
            towerModes.Add(new towerModes_86());
        }
        public void setValue(List<object> obj)
        {
            TwrNodes.value = int.Parse((string)obj[0]);
            TwrFile.value = (string)obj[1];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(TwrNodes.value));
            obj.Add(TwrFile.value);
            return obj;
        }
        public TwrNodes_76 TwrNodes = new TwrNodes_76();
        public TwrFile_77 TwrFile = new TwrFile_77();
        public List<towerStation_78> towerStation = new List<towerStation_78>();
        public List<towerModes_86> towerModes = new List<towerModes_86>();
    }
    public class TwrNodes_76
    {
        public int value = new int();
    }
    public class TwrFile_77
    {
        public string value = "IEA-15-240-RWT-Monopile_ElastoDyn_tower.dat";
    }
    public class towerStation_78
    {
        public void setValue(List<object> obj)
        {
            TwrElev.value = double.Parse((string)obj[0]);
            TwrDiam.value = double.Parse((string)obj[1]);
            TwrCd.value = double.Parse((string)obj[2]);
            HtFract.value = double.Parse((string)obj[3]);
            TMassDen.value = double.Parse((string)obj[4]);
            TwFAStif.value = double.Parse((string)obj[5]);
            TwSSStif.value = double.Parse((string)obj[6]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(TwrElev.value));
            obj.Add(Convert.ToString(TwrDiam.value));
            obj.Add(Convert.ToString(TwrCd.value));
            obj.Add(Convert.ToString(HtFract.value));
            obj.Add(Convert.ToString(TMassDen.value));
            obj.Add(Convert.ToString(TwFAStif.value));
            obj.Add(Convert.ToString(TwSSStif.value));
            return obj;
        }

        public TwrElev_79 TwrElev = new TwrElev_79();
        public TwrDiam_80 TwrDiam = new TwrDiam_80();
        public TwrCd_81 TwrCd = new TwrCd_81();
        public HtFract_82 HtFract = new HtFract_82();
        public TMassDen_83 TMassDen = new TMassDen_83();
        public TwFAStif_84 TwFAStif = new TwFAStif_84();
        public TwSSStif_85 TwSSStif = new TwSSStif_85();
    }
    public class TwrElev_79
    {
        public double value = new double();
    }
    public class TwrDiam_80
    {
        public double value = new double();
    }
    public class TwrCd_81
    {
        public double value = new double();
    }
    public class HtFract_82
    {
        public double value = new double();
    }
    public class TMassDen_83
    {
        public double value = new double();
    }
    public class TwFAStif_84
    {
        public double value = new double();
    }
    public class TwSSStif_85
    {
        public double value = new double();
    }
    public class towerModes_86
    {
        public towerModes_86()
        {
            R.Add(new R_91());
            double[] Default_dampings = { 1, 1, 1, 1 };
            double[] Default_tunr = { 1, 1, 1, 1 };
            for (int i = 0; i < 4; i++)
            {
                dampings[i] = new dampings_87();
                dampings[i].value = Default_dampings[i];
                Tunr[i] = new Tunr_90();
                Tunr[i].value = Default_tunr[i];
            }
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_x1[i] = new Factor_Deflection_x1_92();
                Factor_Deflection_x2[i] = new Factor_Deflection_x2_93();
                Factor_Deflection_y1[i] = new Factor_Deflection_y1_94();
                Factor_Deflection_y2[i] = new Factor_Deflection_y2_95();
            }
            Factor_Rotate_x.Add(new Factor_Rotate_x_96());
            Factor_Rotate_y.Add(new Factor_Rotate_y_97());
        }
        public void setValue(List<object> obj)
        {
            List<string> str0 = (List<string>)obj[0];
            for (int i = 0; i < 4; i++)
            {
                dampings[i].value = double.Parse(str0[i]);
            }
            frequency.value = double.Parse((string)obj[1]);
            NTwInpSt.value = int.Parse((string)obj[2]);

            //Tunr.value = double.Parse((string)obj[3]);
            str0.Clear();
            str0 = (List<string>)obj[3];
            for (int i = 0; i < 4; i++)
            {
                Tunr[i].value = double.Parse(str0[i]);
            }
            List<string> str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                R_91 t = new R_91();
                t.value = double.Parse(str2[i]);
                R.Add(t);
            }
            List<string> str1 = (List<string>)obj[5];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_x1[i].value = double.Parse(str1[i]);
            }

            str1 = (List<string>)obj[6];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_x2[i].value = double.Parse(str1[i]);
            }

            str1 = (List<string>)obj[7];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_y1[i].value = double.Parse(str1[i]);
            }
            str1 = (List<string>)obj[8];
            for (int i = 0; i < 5; i++)
            {
                Factor_Deflection_y2[i].value = double.Parse(str1[i]);
            }
            str2 = (List<string>)obj[9];
            for (int i = 0; i < str2.Count(); i++)
            {
                Factor_Rotate_x_96 t = new Factor_Rotate_x_96();
                t.value = double.Parse(str2[i]);
                Factor_Rotate_x.Add(t);
            }
            str2 = (List<string>)obj[10];
            for (int i = 0; i < str2.Count(); i++)
            {
                Factor_Rotate_y_97 t = new Factor_Rotate_y_97();
                t.value = double.Parse(str2[i]);
                Factor_Rotate_y.Add(t);
            }

        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            //obj.Add(Convert.ToString(dampings.value));
            List<string> str0 = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                str0.Add(Convert.ToString(dampings[i].value));
            }
            obj.Add(str0);
            obj.Add(Convert.ToString(frequency.value));
            obj.Add(Convert.ToString(NTwInpSt.value));
            //obj.Add(Convert.ToString(Tunr.value));
            List<string> str12 = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                str12.Add(Convert.ToString(Tunr[i].value));
            }
            obj.Add(str12);
            List<string> str2 = new List<string>();
            for (int i = 0; i < R.Count(); i++)
            {
                str2.Add(Convert.ToString(R[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str3.Add(Convert.ToString(Factor_Deflection_x1[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str4.Add(Convert.ToString(Factor_Deflection_x2[i].value));
            }
            obj.Add(str4);
            List<string> str5 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str5.Add(Convert.ToString(Factor_Deflection_y1[i].value));
            }
            obj.Add(str5);
            List<string> str6 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                str6.Add(Convert.ToString(Factor_Deflection_y2[i].value));
            }
            obj.Add(str6);
            List<string> str7 = new List<string>();
            for (int i = 0; i < Factor_Rotate_x.Count(); i++)
            {
                str7.Add(Convert.ToString(Factor_Rotate_x[i].value));
            }
            obj.Add(str7);
            List<string> str8 = new List<string>();
            for (int i = 0; i < Factor_Rotate_y.Count(); i++)
            {
                str8.Add(Convert.ToString(Factor_Rotate_y[i].value));
            }
            obj.Add(str8);
            return obj;
        }
        public dampings_87[] dampings = new dampings_87[4];
        public frequency_88 frequency = new frequency_88();
        public NTwInpSt_89 NTwInpSt = new NTwInpSt_89();
        public Tunr_90[] Tunr = new Tunr_90[4];
        public List<R_91> R = new List<R_91>();
        public Factor_Deflection_x1_92[] Factor_Deflection_x1 = new Factor_Deflection_x1_92[5];
        public Factor_Deflection_x2_93[] Factor_Deflection_x2 = new Factor_Deflection_x2_93[5];
        public Factor_Deflection_y1_94[] Factor_Deflection_y1 = new Factor_Deflection_y1_94[5];
        public Factor_Deflection_y2_95[] Factor_Deflection_y2 = new Factor_Deflection_y2_95[5];
        public List<Factor_Rotate_x_96> Factor_Rotate_x = new List<Factor_Rotate_x_96>();
        public List<Factor_Rotate_y_97> Factor_Rotate_y = new List<Factor_Rotate_y_97>();
    }
    public class dampings_87
    {
        public double value = new double();
    }
    public class frequency_88
    {
        public double value = new double();
    }
    public class NTwInpSt_89
    {
        public int value = new int();
    }
    public class Tunr_90
    {
        public double value = new double();
    }
    public class R_91
    {
        public double value = new double();
    }
    public class Factor_Deflection_x1_92
    {
        public double value = new double();
    }
    public class Factor_Deflection_x2_93
    {
        public double value = new double();
    }
    public class Factor_Deflection_y1_94
    {
        public double value = new double();
    }
    public class Factor_Deflection_y2_95
    {
        public double value = new double();
    }
    public class Factor_Rotate_x_96
    {
        public double value = new double();
    }
    public class Factor_Rotate_y_97
    {
        public double value = new double();
    }
    public class DriveTrain_98
    {
        public void setValue(List<object> obj)
        {
            GBoxEff.value = double.Parse((string)obj[0]);
            GBRatio.value = double.Parse((string)obj[1]);
            DTTorSpr.value = double.Parse((string)obj[2]);
            DTTorDmp.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(GBoxEff.value));
            obj.Add(Convert.ToString(GBRatio.value));
            obj.Add(Convert.ToString(DTTorSpr.value));
            obj.Add(Convert.ToString(DTTorDmp.value));
            return obj;
        }

        public GBoxEff_99 GBoxEff = new GBoxEff_99();
        public GBRatio_100 GBRatio = new GBRatio_100();
        public DTTorSpr_101 DTTorSpr = new DTTorSpr_101();
        public DTTorDmp_102 DTTorDmp = new DTTorDmp_102();
    }
    public class GBoxEff_99
    {
        public double value = new double();
    }
    public class GBRatio_100
    {
        public double value = new double();
    }
    public class DTTorSpr_101
    {
        public double value = new double();
    }
    public class DTTorDmp_102
    {
        public double value = new double();
    }
    public class Control_103
    {
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            DT.value = double.Parse((string)obj[1]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(DT.value));
            return obj;
        }
        public Echo_104 Echo = new Echo_104();
        public DT_105 DT = new DT_105();
        public pitchControl_106 pitchControl = new pitchControl_106();
        public TorqueControl_112 TorqueControl = new TorqueControl_112();
        public SimpleTorqueControl_121 SimpleTorqueControl = new SimpleTorqueControl_121();
        public inductonGenerator_126 inductonGenerator = new inductonGenerator_126();
        public HSBrake_128 HSBrake = new HSBrake_128();
        public yawControl_133 yawControl = new yawControl_133();
        public massDamper_135 massDamper = new massDamper_135();
        public BladedInterface_Dll_138 BladedInterface_Dll = new BladedInterface_Dll_138();
        public BladedInterface_Torque_143 BladedInterface_Torque = new BladedInterface_Torque_143();
        public PitcActuator_147 PitcActuator = new PitcActuator_147();
        public Linearization_149 Linearization = new Linearization_149();
    }
    public class Echo_104
    {
        public bool value = new bool();
    }
    public class DT_105
    {
        public double value = new double();
    }
    public class pitchControl_106
    {
        public pitchControl_106()
        {
            double[] Default_Tp = { 9999.9, 9999.9, 9999.9 };
            double[] Default_Pit = { 2, 2, 2 };
            double[] Default_Blpit = { 0, 0, 0 };
            for (int i = 0; i < 3; i++)
            {
                TPitManS_1[i] = new TPitManS_1_109();
                TPitManS_1[i].value = Default_Tp[i];
                PitManRat_1[i] = new PitManRat_1_110();
                PitManRat_1[i].value = Default_Pit[i];
                BlPitchF_1[i] = new BlPitchF_1_111();
                BlPitchF_1[i].value = Default_Blpit[i];
            }
        }
        public void setValue(List<object> obj)
        {
            PCMode.value = int.Parse((string)obj[0]);
            TPCOn.value = double.Parse((string)obj[1]);
            List<string> str1 = (List<string>)obj[2];
            for (int i = 0; i < 3; i++)
            {
                TPitManS_1[i].value = double.Parse(str1[i]);
            }

            str1 = (List<string>)obj[3];
            for (int i = 0; i < 3; i++)
            {
                PitManRat_1[i].value = double.Parse(str1[i]);
            }

            str1 = (List<string>)obj[4];
            for (int i = 0; i < 3; i++)
            {
                BlPitchF_1[i].value = double.Parse(str1[i]);
            }
            //str1 = (List<string>)obj[5];

        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(PCMode.value));
            obj.Add(Convert.ToString(TPCOn.value));
            List<string> str3 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                str3.Add(Convert.ToString(TPitManS_1[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                str4.Add(Convert.ToString(PitManRat_1[i].value));
            }
            obj.Add(str4);
            List<string> str5 = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                str5.Add(Convert.ToString(BlPitchF_1[i].value));
            }
            obj.Add(str5);
            return obj;
        }
        public PCMode_107 PCMode = new PCMode_107();
        public TPCOn_108 TPCOn = new TPCOn_108();
        public TPitManS_1_109[] TPitManS_1 = new TPitManS_1_109[3];
        public PitManRat_1_110[] PitManRat_1 = new PitManRat_1_110[3];
        public BlPitchF_1_111[] BlPitchF_1 = new BlPitchF_1_111[3];
    }
    public class PCMode_107
    {
        public int value = 5;
    }
    public class TPCOn_108
    {
        public double value = new double();
    }
    public class TPitManS_1_109
    {
        public double value = new double();
    }
    public class PitManRat_1_110
    {
        public double value = new double();
    }
    public class BlPitchF_1_111
    {
        public double value = new double();
    }
    public class TorqueControl_112
    {
        public void setValue(List<object> obj)
        {
            VSContrl.value = int.Parse((string)obj[0]);
            GenModel.value = int.Parse((string)obj[1]);
            GenEff.value = double.Parse((string)obj[2]);
            GenTiStr.value = bool.Parse((string)obj[3]);
            GenTiStp.value = bool.Parse((string)obj[4]);
            SpdGenOn.value = double.Parse((string)obj[5]);
            TimGenOn.value = double.Parse((string)obj[6]);
            TimGenOf.value = double.Parse((string)obj[7]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(VSContrl.value));
            obj.Add(Convert.ToString(GenModel.value));
            obj.Add(Convert.ToString(GenEff.value));
            obj.Add(Convert.ToString(GenTiStr.value));
            obj.Add(Convert.ToString(GenTiStp.value));
            obj.Add(Convert.ToString(SpdGenOn.value));
            obj.Add(Convert.ToString(TimGenOn.value));
            obj.Add(Convert.ToString(TimGenOf.value));
            return obj;
        }

        public VSContrl_113 VSContrl = new VSContrl_113();
        public GenModel_114 GenModel = new GenModel_114();
        public GenEff_115 GenEff = new GenEff_115();
        public GenTiStr_116 GenTiStr = new GenTiStr_116();
        public GenTiStp_117 GenTiStp = new GenTiStp_117();
        public SpdGenOn_118 SpdGenOn = new SpdGenOn_118();
        public TimGenOn_119 TimGenOn = new TimGenOn_119();
        public TimGenOf_120 TimGenOf = new TimGenOf_120();
    }
    public class VSContrl_113
    {
        public int value = 5;
    }
    public class GenModel_114
    {
        public int value = 2;
    }
    public class GenEff_115
    {
        public double value = 96.55;
    }
    public class GenTiStr_116
    {
        public bool value = true;
    }
    public class GenTiStp_117
    {
        public bool value = true;
    }
    public class SpdGenOn_118
    {
        public double value = 9999.9;
    }
    public class TimGenOn_119
    {
        public double value = new double();
    }
    public class TimGenOf_120
    {
        public double value = 9999.9;
    }
    public class SimpleTorqueControl_121
    {
        public void setValue(List<object> obj)
        {
            VS_RtGnSp.value = double.Parse((string)obj[0]);
            VS_RtTq.value = double.Parse((string)obj[1]);
            VS_Rgn2K.value = double.Parse((string)obj[2]);
            VS_SlPc.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(VS_RtGnSp.value));
            obj.Add(Convert.ToString(VS_RtTq.value));
            obj.Add(Convert.ToString(VS_Rgn2K.value));
            obj.Add(Convert.ToString(VS_SlPc.value));
            return obj;
        }

        public VS_RtGnSp_122 VS_RtGnSp = new VS_RtGnSp_122();
        public VS_RtTq_123 VS_RtTq = new VS_RtTq_123();
        public VS_Rgn2K_124 VS_Rgn2K = new VS_Rgn2K_124();
        public VS_SlPc_125 VS_SlPc = new VS_SlPc_125();
    }
    public class VS_RtGnSp_122
    {
        public double value = 9999.9;
    }
    public class VS_RtTq_123
    {
        public double value = 9999.9;
    }
    public class VS_Rgn2K_124
    {
        public double value = 9999.9;
    }
    public class VS_SlPc_125
    {
        public double value = 9999.9;
    }
    public class inductonGenerator_126
    {
        public void setValue(List<object> obj)
        {
            TEC_Freq.value = double.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(TEC_Freq.value));
            return obj;
        }
        public TEC_Freq_127 TEC_Freq = new TEC_Freq_127();
    }
    public class TEC_Freq_127
    {
        public double value =9999.9;
    }
    public class HSBrake_128
    {
        public void setValue(List<object> obj)
        {
            HSSBrMode.value = int.Parse((string)obj[0]);
            THSSBrDp.value = double.Parse((string)obj[1]);
            HSSBrDT.value = double.Parse((string)obj[2]);
            HSSBrTqF.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(HSSBrMode.value));
            obj.Add(Convert.ToString(THSSBrDp.value));
            obj.Add(Convert.ToString(HSSBrDT.value));
            obj.Add(Convert.ToString(HSSBrTqF.value));
            return obj;
        }
        public HSSBrMode_129 HSSBrMode = new HSSBrMode_129();
        public THSSBrDp_130 THSSBrDp = new THSSBrDp_130();
        public HSSBrDT_131 HSSBrDT = new HSSBrDT_131();
        public HSSBrTqF_132 HSSBrTqF = new HSSBrTqF_132();
    }
    public class HSSBrMode_129
    {
        public int value = new int();
    }
    public class THSSBrDp_130
    {
        public double value = 9999.9;
    }
    public class HSSBrDT_131
    {
        public double value = 0.6;
    }
    public class HSSBrTqF_132
    {
        public double value = 28116.2;
    }
    public class yawControl_133
    {
        public void setValue(List<object> obj)
        {
            YCMode.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(YCMode.value));
            return obj;
        }
        public YCMode_134 YCMode = new YCMode_134();
    }
    public class YCMode_134
    {
        public int value = new int();
    }
    public class massDamper_135
    {
        public void setValue(List<object> obj)
        {
            CompNTMD.value = bool.Parse((string)obj[0]);
            NTMDfile.value = (string)obj[1];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(CompNTMD.value));
            obj.Add(NTMDfile.value);
            return obj;
        }
        public CompNTMD_136 CompNTMD = new CompNTMD_136();
        public NTMDfile_137 NTMDfile = new NTMDfile_137();
    }
    public class CompNTMD_136
    {
        public bool value = new bool();
    }
    public class NTMDfile_137
    {
        public string value = "unused";
    }
    public class BladedInterface_Dll_138
    {
        public void setValue(List<object> obj)
        {
            DLL_FileName.value = (string)obj[0];
            DLL_InFile.value = (string)obj[1];
            DLL_ProcName.value = (string)obj[2];
            DLL_DT.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(DLL_FileName.value);
            obj.Add(DLL_InFile.value);
            obj.Add(DLL_ProcName.value);
            obj.Add(Convert.ToString(DLL_DT.value));
            return obj;
        }
        public DLL_FileName_139 DLL_FileName = new DLL_FileName_139();
        public DLL_InFile_140 DLL_InFile = new DLL_InFile_140();
        public DLL_ProcName_141 DLL_ProcName = new DLL_ProcName_141();
        public DLL_DT_142 DLL_DT = new DLL_DT_142();
    }
    public class DLL_FileName_139
    {
        public string value = "./ServoData/DISCON.dll";
    }
    public class DLL_InFile_140
    {
        public string value = "DISCON-Monopile.IN";
    }
    public class DLL_ProcName_141
    {
        public string value = "DISCON";
    }
    public class DLL_DT_142
    {
        public double value = 0.01;
    }
    public class BladedInterface_Torque_143
    {
        public BladedInterface_Torque_143()
        {
            GenSpd_TLU.Add(new GenSpd_TLU_145());
            GenTrq_TLU.Add(new GenTrq_TLU_146());
        }
        public void setValue(List<object> obj)
        {
            DLL_NumTrq.value = int.Parse((string)obj[0]);
            List<string> str2 = (List<string>)obj[1];
            for (int i = 0; i < str2.Count(); i++)
            {
                GenSpd_TLU_145 t = new GenSpd_TLU_145();
                t.value = double.Parse(str2[i]);
                GenSpd_TLU.Add(t);
            }
            List<string> str3 = (List<string>)obj[2];
            for (int i = 0; i < str3.Count(); i++)
            {
                GenTrq_TLU_146 t = new GenTrq_TLU_146();
                t.value = double.Parse(str3[i]);
                GenTrq_TLU.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(DLL_NumTrq.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < GenSpd_TLU.Count(); i++)
            {
                str2.Add(Convert.ToString(GenSpd_TLU[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < GenTrq_TLU.Count(); i++)
            {
                str3.Add(Convert.ToString(GenTrq_TLU[i].value));
            }
            obj.Add(str3);
            return obj;
        }
        public DLL_NumTrq_144 DLL_NumTrq = new DLL_NumTrq_144();
        public List<GenSpd_TLU_145> GenSpd_TLU = new List<GenSpd_TLU_145>();
        public List<GenTrq_TLU_146> GenTrq_TLU = new List<GenTrq_TLU_146>();
    }
    public class DLL_NumTrq_144
    {
        public int value = new int();
    }
    public class GenSpd_TLU_145
    {
        public double value = new double();
    }
    public class GenTrq_TLU_146
    {
        public double value = new double();
    }
    public class PitcActuator_147
    {
        public void setValue(List<object> obj)
        {
            UsePitchAct.value = bool.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(UsePitchAct.value));
            return obj;
        }

        public UsePitchAct_148 UsePitchAct = new UsePitchAct_148();
    }
    public class UsePitchAct_148
    {
        public bool value = new bool();
    }
    public class Linearization_149
    {
        public void setValue(List<object> obj)
        {
            Linearize.value = bool.Parse((string)obj[0]);
            CalcSteady.value = bool.Parse((string)obj[1]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Linearize.value));
            obj.Add(Convert.ToString(CalcSteady.value));
            return obj;
        }

        public Linearize_150 Linearize = new Linearize_150();
        public CalcSteady_151 CalcSteady = new CalcSteady_151();
    }
    public class Linearize_150
    {
        public bool value = new bool();
    }
    public class CalcSteady_151
    {
        public bool value = new bool();
    }
    public class Airfoil_152
    {
        public void setValue(List<object> obj)
        {
            InterpOrd.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(InterpOrd.value));
            return obj;
        }
        public Airfoilfile_153 Airfoilfile = new Airfoilfile_153();
        public InterpOrd_169 InterpOrd = new InterpOrd_169();
        public AirfoilBasicSetting_170 AirfoilBasicSetting = new AirfoilBasicSetting_170();
        public AirfoilDataInfo_178 AirfoilDataInfo = new AirfoilDataInfo_178();
    }
    public class Airfoilfile_153
    {
        public Airfoilfile_153()
        {
            for (int i = 0; i < 50; i++)
            {
                AirfoilPerformance.Add(new AirfoilPerformance_157());
            }
            
        }
        public void setValue(List<object> obj)
        {
            AFTabMod.value = int.Parse((string)obj[0]);
            NumAFfiles.value = int.Parse((string)obj[1]);
            AFNames.value = (string)obj[2];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(AFTabMod.value));
            obj.Add(Convert.ToString(NumAFfiles.value));
            obj.Add(Convert.ToString(AFNames.value));
            return obj;
        }
        public AFTabMod_154 AFTabMod = new AFTabMod_154();
        public NumAFfiles_155 NumAFfiles = new NumAFfiles_155();
        public AFNames_156 AFNames = new AFNames_156();
        public List<AirfoilPerformance_157> AirfoilPerformance = new List<AirfoilPerformance_157>();
        public AirfoilShape_163 AirfoilShape = new AirfoilShape_163();
    }
    public class AFTabMod_154
    {
        public int value = new int();
    }
    public class NumAFfiles_155
    {
        public int value = new int();
    }
    public class AFNames_156
    {
        public string value;
    }
    public class AirfoilPerformance_157
    {
        public AirfoilPerformance_157()
        {
            for (int i = 0; i < 50; i++)
            {
                Alpha.Add(new Alpha_159());
                Cl.Add(new Cl_160());
                Cd.Add(new Cd_161());
                Cm.Add(new Cm_162());
            }
            
        }
        public void setValue(List<object> obj)
        {
            NumAlf.value = int.Parse((string)obj[0]);
            List<string> str2 = (List<string>)obj[1];
            for (int i = 0; i < str2.Count(); i++)
            {
                Alpha_159 t = new Alpha_159();
                t.value = double.Parse(str2[i]);
                Alpha.Add(t);
            }

            str2 = (List<string>)obj[2];
            for (int i = 0; i < str2.Count(); i++)
            {
                Cl_160 t = new Cl_160();
                t.value = double.Parse(str2[i]);
                Cl.Add(t);
            }

            str2 = (List<string>)obj[3];
            for (int i = 0; i < str2.Count(); i++)
            {
                Cd_161 t = new Cd_161();
                t.value = double.Parse(str2[i]);
                Cd.Add(t);
            }
            str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                Cm_162 t = new Cm_162();
                t.value = double.Parse(str2[i]);
                Cm.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(NumAlf.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < Alpha.Count(); i++)
            {
                str2.Add(Convert.ToString(Alpha[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < Cl.Count(); i++)
            {
                str3.Add(Convert.ToString(Cl[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < Cd.Count(); i++)
            {
                str4.Add(Convert.ToString(Cd[i].value));
            }
            obj.Add(str4);
            List<string> str5 = new List<string>();
            for (int i = 0; i < Cm.Count(); i++)
            {
                str5.Add(Convert.ToString(Cm[i].value));
            }
            obj.Add(str5);
            return obj;
        }
        public NumAlf_158 NumAlf = new NumAlf_158();
        public List<Alpha_159> Alpha = new List<Alpha_159>();
        public List<Cl_160> Cl = new List<Cl_160>();
        public List<Cd_161> Cd = new List<Cd_161>();
        public List<Cm_162> Cm = new List<Cm_162>();
    }
    public class NumAlf_158
    {
        public int value = new int();
    }
    public class Alpha_159
    {
        public double value = new double();
    }
    public class Cl_160
    {
        public double value = new double();
    }
    public class Cd_161
    {
        public double value = new double();
    }
    public class Cm_162
    {
        public double value = new double();
    }
    public class AirfoilShape_163
    {
        public AirfoilShape_163()
        {
            x2c.Add(new x2c_167());
            y2c.Add(new y2c_168());
        }
        public void setValue(List<object> obj)
        {
            NumCoords.value = (string)obj[0];
            x2c_0.value = double.Parse((string)obj[1]);
            y2c_0.value = double.Parse((string)obj[2]);
            List<string> str2 = (List<string>)obj[3];
            for (int i = 0; i < str2.Count(); i++)
            {
                x2c_167 t = new x2c_167();
                t.value = double.Parse(str2[i]);
                x2c.Add(t);
            }
            str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                y2c_168 t = new y2c_168();
                t.value = double.Parse((string)str2[i]);
                y2c.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(NumCoords.value);
            obj.Add(Convert.ToString(x2c_0.value));
            obj.Add(Convert.ToString(y2c_0.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < x2c.Count(); i++)
            {
                str2.Add(Convert.ToString(x2c[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < y2c.Count(); i++)
            {
                str3.Add(Convert.ToString(y2c[i].value));
            }
            obj.Add(str3);
            return obj;
        }
        public NumCoords_164 NumCoords = new NumCoords_164();
        public x2c_0_165 x2c_0 = new x2c_0_165();
        public y2c_0_166 y2c_0 = new y2c_0_166();
        public List<x2c_167> x2c = new List<x2c_167>();
        public List<y2c_168> y2c = new List<y2c_168>();
    }
    public class NumCoords_164
    {
        public string value = "IEA-15-240-RWT_AeroDyn15_Polar_00_Coords.txt";
    }
    public class x2c_0_165
    {
        public double value = new double();
    }
    public class y2c_0_166
    {
        public double value = new double();
    }
    public class x2c_167
    {
        public double value = new double();
    }
    public class y2c_168
    {
        public double value = new double();
    }
    public class InterpOrd_169
    {
        public int value = 3;
    }
    public class AirfoilBasicSetting_170
    {
        public void setValue(List<object> obj)
        {
            NonDimArea.value = double.Parse((string)obj[0]);
            NumCoords.value = (string)obj[1];
            BL_file.value = (string)obj[2];
            NumTabs.value = int.Parse((string)obj[3]);
            Re.value = double.Parse((string)obj[4]);
            UserProp.value = double.Parse((string)obj[5]);
            InclUAdata.value = bool.Parse((string)obj[6]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(NonDimArea.value));
            obj.Add(NumCoords.value);
            obj.Add(Convert.ToString(BL_file.value));
            obj.Add(Convert.ToString(NumTabs.value));
            obj.Add(Convert.ToString(Re.value));
            obj.Add(Convert.ToString(UserProp.value));
            obj.Add(Convert.ToString(InclUAdata.value));
            return obj;
        }
        public NonDimArea_171 NonDimArea = new NonDimArea_171();
        public NumCoords_172 NumCoords = new NumCoords_172();
        public BL_file_173 BL_file = new BL_file_173();
        public NumTabs_174 NumTabs = new NumTabs_174();
        public Re_175 Re = new Re_175();
        public UserProp_176 UserProp = new UserProp_176();
        public InclUAdata_177 InclUAdata = new InclUAdata_177();
    }
    public class NonDimArea_171
    {
        public double value = 1.0;
    }
    public class NumCoords_172
    {
        public string value;
    }
    public class BL_file_173
    {
        public string value = "AF00_BL.txt";
    }
    public class NumTabs_174
    {
        public int value = 1;
    }
    public class Re_175
    {
        public double value = 0.7500;
    }
    public class UserProp_176
    {
        public double value = new double();
    }
    public class InclUAdata_177
    {
        public bool value = true;
    }
    public class AirfoilDataInfo_178
    {
        public void setValue(List<object> obj)
        {
            alpha0.value = double.Parse((string)obj[0]);
            alpha1.value = double.Parse((string)obj[1]);
            alpha2.value = double.Parse((string)obj[2]);
            eta_e.value = double.Parse((string)obj[3]);
            C_nalpha.value = double.Parse((string)obj[4]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(alpha0.value));
            obj.Add(Convert.ToString(alpha1.value));
            obj.Add(Convert.ToString(alpha2.value));
            obj.Add(Convert.ToString(eta_e.value));
            obj.Add(Convert.ToString(C_nalpha.value));
            return obj;
        }
        public alpha0_179 alpha0 = new alpha0_179();
        public alpha1_180 alpha1 = new alpha1_180();
        public alpha2_181 alpha2 = new alpha2_181();
        public eta_e_182 eta_e = new eta_e_182();
        public C_nalpha_183 C_nalpha = new C_nalpha_183();


    }
    public class alpha0_179
    {
        public double value = -28;
    }
    public class alpha1_180
    {
        public double value = new double();
    }
    public class alpha2_181
    {
        public double value = new double();
    }
    public class eta_e_182
    {
        public double value = 1.0;
    }
    public class C_nalpha_183
    {
        public double value = new double();
    }
    public class Environment_184
    {
        public EnvironmentalConditions_185 EnvironmentalConditions = new EnvironmentalConditions_185();
        public WindCondition_190 WindCondition = new WindCondition_190();
    }
    public class EnvironmentalConditions_185
    {
        public void setValue(List<object> obj)
        {
            AirDens.value = double.Parse((string)obj[0]);
            KinVisc.value = double.Parse((string)obj[1]);
            FluidDepth.value = double.Parse((string)obj[2]);
            Gravity.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(AirDens.value));
            obj.Add(Convert.ToString(KinVisc.value));
            obj.Add(Convert.ToString(FluidDepth.value));
            obj.Add(Convert.ToString(Gravity.value));
            return obj;
        }
        public AirDens_186 AirDens = new AirDens_186();
        public KinVisc_187 KinVisc = new KinVisc_187();
        public FluidDepth_188 FluidDepth = new FluidDepth_188();
        public Gravity_189 Gravity = new Gravity_189();
    }
    public class AirDens_186
    {
        public double value = 1.225;
    }
    public class KinVisc_187
    {
        public double value = 1.48E-05;
    }
    public class FluidDepth_188
    {
        public double value = 0.5;
    }
    public class Gravity_189
    {
        public double value = 9.80665;
    }
    public class WindCondition_190
    {
        public void setValue(List<object> obj)
        {
            BladedWindFileRoot.value = (string)obj[0];
            BinFileName.value = (string)obj[1];
            TowerFile.value = bool.Parse((string)obj[2]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(BladedWindFileRoot.value));
            obj.Add(Convert.ToString(BinFileName.value));
            obj.Add(Convert.ToString(TowerFile.value));
            return obj;
        }

        public WindBasicInfo_191 WindBasicInfo = new WindBasicInfo_191();
        public SteadyWind_199 SteadyWind = new SteadyWind_199();
        public Uniformwind_203 Uniformwind = new Uniformwind_203();
        public BinFileName_207 BinFileName = new BinFileName_207();
        public BladedWindFileRoot_208 BladedWindFileRoot = new BladedWindFileRoot_208();
        public TowerFile_209 TowerFile = new TowerFile_209();
        public HawcWindFile_210 HawcWindFile = new HawcWindFile_210();
        public ScalingParameters_212 ScalingParameters = new ScalingParameters_212();
        public MeanWindProfoile_214 MeanWindProfoile = new MeanWindProfoile_214();
    }
    public class WindBasicInfo_191
    {
        public WindBasicInfo_191()
        {
            WindVxiList.Add(new WindVxiList_196());
            WindVyiList.Add(new WindVyiList_197());
            WindVziList.Add(new WindVziList_198());
        }
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            WindType.value = int.Parse((string)obj[1]);
            PropagationDir.value = double.Parse((string)obj[2]);
            NWindVel.value = int.Parse((string)obj[3]);
            List<string> str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                WindVxiList_196 t = new WindVxiList_196();
                t.value = double.Parse((string)str2[i]);
                WindVxiList.Add(t);
            }
            List<string> str3 = (List<string>)obj[5];
            for (int i = 0; i < str3.Count(); i++)
            {
                WindVyiList_197 t = new WindVyiList_197();
                t.value = double.Parse((string)str3[i]);
                WindVyiList.Add(t);
            }
            List<string> str4 = (List<string>)obj[6];
            for (int i = 0; i < str4.Count(); i++)
            {
                WindVziList_198 t = new WindVziList_198();
                t.value = double.Parse((string)str3[i]);
                WindVziList.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(WindType.value));
            obj.Add(Convert.ToString(PropagationDir.value));
            obj.Add(Convert.ToString(NWindVel.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < WindVxiList.Count(); i++)
            {
                str2.Add(Convert.ToString(WindVxiList[i].value));
            }
            obj.Add(str2);
            List<string> str3 = new List<string>();
            for (int i = 0; i < WindVyiList.Count(); i++)
            {
                str3.Add(Convert.ToString(WindVyiList[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < WindVziList.Count(); i++)
            {
                str4.Add(Convert.ToString(WindVziList[i].value));
            }
            obj.Add(str4);
            return obj;
        }
        public Echo_192 Echo = new Echo_192();
        public WindType_193 WindType = new WindType_193();
        public PropagationDir_194 PropagationDir = new PropagationDir_194();
        public NWindVel_195 NWindVel = new NWindVel_195();
        public List<WindVxiList_196> WindVxiList = new List<WindVxiList_196>();
        public List<WindVyiList_197> WindVyiList = new List<WindVyiList_197>();
        public List<WindVziList_198> WindVziList = new List<WindVziList_198>();
    }
    public class Echo_192
    {
        public bool value = new bool();
    }
    public class WindType_193
    {
        public int value = new int();
    }
    public class PropagationDir_194
    {
        public double value = 0;
    }
    public class NWindVel_195
    {
        public int value = new int();
    }
    public class WindVxiList_196
    {
        public double value = new double();
    }
    public class WindVyiList_197
    {
        public double value = new double();
    }
    public class WindVziList_198
    {
        public double value = new double();
    }
    public class SteadyWind_199
    {
        public void setValue(List<object> obj)
        {
            HWindSpeed.value = double.Parse((string)obj[0]);
            RefHt.value = double.Parse((string)obj[1]);
            PLexp.value = double.Parse((string)obj[2]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(HWindSpeed.value));
            obj.Add(Convert.ToString(RefHt.value));
            obj.Add(Convert.ToString(PLexp.value));
            return obj;
        }
        public HWindSpeed_200 HWindSpeed = new HWindSpeed_200();
        public RefHt_201 RefHt = new RefHt_201();
        public PLexp_202 PLexp = new PLexp_202();
    }
    public class HWindSpeed_200
    {
        public double value = new double();
    }
    public class RefHt_201
    {
        public double value = new double();
    }
    public class PLexp_202
    {
        public double value = new double();
    }
    public class Uniformwind_203
    {
        public void setValue(List<object> obj)
        {
            Filename.value = (string)obj[0];
            RefHt.value = double.Parse((string)obj[1]);
            RefLength.value = double.Parse((string)obj[2]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Filename.value));
            obj.Add(Convert.ToString(RefHt.value));
            obj.Add(Convert.ToString(RefLength.value));
            return obj;
        }
        public Filename_204 Filename = new Filename_204();
        public RefHt_205 RefHt = new RefHt_205();
        public RefLength_206 RefLength = new RefLength_206();
    }
    public class Filename_204
    {
        public string value;
    }
    public class RefHt_205
    {
        public double value = new double();
    }
    public class RefLength_206
    {
        public double value = new double();
    }
    public class BinFileName_207
    {
        public string value;
    }
    public class BladedWindFileRoot_208
    {
        public string value;
    }
    public class TowerFile_209
    {
        public bool value = new bool();
    }
    public class HawcWindFile_210
    {
        public void setValue(List<object> obj)
        {
            FileName_u.value = (string)obj[0];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(FileName_u.value));
            return obj;
        }
        public FileName_u_211 FileName_u = new FileName_u_211();
    }
    public class FileName_u_211
    {
        public string value = "wasp/Output/basic_5u.bin";
    }
    public class ScalingParameters_212
    {
        public void setValue(List<object> obj)
        {
            ScaleMethod.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(ScaleMethod.value));
            return obj;
        }
        public ScaleMethod_213 ScaleMethod = new ScaleMethod_213();
    }
    public class ScaleMethod_213
    {
        public int value = 2;
    }
    public class MeanWindProfoile_214
    {
        public void setValue(List<object> obj)
        {
            URef.value = double.Parse((string)obj[0]);
            WindProfile.value = int.Parse((string)obj[1]);
            PLExp.value = double.Parse((string)obj[2]);
            Z0.value = double.Parse((string)obj[3]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(URef.value));
            obj.Add(Convert.ToString(WindProfile.value));
            obj.Add(Convert.ToString(PLExp.value));
            obj.Add(Convert.ToString(Z0.value));
            return obj;
        }
        public URef_215 URef = new URef_215();
        public WindProfile_216 WindProfile = new WindProfile_216();
        public PLExp_217 PLExp = new PLExp_217();
        public Z0_218 Z0 = new Z0_218();
    }
    public class URef_215
    {
        public double value = 12;
    }
    public class WindProfile_216
    {
        public int value = 2;
    }
    public class PLExp_217
    {
        public double value = 0.2;
    }
    public class Z0_218
    {
        public double value = 0.03;
    }
    public class SimulationControl_219
    {
        public BasicControl_220 BasicControl = new BasicControl_220();
        public SimulationFlags_224 SimulationFlags = new SimulationFlags_224();
        public InputFiles_226 InputFiles = new InputFiles_226();
        public AerodynamicControl_228 AerodynamicControl = new AerodynamicControl_228();
        public StructureSimulationControl_239 StructureSimulationControl = new StructureSimulationControl_239();
        public NonLinearSimulationControl_258 NonLinearSimulationControl = new NonLinearSimulationControl_258();
    }
    public class BasicControl_220
    {
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            TMAX.value = int.Parse((string)obj[1]);
            DT.value = double.Parse((string)obj[2]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(TMAX.value));
            obj.Add(Convert.ToString(DT.value));
            return obj;
        }
        public Echo_221 Echo = new Echo_221();
        public TMAX_222 TMAX = new TMAX_222();
        public DT_223 DT = new DT_223();
    }
    public class Echo_221
    {
        public bool value = new bool();
    }
    public class TMAX_222
    {
        public int value = 100;
    }
    public class DT_223
    {
        public double value = 0.005;
    }
    public class SimulationFlags_224
    {
        public SimulationFlags_224()
        {
            int[] data = new int[8] {1,1,2,1,0,0,0,0};
            for (int i = 0; i < 8; i++)
            {
                CompElast[i] = new CompElast_225();
                CompElast[i].value = data[i];
            }
        }
        public void setValue(List<object> obj)
        {
            module_flag.value = int.Parse((string)obj[0]);
            for (int i = 1; i < 9; i++)
            {
                CompElast[i-1].value = int.Parse((string)obj[i]);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(module_flag.value));
            List<string> str1 = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                str1.Add(Convert.ToString(CompElast[i].value));
            }
            obj.Add(str1);
            return obj;
        }
        public module_flag module_flag = new module_flag();
        public CompElast_225[] CompElast = new CompElast_225[8];
    }
    public class module_flag
    {
        public int value = new int();
    }
    public class CompElast_225
    {
        public int value = new int();
    }
    public class InputFiles_226
    {
        public InputFiles_226()
        {
            string[] Input = { "IEA-15-240-RWT-Monopile_ElastoDyn.dat", "../IEA-15-240-RWT/IEA-15-240-RWT_BeamDyn.dat", "../IEA-15-240-RWT/IEA-15-240-RWT_BeamDyn.dat" , "../IEA-15-240-RWT/IEA-15-240-RWT_BeamDyn.dat" , "../IEA-15-240-RWT/IEA-15-240-RWT_InflowFile.dat", "../IEA-15-240-RWT/IEA-15-240-RWT_AeroDyn15.dat", "IEA-15-240-RWT-Monopile_ServoDyn.dat","unused", "unused", "unused", "unused" };
            for (int i = 0; i < 11; i++)
            {
                EDFile[i] = new EDFile_227();
                EDFile[i].value = Input[i];
            }
        }
        public void setValue(List<object> obj)
        {
            List<string> str1 = (List<string>)obj[0];
            for (int i = 0; i < 11; i++)
            {
                EDFile[i].value = str1[i];
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            List<string> str1 = new List<string>();
            for (int i = 0; i < 11; i++)
            {
                str1.Add(Convert.ToString(EDFile[i].value));
            }
            obj.Add(str1);
            return obj;
        }
        public EDFile_227[] EDFile = new EDFile_227[11];
    }
    public class EDFile_227
    {
        public string value;
    }
    public class AerodynamicControl_228
    {
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            AA_InputFile.value = (string)obj[1];
            OLAFInputFileName.value = (string)obj[2];
            UseBlCm.value = bool.Parse((string)obj[3]);
            ADBlFile_1.value = (string)obj[4];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(AA_InputFile.value));
            obj.Add(Convert.ToString(OLAFInputFileName.value));
            obj.Add(Convert.ToString(UseBlCm.value));
            obj.Add(Convert.ToString(ADBlFile_1.value));
            return obj;
        }
        public Echo_229 Echo = new Echo_229();
        public AA_InputFile_230 AA_InputFile = new AA_InputFile_230();
        public BEM_Options_231 BEM_Options = new BEM_Options_231();
        public OLAFInputFileName_233 OLAFInputFileName = new OLAFInputFileName_233();
        public DynamicStall_234 DynamicStall = new DynamicStall_234();
        public UseBlCm_237 UseBlCm = new UseBlCm_237();
        public ADBlFile_1_238 ADBlFile_1 = new ADBlFile_1_238();
    }
    public class Echo_229
    {
        public bool value = new bool();
    }
    public class AA_InputFile_230
    {
        public string value;
    }
    public class BEM_Options_231
    {
        public void setValue(List<object> obj)
        {
            SkewMod.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SkewMod.value));
            return obj;
        }
        public SkewMod_232 SkewMod = new SkewMod_232();
    }
    public class SkewMod_232
    {
        public int value = 2;
    }
    public class OLAFInputFileName_233
    {
        public string value = "unused";
    }
    public class DynamicStall_234
    {
        public void setValue(List<object> obj)
        {
            UAMod.value = int.Parse((string)obj[0]);
            Flookup.value = bool.Parse((string)obj[1]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(UAMod.value));
            obj.Add(Convert.ToString(Flookup.value));
            return obj;
        }
        public UAMod_235 UAMod = new UAMod_235();
        public Flookup_236 Flookup = new Flookup_236();
    }
    public class UAMod_235
    {
        public int value = 3;
    }
    public class Flookup_236
    {
        public bool value = true;
    }
    public class UseBlCm_237
    {
        public bool value = true;
    }
    public class ADBlFile_1_238
    {
        public string value;
    }
    public class StructureSimulationControl_239
    {
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            Method.value = int.Parse((string)obj[1]);
            DT.value = double.Parse((string)obj[2]);
            BldFile_1.value = (string)obj[3];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(Method.value));
            obj.Add(Convert.ToString(DT.value));
            obj.Add(Convert.ToString(BldFile_1.value));
            return obj;
        }
        public Echo_240 Echo = new Echo_240();
        public Method_241 Method = new Method_241();
        public DT_242 DT = new DT_242();
        public DOF_243 DOF = new DOF_243();
        public InitialConditions_245 InitialConditions = new InitialConditions_245();
        public BldFile_1_257 BldFile_1 = new BldFile_1_257();
    }
    public class Echo_240
    {
        public bool value = new bool();
    }
    public class Method_241
    {
        public int value = new int();
    }
    public class DT_242
    {
        public double value = 0.005;
    }
    public class DOF_243
    {
        public DOF_243()
        {
            for (int i = 0; i < 17; i++)
            {
                DOFOrder[i] = new DOFOrder_244();
            }
        }
        public void setValue(List<object> obj)
        {
            List<string> str1 = (List<string>)obj[0];
            for (int i = 0; i < 17; i++)
            {
                DOFOrder[i].value = bool.Parse(str1[i]);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            List<string> str1 = new List<string>();
            for (int i = 0; i < 17; i++)
            {
                str1.Add(Convert.ToString(DOFOrder[i].value));
            }
            obj.Add(str1);
            return obj;
        }
        public DOFOrder_244[] DOFOrder = new DOFOrder_244[17];
    }
    public class DOFOrder_244
    {
        public bool value = new bool();
    }
    public class InitialConditions_245
    {
        public void setValue(List<object> obj)
        {
            OoPDefl.value = double.Parse((string)obj[0]);
            IPDefl.value = double.Parse((string)obj[1]);
            BlPitch_1.value = double.Parse((string)obj[2]);
            BlPitch_2.value = double.Parse((string)obj[3]);
            BlPitch_3.value = double.Parse((string)obj[4]);
            TeetDefl.value = double.Parse((string)obj[5]);
            Azimuth.value = double.Parse((string)obj[6]);
            RotSpeed.value = double.Parse((string)obj[7]);
            NacYaw.value = double.Parse((string)obj[8]);
            TTDspFA.value = double.Parse((string)obj[9]);
            TTDspSS.value = double.Parse((string)obj[10]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(OoPDefl.value));
            obj.Add(Convert.ToString(IPDefl.value));
            obj.Add(Convert.ToString(BlPitch_1.value));
            obj.Add(Convert.ToString(BlPitch_2.value));
            obj.Add(Convert.ToString(BlPitch_3.value));
            obj.Add(Convert.ToString(TeetDefl.value));
            obj.Add(Convert.ToString(Azimuth.value));
            obj.Add(Convert.ToString(RotSpeed.value));
            obj.Add(Convert.ToString(NacYaw.value));
            obj.Add(Convert.ToString(TTDspFA.value));
            obj.Add(Convert.ToString(TTDspSS.value));
            return obj;
        }
        public OoPDefl_246 OoPDefl = new OoPDefl_246();
        public IPDefl_247 IPDefl = new IPDefl_247();
        public BlPitch_1_248 BlPitch_1 = new BlPitch_1_248();
        public BlPitch_2_249 BlPitch_2 = new BlPitch_2_249();
        public BlPitch_3_250 BlPitch_3 = new BlPitch_3_250();
        public TeetDefl_251 TeetDefl = new TeetDefl_251();
        public Azimuth_252 Azimuth = new Azimuth_252();
        public RotSpeed_253 RotSpeed = new RotSpeed_253();
        public NacYaw_254 NacYaw = new NacYaw_254();
        public TTDspFA_255 TTDspFA = new TTDspFA_255();
        public TTDspSS_256 TTDspSS = new TTDspSS_256();
    }
    public class OoPDefl_246
    {
        public double value = new double();
    }
    public class IPDefl_247
    {
        public double value = new double();
    }
    public class BlPitch_1_248
    {
        public double value = new double();
    }
    public class BlPitch_2_249
    {
        public double value = new double();
    }
    public class BlPitch_3_250
    {
        public double value = new double();
    }
    public class TeetDefl_251
    {
        public double value = new double();
    }
    public class Azimuth_252
    {
        public double value = new double();
    }
    public class RotSpeed_253
    {
        public double value = new double();
    }
    public class NacYaw_254
    {
        public double value = new double();
    }
    public class TTDspFA_255
    {
        public double value = new double();
    }
    public class TTDspSS_256
    {
        public double value = new double();
    }
    public class BldFile_1_257
    {
        public string value= "../IEA-15-240-RWT/IEA-15-240-RWT_ElastoDyn_blade.dat";
    }
    public class NonLinearSimulationControl_258
    {
        public void setValue(List<object> obj)
        {
            Echo.value = bool.Parse((string)obj[0]);
            QuasiStaticInit.value = bool.Parse((string)obj[1]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(Echo.value));
            obj.Add(Convert.ToString(QuasiStaticInit.value));
            return obj;
        }
        public Echo_259 Echo = new Echo_259();
        public QuasiStaticInit_260 QuasiStaticInit = new QuasiStaticInit_260();
    }
    public class Echo_259
    {
        public bool value = new bool();
    }
    public class QuasiStaticInit_260
    {
        public bool value = true;
    }
    public class Outputs_261
    {
        public GeneralOutputSetting_262 GeneralOutputSetting = new GeneralOutputSetting_262();
        public Viualization_264 Viualization = new Viualization_264();
        public AerodynamicOutputs_266 AerodynamicOutputs = new AerodynamicOutputs_266();
        public StructureDynamicOutputs_273 StructureDynamicOutputs = new StructureDynamicOutputs_273();
        public windOutputs_275 windOutputs = new windOutputs_275();
        public NonlinearOutputs_278 NonlinearOutputs = new NonlinearOutputs_278();
        public ControlOutputs_281 ControlOutputs = new ControlOutputs_281();
    }
    public class GeneralOutputSetting_262
    {
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            return obj;
        }
        public SumPrint_263 SumPrint = new SumPrint_263();
    }
    public class SumPrint_263
    {
        public bool value = new bool();
    }
    public class Viualization_264
    {
        public void setValue(List<object> obj)
        {
            WrVTK.value = int.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(WrVTK.value));
            return obj;
        }
        public WrVTK_265 WrVTK = new WrVTK_265();
    }
    public class WrVTK_265
    {
        public int value = new int();
    }
    public class AerodynamicOutputs_266
    {
        public AerodynamicOutputs_266()
        {
            BlOutNd.Add(new BlOutNd_269());
            TwOutNd.Add(new TwOutNd_271());
            OutList.Add(new OutList_272());
        }
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
            NBlOuts.value = int.Parse((string)obj[1]);
            List<string> str2 = (List<string>)obj[2];
            for (int i = 0; i < str2.Count(); i++)
            {
                BlOutNd_269 t = new BlOutNd_269();
                t.value = int.Parse(str2[i]);
                BlOutNd.Add(t);
            }
            NTwOuts.value = int.Parse((string)obj[3]);
            str2 = (List<string>)obj[4];
            for (int i = 0; i < str2.Count(); i++)
            {
                TwOutNd_271 t = new TwOutNd_271();
                t.value = int.Parse(str2[i]);
                TwOutNd.Add(t);
            }
            str2 = (List<string>)obj[5];
            for (int i = 0; i < str2.Count(); i++)
            {
                OutList_272 t = new OutList_272();
                t.value = str2[i];
                OutList.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            obj.Add(Convert.ToString(NBlOuts.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < BlOutNd.Count(); i++)
            {
                str2.Add(Convert.ToString(BlOutNd[i].value));
            }
            obj.Add(str2);
            obj.Add(Convert.ToString(NTwOuts.value));
            List<string> str3 = new List<string>();
            for (int i = 0; i < TwOutNd.Count(); i++)
            {
                str3.Add(Convert.ToString(TwOutNd[i].value));
            }
            obj.Add(str3);
            List<string> str4 = new List<string>();
            for (int i = 0; i < OutList.Count(); i++)
            {
                str4.Add(Convert.ToString(OutList[i].value));
            }
            obj.Add(str4);
            return obj;
        }
        public SumPrint_267 SumPrint = new SumPrint_267();
        public NBlOuts_268 NBlOuts = new NBlOuts_268();
        public List<BlOutNd_269> BlOutNd = new List<BlOutNd_269>();
        public NTwOuts_270 NTwOuts = new NTwOuts_270();
        public List<TwOutNd_271> TwOutNd = new List<TwOutNd_271>();
        public List<OutList_272> OutList = new List<OutList_272>();
    }
    public class SumPrint_267
    {
        public bool value = new bool();
    }
    public class NBlOuts_268
    {
        public int value = 9;
    }
    public class BlOutNd_269
    {
        public int value = new int();
    }
    public class NTwOuts_270
    {
        public int value = 9;
    }
    public class TwOutNd_271
    {
        public int value = new int();
    }
    public class OutList_272
    {
        public string value;
    }
    public class StructureDynamicOutputs_273
    {
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            return obj;
        }
        public SumPrint_274 SumPrint = new SumPrint_274();
    }
    public class SumPrint_274
    {
        public bool value = new bool();
    }
    public class windOutputs_275
    {
        public windOutputs_275()
        {
            OutList.Add(new OutList_277());
        }
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
            List<string> str2 = (List<string>)obj[1];
            for (int i = 0; i < str2.Count(); i++)
            {
                OutList_277 t = new OutList_277();
                t.value = str2[i];
                OutList.Add(t);
            }
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            List<string> str2 = new List<string>();
            for (int i = 0; i < OutList.Count(); i++)
            {
                str2.Add(Convert.ToString(OutList[i].value));
            }
            obj.Add(str2);
            return obj;
        }
        public SumPrint_276 SumPrint = new SumPrint_276();
        public List<OutList_277> OutList = new List<OutList_277>();
    }
    public class SumPrint_276
    {
        public bool value = new bool();
    }
    public class OutList_277
    {
        public string value;
    }
    public class NonlinearOutputs_278
    {
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
            OutFmt.value = (string)obj[1];
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            obj.Add(Convert.ToString(OutFmt.value));
            return obj;
        }
        public SumPrint_279 SumPrint = new SumPrint_279();
        public OutFmt_280 OutFmt = new OutFmt_280();
    }
    public class SumPrint_279
    {
        public bool value = true;
    }
    public class OutFmt_280
    {
        public string value= "\"ES10.3E2\"";
    }
    public class ControlOutputs_281
    {
        public void setValue(List<object> obj)
        {
            SumPrint.value = bool.Parse((string)obj[0]);
        }
        public List<object> getValue()
        {
            List<object> obj = new List<object>();
            obj.Add(Convert.ToString(SumPrint.value));
            return obj;
        }
        public SumPrint_282 SumPrint = new SumPrint_282();
    }
    public class SumPrint_282
    {
        public bool value = true;
    }
}
