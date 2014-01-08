using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.ModelLayer;

namespace Cinema.ControlLayer
{
    public class AlgorithmCtr
    {
        private static AlgorithmCtr instance = null;

        public static AlgorithmCtr getInstance()
        {
            if (instance == null)
            {
                instance = new AlgorithmCtr();
            }
            return instance;
        }

        public AlgorithmCtr() { }

        public List<Seat> getAdjancentSeats(Seat[][] receivedSeats, int noOfWantedSeats)
        {
            return Algorithm3.getSeatsToReserve(receivedSeats, noOfWantedSeats);
        }
    }
}
