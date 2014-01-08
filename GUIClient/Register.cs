using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUIClient
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private static CustomerSrv.ICustomerService customerService = new CustomerSrv.CustomerServiceClient();

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void VerifyFields()
        {
            string regEmail = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            string regUserName = @"^[a-z0-9_-]{3,16}$";
            string regPassword = @"^[a-z0-9_-]{6,18}$";
            Regex reg1 = new Regex(regEmail);
            Regex reg2 = new Regex(regUserName);
            Regex reg3 = new Regex(regPassword);

            if (fNameTxt.Text.Equals("") || lNameTxt.Text.Equals("") || cityTxt.Text.Equals("") || addressTxt.Text.Equals("") || phoneTxt.Text.Equals("") || emailTxt.Text.Equals("") || userNameTxt.Text.Equals("") || passwordTxt.Text.Equals(""))
            {
                MessageBox.Show("You have not provided all the info!");
            }
            else
            {
                if (!reg1.IsMatch(emailTxt.Text))
                {
                    MessageBox.Show("Email not corect!");
                    emailTxt.Text = "";
                }
                else
                {
                    if (!reg2.IsMatch(userNameTxt.Text))
                    {
                        MessageBox.Show("UserName not correct!");
                        userNameTxt.Text = "";
                    }
                    else
                    {
                        if (!reg3.IsMatch(passwordTxt.Text))
                        {
                            MessageBox.Show("Password not correct!");
                            passwordTxt.Text = "";
                        }
                        else
                        {
                            int result = -1;
                            result = customerService.insertCustomer(fNameTxt.Text.ToString(), lNameTxt.Text.ToString(), cityTxt.Text.ToString(), addressTxt.Text.ToString(), emailTxt.Text.ToString(), phoneTxt.Text.ToString(), userNameTxt.Text.ToString(), passwordTxt.Text.ToString());
                            MessageBox.Show("Congrats you can now log in with your user name and password");
                            this.Hide();
                            LogIn logIn = new LogIn();
                            logIn.ShowDialog();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            VerifyFields();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.ShowDialog();
            this.Close();
        }


    }
}
