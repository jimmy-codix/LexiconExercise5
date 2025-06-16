using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5.Vehicles
{
    public enum CarFuelType
    {
        Petrol95,
        Petrol98,
        Diesel,
        Gas
    }

    internal class Car : Vehicle
    {
        public CarFuelType FuelType { get; private set; }
        public Car(int unitSize, CarFuelType carFuelType) : base(unitSize) 
        { 
            FuelType = carFuelType;
        }
    }
}
