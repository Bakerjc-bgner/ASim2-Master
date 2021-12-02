using ASimInterfaces;
using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ASimFormsLibrary
{
    public partial class RowShow : UserControl
    {
        ArrayList[] plists;
        int MAX;

        public RowShow()
        {
            InitializeComponent();
            DataLoad();
        }

        public RowShow(ArrayList[] plists)
        {
            InitializeComponent();
            this.plists = plists;
            this.MAX = maxlength(this.plists); 
            DataLoad();
        }

        private static int maxlength(ArrayList[] plists)
        {
            int[] lengths = new int[plists.Length];
            for (int i = 0; i < plists.Length; i++)
            {
                lengths[i] = plists[i].Count;
            }
            return lengths.Max();
        }

        public void DataLoad()
        {
            // 指定DataGridView控件显示的列数
            dataGridView1.ColumnCount = 6;
            //dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.BackgroundColor = Color.White;
            // 设置DataGridView控件标题列的样式
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = true;
            //设置DataGridView控件的标题列名
            for(int i = 0; i < 6; i++)
            {
                dataGridView1.Columns[i].Name = "" + (i + 1);
            }

            // Populate the rows.
            string[] row1 = new string[] { "", "", "", "", "", "" };
            string[] row2 = new string[] { "", "", "", "", "", "" };
            string[] row3 = new string[] { "", "", "", "", "", "" };
            string[] row4 = new string[] { "", "", "", "", "", "" };
            string[] row5 = new string[] { "", "", "", "", "", "" };
            string[] row6 = new string[] { "", "", "", "", "", "" };

            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            foreach (string[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows[i].Height = this.dataGridView1.Height/12;
            }
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Columns[i].Width = this.dataGridView1.Width/6;
            }
        }
        public string[,] SavaData()
        {
            string[,] str = new string[6, 6];

            return str;
        }
    }
}
