using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class ShowArray : UserControl
    {
        int allnum = 0, alllen = 0;
        object[] AllRows = new object[1000];
        object[,] Ans;
        List<string> Type = new List<string>();
        List<string> Des = new List<string>();
        bool sw = false;
        bool DataType = false;
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
        public int MaxLen = new int();
        public ShowArray()
        {
            InitializeComponent();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e) //判断是否按下：Ctrl+V
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)//对象不为null，且对象为DataGridView类型
            {
                if (sender != null && sender.GetType() == typeof(DataGridView))
                    DataGirdViewCellPaste((DataGridView)sender, 0);//调用黏贴方法
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    Ans[i, j] = temp;
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

        public void DataLoad(List<string> des, List<string> name, List<string> sg, int len, string[,] value, List<string> type)
        {
            Ans = new object[1000, name.Count()];
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
            dataGridView1.ColumnCount = num;// 指定DataGridView控件显示的列数
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.BackgroundColor = Color.White;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();// 设置DataGridView控件标题列的样式
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            this.dataGridView1.AllowUserToAddRows = false;
            string[] sgrow = new string[num];
            for (int i = 0; i < num; i++)
            {
                dataGridView1.Columns[i].Name = name[i];
                dataGridView1.Columns[i].Width = 100;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                sgrow[i] = sg[i];
            }
            dataGridView1.Rows.Add(sgrow);
            dataGridView1.Rows[0].ReadOnly = true;
            dataGridView1.Rows[0].Height = 20;
            for (int i = 0; i < num; i++)
            {
                dataGridView1.Rows[0].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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
                    Ans[i, j] = row1[j];
                }
                dataGridView1.Rows.Add(row1);
                dataGridView1.Rows[i].Height = 20;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1) + "";
            }
            dataGridView1.Rows[len].HeaderCell.Value = (len + 1) + "";
            this.sw = true;
        }

        public void DataLoad(List<string> des, List<string> name, List<string> sg, List<int> mode, int len, string[,] value, List<string> type)
        {
            Ans = new object[1000, name.Count()];
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
            dataGridView1.ColumnCount = num;// 指定DataGridView控件显示的列数
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.BackgroundColor = Color.White;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();// 设置DataGridView控件标题列的样式
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
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
                for (int j = 0; j < num; j++)
                {
                    if (i < value.Length)
                    {
                        str.Add(value[i, j]);
                        Ans[i, j] = value[i, j];
                    }
                    else
                    {
                        str.Add("0");
                        Ans[i, j] = "0";
                    }
                }
                row1 = GetDGRow(str);
                dataGridView1.Rows.Add(row1);
                dataGridView1.Rows[i].Height = 20;
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1) + "";
            }
            dataGridView1.Rows[len].HeaderCell.Value = (len + 1) + "";
            this.sw = true;
            this.DataType = true;
        }

        public DataGridViewRow GetDGRow(List<string> value)
        {
            DataGridViewRow dg = new DataGridViewRow();
            int i = 0;
            dg.CreateCells(this.dataGridView1);
            string[] s = new string[value.Count];
            foreach (string str in value)
            {
                dg.Cells[i].Value = str;
                i++;
            }
            return dg;
        }

        public void add()
        {
            List<string> row = new List<string>();
            for (int i = 0; i < allnum; i++)
            {
                row.Add("0");
                Ans[alllen, i] = "0";
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
            dataGridView1.Rows[alllen].Height = 20;
            dataGridView1.Rows[alllen].HeaderCell.Value = (alllen + 1) + "";
            alllen++;
        }

        public string[,] SaveData()
        {
            int len = Math.Max(alllen - 1, 0);
            string[,] Data = new string[len, allnum];
            for (int i = 0; i < alllen - 1; i++)
            {
                for (int j = 0; j < allnum; j++)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.ColumnIndex;
            int j = dataGridView1.CurrentCell.RowIndex;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
        }

        public void SetSize(int height, int width)
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Height = height;
            this.Width = width;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Width = width * 4 / 5;
            this.dataGridView1.Height = height;
            this.textBox1.Location = new Point(this.dataGridView1.Width, 0);
            this.textBox1.Width = width - this.dataGridView1.Width;
            this.textBox1.Height = height;
            for (int i = 0; i < alllen; i++)
            {
                this.dataGridView1.Rows[i].Height = 30;
            }
        }

        /// <summary>
        /// 向DataGridView控件粘贴数据
        /// </summary>
        public void DataGirdViewCellPaste(DataGridView dgv, int type)
        {
            if (dgv.CurrentCell == null)//判断当前单元格已选中，复制黏贴单元格初始位置
                return;
            int insertRowIndex = dgv.CurrentCell.RowIndex;//获取当前单元格行索引,打印单元格内容调用
            int insertColIndex = dgv.CurrentCell.ColumnIndex;//获取当前单元格列索引,打印单元格内容调用
            if (dgv.Rows[insertRowIndex].Cells[insertColIndex].ReadOnly == true)
            {
                MessageBox.Show("该格子不可粘贴或者所需粘贴的内容过多");
                return;
            }
            string pasteText = Clipboard.GetText();//获取当前剪切板的内容（黏贴内容必须是表格形式）
            if (string.IsNullOrEmpty(pasteText))//剪贴板内容不为空
            {
                MessageBox.Show("剪贴板为空，无法复制粘贴");
                return;
            }
            #region 获取剪贴板内容的行、列数
            //剪切板内容：21\t\t\r\n11\t12\r\n（\t:表示空格；\r\n:表示换行）
            #region 获取行数
            char[] c = pasteText.ToCharArray();//化整为零，将字符串转化成字符数组，逐个遍历
            int RowCount = 0;//行数初始为零
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '\n')//根据"\r\n"中的'\n'获取换行次数，从而获取总行数
                {
                    RowCount++;
                }
            }
            //判断复制范围是否在最大行范围内：（黏贴内容行数-1）+（当前单元格行索引值+1） > 表格总行数
            if (RowCount + insertRowIndex > dgv.RowCount)//(黏贴内容行数 -1）:因为有一行刚好黏贴在当前行
            {
                MessageBox.Show("粘贴的行数不正确");
                return;
            }
            if (type == 1 && RowCount != 1)
            {
                MessageBox.Show("粘贴的行数不正确");
                return;
            }
            #endregion
            #region 获取列数
            string[] s = pasteText.Split(new char[] { '\r', '\n' });//根据'/r'、'/n'，把数据分为行单位内容
            string[] Col = s[0].Split('\t');//根据'\t',获取每行单元格数，也就是列数
            int ColCount = Col.Length;//列数
            if (ColCount + insertColIndex > dgv.ColumnCount)//判断复制范围是否在最列行范围内：（黏贴内容列数-1）+（当前单元格列索引值+1） > 表格总列数
            {
                MessageBox.Show("粘贴的列数不正确");
                return;
            }
            if (type == 0 && ColCount != 1)
            {
                MessageBox.Show("粘贴的列数不正确");
                return;
            }
            #endregion

            #endregion

            #region 黏贴单元格内容
            List<string> listRow = new List<string>();//声明集合，存储行单位内容
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != "")//存储不为null的行单位内容
                {
                    listRow.Add(s[i]);
                }
            }
            //黏贴单元格内容到表格上
            for (int iR = 0; iR < RowCount; iR++)
            {
                for (int iC = 0; iC < ColCount; iC++)
                {
                    //注意黏贴单元格索引位置：在当前单元格的初始索引上叠加
                    dgv[iC + insertColIndex, iR + insertRowIndex].Value = listRow[iR].Split('\t')[iC];
                }
            }
            #endregion
        }

        public int getLenth()
        {
            int length = this.dataGridView1.Rows.Count - 1;
            return length;
        }
    }
}
