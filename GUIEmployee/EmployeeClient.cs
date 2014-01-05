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
        private static ReservationSrv.IReservationService rzvService = new ReservationSrv.ReservationServiceClient();
        private static CustomerSrv.ICustomerService custService = new CustomerSrv.CustomerServiceClient();

        private void EmployeeClient_Load(object sender, EventArgs e)
        {
            loadCustomerGrid();
            loadMovieGrid();
            loadReservationGrid();
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

        private void loadReservationGrid()
        {
            gridReservation.ColumnCount = 8;
            gridReservation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridReservation.MultiSelect = false;
            gridReservation.Columns[0].HeaderCell.Value = "ReservationId";
            gridReservation.Columns[1].HeaderCell.Value = "custFName";
            gridReservation.Columns[2].HeaderCell.Value = "custLName";
            gridReservation.Columns[3].HeaderCell.Value = "SessionId";
            gridReservation.Columns[4].HeaderCell.Value = "NoOfSeats";
            gridReservation.Columns[5].HeaderCell.Value = "Price";
            gridReservation.Columns[6].HeaderCell.Value = "Status";
            gridReservation.Columns[7].HeaderCell.Value = "date";


            ReservationSrv.Reservation[] returnList = rzvService.getReservations();

            foreach (ReservationSrv.Reservation rzv in returnList)
            {
                gridReservation.Rows.Add(new object[] { rzv.ReservationId, rzv.Customer.CustomerFirstName, rzv.Customer.CustomerLastName, rzv.Session.SessionId, rzv.NoOfSeats, rzv.Price, rzv.Status, rzv.Date });
            }
        
        }

        private void loadCustomerGrid()
        {
            gridCustomer.ColumnCount = 8;
            gridCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCustomer.MultiSelect = false;
            gridCustomer.Columns[0].HeaderCell.Value = "FName";
            gridCustomer.Columns[1].HeaderCell.Value = "LName";
            gridCustomer.Columns[2].HeaderCell.Value = "UserName";
            gridCustomer.Columns[3].HeaderCell.Value = "Password";
            gridCustomer.Columns[4].HeaderCell.Value = "City";
            gridCustomer.Columns[5].HeaderCell.Value = "Address";
            gridCustomer.Columns[6].HeaderCell.Value = "E-mail";
            gridCustomer.Columns[7].HeaderCell.Value = "PhoneNo";

            CustomerSrv.Customer[] returnList = custService.getCustomers();

            foreach (CustomerSrv.Customer cust in returnList)
            {
                gridCustomer.Rows.Add(new object[] { cust.CustomerFirstName, cust.CustomerLastName, cust.CustomerUsername, cust.CustomerPassword, cust.CustomerCity, cust.CustomerAddress, cust.CustomerEmail, cust.CustomerPhoneNo });
            }
        }     
    }
}
