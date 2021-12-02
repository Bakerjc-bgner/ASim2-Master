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
    public partial class ArrayShow : UserControl
    {
        public ArrayShow()
        {
            InitializeComponent();
        }
        int allnum = 0,alllen = 0;
        object[] AllRows = new object[100];
        object[,] Ans;
        List<string> Type = new List<string>();
        List<string> Des = new List<string>();
        bool sw = false;
        bool DataType = false;
        public void DataLoad(List<string>des,List<string> name,List<string>sg,int len,string[,] value,List<string> type)
        {
            Ans = new object[100, name.Count()];
            this.Des.Clear();
            this.Type.Clear();
            foreach(string str in type)
            {
                this.Type.Add(str);
            }
            foreach (string str in des)
            {
                this.Des.Add(str);
            }
            dataGridView1.Rows.Clear();
            int num = name.Count();
            allnum = num;
            alllen = len + 1;
            // 指定DataGridView控件显示的列数
            dataGridView1.ColumnCount = num;
            dataGridView1.ColumnHeadersVisible = true;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //设置DataGridView控件的标题列名
            this.dataGridView1.AllowUserToAddRows = false;
            string[] sgrow = new string[num];
            for(int i = 0; i < num; i++)
            {
                dataGridView1.Columns[i].Name = name[i];
                dataGridView1.Columns[i].Width = 100;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                sgrow[i] = sg[i];
            }
            dataGridView1.Rows.Add(sgrow);
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Height = 20;
            for(int i = 0;i < num; i++)
            {
                dataGridView1.Rows[0].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            //MessageBox.Show(value.GetLength(0) + " " + value.GetLength(1));
            //MessageBox.Show(len + " " + num);
            for (int i = 0; i < len; i++)
            {
                string[] row1 = new string[num];
                for (int j = 0; j < num; j++)
                {
                    if (i < value.GetLength(0))
                    {
                        row1[j] = value[i, j];
                    }
                    else
                    {
                        row1[j] = "0";
                    }
                }
                dataGridView1.Rows.Add(row1);
                dataGridView1.Rows[i].Height = 30;
                dataGridView1.Rows[i].HeaderCell.Value = i + "";
            }
            this.sw = true;
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
        DataGridViewRow DGRow;
        public void DataLoad(List<string> des, List<string> name, List<string> sg,List<int> mode, int len,string[,] value, List<string> type)
        {
            Ans = new object[100, name.Count()];
            this.Des.Clear();
            this.Type.Clear();
            foreach (string str in type)
            {
                this.Type.Add(str);
            }
            foreach (string str in des)
            {
                this.Des.Add(str);
            }
            dataGridView1.Rows.Clear();
            int num = name.Count();
            allnum = num;
            alllen = len + 1;
            // 指定DataGridView控件显示的列数
            dataGridView1.ColumnCount = num;
            dataGridView1.ColumnHeadersVisible = true;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //设置DataGridView控件的标题列名
            this.dataGridView1.AllowUserToAddRows = false;
            string[] sgrow = new string[num];
            string[] emp = new string[num];
            for (int i = 0; i < num; i++)
            {
                dataGridView1.Columns[i].Name = name[i];
                dataGridView1.Columns[i].Width = 100;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                sgrow[i] = sg[i];
            }
            dataGridView1.Rows.Add(sgrow);
            dataGridView1.Rows.Add(emp);
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Height = 20;
            DGRow = new DataGridViewRow();
            for (int i = 0; i < num; i++)
            {
                dataGridView1.Rows[0].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int i = 0; i < len; i++)
            {
                DataGridViewRow row1;
                List<string> str = new List<string>();
                for(int j = 0; j < num; j++)
                {
                    if (i < value.Length)
                    {
                        str.Add(value[i, j]);
                    }
                    else
                    {
                        str.Add("0");
                    }
                }
                row1 = GetDGRow(str);
                dataGridView1.Rows.Add(row1);
                dataGridView1.Rows[i].Height = 30;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1) + "";
            }
            this.sw = true;
            this.DataType = true;
        }
        public int MaxLen = new int();
        public DataGridViewRow GetDGRow(List<string> value)
        {
            DataGridViewRow dg = new DataGridViewRow();
            int i = 0;
            dg.CreateCells(this.dataGridView1);
            string[] s = new string[value.Count];
            foreach(string str in value)
            {
                dg.Cells[i].Value = str;
                i++;
            }
            return dg;
        }

        public void add()
        {

            //string[] row = new string[allnum];
            List<string> row = new List<string>(); 
            for (int i = 0; i < allnum; i++)
            {
                row.Add("0");
            }
            DataGridViewRow Row1 = GetDGRow(row);
            if (this.DataType)
            {
                
                dataGridView1.Rows.Add(Row1);
            }
            else
            {
                dataGridView1.Rows.Add(Row1);
            }
            dataGridView1.Rows[alllen].Height = 30;
            dataGridView1.Rows[alllen].HeaderCell.Value = alllen + "";
            alllen++;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.ColumnIndex;
            int j = dataGridView1.CurrentCell.RowIndex;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView1.CurrentCell.ColumnIndex;
            int j = dataGridView1.CurrentCell.RowIndex;
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
                if (temp == "False" || temp == "True")
                {
                    Ans[i,j] = temp;
                }
                else
                {
                    temp = Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                    if (temp == string.Empty)
                    {
                        MessageBox.Show("请勿输入空值");
                    }
                    else if (Type[j] == "float")
                    {
                        try
                        {
                            double d = double.Parse(temp);
                        }
                        catch
                        {
                            MessageBox.Show("请输入浮点类型的数值");
                        }
                        Ans[i, j] = temp;
                    }
                    else if (Type[j] == "int")
                    {
                        try
                        {
                            int d = int.Parse(temp);
                        }
                        catch
                        {
                            MessageBox.Show("请输入整数类型数值");
                        }
                        Ans[i, j] = temp;
                    }
                    else if (Type[j] == "bool")
                    {
                        Ans[i, j] = temp;
                    }
                    else
                    {
                        Ans[i, j] = temp;
                    }
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.ColumnIndex;
            this.textBox1.Clear();
            if (sw)
            {
                this.textBox1.Text += this.Des[i];
            }
            
            
        }

        public string[,] SaveData()
        {
            int len = Math.Max(alllen - 1,0);
            string[,] Data = new string[len,allnum];
            for(int i = 0; i < alllen - 1; i++)
            {
                for(int j = 0; j < allnum; j++)
                {
                    Data[i, j] = Convert.ToString(dataGridView1.Rows[i + 1].Cells[j].Value);
                }
            }
            return Data;
        }
        public void delete()
        {
            DataGridViewRow row = dataGridView1.Rows[alllen - 1];
            alllen--;
            dataGridView1.Rows.Remove(row);
        }

        public void SetSize(int height, int width)
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Height = height;
            this.Width = width;
            //this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom ;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Width = width * 4 / 5;
            this.dataGridView1.Height = height;
            this.textBox1.Location = new Point(this.dataGridView1.Width, 0);
            //this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.textBox1.Width = width - this.dataGridView1.Width;
            this.textBox1.Height = height;
            for(int i = 0; i < alllen; i++)
            {
                this.dataGridView1.Rows[i].Height = 30;
            }
        }
    }
}
