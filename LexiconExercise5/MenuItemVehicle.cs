using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    internal class MenuItemVehicle : MenuItemBase
    {
        private VehicleType _vehicleType;
        private Action<VehicleType> _action;
        public MenuItemVehicle(string text, int key, Action<VehicleType> action) : base (text,key)
        {
            _action = action;
        }

    }
}