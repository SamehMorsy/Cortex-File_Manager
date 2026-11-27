using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cortex
{
    public partial class Form_PopUp : Form
    {
        public Form_PopUp()
        {
            InitializeComponent();
        }
        private void Form_PopUp_Load(object sender, EventArgs e)
        {
            Welcome_Pnl.Visible = true;
            Pnl_Start.Visible = false;
            Pnl_Start.Parent = this;
        }

        private void Btn_Welcome_MouseClick(object sender, MouseEventArgs e)
        {
            Welcome_Pnl.Visible = false;
            Pnl_Start.Visible = true;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Form_Main Main = new Form_Main();
            Main.Show();
            this.Hide();
        }
    }
}

