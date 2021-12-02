using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class VarShow : UserControl
    {
        public VarShow()
        {
            InitializeComponent();
            this.dataGridView2.Visible = false;
            this.data.Clear();
        }
        int allnum = 0;
        object[] AllRows = new object[100];
        string[] Ans;
        List<object> Value = new List<object>();
        List<object> data = new List<object>();
        List<string> Des = new List<string>();
        List<string> Type = new List<string>();
        bool Mode = false;
        public void DataLoad(List<string> type, List<string> des, List<string> name, List<string> sg,List<object> value)
        {
            //this.dataGridView1.Dock = DockStyle.Top;
            this.dataGridView2.Visible = false;
            //this.textBox1.Dock = DockStyle.Top;
            this.Des.Clear();
            this.Value.Clear();
            this.data.Clear();
            foreach (object str in value)
            {
                this.Value.Add(str);
            }
            for (int i = 0; i < type.Count; i++)
            {
                this.Type.Add(type[i]);
            }
            foreach (string str in des)
            {
                this.Des.Add(str);
            }
            foreach (object str in value)
            {
                this.data.Add(str);
            }
            //MessageBox.Show(this.data.Count.ToString());
            dataGridView1.Rows.Clear();
            allnum = name.Count();
            Ans = new string[allnum];
            // 指定DataGridView控件显示的列数
            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //设置DataGridView控件的标题列名
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Value";
            dataGridView1.Columns[2].Name = "Unit";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            // Populate the rows.
            this.dataGridView1.AllowUserToAddRows = false;
            int width = this.dataGridView1.Width;
            int avgWidth = width / 3;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Columns[i].Width = avgWidth;
            }
            for (int i = 0; i < name.Count(); i++)
            {
                //object obj = new object();
                //this.data.Add(obj);
                string[] row1 = new string[3];
                row1[0] = name[i];
                row1[1] = Convert.ToString(value[i]);
                row1[2] = sg[i];
                dataGridView1.Rows.Add(row1);
                //if (i < type.Count)
                //{
                    if (type[i] == "bool")
                    {
                        DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                        echo.DataSource = boolean;
                        echo.Value = "False";
                    
                        dataGridView1.Rows[i].Cells[1] = echo;
                    }
                //}
                
                dataGridView1.Rows[i].Height = 20;
            }
        }
        string[] boolean = { "True", "False" };
        string[] number1 = { "0", "1", "2", "3" };
        string[] number2 = { "0", "1", "2", "3", "4", "5" };
        string[] number3 = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] number5 = { "0", "1", "3", "4", "5" };
        string[] number6 = { "0", "1" };
        string[] number7 = { "0", "3", "4", "5" };
        string[] number8 = { "1", "2", "3", "4", "5", "6" };
        string[] number12 = { "1", "2", "3" };
        string[] number13 = { "1", "3" };
        public void DataLoad(List<string> type, List<string> des, List<string> name, List<string> sg, List<int> mode, List<object> value)
        {
            this.Des.Clear();
            this.Type.Clear();
            this.data.Clear();
            this.Value.Clear();
            foreach (string str in des)
            {
                this.Des.Add(str);
            }
            foreach (string str in type)
            {
                this.Type.Add(str);
            }
            foreach (object str in value)
            {
                this.data.Add(str);
            }
            foreach (object str in value)
            {
                this.Value.Add(str);
            }
            dataGridView1.Rows.Clear();
            allnum = name.Count();
            Ans = new string[allnum];
            // 指定DataGridView控件显示的列数
            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //设置DataGridView控件的标题列名
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Value";
            dataGridView1.Columns[2].Name = "Unit";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            // Populate the rows.
            this.dataGridView1.AllowUserToAddRows = false;
            int width = this.dataGridView1.Width;
            int avgWidth = width / 3;
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Columns[i].Width = avgWidth;
            }
            int he = this.dataGridView1.Height;
            for (int i = 0; i < name.Count(); i++)
            {
                //object obj = new object();
                //this.data.Add(obj);
                string[] row1 = new string[3];
                row1[0] = name[i];
                if(mode[i] == 9 || mode[i] == 10)
                {
                    row1[1] = "";
                }
                else
                {
                    row1[1] = Convert.ToString(value[i]);
                }
                row1[2] = sg[i];
                dataGridView1.Rows.Add(row1);
                if (mode[i] == 1)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = boolean;
                    echo.Value = "False";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    /*if (faultData[i] != null)
                    {
                        echo.Value = faultData[i];
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 2)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number1;
                    echo.Value = "0";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 3)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number2;
                    echo.Value = "0";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 4)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number3;
                    echo.Value = "1";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                } else if (mode[i] == 5)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number5;
                    echo.Value = "0";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                } else if (mode[i] == 6)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number6;
                    echo.Value = "0";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 7)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number7;
                    echo.Value = "0";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 8)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number8;
                    echo.Value = "1";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 9)
                {
                    DataGridViewButtonCell MatrixButton = new DataGridViewButtonCell();
                    MatrixButton.Value = "InputMatrix";
                    dataGridView1.Rows[i].Cells[1] = MatrixButton;
                }
                else if (mode[i] == 10)
                {
                    DataGridViewButtonCell ArrayButton = new DataGridViewButtonCell();
                    ArrayButton.Value = "InputArray";
                    dataGridView1.Rows[i].Cells[1] = ArrayButton;
                }
                else if (mode[i] == 11)
                {
                    this.dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                    this.dataGridView1.Rows[i].Cells[1].Value = "-";
                }
                else if (mode[i] == 12)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number12;
                    echo.Value = "1";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 13)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number13;
                    echo.Value = "1";
                    /*if (Convert.ToString(value[i]) != string.Empty)
                    {
                        echo.Value = Convert.ToString(value[i]);
                    }*/
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                dataGridView1.Rows[i].Height = 20;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView2.Visible = false;
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "InputMatrix")
                {
                    this.dataGridView2.Visible = true;
                    this.Mode = true;
                    this.SetSize(this.Height, this.Width);
                    string[,] value = new string[6,6];
                    for (int i = 0; i < 6; i++)
                    {
                        for(int j = 0; j < 6; j++)
                        {
                            value[i,j] = ((string[,])this.Value[e.RowIndex])[i, j];
                        }
                    }
                    //List<object> value = new List<object>();
                    this.MatrixLoad(value);
                }
                else if (Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "InputArray")
                {
                    this.dataGridView2.Visible = true;
                    //SA = new ShowArray();
                    this.Mode = false;
                    this.SetSize(this.Height, this.Width);
                    string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    string sg = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    //SA.DataLoad(name,sg,10);
                    //SA.Show();
                    //List<object> value = (List<object>)this.Value[e.RowIndex];
                    List<string> value = new List<string>();
                    for(int i = 0; i < ((List<string>)this.Value[e.RowIndex]).Count; i++)
                    {
                        value.Add(((List<string>)this.Value[e.RowIndex])[i]);
                    }
                    this.ArrayLoad(name, sg,10 ,value);

                }
            }
        }
        string[] arrayData;
        public int arrayLen = 0;
        private void ArrayLoad(string name, string sg, int len,List<string> value)
        {
            dataGridView2.Rows.Clear();
            int num = 1;
            arrayLen = Math.Max(len,value.Count);
            if(arrayData == null)
            {
                arrayData = new string[arrayLen];
                arrayLen = Math.Max(arrayData.Length, value.Count);
                for (int i = 0; i < arrayLen; i++)
                {
                    arrayData[i] = value[i];
                }
            }

            // 指定DataGridView控件显示的列数
            dataGridView2.ColumnCount = arrayLen + 1;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //设置DataGridView控件的标题列名
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Columns[0].ReadOnly = true;
            for (int i = 0; i < num; i++)
            {
                string[] row1 = new string[arrayLen+1];
                row1[0] = name + "(" + sg + ")";
                for (int j = 0; j < arrayLen; j++)
                {
                    if(j < value.Count)
                    {
                        row1[j + 1] = arrayData[j];
                    }
                    else
                    {
                        row1[j + 1] = "";
                    }
                }
                dataGridView2.Rows.Add(row1);
                dataGridView2.Rows[i].Height = 20;
                dataGridView2.Rows[i].HeaderCell.Value = i + "";
            }
        }
        private List<string> arraySave()
        {
            //string[] str = new string[this.arrayData.Length];
            List<string> str = new List<string>();
            //MessageBox.Show(arrayLen+" "+this.dataGridView2.Rows[0].Cells.Count);
            for(int i = 0; i < arrayLen - 1; i++)
            {
                string temp = Convert.ToString(dataGridView2.Rows[0].Cells[i + 1].Value);
                if(temp != null)
                {
                    arrayData[i] = temp;
                    str.Add(temp);
                    //str[i] = arrayData[i];
                }
            }
            return str;
        }
        private string[,] ListToString(List<object> obj)
        {
            string[,] str = new string[6, 6];
            for(int i = 0; i < 6; i++)
            {
                List<object> temp = (List<object>)obj[i];
                for(int j = 0; j < 6; i++)
                {
                    str[i, j] = Convert.ToString(temp[j]);
                }
            }
            return str;
        }
        string[,] MatrixData;
        private void MatrixLoad(List<object> value)
        {
            MatrixData = new string[6,6];
            dataGridView2.Rows.Clear();
            arrayLen = 6;
            // 指定DataGridView控件显示的列数
            dataGridView2.ColumnCount = 6;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //设置DataGridView控件的标题列名
            this.dataGridView2.AllowUserToAddRows = false;
            for (int i = 0; i < 6; i++)
            {
                string[] row = new string[6];
                for(int j = 0; j < 6; j++)
                {
                    //row[j] = str[i, j];
                    row[j] = "";
                }
                dataGridView2.Rows.Add(row);
                dataGridView2.Rows[i].Height = 20;
                dataGridView2.Rows[i].HeaderCell.Value = i + "";
            }
        }
        private void MatrixLoad(string[,] value)
        {
            MatrixData = new string[6, 6];
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    MatrixData[i, j] = value[i, j];
                }
            }
            dataGridView2.Rows.Clear();
            arrayLen = 6;
            // 指定DataGridView控件显示的列数
            dataGridView2.ColumnCount = 6;
            dataGridView2.ColumnHeadersVisible = true;
            dataGridView2.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //设置DataGridView控件的标题列名
            this.dataGridView2.AllowUserToAddRows = false;
            for (int i = 0; i < 6; i++)
            {
                string[] row = new string[6];
                for (int j = 0; j < 6; j++)
                {
                    row[j] = value[i, j];
                    //row[j] = "";
                }
                dataGridView2.Rows.Add(row);
                dataGridView2.Rows[i].Height = 20;
                dataGridView2.Rows[i].HeaderCell.Value = i + "";
            }
        }
        private object MatrixSave()
        {
            string[,] str = new string[6, 6];
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    this.MatrixData[i, j] = Convert.ToString(this.dataGridView2.Rows[i].Cells[j].Value);
                    str[i, j] = this.MatrixData[i,j];
                }
            }
            return str;
        }
        int LastIDi = new int();
        bool isMatrix = false;
        bool isArray = false;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if (isMatrix)
            {
                string temp = Convert.ToString(this.dataGridView1.Rows[LastIDi].Cells[1].Value);
                if (temp == "InputMatrix")
                {
                    string[,] st = (string[,])this.MatrixSave();
                    this.data[LastIDi] = st;
                }
            }
            if (isArray)
            {
                string temp = Convert.ToString(this.dataGridView1.Rows[LastIDi].Cells[1].Value);
                if (temp == "InputArray")
                {
                    List<string> st = this.arraySave();
                    this.data[LastIDi] = st;
                }
            }
            this.dataGridView2.Visible = false;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
            string judge = Convert.ToString(this.dataGridView1.Rows[i].Cells[1].Value);
            isMatrix = false;
            isArray = false;
            if (judge == "InputMatrix")
            {
                isMatrix = true;
            }
            else if(judge == "InputArray")
            {
                isArray = true;
            }
            this.LastIDi = dataGridView1.CurrentCell.RowIndex;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            this.dataGridView2.Visible = false;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if (e.ColumnIndex != -1)
            {
                int j = dataGridView1.CurrentCell.ColumnIndex;
                string temp = Convert.ToString(this.dataGridView1.Rows[i].Cells[j].Value);
                if (temp == "InputMatrix")
                {
                    string[,] st = (string[,])this.MatrixSave();
                    data[i] = st;
                }
                else if (temp == "InputArray")
                {
                    List<string> st = this.arraySave(); 
                    data[i] = st;
                }
                else if (temp == "False" || temp == "True")
                {
                    data[i] = temp;
                }
                else
                {
                    temp = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    if (temp == string.Empty)
                    {
                        MessageBox.Show("请勿输入空值");
                    }
                    else if(Type[i]=="float")
                    {
                        try
                        {
                            double d = double.Parse(temp);
                        }
                        catch
                        {
                            MessageBox.Show("请输入浮点类型的数值");
                        }
                        data[i] = temp;
                    }
                    else if (Type[i]=="int")
                    {
                        try
                        {
                            int d = int.Parse(temp);
                        }
                        catch
                        {
                            MessageBox.Show("请输入整数类型数值");
                        }
                        data[i] = temp;
                    }
                    else if (Type[i]=="bool")
                    {
                        data[i] = temp;
                    }
                    else
                    {
                        data[i] = temp;
                    }
                }
            }
            this.dataGridView2.Visible = false;
        }
        public List<object> SaveData()
        {
            List<object> ans = new List<object>();
            foreach(object obj in this.data)
            {
                ans.Add(obj);
            }
            return ans;
        }
        public void SetSize(int height,int width)
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Height = height;
            this.Width = width;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Width = width * 4 / 5;
            this.dataGridView2.Width = width * 4 / 5;
            this.dataGridView1.Height = height;
            if (Mode)
            {
                this.dataGridView2.Location = new Point(0, height - (height / 2));
                this.dataGridView2.Height = height / 2;
            }
            else
            {
                this.dataGridView2.Location = new Point(0, height - (height / 3));
                this.dataGridView2.Height = height / 3;
            }

            this.textBox1.Location = new Point(this.dataGridView1.Width, 0);
            this.textBox1.Width = width - this.dataGridView1.Width;
            this.textBox1.Height = height;
            for (int i= 0; i < allnum; i++)
            {
                this.dataGridView1.Rows[i].Height = 20;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
