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
        public Motorcycle(string regNr, int nrOfWheels) : base(regNr, 1) 
        {
            NrOfWheels = nrOfWheels;
        }

        public override string Details()
        {
            return base.ToString() + $" Nr wheels={NrOfWheels}";
        }
    }
}
