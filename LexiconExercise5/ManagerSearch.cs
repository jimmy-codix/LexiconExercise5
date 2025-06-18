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
        private void SearchMotorcycle()
        {
            GarageInfo();
            int wheels = UI.ReadInt("How many wheels does the motocycle have?");
            //Vehicle[] arr = _handler.SearchMotorCycle(wheels);
            Func<IEnumerable<Vehicle>, Vehicle[]> exp = y => y.OfType<Motorcycle>().Where(x => x.NrOfWheels == wheels).ToArray();
            Vehicle[] arr = _handler.TestSearch(exp);
            if (arr.Length == 0)
            {
                UI.WriteLine($"No motorcycle could be found with {wheels} wheels.");
                return;
            }

            UI.WriteLine("The following motorcycles was found:");
            foreach (var vehicle in arr)
            {
                UI.WriteLine(vehicle.Details());
            }
        }

        private void SearchCar()
        {
            throw new NotImplementedException();
        }

        private void SearchBus()
        {
            throw new NotImplementedException();
        }

        private void SearchBoat()
        {
            throw new NotImplementedException();
        }

        private void SearchAirplane()
        {
            throw new NotImplementedException();
        }
    }
}
