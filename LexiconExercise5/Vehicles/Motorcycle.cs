using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int NrOfWheels { get; private set; }
        public Motorcycle(int unitSize, int nrOfWheels) : base(unitSize) 
        {
            NrOfWheels = nrOfWheels;
        }
    }
}
