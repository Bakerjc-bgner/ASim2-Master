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
    public partial class ShowVar : UserControl
    {
        int allnum = 0;
        List<object> Value = new List<object>();
        List<object> data = new List<object>();
        List<string> Des = new List<string>();
        List<string> Type = new List<string>();
        string[] arrayData;
        public int arrayLen = 0;
        string[,] MatrixData;
        int LastIDi = new int();
        bool isMatrix = false;
        bool isArray = false;
        bool Mode = false;
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
        public ShowVar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            this.dataGridView2.Visible = false;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            this.dataGridView2.Visible = false;
            this.textBox1.Clear();
            this.textBox1.Text += this.Des[i];
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
                    string[,] value = new string[6, 6];
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            value[i, j] = ((string[,])this.Value[e.RowIndex])[i, j];
                        }
                    }
                    this.MatrixLoad(value);
                }
                else if (Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == "InputArray")
                {
                    this.dataGridView2.Visible = true;
                    this.Mode = false;
                    this.SetSize(this.Height, this.Width);
                    string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    string sg = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    List<string> value = new List<string>();
                    if(arrayData == null)
                    {
                        arrayData = new string[100];
                        for (int i = 0; i < ((List<string>)this.Value[e.RowIndex]).Count; i++)
                        {
                            arrayData[i] = ((List<string>)this.Value[e.RowIndex])[i];
                        }
                        arrayLen = ((List<string>)this.Value[e.RowIndex]).Count;
                    }
                    else
                    {
                        for (int i = 0; i < ((List<string>)this.Value[e.RowIndex]).Count; i++)
                        {
                            arrayData[i] = ((List<string>)this.Value[e.RowIndex])[i];
                        }
                        arrayLen = ((List<string>)this.Value[e.RowIndex]).Count;
                    }
                    for (int i = 0; i < arrayLen; i++)
                    {
                        value.Add(arrayData[i]);
                    }
                    int len = Math.Max(arrayLen, 10);
                    this.ArrayLoad(name, sg, len, value,Type[e.RowIndex]);

                }
            }
        }

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
                    this.Value[LastIDi] = st;
                }
            }
            if (isArray)
            {
                string temp = Convert.ToString(this.dataGridView1.Rows[LastIDi].Cells[1].Value);
                if (temp == "InputArray")
                {
                    List<string> st = this.arraySave();
                    this.data[LastIDi] = st;
                    this.Value[LastIDi] = st;
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
            else if (judge == "InputArray")
            {
                isArray = true;
            }
            this.LastIDi = dataGridView1.CurrentCell.RowIndex;
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
                    Value[i] = st;
                }
                else if (temp == "InputArray")
                {
                    List<string> st = this.arraySave();
                    data[i] = st;
                    Value[i] = st;
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
                    else if (Type[i] == "float")
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
                    else if (Type[i] == "int")
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
                    else if (Type[i] == "bool")
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
        public void DataLoad(List<string> type, List<string> des, List<string> name, List<string> sg, List<object> value)
        {
            this.dataGridView2.Visible = false;
            this.Des.Clear();
            this.Value.Clear();
            this.data.Clear();
            this.Type.Clear();
            this.arrayData = new string[100];
            this.arrayLen = 0;
            this.MatrixData = new string[6,6];
            this.LastIDi = 0;
            this.isMatrix = false;
             this.isArray = false;
             this.Mode = false;
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
            dataGridView1.Rows.Clear();
            allnum = name.Count();
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
                string[] row1 = new string[3];
                row1[0] = name[i];
                row1[1] = Convert.ToString(value[i]);
                row1[2] = sg[i];
                dataGridView1.Rows.Add(row1);
                if (type[i] == "bool")
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = boolean;
                    echo.Value = "False";

                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                dataGridView1.Rows[i].Height = 20;
            }
        }
        public void DataLoad(List<string> type, List<string> des, List<string> name, List<string> sg, List<int> mode, List<object> value)
        {
            this.dataGridView2.Visible = false;
            this.Des.Clear();
            this.Value.Clear();
            this.data.Clear();
            this.Type.Clear();
            this.arrayData = new string[100];
            this.arrayLen = 0;
            this.MatrixData = new string[6, 6];
            this.LastIDi = 0;
            this.isMatrix = false;
            this.isArray = false;
            this.Mode = false;

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
                string[] row1 = new string[3];
                row1[0] = name[i];
                if (mode[i] == 9 || mode[i] == 10)
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
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 2)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number1;
                    echo.Value = "0";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 3)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number2;
                    echo.Value = "0";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 4)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number3;
                    echo.Value = "1";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 5)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number5;
                    echo.Value = "0";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 6)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number6;
                    echo.Value = "0";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 7)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number7;
                    echo.Value = "0";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 8)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number8;
                    echo.Value = "1";
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
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                else if (mode[i] == 13)
                {
                    DataGridViewComboBoxCell echo = new DataGridViewComboBoxCell();
                    echo.DataSource = number13;
                    echo.Value = "1";
                    dataGridView1.Rows[i].Cells[1] = echo;
                }
                dataGridView1.Rows[i].Height = 20;
            }
        }
        private void ArrayLoad(string name, string sg, int len, List<string> value,string type)
        {
            dataGridView2.Rows.Clear();
            int num = 1;
            arrayLen = Math.Max(len,value.Count);
            // 指定DataGridView控件显示的列数
            dataGridView2.ColumnCount = arrayLen + 10;
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
                string[] row1 = new string[arrayLen + 1];
                row1[0] = name + "(" + sg + ")";
                for (int j = 0; j < arrayLen; j++)
                {
                    if (j < value.Count)
                    {
                        row1[j + 1] = arrayData[j];
                    }
                    else
                    {
                        if(type == "int" || type == "float")
                        {
                            row1[j + 1] = "0";
                        }
                        else if(type == "bool")
                        {
                            row1[j + 1] = "False";
                        }
                        else
                        {
                            row1[j + 1] = "";
                        }
                    }
                }
                dataGridView2.Rows.Add(row1);
                dataGridView2.Rows[i].Height = 20;
                dataGridView2.Rows[i].HeaderCell.Value = i + "";
            }
        }
        private void MatrixLoad(List<object> value)
        {
            MatrixData = new string[6, 6];
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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
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
        private List<string> arraySave()
        {
            List<string> str = new List<string>();
            for (int i = 0; i < arrayLen; i++)
            {
                string temp = Convert.ToString(dataGridView2.Rows[0].Cells[i + 1].Value);
                if (temp != null)
                {
                   arrayData[i] = temp;
                   str.Add(temp);
                }

            }
            return str;
        }
        private object MatrixSave()
        {
            string[,] str = new string[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    this.MatrixData[i, j] = Convert.ToString(this.dataGridView2.Rows[i].Cells[j].Value);
                    str[i, j] = this.MatrixData[i, j];
                }
            }
            return str;
        }
        public List<object> SaveData()
        {
            List<object> ans = new List<object>();
            foreach (object obj in this.data)
            {
                ans.Add(obj);
            }
            return ans;
        }
        public void SetSize(int height, int width)
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
            for (int i = 0; i < allnum; i++)
            {
                this.dataGridView1.Rows[i].Height = 20;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //判断是否按下：Ctrl+V
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                //对象不为null，且对象为DataGridView类型
                if (sender != null && sender.GetType() == typeof(DataGridView))
                    DataGirdViewCellPaste((DataGridView)sender,0);//调用黏贴方法
            }
        }
        /// <summary>
        /// 向DataGridView控件粘贴数据
        /// </summary>
        public void DataGirdViewCellPaste(DataGridView dgv,int type)
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
            //(黏贴内容行数 -1）:因为有一行刚好黏贴在当前行
            if (RowCount + insertRowIndex > dgv.RowCount)
            {
                MessageBox.Show("粘贴的行数不正确");
                return;
            }
            if(type == 1 && RowCount != 1)
            {
                MessageBox.Show("粘贴的行数不正确");
                return;
            }
            #endregion

            #region 获取列数
            string[] s = pasteText.Split(new char[] { '\r', '\n' });//根据'/r'、'/n'，把数据分为行单位内容
            string[] Col = s[0].Split('\t');//根据'\t',获取每行单元格数，也就是列数
            int ColCount = Col.Length;//列数
            //判断复制范围是否在最列行范围内：（黏贴内容列数-1）+（当前单元格列索引值+1） > 表格总列数
            if (ColCount + insertColIndex > dgv.ColumnCount)
            {
                MessageBox.Show("粘贴的列数不正确");
                return;
            }
            if(type == 0 && ColCount != 1)
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
                    // listRow[iR]:第[iR+1]行单元格内容
                    // listRow[iR].Split('\t')：把第[iR+1]行单元格内容划分
                    // listRow[iR].Split('\t')[iC]:提取第[iR+1]行的第[iC+1]个单元格内容
                }
            }
            #endregion
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            //判断是否按下：Ctrl+V
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                //对象不为null，且对象为DataGridView类型
                if (sender != null && sender.GetType() == typeof(DataGridView))
                {
                    if (isArray)
                    {
                        DataGirdViewCellPaste((DataGridView)sender, 1);//调用黏贴方法
                    }
                    else if(isMatrix)
                    {
                        DataGirdViewCellPaste((DataGridView)sender, 2);//调用黏贴方法
                    }
                }

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            if(i != -1)
            {
                if (isMatrix)
                {
                    string temp = Convert.ToString(this.dataGridView1.Rows[LastIDi].Cells[1].Value);
                    if (temp == "InputMatrix")
                    {
                        string[,] st = (string[,])this.MatrixSave();
                        this.data[LastIDi] = st;
                        this.Value[LastIDi] = st;
                    }
                }
                if (isArray)
                {
                    string temp = Convert.ToString(this.dataGridView1.Rows[LastIDi].Cells[1].Value);
                    if (temp == "InputArray")
                    {
                        List<string> st = this.arraySave();
                        this.data[LastIDi] = st;
                        this.Value[LastIDi] = st;
                    }
                }
                this.dataGridView2.Visible = false;
                this.textBox1.Clear();
                this.textBox1.Text += this.Des[i];
                isMatrix = false;
                isArray = false;
            }

        }
    }
}
