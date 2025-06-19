using LexiconExercise5.Vehicles;

namespace LexiconExercise5.Interfaces
{
    public interface IHandler
    {
        void CreateGarage(int capacity);
        VehicleBase DepartVehicle(VehicleBase vehicle);
        int GetGarageCapacity();
        int GetGarageFreeCapacity();
        List<VehicleBase> GetVehicles();
        bool IsRegUnique(string reg);
        bool ParkVehicle(VehicleBase vehicle);
        VehicleBase[] Search(Func<IEnumerable<VehicleBase>, VehicleBase[]> exp);
        VehicleBase? SearchReg(string reg);
    }
}