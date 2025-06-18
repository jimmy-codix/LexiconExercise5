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

        private void ParkBus()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"Does the bus have a toilet? Enter 0 for no or 1 for yes.");
            int nr = UI.ReadInt("Error, Does the bus have a toilet? Enter 0 for no or 1 for yes.", 1, 0);
            bool res = _handler.ParkVehicle(new Bus(reg, Convert.ToBoolean(nr)));
            if (res == true)
                _lastMessage = "The bus has been parked.";
            else
                _lastMessage = "The bus could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkMotorcycle()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"How many wheels does this motorcycle have?");
            int nr = UI.ReadInt("Error, How many wheels does this motorcycle have?", 1000, 1);
            bool res = _handler.ParkVehicle(new Motorcycle(reg, nr));
            if (res == true)
                _lastMessage = "The Motorcycle has been parked.";
            else
                _lastMessage = "The Motorcycle could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkCar()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"How many car doors does this car have?");
            int nr = UI.ReadInt("Error, How many car doors does this car have?", 1000, 1);
            bool res = _handler.ParkVehicle(new Car(reg, nr));
            if (res == true)
                _lastMessage = "The Car has been parked.";
            else
                _lastMessage = "The Car could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkBoat()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"Is this boat sinkable (0 for no and 1 for yes)?");
            int nr = UI.ReadInt("Error, Is this boat sinkable (0 for no and 1 for yes)?", 1, 0);
            bool res = _handler.ParkVehicle(new Boat(reg, Convert.ToBoolean(nr)));
            if (res == true)
                _lastMessage = "The Boat has been parked.";
            else
                _lastMessage = "The Boat could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkAirplane()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"How many seats are there?");
            int nr = UI.ReadInt("Error, How many seats are there?", 1000, 1);
            bool res = _handler.ParkVehicle(new Airplane(reg, nr));
            if (res == true)
                _lastMessage = "The Airplane has been parked.";
            else
                _lastMessage = "The Airplane could NOT be parked.";

            ParkVehicleMenu();
        }
    }
}
