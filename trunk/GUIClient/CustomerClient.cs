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
            loadList();
        }

        private static MovieSrv.IMovieService movService = new MovieSrv.MovieServiceClient();
        private static SessionSrv.ISessionService sessionService = new SessionSrv.SessionServiceClient();
        private static RoomSrv.IRoomService roomService = new RoomSrv.RoomServiceClient();
        private static SeatSrv.ISeatService seatService = new SeatSrv.SeatServiceClient();
        private static ReservationSrv.IReservationService reservationService = new ReservationSrv.ReservationServiceClient();

        private int sessionId=-1;

        private string movieName;
        private string customerFName;

        public string CustomerFName
        {
            get { return customerFName; }
            set { customerFName = value; }
        }
        private string customerLName;

        public string CustomerLName
        {
            get { return customerLName; }
            set { customerLName = value; }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            movieName = listBox1.SelectedItem.ToString();
            

        }

        private void CustomerClient_Load(object sender, EventArgs e)
        {
            label3.Text = "Logged IN AS " + CustomerFName + " " + CustomerLName; 
        }

        private void OkMovBtn_Click(object sender, EventArgs e)
        {

            gridSession.Rows.Clear();
            MovieSrv.Movie mov = new MovieSrv.Movie();
            mov = movService.getMovieByName(movieName);

            int movieId = mov.MovieId;
            loadSessionGrid(movieId);



        }

        

        private void loadList()
        {

            MovieSrv.Movie[] returnList = movService.getMovies();
            String showString = "default";
            List<string> showList = new List<string>();
            foreach (MovieSrv.Movie movie in returnList)
            {
                showString = movie.Name;
                showList.Add(showString);
            }
            listBox1.DataSource = showList;
        }

        private void loadSessionGrid(int movieId)
        {
            gridSession.ColumnCount = 6;
            gridSession.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSession.MultiSelect = false;
            gridSession.Columns[0].HeaderCell.Value = "SessionId";
            gridSession.Columns[1].HeaderCell.Value = "RoomNumber";
            gridSession.Columns[2].HeaderCell.Value = "Date";
            gridSession.Columns[3].HeaderCell.Value = "EnterTime";
            gridSession.Columns[4].HeaderCell.Value = "ExitTime";
            gridSession.Columns[5].HeaderCell.Value = "Price";

            SessionSrv.Session[] returnList = sessionService.getMovieSessions(movieId);
            
           
            foreach(SessionSrv.Session session in returnList)
            {
                RoomSrv.Room rom = new RoomSrv.Room();
                rom.RoomNumber = session.Room.RoomNumber;
                int roomNumber = rom.RoomNumber;
                gridSession.Rows.Add(new object[] {session.SessionId, roomNumber, session.Date, session.EnterTime, session.ExitTime, session.Price });


            }
        }

        private void loadSeatGrid(int sessionId)
        {

            gridSeats.ColumnCount = 4;
            gridSeats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSeats.MultiSelect = false;
            gridSeats.Columns[0].HeaderCell.Value = "SeatId";
            gridSeats.Columns[1].HeaderCell.Value = "SeatNumber";
            gridSeats.Columns[2].HeaderCell.Value = "RowNumber";
            gridSeats.Columns[3].HeaderCell.Value = "Status";

            SessionSrv.Seat[] returnList = sessionService.getSessionSeats(sessionId);

            foreach (SessionSrv.Seat seat in returnList)
            {

                gridSeats.Rows.Add(new object[] { seat.SeatId, seat.SeatNumber, seat.RowNumber, seat.Status });
            }
            
        }

        private void OkSesBtn_Click(object sender, EventArgs e)
        {
            gridSeats.Rows.Clear();
            try
            {
                string data = gridSession.SelectedRows[0].Cells[0].Value.ToString();

                sessionId = Convert.ToInt32(data);
                loadSeatGrid(sessionId);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have selected a no seat session.");
            }
           
        }

        

        private void gridSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridSeats.Rows.Clear();
            string data = gridSession.SelectedRows[0].Cells[0].Value.ToString();

            sessionId = Convert.ToInt32(data);
        }

        

        private void ReserveAutoBtn_Click(object sender, EventArgs e)
        {
            if (sessionId == -1 || noOfSeatsTxt.Text.Equals("") == true)
            {
                MessageBox.Show("Pls Select a Movie, a Session  for the Movie and the number of wanted seats");
            }
            else
            {
                SessionSrv.Session sess = new SessionSrv.Session();
                sess = sessionService.getSession(sessionId);
                double sessionPrice = sess.Price;
                int noOfWantedSeats = Convert.ToInt32(noOfSeatsTxt.Text);
                string status = "Made";
                reservationService.trustedInsertReservedSeats(customerFName, customerLName, sessionId, noOfWantedSeats, sessionPrice, status);

                
            }
        }

        

        
    }
}
