using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIEmployee
{
    public partial class LogIn : Form
    {
        
        private static EmployeeSrv.IEmployeeService empService = new EmployeeSrv.EmployeeServiceClient();

        public LogIn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked == true)
            {
                passTxt.UseSystemPasswordChar = false;

            }
            else passTxt.UseSystemPasswordChar = true;
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string password = passTxt.Text;
            string username = userNameTxt.Text;

            EmployeeSrv.Employee employee = new EmployeeSrv.Employee();
            employee = empService.getEmployeeByUserName(username);

            string actualPassword = employee.Password;

            if (password.Equals(actualPassword) == true)
            {
                MessageBox.Show("Welcome " + username);
                EmployeeClient empClient = new EmployeeClient();
                this.Hide();
                empClient.ShowDialog();
            }

        }
    }
}
