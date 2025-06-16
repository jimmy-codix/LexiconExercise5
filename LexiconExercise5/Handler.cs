using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    internal class Handler
    {
        //Handler sksa sköta mera
        private Garage<Vehicle> _garage;
        public Handler() { }

        //TODO Denna kan flyttas till konstruktorn.
        public void CreateGarage(int capacity)
        {
            _garage = new Garage<Vehicle>(capacity);
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            return _garage.Park(vehicle);
        }

        internal int GetGarageCapacity()
        {
            return _garage.Capacity;
        }

        internal int GetGarageFreeCapacity()
        {
            return _garage.FreeCapacity;
        }

        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> list = new List<Vehicle>();
            foreach (var item in _garage)
            {
                list.Add(item);
            }

            return list;
        }
    }
}