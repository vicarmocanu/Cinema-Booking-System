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
    public partial class LogIn : Form
    {

        private static CustomerSrv.ICustomerService customerService = new CustomerSrv.CustomerServiceClient();

        public LogIn()
        {
            InitializeComponent();

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

            CustomerSrv.Customer customer = new CustomerSrv.Customer();
            customer = customerService.getCustomerByUsername(username);


            string actualPassword = customer.CustomerPassword;

            if(password.Equals(actualPassword)== true)
            {
                MessageBox.Show("Welcome" + username);
                
                CustomerClient custClient = new CustomerClient();
                this.Hide();
                custClient.ShowDialog();
            }                          
        }       
    }
}
