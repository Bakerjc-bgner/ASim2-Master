using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OutputModel;
using OutputModel.FileRead;
using DataLibrary;

namespace ASimChart
{
    public partial class UserControl1 : UserControl
    {
        /// <summary>
        /// 时间步长，需获取    DT
        /// </summary>
        private double dx = 1;

        /// <summary>
        /// 线性与非线性，需获取  CompElast == 1 线性  CompElast == 2 非线性
        /// </summary>
        bool islinear = true;

        /// <summary>
        /// 读取输出文件名，需获取
        /// </summary>
        public const string outputFileName = "IEA-15-240-RWT-Monopile.out";

        /// <summary>
        /// BldGagNd(线性） 固定 blade Stru 线性
        /// </summary>
        private double[] BldGagNd = { 1, 6, 11, 20, 30, 38, 43, 47, 50 };
        /// <summary>
        /// OutNd（非线性） 固定 blade Stru 非线性
        /// </summary>
        private double[] OutNd = { 1, 6, 11, 15, 20, 25, 30, 35, 41 };
        /// <summary>
        /// BlOutNd     blade Aero
        /// </summary>
        private double[] BlOutNd = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// <summary>
        /// TwrGagNd 固定 tower Stru
        /// </summary>
        private double[] TwrGagNd = { 1, 4, 6, 8, 10, 12, 15, 18, 20 };
        /// <summary>
        /// TwOutNd     tower Aero
        /// </summary>
        private double[] TwOutNd = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        /// <summary>
        /// WindVziList  windVal 
        /// </summary>
        private double[] WindVziList = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        //////////////////////////////////////////////////////////////////////////////////////

        private int totalX = 0; //横坐标全局递增，在初始化功能中清0

        private int currentX = 0;  //已显示个数

        private double curPosition = 0; //当前视图位置

        private int realScale = 100; //初始化以及曲线更新时的窗口大小

        private int XVuale = 0; //记录鼠标当前所处坐标

        //拖动功能
        private bool isMouseDown = false; //鼠标按压状态

        private int lastMove = 0; // 用于记录鼠标上次移动的点，用于判断是左移还是右移

        int lineNum = 0;    //曲线序号

        public Simulation_0 sim0;   //需要调用时传入，必要////////////////////////////

        Outputs_oneTimeStep output = new Outputs_oneTimeStep();
        Assembly assembly = Assembly.Load("OutputModel");
        OutputReader outputReader;

        public bool isSucc = false;

        public UserControl1()
        {
            InitializeComponent();
            outputReader = new OutputReader(@".\Resources\IEA-15-240-RWT-Monopile\" + outputFileName, islinear);
            Init();
            if (Init()) this.isSucc = true;
        }

        public UserControl1(Simulation_0 sim)
        {
            InitializeComponent();
            GetPara(sim);
            outputReader = new OutputReader(@".\Resources\IEA-15-240-RWT-Monopile\" + outputFileName, islinear);
            if (Init()) this.isSucc = true ;
        }

        public void Reload(Simulation_0 sim)
        {
            GetPara(sim);
            outputReader = new OutputReader(@".\Resources\IEA-15-240-RWT-Monopile\" + outputFileName, islinear);
            Reload();
        }

        private void GetPara(Simulation_0 sim)
        {
            this.sim0 = sim;
            dx = sim0.SimulationControl.BasicControl.DT.value;
            islinear = (sim0.SimulationControl.SimulationFlags.CompElast[0].value) == 1 ?true:false;

            /*BldGagNd = BldGagNd;
            OutNd = OutNd;
            TwrGagNd = TwrGagNd;*/

            for (int i = 0; i < sim0.Outputs.AerodynamicOutputs.BlOutNd.Count; i++)
            {
                BlOutNd[i] = sim0.Outputs.AerodynamicOutputs.BlOutNd[i].value;
            }
            for (int i = 0; i < sim0.Outputs.AerodynamicOutputs.TwOutNd.Count; i++)
            {
                BlOutNd[i] = sim0.Outputs.AerodynamicOutputs.TwOutNd[i].value;
            }
            for (int i = 0; i < sim0.Environment.WindCondition.WindBasicInfo.WindVziList.Count; i++)
            {
                BlOutNd[i] = sim0.Environment.WindCondition.WindBasicInfo.WindVziList[i].value;
            }
            
        }

        private void Reload()
        {
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            this.comboBox3.Items.Clear();
            this.comboBox4.Items.Clear();
            this.comboBox5.Items.Clear();
            this.listBox1.Items.Clear();
            this.listView1.Items.Clear();
            this.chart1.Series.Clear();
            this.chart1.ChartAreas[0].CursorX.Position = -1;
            this.currentX = 0;
            this.lineNum = 0;
            this.timer2_line.Stop();
            this.timer3_fit.Stop();
            this.timer4_realTime.Stop();
            InitConbobox1();
        }

        private bool Init()
        {
            if (!outputReader.fileRead())
            {
                MessageBox.Show("所需输出文件不存在！");
                return false;
            }
            InitConbobox1();
            InitListView();
            InitContextMenu();
            InitChart();
            this.timer1_file.Start();
            return true;
        }

        public void InitContextMenu()
        {
            //初始化定义右键菜单
            contextMenuStrip1.Items.Add("显示/隐藏");//1
            contextMenuStrip1.Items.Add("删除"); //2
            contextMenuStrip1.Items[0].Click += Item1_Click;
            contextMenuStrip1.Items[1].Click += Item2_Click;

            //初始化定义右键菜单
            contextMenuStrip2.Items.Add("线性");//1
            contextMenuStrip2.Items.Add("非线性"); //2
            contextMenuStrip2.Items[0].Click += Item3_Click;
            contextMenuStrip2.Items[1].Click += Item4_Click;
        }

        public void InitConbobox1()
        {
            Type t = assembly.GetType("OutputModel.Outputs_oneTimeStep");
            foreach (FieldInfo item in t.GetFields())
            {
                string valName = item.Name;
                Type t2 = item.FieldType;
                string type = t2.ToString();
                object ob = item.GetValue(output);
                string showName = t2.GetProperty("showName").GetValue(ob).ToString();
                comboBox1.Items.Add(new ComboxItem("  " + showName, valName, type, ob));
            }
        }

        public void InitListView()
        {
            listView1.Columns.Add("", 20, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 300, HorizontalAlignment.Center);
            listView1.Columns.Add("Units", 200, HorizontalAlignment.Center);
        }

        private void InitChart()
        {
            this.timer1_file.Interval = 300;    //读文件频率
            this.timer2_line.Interval = 30;     //曲线更新频率
            this.timer4_realTime.Interval = 30;     
            this.timer3_fit.Interval = 500;    //视图大小更新频率

            //// 
            //// this.chart1
            //// 
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.None;
            this.chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;      //滚动条
            this.chart1.ChartAreas[0].AxisX.Title = "xTitle";
            this.chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            this.chart1.ChartAreas[0].AxisY.Title = "yTitle";
            this.chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.chart1.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            this.chart1.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends[0].IsTextAutoFit = false;
            this.chart1.ChartAreas[0].AxisX.ScaleView.Position = 0;

            //设置图表属性
            this.chart1.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.chart1.ChartAreas[0].AxisX.ScaleView.Size = realScale; // 使用时先对ScaleView做一下初始化
            this.chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            this.chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "f";

            this.chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true; //设置是否自动调整轴标签
            this.chart1.ChartAreas[0].AxisY.IsLabelAutoFit = true; //设置是否自动调整轴标签

            //坐标轴Title
            this.chart1.ChartAreas[0].AxisX.Title = "time/s";
            this.chart1.ChartAreas[0].AxisY.Title = "value";

            this.chart1.Series.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            ComboxItem selectItem = (ComboxItem)comboBox1.SelectedItem;
            if (selectItem == null) return;

            Type t = assembly.GetType(selectItem.Type);
            object ob = selectItem.ob;
            foreach (FieldInfo item in t.GetFields())   //二级菜单，有数组
            {
                string valName = item.Name;
                Type t2 = item.FieldType;
                string type = t2.ToString();
                object temp = item.GetValue(ob);
                string showName = t2.GetProperty("showName").GetValue(temp).ToString();
                comboBox2.Items.Add(new ComboxItem("  " + showName, valName, type, temp));
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox3.Items.Clear();
            ComboxItem selectItem = (ComboxItem)comboBox2.SelectedItem;
            if (selectItem == null) return;

            if (((VisiableObject)selectItem.ob).isArray)
            {
                double[] index = { };
                switch (selectItem.Value)
                {
                    case "BladeSectionSTRUOutputs" :
                        if (islinear)
                            index = BldGagNd;
                        else
                            index = OutNd;
                        break;
                    case "BladeSectionAeroInfo" :
                        index = BlOutNd;
                        break;
                    case "TowerSectionSTRUOutputs" :
                        index = TwrGagNd;
                        break;
                    case "TowerSectionAeroInfo" :
                        index = TwOutNd;
                        break;
                    case "windVel":
                        index = WindVziList;
                        break;

                    default:
                        break;
                }

                for (int i = 0; i < index.Length; i++)
                {
                    comboBox3.Items.Add(new ComboxItem("  " + index[i].ToString(), i.ToString()));
                }
            }

            Type t = assembly.GetType(selectItem.Type);

            if (t.Name == "VisiableOutput") return;

            object ob = selectItem.ob;
            foreach (FieldInfo item in t.GetFields())   //二级菜单，有数组
            {
                string valName = item.Name;

                Type t2 = item.FieldType;
                //Type t2 = (item.FieldType.GetElementType() == null) ? item.FieldType : item.FieldType.GetElementType();
                string type = t2.ToString();

                object temp = item.GetValue(ob);

                //object tmp = item.GetValue(ob);
                string showName = t2.GetProperty("showName").GetValue(temp).ToString();

                if (t.Name == "VisiableVector6" || t.Name == "VisiableForce6")
                {
                    comboBox5.Items.Add(new ComboxItem("  " + (showName == "" ? valName : showName), valName, type, temp));
                }
                else
                {
                    comboBox4.Items.Add(new ComboxItem("  " + showName, valName, type, temp));
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            ComboxItem selectItem = (ComboxItem)comboBox4.SelectedItem;
            if (selectItem == null) return;

            Type t = assembly.GetType(selectItem.Type);

            object ob = selectItem.ob;
            foreach (FieldInfo item in t.GetFields())   //二级菜单，有数组
            {
                string valName = item.Name;
                Type t2 = item.FieldType;
                string type = t2.ToString();


                object temp = item.GetValue(ob);

                //object tmp = item.GetValue(ob);
                string showName = t2.GetProperty("showName").GetValue(temp).ToString();
                comboBox5.Items.Add(new ComboxItem("  " + (showName == "" ? valName : showName), valName, type, temp));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Items.Count != 0 && comboBox1.SelectedIndex == -1)
                 || (comboBox2.Items.Count != 0 && comboBox2.SelectedIndex == -1)
                 || (comboBox4.Items.Count != 0 && comboBox4.SelectedIndex == -1)
                 || (comboBox5.Items.Count != 0 && comboBox5.SelectedIndex == -1)
                 || (comboBox3.Items.Count != 0 && comboBox3.SelectedIndex == -1))
            {
                MessageBox.Show("未选择！");
                return;
            }
            ComboxItem selectItem1 = (ComboxItem)comboBox1.SelectedItem;
            string s1 = selectItem1.Value;

            ComboxItem selectItem2 = (ComboxItem)comboBox2.SelectedItem;
            string s2 = "." + selectItem2.Value;

            ComboxItem selectItem3 = (ComboxItem)comboBox3.SelectedItem;
            string s3 = (comboBox3.SelectedItem == null) ? "" : ("[" + selectItem3.Value + "]");

            ComboxItem selectItem4 = (ComboxItem)comboBox4.SelectedItem;
            string s4 = (selectItem4 == null) ? "" : "." + selectItem4.Value;

            ComboxItem selectItem5 = (ComboxItem)comboBox5.SelectedItem;
            string s5 = (selectItem5 == null) ? "" : "." + selectItem5.Value;

            string fullname = s1 + s2 + s3 + s4 + s5;

            //MessageBox.Show(fullname);

            VisiableOutput res = outputReader.GetOutput(fullname);

            if (res == null)
            {
                MessageBox.Show("该变量无效！");
                return;
            }


            if (this.chart1.Series.IsUniqueName(res.name))
            {
                this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  

                ListViewItem lvi = new ListViewItem();

                lvi.ImageIndex = lineNum;     //通过与imageList绑定，显示imageList中第i项图标  

                lvi.Tag = res;

                lvi.SubItems.Add(res.name);

                lvi.SubItems.Add(res.units);

                //lvi.SubItems.Add(fullname);

                //lvi.SubItems.Add(lvi.ImageIndex.ToString());

                this.listView1.Items.Add(lvi);

                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 

                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    BorderWidth = 2,
                    ChartArea = "ChartArea1",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline,
                    Legend = "Legend1",
                    LegendText = res.name + res.units,
                    Name = res.name,
                    XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
                };

                this.chart1.Series.Add(series1);

                for (int i = 0; i < currentX; i++)
                {
                    this.chart1.Series[lineNum].Points.AddXY(Convert.ToString(Convert.ToDouble(i * dx)), res.data[i]);
                }

                lineNum++;
            }
            else
                MessageBox.Show("曲线已存在！");

            timer3_fit.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            this.chart1.Series.Clear();
            currentX = 0;
            lineNum = 0;

            this.chart1.ChartAreas[0].CursorX.Position = -1;

            //timer1_file.Stop();
            timer2_line.Stop();
            timer3_fit.Stop();
            timer4_realTime.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Items.Count != 0 && comboBox1.SelectedIndex == -1)
                || (comboBox2.Items.Count != 0 && comboBox2.SelectedIndex == -1)
                || (comboBox4.Items.Count != 0 && comboBox4.SelectedIndex == -1)
                || (comboBox5.Items.Count != 0 && comboBox5.SelectedIndex == -1)
                || (comboBox3.Items.Count != 0 && comboBox3.SelectedIndex == -1))
            {
                MessageBox.Show("未选择！");
                return;
            }
            if (this.listView1.Items.Count == 0)
            {
                button1_Click(button1, e);
            }
            this.chart1.ChartAreas[0].AxisX.ScaleView.Size = realScale;
            this.timer2_line.Start();
            this.timer4_realTime.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.timer2_line.Stop();
            this.timer4_realTime.Stop();
        }

        private void timer1_file_Tick(object sender, EventArgs e)
        {
            outputReader.fileRead();
            totalX = outputReader.curLine - 8;
        }

        private void timer2_line_Tick(object sender, EventArgs e)
        {
            // 从选中output中获取数据绘制曲线
            for (int j = 0; j < 1; j++)
            {
                if (currentX >= totalX - 1) break;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    ListViewItem lvi = listView1.Items[i];
                    VisiableOutput lviOutput = (VisiableOutput)lvi.Tag;

                    this.chart1.Series[lvi.ImageIndex].Points.AddXY(Convert.ToString(Convert.ToDouble(currentX * dx)), lviOutput.data[currentX]);
                }
                currentX++;
            }
        }

        private void timer3_fit_Tick(object sender, EventArgs e)
        {
            this.chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void timer4_realTime_Tick(object sender, EventArgs e)
        {
            // 实现滑动窗口
            try
            {
                curPosition = this.chart1.Series[0].Points.Count - this.chart1.ChartAreas[0].AxisX.ScaleView.Size * 0.8;
            }
            catch (Exception) { }

            if (curPosition > 0)
            {
                this.chart1.ChartAreas[0].AxisX.ScaleView.Position = Convert.ToInt32(curPosition);
            }
            else
            {
                this.chart1.ChartAreas[0].AxisX.ScaleView.Position = 0;
            }
        }

        /// <summary>
        /// 鼠标滚轮缩放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
            {
                if (this.chart1.Series.Count == 0) return;
                // 鼠标滚轮滚动一圈时e.Delta = 120，正反转对应正负120
                if (this.chart1.ChartAreas[0].AxisX.ScaleView.Size > 20) // 防止越过左边界
                {
                    this.chart1.ChartAreas[0].AxisX.ScaleView.Size -= (e.Delta / 40); // 每次缩放1
                }
                else if (e.Delta < 0)
                {
                    this.chart1.ChartAreas[0].AxisX.ScaleView.Size -= (e.Delta / 40); // 每次缩放1
                }
            }
            else
            {
                if (this.chart1.Series.Count == 0) return;
                // 鼠标滚轮滚动一圈时e.Delta = 120，正反转对应正负120
                if (this.chart1.ChartAreas[0].AxisY.ScaleView.Size > 20) // 防止越过左边界
                {
                    this.chart1.ChartAreas[0].AxisY.ScaleView.Size -= (e.Delta / 40); // 每次缩放1
                }
                else if (e.Delta < 0)
                {
                    this.chart1.ChartAreas[0].AxisY.ScaleView.Size -= (e.Delta / 40); // 每次缩放1
                }
            }
        }


        /// <summary>
        /// 鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            lastMove = 0;
            if(e.Button == MouseButtons.Left)
            {
                this.timer4_realTime.Stop();
                isMouseDown = true;
                this.Cursor = Cursors.NoMoveHoriz;
            }
            else
                this.timer4_realTime.Start();

        }


        /// <summary>
        /// 鼠标弹起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            this.Cursor = Cursors.Arrow;
        }


        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.chart1.Series.Count == 0) return;
            if (isMouseDown)
            {
                if (lastMove != 0 && e.X - lastMove > 0 && this.chart1.ChartAreas[0].AxisX.ScaleView.Position > 1) //防止越过左界
                {
                    this.chart1.ChartAreas[0].AxisX.ScaleView.Position -= Convert.ToInt32(this.chart1.ChartAreas[0].AxisX.ScaleView.Size * 0.007 + 1);  // 每次向左移动1
                }
                else if (lastMove != 0 && e.X - lastMove < 0
                    && this.chart1.ChartAreas[0].AxisX.ScaleView.Position < (this.chart1.Series[0].Points.Count * 1.1 - this.chart1.ChartAreas[0].AxisX.ScaleView.Size))
                {
                    this.chart1.ChartAreas[0].AxisX.ScaleView.Position += Convert.ToInt32(this.chart1.ChartAreas[0].AxisX.ScaleView.Size * 0.007 + 1); // 每次向右移动1
                }
                lastMove = e.X;
            }
            else
            {
                try
                {
                    XVuale = Convert.ToInt32(this.chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X)) - 1;
                }
                catch (Exception) { }

                if (XVuale >= currentX)
                {
                    XVuale = currentX - 1;
                }
                else if (XVuale < 0)
                {
                    XVuale = 0;
                }


                if (XVuale > -1 && XVuale < this.chart1.Series[0].Points.Count)
                {
                    this.chart1.ChartAreas[0].CursorX.Position = XVuale + 1;

                    listBox1.Items.Clear();

                    listBox1.Items.Add("X:" + XVuale * dx);

                    foreach (Series series in this.chart1.Series)
                    {
                        if (series.Enabled)
                        {
                            listBox1.Items.Add(series.Name + ": " + series.Points[XVuale].YValues[0]);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 曲线信息list右键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(listView1, e.Location);//鼠标右键按下弹出菜单
            }
        }

        /// <summary>
        /// list右键点击选项1事件-隐藏/显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                if (this.chart1.Series[item.ImageIndex].Enabled)
                {
                    item.BackColor = Color.Silver;
                }
                else
                {
                    item.BackColor = Color.White;
                }
                this.chart1.Series[item.ImageIndex].IsVisibleInLegend = !this.chart1.Series[item.ImageIndex].IsVisibleInLegend;
                this.chart1.Series[item.ImageIndex].Enabled = !this.chart1.Series[item.ImageIndex].Enabled;
                item.Selected = false;
            }
        }

        /// <summary>
        /// list右键点击选项2事件-移除曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.SelectedItems)
            {
                this.chart1.Series[item.ImageIndex].IsVisibleInLegend = false;
                this.chart1.Series[item.ImageIndex].Enabled = false;
                this.chart1.Series[item.ImageIndex].Name = "" + item.ImageIndex;
                item.Remove();
            }
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button_input,new Point(0,0));
        }

        private void importOutput(bool _isliner)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "输出文件(*.out)|*.out";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                islinear = _isliner;
                outputReader = new OutputReader(openFileDialog.FileName, islinear);
                Reload();
            }
        }

        private void Item3_Click(object sender, EventArgs e)
        {
            importOutput(true);
        }
        private void Item4_Click(object sender, EventArgs e)
        {
            importOutput(false);
        }


        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "输出文件(*.out)|*.out";
            saveFileDialog.FileName = "save.out";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(outputReader.path, saveFileDialog.FileName, saveFileDialog.OverwritePrompt);
            }
        }

    }
}
