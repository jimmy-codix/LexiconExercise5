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

        public Vehicle DepartVehicle(Vehicle vehicle)
        {
            return _garage.Depart(vehicle);
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

        internal Vehicle? SearchReg(string reg)
        {
            return _garage.FirstOrDefault(x => x.RegistrationNr.ToLower() == reg.ToLower());
        }

        internal Vehicle[] SearchMotorCycle(int nrWheels)
        {
            return _garage
                .OfType<Motorcycle>()
                .Where(x => x.NrOfWheels == nrWheels)
                .ToArray();
        }

        internal Vehicle[] TestSearch(Func<IEnumerable<Vehicle>, Vehicle[]> exp)
        {
            return exp(_garage);
        }
    }
}