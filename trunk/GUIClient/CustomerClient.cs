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
    public partial class CustomerClient : Form
    {
        public CustomerClient()
        {
            InitializeComponent();
           
        }

        private static MovieSrv.IMovieService movService = new MovieSrv.MovieServiceClient();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerClient_Load(object sender, EventArgs e)
        {

        }

        
    }
}
