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
        public int NrCarDoors { get; private set; }
        public Car(string regNr, int nrCarDoors) : base(regNr, 1) 
        { 
            NrCarDoors = nrCarDoors;
        }

        public override string Details()
        {
            return base.ToString() + $" Car doors={NrCarDoors}";
        }

    }
}
