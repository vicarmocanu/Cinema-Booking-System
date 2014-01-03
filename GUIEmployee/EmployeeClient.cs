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
    public partial class EmployeeClient : Form
    {
        public EmployeeClient()
        {
            InitializeComponent();
        }

        private static MovieSrv.IMovieService movService = new MovieSrv.MovieServiceClient();

        private void EmployeeClient_Load(object sender, EventArgs e)
        {

        }

        private void loadMovieGrid()
        {

            gridMovie.ColumnCount = 5;
            gridMovie.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridMovie.MultiSelect = false;
            gridMovie.Columns[0].HeaderCell.Value = "MovieId";
            gridMovie.Columns[1].HeaderCell.Value = "Name";
            gridMovie.Columns[2].HeaderCell.Value = "Genre";
            gridMovie.Columns[3].HeaderCell.Value = "AgeLimit";
            gridMovie.Columns[4].HeaderCell.Value = "Length";

            MovieSrv.Movie[] returnList = movService.getMovies();

            foreach (MovieSrv.Movie mov in returnList)
            {

                gridMovie.Rows.Add(new object[] { mov.MovieId, mov.Name, mov.Genre, mov.AgeLimit, mov.Length });
            }

        }

        private void movieTab_Click(object sender, EventArgs e)
        {
            gridMovie.Rows.Clear();
            try 
            {
               
                loadMovieGrid();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have't done it right");
                
            }
        }

        


    }
}
