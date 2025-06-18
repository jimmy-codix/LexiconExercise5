using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Airplane : Vehicle
    {
        public const int SEATS_MAX = 300;
        public const int SEATS_MIN = 100;
        public int NrOfSeats { get; private set; }

        public Airplane(string regNr, int nrOfSeats) : base(regNr, 1) 
        {
            if (nrOfSeats < SEATS_MIN || nrOfSeats > SEATS_MAX)
                throw new ArgumentOutOfRangeException(nameof(nrOfSeats),
                    $"The number of seats must be between {SEATS_MIN} and {SEATS_MAX}.");
            else
                NrOfSeats = nrOfSeats;
        }

        public override string Details()
        {
            return base.ToString() + $" NrSeats={NrOfSeats}";
        }
    }
}
