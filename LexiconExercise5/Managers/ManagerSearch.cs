using LexiconExercise5.UserInterface;
using LexiconExercise5.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise5
{
    internal partial class Manager
    {
        private void SearchVehicle(Func<IEnumerable<VehicleBase>, VehicleBase[]> exp)
        {
            VehicleBase[] arr = _handler.TestSearch(exp);
            if (arr.Length == 0)
            {
                UI.WriteLine($"No match was found.");
                return;
            }

            UI.WriteLine("The following matches was found:");
            foreach (var vehicle in arr)
                UI.WriteLine(vehicle.Details());
        }

        private void SearchMotorcycle()
        {
            GarageInfo();
            int wheels = UI.ReadInt("How many wheels does the motocycle have?",Motorcycle.WHEELS_MAX,Motorcycle.WHEELS_MIN);
            SearchVehicle(y => y.OfType<Motorcycle>().Where(x => x.NrOfWheels == wheels).ToArray());
        }

        private void SearchCar()
        {
            GarageInfo();
            int nr = UI.ReadInt("How many doors does the car have?",Car.DOORS_MAX,Car.DOORS_MIN);
            SearchVehicle(y => y.OfType<Car>().Where(x => x.NrCarDoors == nr).ToArray());
        }

        private void SearchBus()
        {
            GarageInfo();
            int nr = UI.ReadInt("Does the bus have a toilet? Enter 0 for No and 1 for Yes.", 1, 0);
            SearchVehicle(y => y.OfType<Bus>().Where(x => x.HasToilet == Convert.ToBoolean(nr)).ToArray());
        }

        private void SearchBoat()
        {
            GarageInfo();
            int nr = UI.ReadInt("Is the boat sinkable Enter 0 for No and 1 for Yes?", 1, 0);
            SearchVehicle(y => y.OfType<Boat>().Where(x => x.IsSinkable == Convert.ToBoolean(nr)).ToArray());
        }

        private void SearchAirplane()
        {
            GarageInfo();
            int nr = UI.ReadInt("How many seats does the airplane have?", Airplane.SEATS_MAX, Airplane.SEATS_MIN);
            SearchVehicle(y => y.OfType<Airplane>().Where(x => x.NrOfSeats == nr).ToArray());
        }
    }
}
