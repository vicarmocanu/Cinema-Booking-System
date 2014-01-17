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
            loadListMovie();
        }

        private static MovieSrv.IMovieService movService = new MovieSrv.MovieServiceClient();
        private static SessionSrv.ISessionService sessionService = new SessionSrv.SessionServiceClient();
        private static RoomSrv.IRoomService roomService = new RoomSrv.RoomServiceClient();
        private static SeatSrv.ISeatService seatService = new SeatSrv.SeatServiceClient();
        private static ReservationSrv.IReservationService reservationService = new ReservationSrv.ReservationServiceClient();

        private int sessionId= -1;
        private int sessionId2 = -1;
        private string movieName;
        private string customerFName;
        private string movieName2;

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

        private void CustomerClient_Load(object sender, EventArgs e)
        {
            label3.Text = "Logged IN AS " + CustomerFName + " " + CustomerLName; 
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
        private void loadListMovie()
        {
            MovieSrv.Movie[] returnList = movService.getMovies();
            String showString = "default";
            List<string> showList = new List<string>();
            foreach (MovieSrv.Movie movie in returnList)
            {
                showString = movie.Name;
                showList.Add(showString);
            }
            listMovie.DataSource = showList;
        }
        private void loadListSession(int movieId)
        {
            SessionSrv.Session[] returnList = sessionService.getMovieSessions(movieId);

            foreach (SessionSrv.Session ses in returnList)
            {
                int id = ses.SessionId;
                string showString = id.ToString();
                listSession.Items.Add(showString);
            }
        }
        private void loadSeats_Click(object sender, EventArgs e)
        {
            if (sessionId2 == -1)
            {
                MessageBox.Show("Pls select a suitable ses!");
            }
            else
            {
                drawSeat(sessionId2);
            }
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
                int[] results = reservationService.trustedInsertReservedSeats(customerFName, customerLName, sessionId, noOfWantedSeats, sessionPrice, status);
                if (results.Length == 0)
                {
                    MessageBox.Show("Seat(s) -1!");
                    gridSeats.Rows.Clear();
                    loadSeatGrid(sessionId);
                }
                else
                {
                    string lineResults = "";
                    for (int i = 0; i < results.Length; i++)
                    {
                        lineResults = lineResults + results[i] + " ";
                    }
                    MessageBox.Show("Seat(s) " + lineResults + "!");
                    gridSeats.Rows.Clear();
                    loadSeatGrid(sessionId);
                }
            }
        }
        private void OkMovBtn_Click(object sender, EventArgs e)
        {
            gridSession.Rows.Clear();
            MovieSrv.Movie mov = new MovieSrv.Movie();
            mov = movService.getMovieByName(movieName);

            int movieId = mov.MovieId;

            loadSessionGrid(movieId);
        }
        private void setSes_Click(object sender, EventArgs e)
        {
            listSession.Items.Clear();
            MovieSrv.Movie mov = new MovieSrv.Movie();

            mov = movService.getMovieByName(movieName2);
            int movieId = mov.MovieId;
            loadListSession(movieId);
        }
        private void OkSesBtn_Click(object sender, EventArgs e)
        {
            gridSeats.Rows.Clear();
            try
            {
                string stringData = gridSession.SelectedRows[0].Cells[0].Value.ToString();
                sessionId = Convert.ToInt32(stringData);
                loadSeatGrid(sessionId);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You have selected a no seat session.");
            }
            

        }
        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logged Out");
            this.Close();
            LogIn.getInstance().ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            movieName = listBox1.SelectedItem.ToString();
        }
        private void listSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sessionId2 = Convert.ToInt32(listSession.SelectedItem.ToString());
            }
            catch(NullReferenceException)
            { 
              
            }
            
        }
        private void listMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            movieName2 = listMovie.SelectedItem.ToString();
        }

        private void gridSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridSeats.Rows.Clear();
            try
            {
                string data = gridSession.SelectedRows[0].Cells[0].Value.ToString();

                sessionId = Convert.ToInt32(data);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Empty space selected");
            }
        }

        private void drawSeat(int sessionId)
        {
            int rows = 0;
            int columns = 0;

            SessionSrv.Seat[] returnList = sessionService.getSessionSeats(sessionId);

            rows = returnList[returnList.Length - 1].RowNumber;
            columns = returnList.Length / rows;
            Pen pn1 = new Pen(Color.Green);
            Pen pn2 = new Pen(Color.Red);

            SolidBrush sb = new SolidBrush(Color.Green);
            SolidBrush sb2 = new SolidBrush(Color.Red);

            Graphics g = panel1.CreateGraphics();
            foreach (SessionSrv.Seat seat in returnList)
            {
                if (seat.Status.Equals("E"))
                {
                    if (seat.SeatNumber % columns == 0)
                    {
                        g.DrawRectangle(pn1, 50 * (columns), 50 * (seat.RowNumber), 30, 30);
                        g.FillRectangle(sb, 50 * (columns), 50 * (seat.RowNumber), 30, 30);

                    }
                    else
                    {
                        g.DrawRectangle(pn1, 50 * (seat.SeatNumber % columns), 50 * (seat.RowNumber), 30, 30);
                        g.FillRectangle(sb, 50 * (seat.SeatNumber % columns), 50 * (seat.RowNumber), 30, 30);
                    }
                }

                if (seat.Status.Equals("O"))
                {
                    if (seat.SeatNumber % columns == 0)
                    {
                        g.DrawRectangle(pn2, 50 * (columns), 50 * (seat.RowNumber), 30, 30);
                        g.FillRectangle(sb2, 50 * (columns), 50 * (seat.RowNumber), 30, 30);
                    }
                    else
                    {
                        g.DrawRectangle(pn2, 50 * (seat.SeatNumber % columns), 50 * (seat.RowNumber), 30, 30);
                        g.FillRectangle(sb2, 50 * (seat.SeatNumber % columns), 50 * (seat.RowNumber), 30, 30);
                    }
                }
            }

        }
    }
}
