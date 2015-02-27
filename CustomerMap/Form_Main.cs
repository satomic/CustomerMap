using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerMap
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void lb_DataProcess_Click(object sender, EventArgs e)
        {
            Form_DataProcess form_DataProcess = new Form_DataProcess();
            form_DataProcess.Show();

        }
    }
}
