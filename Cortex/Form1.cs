using Cortex.Models;
using Cortex.Transfere;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            TransferOperations.CopyFile(@"C:\test\a.txt", @"C:\test\out\a.txt", DuplicateAction.Rename, out string err);
        }
    }
}
