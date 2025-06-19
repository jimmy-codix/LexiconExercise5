using LexiconExercise5.UserInterface;
using LexiconExercise5.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5
{
    internal partial class Manager
    {
        private void ParkVehicle(VehicleBase vehicle)
        {
            bool res = _handler.ParkVehicle(vehicle);
            if (res == true)
                _lastMessage = $"The {vehicle.GetType().Name.ToLower()} has been parked.";
            else
                _lastMessage = $"The {vehicle.GetType().Name.ToLower()} could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkBus()
        {
            string reg = GetRegNumber();
            int nr = UI.ReadInt("Does the bus have a toilet? Enter 0 for no or 1 for yes: ", 1, 0);
            ParkVehicle(new Bus(reg, Convert.ToBoolean(nr)));
        }

        private void ParkMotorcycle()
        {
            string reg = GetRegNumber();
            int nr = UI.ReadInt("How many wheels does this motorcycle have?:", Motorcycle.WHEELS_MAX, Motorcycle.WHEELS_MIN);
            ParkVehicle(new Motorcycle(reg, nr));
        }

        private void ParkCar()
        {
            string reg = GetRegNumber();
            int nr = UI.ReadInt("How many car doors does this car have?:", Car.DOORS_MAX, Car.DOORS_MIN);
            ParkVehicle(new Car(reg, nr));
        }

        private void ParkBoat()
        {
            string reg = GetRegNumber();
            int nr = UI.ReadInt("Is this boat sinkable (0 for no and 1 for yes)?:", 1, 0);
            ParkVehicle(new Boat(reg, Convert.ToBoolean(nr)));
        }

        private void ParkAirplane()
        {
            string reg = GetRegNumber();
            int nr = UI.ReadInt("How many seats are there?:", Airplane.SEATS_MAX, Airplane.SEATS_MIN);
            ParkVehicle(new Airplane(reg, nr));
        }
    }
}
