using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    /*
    public enum CarFuelType
    {
        Petrol95,
        Petrol98,
        Diesel,
        Gas
    }
    */

    internal class Car : Vehicle
    {
        //public CarFuelType FuelType { get; private set; }
        public const int DOORS_MAX = 5;
        public const int DOORS_MIN = 2;
        public int NrCarDoors { get; private set; }
        public Car(string regNr, int nrCarDoors) : base(regNr, 1) 
        {
            if (nrCarDoors < DOORS_MIN || nrCarDoors > DOORS_MAX)
                throw new ArgumentOutOfRangeException(nameof(nrCarDoors),
                    $"The number of wheels must be between {DOORS_MIN} and {DOORS_MAX}.");
            else
                NrCarDoors = nrCarDoors;
        }

        public override string Details()
        {
            return base.ToString() + $" Car doors={NrCarDoors}";
        }

    }
}
