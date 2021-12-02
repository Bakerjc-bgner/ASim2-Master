using ASimFormsLibrary;
using ASimInterfaces;
using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableLibrary;
using DataLibrary;
using Newtonsoft.Json;
using System.IO;
using ASimChart;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace ASim2
{
    public partial class ASimForm : Form
    {
        Simulation_0 sim0 = new Simulation_0();
        Simulation simulation = new Simulation("Simulation", 0);
        private int LastID = 0;
        private int nowID = 0;
        //VarShow VS = new VarShow();
        ShowVar VS = new ShowVar();
        Test1 t1 = new Test1();
        //ArrayShow AShow = new ArrayShow();
        ShowArray AShow = new ShowArray();
        public ASimForm()
        {
            InitializeComponent();
            this.parameterView1.SelectObjectChanged += new Action<VisibleObject>(parameterListView1_SelectObjectChanged);
            this.comboBox1.Visible = false;
            this.SectionMatrixSourse.Add(1);
            this.runStopToolStripMenuItem.Visible = false;
        }
        private void parameterListView1_SelectObjectChanged(VisibleObject obj)//树形结构与显示界面关联
        {
            nowID = obj.ID;
            int i = new int();
            if(obj.ID == 152|| obj.ID ==153|| obj.ID ==178|| obj.ID ==170|| obj.ID == 59 || nowID == 157 || nowID == 163)
            {
                if (obj.ID == 59)
                {
                    int[] tem = new int[this.SectionMatrixSourse.Count];
                    for (int k = 0; k < this.SectionMatrixSourse.Count; k++)
                    {
                        tem[k] = this.SectionMatrixSourse[k];
                    }
                    this.comboBox1.DataSource = tem;
                }
                else
                {
                    this.comboBox1.DataSource = this.AirfoilSourse;
                }
                i = (int)this.comboBox1.SelectedValue - 1;
               
            }
            List<object> vs = VS.SaveData();
            string[,] As = AShow.SaveData();
            bool vsSave = true, AsSave = true;
            for(int j = 0; j < vs.Count; j++)
            {
                if (vs[j] == null)
                {
                    vsSave = false;
                    break;
                }
            }
            for(int j = 0; j < As.GetLength(0); j++)
            {
                if (As[j,0] == null)
                {
                    AsSave = false;
                    break;
                }
            }
            if ((vsSave||AsSave) && LastID != obj.ID)
            {
                if (LastID == 2)
                {
                    sim0.WindTurbine.TurbineConfiguration.setValue(vs);
                }
                else if (LastID == 18)
                {
                    sim0.WindTurbine.MassInfo.setValue(vs);
                }
                else if (LastID == 29)
                {
                    sim0.WindTurbine.Blade.setValue(vs);
                }
                else if (LastID == 75)
                {
                    sim0.WindTurbine.Tower.setValue(vs);
                }
                else if (LastID == 98)
                {
                    sim0.WindTurbine.DriveTrain.setValue(vs);
                }
                else if (LastID == 103)
                {
                    sim0.WindTurbine.Control.setValue(vs);
                }
                else if (LastID == 152)
                {
                    sim0.Airfoil[i].setValue(vs);
                }
                else if (LastID == 153)
                {
                    sim0.Airfoil[i].Airfoilfile.setValue(vs);
                }
                else if (LastID == 170)
                {
                    sim0.Airfoil[i].AirfoilBasicSetting.setValue(vs);

                }
                else if (LastID == 178)
                {
                    sim0.Airfoil[i].AirfoilDataInfo.setValue(vs);
                }
                else if (LastID == 185)
                {
                    sim0.Environment.EnvironmentalConditions.setValue(vs);
                }
                else if (LastID == 190)
                {
                    sim0.Environment.WindCondition.setValue(vs);
                }
                else if (LastID == 220)
                {
                    sim0.SimulationControl.BasicControl.setValue(vs);
                }
                else if (LastID == 224)
                {
                    sim0.SimulationControl.SimulationFlags.setValue(vs);
                }
                else if (LastID == 226)
                {
                    sim0.SimulationControl.InputFiles.setValue(vs);
                }
                else if (LastID == 228)
                {
                    sim0.SimulationControl.AerodynamicControl.setValue(vs);
                }
                else if (LastID == 239)
                {
                    sim0.SimulationControl.StructureSimulationControl.setValue(vs);
                }
                else if (LastID == 258)
                {
                    sim0.SimulationControl.NonLinearSimulationControl.setValue(vs);
                }
                else if (LastID == 262)
                {
                    sim0.Outputs.GeneralOutputSetting.setValue(vs);
                }
                else if (LastID == 264)
                {
                    sim0.Outputs.Viualization.setValue(vs);
                }
                else if (LastID == 266)
                {
                    sim0.Outputs.AerodynamicOutputs.setValue(vs);
                }
                else if (LastID == 273)
                {
                    sim0.Outputs.StructureDynamicOutputs.setValue(vs);
                }
                else if (LastID == 275)
                {
                    sim0.Outputs.windOutputs.setValue(vs);
                }
                else if (LastID == 278)
                {
                    sim0.Outputs.NonlinearOutputs.setValue(vs);
                }
                else if (LastID == 281)
                {
                    sim0.Outputs.ControlOutputs.setValue(vs);
                }
                else if (LastID == 31)
                {
                    if(As.GetLength(0) != sim0.WindTurbine.Blade.NumBlNds.value)
                    {
                        MessageBox.Show("所输入的数值数量与NumBlNds对应数值不一致，请确认您输入正确");
                    }
                    for (int x = sim0.WindTurbine.Blade.BladeStation.Count + 1; x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Blade.BladeStation.Add(new BladeStation_31());
                    }
                    for (int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for (int y = 0; y < As.GetLength(1); y++)
                        {
                            ans.Add(As[x,y]);
                        }
                        sim0.WindTurbine.Blade.BladeStation[x].setValue(ans);
                    }
                }
                else if (LastID == 45)
                {
                    for(int x = sim0.WindTurbine.Blade.NonlinearKeyPoints.Count + 1;x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Blade.NonlinearKeyPoints.Add(new NonlinearKeyPoints_45());
                    }
                    for(int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for(int y =0;y< As.GetLength(1); y++)
                        {
                            ans.Add(As[x, y]);
                        }
                        sim0.WindTurbine.Blade.NonlinearKeyPoints[x].setValue(ans);
                    }
                }
                else if (LastID == 50)
                {
                    sim0.WindTurbine.Blade.NonlinearBladeInfo.setValue(vs);
                }
                else if (LastID == 59)
                {
                    sim0.WindTurbine.Blade.SectionMatrix[i].setValue(vs);
                }
                else if (LastID == 63)
                {
                    sim0.WindTurbine.Blade.BladeModes[0].setValue(vs);
                }
                else if (LastID == 78)
                {
                    for (int x = sim0.WindTurbine.Tower.towerStation.Count + 1; x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Tower.towerStation.Add(new towerStation_78());
                    }
                    for (int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for (int y = 0; y < As.GetLength(1); y++)
                        {
                            ans.Add(As[x, y]);
                        }
                        sim0.WindTurbine.Tower.towerStation[x].setValue(ans);
                    }
                    //sim0.WindTurbine.Tower.towerStation[0].setValue(vs);
                }
                else if (LastID == 86)
                {
                    sim0.WindTurbine.Tower.towerModes[0].setValue(vs);
                }
                else if (LastID == 106)
                {
                    sim0.WindTurbine.Control.pitchControl.setValue(vs);
                }
                else if (LastID == 112)
                {
                    sim0.WindTurbine.Control.TorqueControl.setValue(vs);
                }
                else if (LastID == 121)
                {
                    sim0.WindTurbine.Control.SimpleTorqueControl.setValue(vs);
                }
                else if (LastID == 126)
                {
                    sim0.WindTurbine.Control.inductonGenerator.setValue(vs);
                }
                else if (LastID == 128)
                {
                    sim0.WindTurbine.Control.HSBrake.setValue(vs);
                }
                else if (LastID == 133)
                {
                    sim0.WindTurbine.Control.yawControl.setValue(vs);
                }
                else if (LastID == 135)
                {
                    sim0.WindTurbine.Control.massDamper.setValue(vs);
                }
                else if (LastID == 138)
                {
                    sim0.WindTurbine.Control.BladedInterface_Dll.setValue(vs);
                }
                else if (LastID == 143)
                {
                    sim0.WindTurbine.Control.BladedInterface_Torque.setValue(vs);
                }
                else if (LastID == 147)
                {
                    sim0.WindTurbine.Control.PitcActuator.setValue(vs);
                }
                else if (LastID == 149)
                {
                    sim0.WindTurbine.Control.Linearization.setValue(vs);
                }
                else if (LastID == 157)
                {
                    sim0.Airfoil[0].Airfoilfile.AirfoilPerformance[0].setValue(vs);
                }
                else if (LastID == 163)
                {
                    sim0.Airfoil[0].Airfoilfile.AirfoilShape.setValue(vs);
                }
                else if (LastID == 191)
                {
                    sim0.Environment.WindCondition.WindBasicInfo.setValue(vs);
                }
                else if (LastID == 199)
                {
                    sim0.Environment.WindCondition.SteadyWind.setValue(vs);
                }
                else if (LastID == 203)
                {
                    sim0.Environment.WindCondition.Uniformwind.setValue(vs);
                }
                else if (LastID == 210)
                {
                    sim0.Environment.WindCondition.HawcWindFile.setValue(vs);
                }
                else if (LastID == 212)
                {
                    sim0.Environment.WindCondition.ScalingParameters.setValue(vs);
                }
                else if (LastID == 214)
                {
                    sim0.Environment.WindCondition.MeanWindProfoile.setValue(vs);
                }
                else if (LastID == 231)
                {
                    sim0.SimulationControl.AerodynamicControl.BEM_Options.setValue(vs);
                }
                else if (LastID == 234)
                {
                    sim0.SimulationControl.AerodynamicControl.DynamicStall.setValue(vs);
                }
                else if (LastID == 243)
                {
                    sim0.SimulationControl.StructureSimulationControl.DOF.setValue(vs);
                }
                else if (LastID == 245)
                {
                    sim0.SimulationControl.StructureSimulationControl.InitialConditions.setValue(vs);
                }
            }
            else
            {
                if(LastID != obj.ID)
                {
                    MessageBox.Show("请输入完整数值，请勿输入空值。\n 如果出现空值本页面将不会保存，需要您重新输入！！！");
                }

            }
            LastID = obj.ID;
            int mode = 0;
            this.dataToolStripMenuItem.Visible = false;
            this.panel1.Controls.Clear();
            this.addItemToolStripMenuItem.Visible = false;
            this.comboBox1.Visible = false;
            if (obj.ID == 2)
            {
                List<object> o = sim0.WindTurbine.TurbineConfiguration.getValue();

                VS.DataLoad(t1.sd1, t1.sc1, t1.sa1, t1.sb1, sim0.WindTurbine.TurbineConfiguration.getValue());
            }
            else if (obj.ID == 18)
            {
                VS.DataLoad(t1.sd2, t1.sc2, t1.sa2, t1.sb2, sim0.WindTurbine.MassInfo.getValue());
            }
            else if (obj.ID == 29)
            {
                VS.DataLoad(t1.sd3, t1.sc3, t1.sa3, t1.sb3, sim0.WindTurbine.Blade.getValue());
            }
            else if (obj.ID == 75)
            {
                VS.DataLoad(t1.sd4, t1.sc4, t1.sa4, t1.sb4, sim0.WindTurbine.Tower.getValue());
            }
            else if (obj.ID == 98)
            {
                VS.DataLoad(t1.sd5, t1.sc5, t1.sa5, t1.sb5, sim0.WindTurbine.DriveTrain.getValue());
            }
            else if (obj.ID == 103)
            {
                VS.DataLoad(t1.sd6, t1.sc6, t1.sa6, t1.sb6, sim0.WindTurbine.Control.getValue());
            }
            else if (obj.ID == 152)
            {
                mode = 3;
                VS.DataLoad(t1.sd7, t1.sc7, t1.sa7, t1.sb7, t1.se7, sim0.Airfoil[i].getValue());
            }
            else if (obj.ID == 153)
            {
                mode = 3;
                VS.DataLoad(t1.sd8, t1.sc8, t1.sa8, t1.sb8, t1.se8, sim0.Airfoil[i].Airfoilfile.getValue());
            }
            else if (obj.ID == 170)
            {
                mode = 3;
                VS.DataLoad(t1.sd9, t1.sc9, t1.sa9, t1.sb9, t1.se9, sim0.Airfoil[i].AirfoilBasicSetting.getValue());
            }
            else if (obj.ID == 178)
            {
                mode = 3;
                VS.DataLoad(t1.sd10, t1.sc10, t1.sa10, t1.sb10, sim0.Airfoil[i].AirfoilDataInfo.getValue());
            }
            else if (obj.ID == 185)
            {
                VS.DataLoad(t1.sd11, t1.sc11, t1.sa11, t1.sb11, sim0.Environment.EnvironmentalConditions.getValue());
            }
            else if (obj.ID == 190)
            {
                VS.DataLoad(t1.sd12, t1.sc12, t1.sa12, t1.sb12, sim0.Environment.WindCondition.getValue());
            }
            else if (obj.ID == 220)
            {
                VS.DataLoad(t1.sd13, t1.sc13, t1.sa13, t1.sb13, sim0.SimulationControl.BasicControl.getValue());
            }
            else if (obj.ID == 224)
            {
                List<object> conpElast = sim0.SimulationControl.SimulationFlags.getValue();
                List<object> Ter = new List<object>();
                Ter.Add(conpElast[0]);
                List<string> o = (List<string>)conpElast[1];
                foreach (string item in o)
                {
                    Ter.Add(item);
                }
                VS.DataLoad(t1.sd14, t1.sc14, t1.sa14, t1.sb14, t1.se14, Ter);
            }
            else if (obj.ID == 226)
            {
                VS.DataLoad(t1.sd15, t1.sc15, t1.sa15, t1.sb15, t1.se15, sim0.SimulationControl.InputFiles.getValue());
            }
            else if (obj.ID == 228)
            {
                VS.DataLoad(t1.sd16, t1.sc16, t1.sa16, t1.sb16, sim0.SimulationControl.AerodynamicControl.getValue());
            }
            else if (obj.ID == 239)
            {
                VS.DataLoad(t1.sd17, t1.sc17, t1.sa17, t1.sb17, t1.se17, sim0.SimulationControl.StructureSimulationControl.getValue());
            }
            else if (obj.ID == 258)
            {
                VS.DataLoad(t1.sd18, t1.sc18, t1.sa18, t1.sb18, sim0.SimulationControl.NonLinearSimulationControl.getValue());
            }
            else if (obj.ID == 262)
            {
                VS.DataLoad(t1.sd19, t1.sc19, t1.sa19, t1.sb19, sim0.Outputs.GeneralOutputSetting.getValue());
            }
            else if (obj.ID == 264)
            {
                VS.DataLoad(t1.sd20, t1.sc20, t1.sa20, t1.sb20, t1.se20, sim0.Outputs.Viualization.getValue());
            }
            else if (obj.ID == 266)
            {
                VS.DataLoad(t1.sd21, t1.sc21, t1.sa21, t1.sb21, t1.se21, sim0.Outputs.AerodynamicOutputs.getValue());
            }
            else if (obj.ID == 273)
            {
                VS.DataLoad(t1.sd22, t1.sc22, t1.sa22, t1.sb22, sim0.Outputs.StructureDynamicOutputs.getValue());
            }
            else if (obj.ID == 275)
            {
                VS.DataLoad(t1.sd23, t1.sc23, t1.sa23, t1.sb23, t1.se23, sim0.Outputs.windOutputs.getValue());
            }
            else if (obj.ID == 278)
            {
                VS.DataLoad(t1.sd24, t1.sc24, t1.sa24, t1.sb24, sim0.Outputs.NonlinearOutputs.getValue());
            }
            else if (obj.ID == 281)
            {
                VS.DataLoad(t1.sd25, t1.sc25, t1.sa25, t1.sb25, sim0.Outputs.ControlOutputs.getValue());
            }
            else if (obj.ID == 31)
            {
                mode = 1;
                string[,] str = new string[sim0.WindTurbine.Blade.BladeStation.Count, 13];
                for (int x = 0; x < sim0.WindTurbine.Blade.BladeStation.Count; x++)
                {
                    List<object> st = sim0.WindTurbine.Blade.BladeStation[x].getValue();
                    for (int y = 0; y < 13; y++)
                    {
                        str[x, y] = (string)st[y];
                    }
                }
                int len = Math.Max(50, sim0.WindTurbine.Blade.BladeStation.Count);
                AShow.DataLoad(t1.sc26, t1.sa26, t1.sb26, len, str, t1.sd26);
            }
            else if (obj.ID == 45)
            {
                mode = 1;
                string[,] str = new string[sim0.WindTurbine.Blade.NonlinearKeyPoints.Count,4];
                for(int x = 0; x< sim0.WindTurbine.Blade.NonlinearKeyPoints.Count; x++)
                {
                    List<object> st = sim0.WindTurbine.Blade.NonlinearKeyPoints[x].getValue();
                    string ans = "";
                    for(int y = 0; y < 4; y++)
                    {
                        str[x, y] = (string)st[y];
                        ans += str[x, y] + " ";
                    }
                }
                int len = Math.Max(10, sim0.WindTurbine.Blade.NonlinearKeyPoints.Count);
                AShow.DataLoad(t1.sc27, t1.sa27, t1.sb27, len, str, t1.sd27);
            }
            else if (obj.ID == 50)
            {
                VS.DataLoad(t1.sd28, t1.sc28, t1.sa28, t1.sb28, t1.se28, sim0.WindTurbine.Blade.NonlinearBladeInfo.getValue());
            }
            else if (obj.ID == 59)
            {
                mode = 2;
                VS.DataLoad(t1.sd29, t1.sc29, t1.sa29, t1.sb29, t1.se29, sim0.WindTurbine.Blade.SectionMatrix[i].getValue());
            }
            else if (obj.ID == 63)
            {
                VS.DataLoad(t1.sd30, t1.sc30, t1.sa30, t1.sb30, t1.se30, sim0.WindTurbine.Blade.BladeModes[0].getValue());
            }
            else if (obj.ID == 78)
            {
                mode = 1;
                string[,] str = new string[sim0.WindTurbine.Tower.towerStation.Count, 7];
                for (int x = 0; x < sim0.WindTurbine.Tower.towerStation.Count; x++)
                {
                    List<object> st = sim0.WindTurbine.Tower.towerStation[x].getValue();
                    for (int y = 0; y < 7; y++)
                    {
                        str[x, y] = (string)st[y];
                    }
                }
                int len = Math.Max(10, sim0.WindTurbine.Tower.towerStation.Count);
                AShow.DataLoad(t1.sc31, t1.sa31, t1.sb31, len, str, t1.sd31);
            }
            else if (obj.ID == 86)
            {
                VS.DataLoad(t1.sd32, t1.sc32, t1.sa32, t1.sb32, t1.se32, sim0.WindTurbine.Tower.towerModes[0].getValue());
            }
            else if (obj.ID == 106)
            {
                VS.DataLoad(t1.sd33, t1.sc33, t1.sa33, t1.sb33, t1.se33, sim0.WindTurbine.Control.pitchControl.getValue());
            }
            else if (obj.ID == 112)
            {
                VS.DataLoad(t1.sd34, t1.sc34, t1.sa34, t1.sb34, t1.se34, sim0.WindTurbine.Control.TorqueControl.getValue());
            }
            else if (obj.ID == 121)
            {
                VS.DataLoad(t1.sd35, t1.sc35, t1.sa35, t1.sb35, sim0.WindTurbine.Control.SimpleTorqueControl.getValue());
            }
            else if (obj.ID == 126)
            {
                VS.DataLoad(t1.sd36, t1.sc36, t1.sa36, t1.sb36, sim0.WindTurbine.Control.inductonGenerator.getValue());
            }
            else if (obj.ID == 128)
            {
                VS.DataLoad(t1.sd37, t1.sc37, t1.sa37, t1.sb37, sim0.WindTurbine.Control.HSBrake.getValue());
            }
            else if (obj.ID == 133)
            {
                VS.DataLoad(t1.sd38, t1.sc38, t1.sa38, t1.sb38, sim0.WindTurbine.Control.yawControl.getValue());
            }
            else if (obj.ID == 135)
            {
                VS.DataLoad(t1.sd39, t1.sc39, t1.sa39, t1.sb39, sim0.WindTurbine.Control.massDamper.getValue());
            }
            else if (obj.ID == 138)
            {
                VS.DataLoad(t1.sd40, t1.sc40, t1.sa40, t1.sb40, sim0.WindTurbine.Control.BladedInterface_Dll.getValue());
            }
            else if (obj.ID == 143)
            {
                VS.DataLoad(t1.sd41, t1.sc41, t1.sa41, t1.sb41, t1.se41, sim0.WindTurbine.Control.BladedInterface_Torque.getValue());
            }
            else if (obj.ID == 147)
            {
                VS.DataLoad(t1.sd42, t1.sc42, t1.sa42, t1.sb42, sim0.WindTurbine.Control.PitcActuator.getValue());
            }
            else if (obj.ID == 149)
            {
                VS.DataLoad(t1.sd43, t1.sc43, t1.sa43, t1.sb43, sim0.WindTurbine.Control.Linearization.getValue());
            }
            else if (obj.ID == 157)
            {
                mode = 3;
                VS.DataLoad(t1.sd44, t1.sc44, t1.sa44, t1.sb44, t1.se44, sim0.Airfoil[i].Airfoilfile.AirfoilPerformance[0].getValue());
            }
            else if (obj.ID == 163)
            {
                mode = 3;
                VS.DataLoad(t1.sd45, t1.sc45, t1.sa45, t1.sb45, t1.se45, sim0.Airfoil[i].Airfoilfile.AirfoilShape.getValue());
            }
            else if (obj.ID == 191)
            {
                VS.DataLoad(t1.sd46, t1.sc46, t1.sa46, t1.sb46, t1.se46, sim0.Environment.WindCondition.WindBasicInfo.getValue());
            }
            else if (obj.ID == 199)
            {
                VS.DataLoad(t1.sd47, t1.sc47, t1.sa47, t1.sb47, sim0.Environment.WindCondition.SteadyWind.getValue());
            }
            else if (obj.ID == 203)
            {
                VS.DataLoad(t1.sd48, t1.sc48, t1.sa48, t1.sb48, sim0.Environment.WindCondition.Uniformwind.getValue());
            }
            else if (obj.ID == 210)
            {
                VS.DataLoad(t1.sd49, t1.sc49, t1.sa49, t1.sb49, sim0.Environment.WindCondition.HawcWindFile.getValue());
            }
            else if (obj.ID == 212)
            {
                VS.DataLoad(t1.sd50, t1.sc50, t1.sa50, t1.sb50, sim0.Environment.WindCondition.ScalingParameters.getValue());
            }
            else if (obj.ID == 214)
            {
                VS.DataLoad(t1.sd51, t1.sc51, t1.sa51, t1.sb51, sim0.Environment.WindCondition.MeanWindProfoile.getValue());
            }
            else if (obj.ID == 231)
            {
                VS.DataLoad(t1.sd52, t1.sc52, t1.sa52, t1.sb52, sim0.SimulationControl.AerodynamicControl.BEM_Options.getValue());
            }
            else if (obj.ID == 234)
            {
                VS.DataLoad(t1.sd53, t1.sc53, t1.sa53, t1.sb53, sim0.SimulationControl.AerodynamicControl.DynamicStall.getValue());
            }
            else if (obj.ID == 243)
            {
                VS.DataLoad(t1.sd54, t1.sc54, t1.sa54, t1.sb54, sim0.SimulationControl.StructureSimulationControl.DOF.getValue());
            }
            else if (obj.ID == 245)
            {
                VS.DataLoad(t1.sd55, t1.sc55, t1.sa55, t1.sb55, sim0.SimulationControl.StructureSimulationControl.InitialConditions.getValue());
            }
            if (mode == 0)
            {
                this.panel1.Controls.Add(VS);
                this.VS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            else if (mode == 1)
            {
                this.dataToolStripMenuItem.Visible = true;
                this.panel1.Controls.Add(AShow);
                this.AShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
            else if(mode == 2)
            {
                this.dataToolStripMenuItem.Visible = true;
                this.comboBox1.Visible = true;
                this.comboBox1.DataSource = this.SectionMatrixSourse;
                this.addItemToolStripMenuItem.Visible = true;
                this.panel1.Controls.Add(VS);
            }
            else if (mode == 3)
            {
                this.comboBox1.Visible = true;
                this.comboBox1.DataSource = this.AirfoilSourse;
                this.panel1.Controls.Add(VS);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//退出程序
        {
            DialogResult res = MessageBox.Show("真的要退出程序吗？若点确定将保存自动当前进度", "退出程序", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void introductionToolStripMenuItem_Click(object sender, EventArgs e)//打开使用说明书
        {
            System.Diagnostics.Process.Start("notepad.exe", "..\\Introduction.txt");
        }

        private AboutASim AS;
        private ExitForm EF;
        private void aboutASimToolStripMenuItem_Click(object sender, EventArgs e)//打开作者及其权限窗口
        {
            this.AS = new AboutASim();
            this.AS.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//自定义退出窗口
        {

            this.EF = new ExitForm();
            this.EF.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)//主界面载入时刷新树形结构
        {
            this.parameterView1.ChangeSimulation(simulation);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("提示信息", "标题", "文本内容", -1, -1);
            int num = 0;
            bool isRight = false;
            while(!isRight){
                try
                {
                    num = int.Parse(str);
                    isRight = true;
                }
                catch
                {
                    MessageBox.Show("请输入正确的数值");
                }
            }
            int length = this.AShow.getLenth();
            if(num + length >= 1000)
            {
                MessageBox.Show("您输入的数组长度过大，请重新输入");
                return;
            }
            for(int i = 0; i < num; i++)
            {
                this.AShow.add();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AShow.delete();
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (isChart)
            {
                this.panel1.Location = new Point(0, 29);
                this.panel1.Width = this.menuStrip1.Width;
                this.parameterView1.Visible = false;
                this.uc.Width = this.panel1.Width;
                this.uc.Height = this.panel1.Height;
            }
            else
            {
                this.parameterView1.Visible = true;
                this.comboBox1.BringToFront();
                this.parameterView1.Width = this.Width / 6;
                this.panel1.Location = new Point(this.parameterView1.Width, this.parameterView1.Location.Y);
                this.panel1.Width = this.Width - this.parameterView1.Width - 15;
                this.VS.SetSize(this.panel1.Height, this.panel1.Width);
                this.AShow.SetSize(this.panel1.Height, this.panel1.Width);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {            
            if (isChart)
            {
                this.panel1.Location = new Point(0, 29);
                this.panel1.Width = this.menuStrip1.Width;
                this.parameterView1.Visible = false;
                this.uc.Width = this.panel1.Width;
                this.uc.Height = this.panel1.Height;
            }
            else
            {
                this.parameterView1.Visible = true;
                this.comboBox1.BringToFront();
                this.parameterView1.Width = this.Width / 6;
                this.panel1.Location = new Point(this.parameterView1.Width + 5, this.parameterView1.Location.Y);
                this.panel1.Width = this.Width - this.parameterView1.Width - 15;
                this.VS.SetSize(this.panel1.Height, this.panel1.Width);
                this.AShow.SetSize(this.panel1.Height, this.panel1.Width);
            }
        }
        /// <summary>
        /// 将数据类保存到JSON字符串中
        /// </summary>
        /// <returns>JSON字符串</returns>
        public void SaveToJson(string path)
        {
            JsonSerializerSettings json1 = new JsonSerializerSettings();
            json1.DefaultValueHandling = DefaultValueHandling.Ignore;
            json1.ObjectCreationHandling = ObjectCreationHandling.Reuse;
            //json1.Formatting = Formatting.Indented;
            String json = JsonConvert.SerializeObject(sim0, Formatting.None, json1);
            StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
            sw.Write(json);
            sw.Flush();
            sw.Close();
            MessageBox.Show("成功保存数据");
        }
        /// <summary>
        /// 从JSON字符串中恢复数据类对象
        /// </summary>
        /// <param name="json">JSON字符串</param>
        /// <returns>是否成功恢复</returns>
        public bool JsonToSimulation(String json)
        {
            JsonSerializerSettings json1 = new JsonSerializerSettings();
            json1.DefaultValueHandling = DefaultValueHandling.Ignore;
            json1.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json1.Formatting = Formatting.Indented;
            sim0 = JsonConvert.DeserializeObject<Simulation_0>(json, json1);
            return sim0 != null;
        }

        private void parameterListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.parameterView1.ChangeSimulation(simulation);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<object> vs = VS.SaveData();
            string[,] As = AShow.SaveData();
            int i = new int();
            if (nowID == 152 || nowID == 153 || nowID == 178 || nowID == 170 || nowID == 59 || nowID == 157 || nowID == 163)
            {
                i = (int)this.comboBox1.SelectedValue - 1;

            }
            bool vsSave = true, AsSave = true;
            for (int j = 0; j < vs.Count; j++)
            {
                if (vs[j] == null)
                {
                    vsSave = false;
                    break;
                }
            }
            for (int j = 0; j < As.GetLength(0); j++)
            {
                if (As[j,0] == null)
                {
                    AsSave = false;
                    break;
                }
            }
            if (vsSave || AsSave)
            {
                if (nowID == 2)
                {
                    sim0.WindTurbine.TurbineConfiguration.setValue(vs);
                }
                else if (nowID == 18)
                {
                    sim0.WindTurbine.MassInfo.setValue(vs);
                }
                else if (nowID == 29)
                {
                    sim0.WindTurbine.Blade.setValue(vs);
                }
                else if (nowID == 75)
                {
                    sim0.WindTurbine.Tower.setValue(vs);
                }
                else if (nowID == 98)
                {
                    sim0.WindTurbine.DriveTrain.setValue(vs);
                }
                else if (nowID == 103)
                {
                    sim0.WindTurbine.Control.setValue(vs);
                }
                else if (nowID == 152)
                {
                    sim0.Airfoil[i].setValue(vs);
                }
                else if (nowID == 153)
                {
                    sim0.Airfoil[i].Airfoilfile.setValue(vs);
                }
                else if (nowID == 170)
                {
                    sim0.Airfoil[i].AirfoilBasicSetting.setValue(vs);
                }
                else if (nowID == 178)
                {
                    sim0.Airfoil[i].AirfoilDataInfo.setValue(vs);
                }
                else if (nowID == 185)
                {
                    sim0.Environment.EnvironmentalConditions.setValue(vs);
                }
                else if (nowID == 190)
                {
                    sim0.Environment.WindCondition.setValue(vs);
                }
                else if (nowID == 220)
                {
                    sim0.SimulationControl.BasicControl.setValue(vs);
                }
                else if (nowID == 224)
                {
                    sim0.SimulationControl.SimulationFlags.setValue(vs);
                }
                else if (nowID == 226)
                {
                    sim0.SimulationControl.InputFiles.setValue(vs);
                }
                else if (nowID == 228)
                {
                    sim0.SimulationControl.AerodynamicControl.setValue(vs);
                }
                else if (nowID == 239)
                {
                    sim0.SimulationControl.StructureSimulationControl.setValue(vs);
                }
                else if (nowID == 258)
                {
                    sim0.SimulationControl.NonLinearSimulationControl.setValue(vs);
                }
                else if (nowID == 262)
                {
                    sim0.Outputs.GeneralOutputSetting.setValue(vs);
                }
                else if (nowID == 264)
                {
                    sim0.Outputs.Viualization.setValue(vs);
                }
                else if (nowID == 266)
                {
                    sim0.Outputs.AerodynamicOutputs.setValue(vs);
                }
                else if (nowID == 273)
                {
                    sim0.Outputs.StructureDynamicOutputs.setValue(vs);
                }
                else if (nowID == 275)
                {
                    sim0.Outputs.windOutputs.setValue(vs);
                }
                else if (nowID == 278)
                {
                    sim0.Outputs.NonlinearOutputs.setValue(vs);
                }
                else if (nowID == 281)
                {
                    sim0.Outputs.ControlOutputs.setValue(vs);
                }
                else if (nowID == 31)
                {
                    if (As.GetLength(0) != sim0.WindTurbine.Blade.NumBlNds.value)
                    {
                        MessageBox.Show("所输入的数值数量与NumBlNds对应数值不一致，请确认您输入正确");
                    }
                    for (int x = sim0.WindTurbine.Blade.BladeStation.Count + 1; x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Blade.BladeStation.Add(new BladeStation_31());
                    }
                    for (int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for (int y = 0; y < As.GetLength(1); y++)
                        {
                            ans.Add(As[x, y]);
                        }
                        sim0.WindTurbine.Blade.BladeStation[x].setValue(ans);
                    }
                }
                else if (nowID == 45)
                {
                    for (int x = sim0.WindTurbine.Blade.NonlinearKeyPoints.Count + 1; x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Blade.NonlinearKeyPoints.Add(new NonlinearKeyPoints_45());
                    }
                    for (int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for (int y = 0; y < As.GetLength(1); y++)
                        {
                            ans.Add(As[x, y]);
                        }
                        sim0.WindTurbine.Blade.NonlinearKeyPoints[x].setValue(ans);
                    }
                }
                else if (nowID == 50)
                {
                    sim0.WindTurbine.Blade.NonlinearBladeInfo.setValue(vs);
                }
                else if (nowID == 59)
                {
                    sim0.WindTurbine.Blade.SectionMatrix[i].setValue(vs);
                }
                else if (nowID == 63)
                {
                    sim0.WindTurbine.Blade.BladeModes[0].setValue(vs);
                }
                else if (nowID == 78)
                {
                    for (int x = sim0.WindTurbine.Tower.towerStation.Count + 1; x <= As.GetLength(0); x++)
                    {
                        sim0.WindTurbine.Tower.towerStation.Add(new towerStation_78());
                    }
                    for (int x = 0; x < As.GetLength(0); x++)
                    {
                        List<object> ans = new List<object>();
                        for (int y = 0; y < As.GetLength(1); y++)
                        {
                            ans.Add(As[x, y]);
                        }
                        sim0.WindTurbine.Tower.towerStation[x].setValue(ans);
                    }
                }
                else if (nowID == 86)
                {
                    sim0.WindTurbine.Tower.towerModes[0].setValue(vs);
                }
                else if (nowID == 106)
                {
                    sim0.WindTurbine.Control.pitchControl.setValue(vs);
                }
                else if (nowID == 112)
                {
                    sim0.WindTurbine.Control.TorqueControl.setValue(vs);
                }
                else if (nowID == 121)
                {
                    sim0.WindTurbine.Control.SimpleTorqueControl.setValue(vs);
                }
                else if (nowID == 126)
                {
                    sim0.WindTurbine.Control.inductonGenerator.setValue(vs);
                }
                else if (nowID == 128)
                {
                    sim0.WindTurbine.Control.HSBrake.setValue(vs);
                }
                else if (nowID == 133)
                {
                    sim0.WindTurbine.Control.yawControl.setValue(vs);
                }
                else if (nowID == 135)
                {
                    sim0.WindTurbine.Control.massDamper.setValue(vs);
                }
                else if (nowID == 138)
                {
                    sim0.WindTurbine.Control.BladedInterface_Dll.setValue(vs);
                }
                else if (nowID == 143)
                {
                    sim0.WindTurbine.Control.BladedInterface_Torque.setValue(vs);
                }
                else if (nowID == 147)
                {
                    sim0.WindTurbine.Control.PitcActuator.setValue(vs);
                }
                else if (nowID == 149)
                {
                    sim0.WindTurbine.Control.Linearization.setValue(vs);
                }
                else if (nowID == 157)
                {
                    sim0.Airfoil[i].Airfoilfile.AirfoilPerformance[0].setValue(vs);
                }
                else if (nowID == 163)
                {
                    sim0.Airfoil[i].Airfoilfile.AirfoilShape.setValue(vs);
                }
                else if (nowID == 191)
                {
                    sim0.Environment.WindCondition.WindBasicInfo.setValue(vs);
                }
                else if (nowID == 199)
                {
                    sim0.Environment.WindCondition.SteadyWind.setValue(vs);
                }
                else if (nowID == 203)
                {
                    sim0.Environment.WindCondition.Uniformwind.setValue(vs);
                }
                else if (nowID == 210)
                {
                    sim0.Environment.WindCondition.HawcWindFile.setValue(vs);
                }
                else if (nowID == 212)
                {
                    sim0.Environment.WindCondition.ScalingParameters.setValue(vs);
                }
                else if (nowID == 214)
                {
                    sim0.Environment.WindCondition.MeanWindProfoile.setValue(vs);
                }
                else if (nowID == 231)
                {
                    sim0.SimulationControl.AerodynamicControl.BEM_Options.setValue(vs);
                }
                else if (nowID == 234)
                {
                    sim0.SimulationControl.AerodynamicControl.DynamicStall.setValue(vs);
                }
                else if (nowID == 243)
                {
                    sim0.SimulationControl.StructureSimulationControl.DOF.setValue(vs);
                }
                else if (nowID == 245)
                {
                    sim0.SimulationControl.StructureSimulationControl.InitialConditions.setValue(vs);
                }
            }
            string path = "";
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = System.Environment.CurrentDirectory;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.json)|*.json";
            
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                path = fileDialog.FileName;
                StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
                sw.Close();
                this.SaveToJson(path);
            }
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sw;
            string JsonStr = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = System.Environment.CurrentDirectory;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.json)|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                string fileName = fileInfo.FullName;
                string tableName = fileDialog.SafeFileName.TrimEnd('.', 'd', 'b');
                MessageBox.Show(tableName);
                sw = new StreamReader(fileName);
                while (!sw.EndOfStream)
                {
                    string str = sw.ReadLine();
                    JsonStr += str;
                }
                sw.Close();
                if (this.JsonToSimulation(JsonStr))
                {
                    MessageBox.Show("成功加载数据");
                }
                JsonStr = "";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("是否保存项目？", "保存项目", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                string path = "";
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*.json)|*.json";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = System.IO.Path.GetFileNameWithoutExtension(fileDialog.FileName);

                    StreamWriter se = new StreamWriter(path, false, Encoding.UTF8);
                    se.Close();
                    this.SaveToJson(path);
                    
                }
            }
            string JsonStr = "";
            StreamReader sw = new StreamReader(@"..\\DataBase0.json");
            while (!sw.EndOfStream)
            {
                string str = sw.ReadLine();
                JsonStr += str;
            }
            sw.Close();
            if (this.JsonToSimulation(JsonStr))
            {
                MessageBox.Show("成功建立新项目");
            }
        }
        List<int> SectionMatrixSourse = new List<int>();
        int[] AirfoilSourse = new int[50] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, };
        int LastSe = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mode = 0;
            int i = new int();
            if (nowID == 152 || nowID == 153 || nowID == 178 || nowID == 170 || nowID == 59 || nowID == 157 || nowID == 163)
            {
                if (nowID == 59)
                {
                    int[] tem = new int[this.SectionMatrixSourse.Count];
                    for (int k = 0; k < this.SectionMatrixSourse.Count; k++)
                    {
                        tem[k] = this.SectionMatrixSourse[k];
                    }
                    this.comboBox1.DataSource = tem;
                }
                else
                {
                    this.comboBox1.DataSource = this.AirfoilSourse;
                }
                i = (int)this.comboBox1.SelectedValue - 1;

            }
            List<object> vs = VS.SaveData();
            string[,] As = AShow.SaveData();
            if (LastID == 152)
            {
                sim0.Airfoil[LastSe].setValue(vs);
            }
            else if (LastID == 153)
            {
                sim0.Airfoil[LastSe].Airfoilfile.setValue(vs);
            }
            else if (LastID == 170)
            {
                sim0.Airfoil[LastSe].AirfoilBasicSetting.setValue(vs);

            }
            else if (LastID == 178)
            {
                sim0.Airfoil[LastSe].AirfoilDataInfo.setValue(vs);
            }
            else if (LastID == 157)
            {
                sim0.Airfoil[LastSe].Airfoilfile.AirfoilPerformance[0].setValue(vs);
            }
            else if (LastID == 163)
            {
                sim0.Airfoil[LastSe].Airfoilfile.AirfoilShape.setValue(vs);
            }
            this.dataToolStripMenuItem.Visible = false;
            this.panel1.Controls.Clear();
            this.addItemToolStripMenuItem.Visible = false;
            this.comboBox1.Visible = false;
            //this.parameterView1.ChangeSimulation(simulation);
            if (nowID == 152)
            {
                mode = 3;
                VS.DataLoad(t1.sd7, t1.sc7, t1.sa7, t1.sb7, t1.se7, sim0.Airfoil[i].getValue());
            }
            else if (nowID == 153)
            {
                mode = 3;
                VS.DataLoad(t1.sd8, t1.sc8, t1.sa8, t1.sb8, t1.se8, sim0.Airfoil[i].Airfoilfile.getValue());
            }
            else if (nowID == 170)
            {
                mode = 3;
                VS.DataLoad(t1.sd9, t1.sc9, t1.sa9, t1.sb9, t1.se9, sim0.Airfoil[i].AirfoilBasicSetting.getValue());
            }
            else if (nowID == 178)
            {
                mode = 3;
                VS.DataLoad(t1.sd10, t1.sc10, t1.sa10, t1.sb10, sim0.Airfoil[i].AirfoilDataInfo.getValue());
            }
            else if (nowID == 157)
            {
                mode = 3;
                VS.DataLoad(t1.sd44, t1.sc44, t1.sa44, t1.sb44, t1.se44, sim0.Airfoil[i].Airfoilfile.AirfoilPerformance[0].getValue());
            }
            else if (nowID == 163)
            {
                mode = 3;
                VS.DataLoad(t1.sd45, t1.sc45, t1.sa45, t1.sb45, t1.se45, sim0.Airfoil[i].Airfoilfile.AirfoilShape.getValue());
            }
            if (mode == 3)
            {
                this.comboBox1.Visible = true;
                this.comboBox1.DataSource = this.AirfoilSourse;
                this.panel1.Controls.Add(VS);
            }
            LastSe = i;

        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SectionMatrixSourse.Add(this.SectionMatrixSourse.Count+1);
            int[] tem = new int[this.SectionMatrixSourse.Count];
            for (int i = 0; i < this.SectionMatrixSourse.Count; i++)
            {
                tem[i] = this.SectionMatrixSourse[i];
            }
            this.comboBox1.Invalidate();
            this.comboBox1.Update();
            this.comboBox1.DataSource = tem;
            this.comboBox1.SelectedIndex = this.comboBox1.FindString((this.SectionMatrixSourse.Count-1).ToString());
        }
        bool isChart = new bool();
        UserControl1 uc;
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uc.Reload(sim0);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isChart = false;
            this.panel1.Controls.Clear();
            this.parameterView1.Visible = true;
            this.comboBox1.BringToFront();
            this.parameterView1.Width = this.Width / 6;
            this.panel1.Location = new Point(this.parameterView1.Width, this.parameterView1.Location.Y);
            this.panel1.Width = this.Width - this.parameterView1.Width - 15;
            this.VS.SetSize(this.panel1.Height, this.panel1.Width);
            this.AShow.SetSize(this.panel1.Height, this.panel1.Width);
        }

        private void runStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uc == null)
            {
                uc = new ASimChart.UserControl1(sim0);
                if (uc.isSucc == false)
                {
                    uc = null;
                    return;
                }
            }
            this.isChart = true;
            this.panel1.Controls.Clear();
            this.panel1.Width = this.menuStrip1.Width;
            this.panel1.Controls.Add(uc);
            
        }
        private void submitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            WriteFst fst = new WriteFst(sim0);
            ExecuteOpenFst exe = new ExecuteOpenFst();
            this.runStopToolStripMenuItem.Visible = true;
        }
    }
}
