using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    internal class Motorcycle : VehicleBase
    {
        public const int WHEELS_MAX = 6;
        public const int WHEELS_MIN = 2;
        public int NrOfWheels { get; private set; }
        public Motorcycle(string regNr, int nrOfWheels) : base(regNr, 1) 
        {
            if (nrOfWheels < WHEELS_MIN || nrOfWheels > WHEELS_MAX)
                throw new ArgumentOutOfRangeException(nameof(nrOfWheels), 
                    $"The number of wheels must be between {WHEELS_MIN} and {WHEELS_MAX}.");
            else
                NrOfWheels = nrOfWheels;
        }

        public override string Details()
        {
            return base.ToString() + $" Nr wheels={NrOfWheels}";
        }
    }
}
