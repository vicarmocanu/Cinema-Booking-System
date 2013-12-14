using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient
{
    public partial class LogInEmployee : Form
    {
        public LogInEmployee()
        {
            InitializeComponent();
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked == true)
            {
                passTxt.UseSystemPasswordChar = false;

            }
            else passTxt.UseSystemPasswordChar = true;
        }
    }
}
