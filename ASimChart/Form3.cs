using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASimChart
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(uc);
            
        }
        UserControl1 uc = new UserControl1();
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            this.uc.Width = this.panel1.Width;
            this.uc.Height = this.panel1.Height;
        }
    }
}
