using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    internal class Handler
    {
        //Handler sksa sköta mera
        private Garage<VehicleBase> _garage;
        public Handler() { }

        //TODO Denna kan flyttas till konstruktorn.
        public void CreateGarage(int capacity)
        {
            _garage = new Garage<VehicleBase>(capacity);
        }

        public bool ParkVehicle(VehicleBase vehicle)
        {
            return _garage.Park(vehicle);
        }

        public VehicleBase DepartVehicle(VehicleBase vehicle)
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

        public List<VehicleBase> GetVehicles()
        {
            List<VehicleBase> list = new List<VehicleBase>();
            foreach (var item in _garage)
            {
                list.Add(item);
            }

            return list;
        }

        internal VehicleBase? SearchReg(string reg)
        {
            return _garage.FirstOrDefault(x => x.RegistrationNr.ToLower() == reg.ToLower());
        }

        internal VehicleBase[] SearchMotorCycle(int nrWheels)
        {
            return _garage
                .OfType<Motorcycle>()
                .Where(x => x.NrOfWheels == nrWheels)
                .ToArray();
        }

        internal VehicleBase[] TestSearch(Func<IEnumerable<VehicleBase>, VehicleBase[]> exp)
        {
            return exp(_garage);
        }

        internal bool IsRegUnique(string reg)
        {
            VehicleBase? vehicle = SearchReg(reg);
            if (vehicle == null)
                return true;
            else
                return false;

        }
    }
}