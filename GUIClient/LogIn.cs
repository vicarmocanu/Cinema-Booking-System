﻿using System;
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
        private static LogIn instance = null;
        int failure = 0;

        public static LogIn getInstance()
        {
            if (instance == null)
            {
                instance = new LogIn();
            }
            return instance;
        }

        private static CustomerSrv.ICustomerService customerService = new CustomerSrv.CustomerServiceClient();

        public LogIn()
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

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string password = passTxt.Text;
            string username = userNameTxt.Text;
            string actualPassword = "Error";
            string customerFName = "Error";
            string customerLName = "Error";

            CustomerSrv.Customer customer = new CustomerSrv.Customer();
            customer = customerService.getCustomerByUsername(username);
            try
            {
                actualPassword = customer.CustomerPassword;
                customerFName = customer.CustomerFirstName;
                customerLName = customer.CustomerLastName;
            }
            catch(NullReferenceException)
            { 
                
            }




            if (password.Equals(actualPassword) == true)
            {
                MessageBox.Show("Welcome " + username + "!");

                CustomerClient custClient = new CustomerClient();
                custClient.CustomerFName = customerFName;
                custClient.CustomerLName = customerLName;
                this.Hide();
                custClient.ShowDialog();
                this.Close();

            }
            else
            {
                if (failure == 2)
                {
                    MessageBox.Show("Come again later");
                    Application.Exit();
                }
                MessageBox.Show("UserName or Password was incorect");
                userNameTxt.Text = "";
                passTxt.Text = "";
                failure++;
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
            this.Close();
        }


    }
}
