using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    public class Handler : IHandler
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

        public int GetGarageCapacity()
        {
            return _garage.Capacity;
        }

        public int GetGarageFreeCapacity()
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

        public VehicleBase? SearchReg(string reg)
        {
            return _garage.FirstOrDefault(x => x.RegistrationNr.ToLower() == reg.ToLower());
        }

        public VehicleBase[] Search(Func<IEnumerable<VehicleBase>, VehicleBase[]> exp)
        {
            return exp(_garage);
        }

        public bool IsRegUnique(string reg)
        {
            VehicleBase? vehicle = SearchReg(reg);
            if (vehicle == null)
                return true;
            else
                return false;

        }
    }
}