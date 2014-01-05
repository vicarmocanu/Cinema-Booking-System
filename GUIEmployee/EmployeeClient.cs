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
        private static SessionSrv.ISessionService sesService = new SessionSrv.SessionServiceClient();

        private void EmployeeClient_Load(object sender, EventArgs e)
        {
            loadCustomerGrid();
            loadMovieGrid();
            loadReservationGrid();
            loadSessionGrid();
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

        private void loadSessionGrid()
        {
            gridSession.ColumnCount = 6;
            gridSession.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSession.MultiSelect = false;
            gridSession.Columns[0].HeaderCell.Value = "SessionId";
            gridSession.Columns[1].HeaderCell.Value = "MovieId";
            gridSession.Columns[2].HeaderCell.Value = "EnterTime";
            gridSession.Columns[3].HeaderCell.Value = "ExitTime";
            gridSession.Columns[4].HeaderCell.Value = "Date";
            gridSession.Columns[5].HeaderCell.Value = "Price";

            SessionSrv.Session[] returnList = sesService.getSessions();

            foreach (SessionSrv.Session ses in returnList)
            {
                gridSession.Rows.Add(new object[] { ses.SessionId, ses.Movie.MovieId, ses.EnterTime, ses.ExitTime, ses.Date, ses.Price });
            }
        }

        private void gridReservation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridReservation.Rows[e.RowIndex];

                rezervationIdTxt.Text = row.Cells[0].Value.ToString();
                custFNameTxt.Text = row.Cells[1].Value.ToString();
                custLNameTxt.Text = row.Cells[2].Value.ToString();
                sessionIdTxt.Text = row.Cells[3].Value.ToString();
                noOfSeatsTxt.Text = row.Cells[4].Value.ToString();
                priceTxt.Text = row.Cells[5].Value.ToString();
                statusTxt.Text = row.Cells[6].Value.ToString();
                dateTxt.Text = row.Cells[7].Value.ToString();
            }
        }

        private void gridCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridCustomer.Rows[e.RowIndex];

                fnametxt.Text = row.Cells[0].Value.ToString();
                lnametxt.Text = row.Cells[1].Value.ToString();
                usernameTxt.Text = row.Cells[2].Value.ToString();
                passwordTxt.Text = row.Cells[3].Value.ToString();
                cityTxt.Text = row.Cells[4].Value.ToString();
                addressTxt.Text = row.Cells[5].Value.ToString();
                emailTxt.Text = row.Cells[6].Value.ToString();
                phoneNoTxt.Text = row.Cells[7].Value.ToString();
            }
        }

        private void gridMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridMovie.Rows[e.RowIndex];

                ageLimitTxt.Text = row.Cells[0].Value.ToString();
                genreTxt.Text = row.Cells[1].Value.ToString();
                lenghtTxt.Text = row.Cells[2].Value.ToString();
                movieIdTxt.Text = row.Cells[3].Value.ToString();
                nameTxt.Text = row.Cells[4].Value.ToString();
            }
        }

        private void gridSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridSession.Rows[e.RowIndex];

                txtSesId.Text = row.Cells[0].Value.ToString();
                txtSesMovId.Text = row.Cells[1].Value.ToString();
                txtEnterTime.Text = row.Cells[2].Value.ToString();
                txtExitTime.Text = row.Cells[3].Value.ToString();
                txtSesDate.Text = row.Cells[4].Value.ToString();
                txtSesPrice.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}
