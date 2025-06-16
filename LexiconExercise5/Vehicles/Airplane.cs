using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NrOfSeats { get; private set; }

        public Airplane(int unitSize, int nrOfSeats) : base(unitSize) 
        { 
            NrOfSeats = nrOfSeats;
        }
    }
}
