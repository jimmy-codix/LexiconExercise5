using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    internal class MenuItemVehicle : MenuItemBase
    {
        public VehicleType Type {get; private set;}
        public Action<VehicleType> Caller { get; private set; }
        public MenuItemVehicle(string text, int key, Action<VehicleType> caller, VehicleType type) : base (text,key)
        {
            Caller = caller;
            Type = type;
        }
    }
}