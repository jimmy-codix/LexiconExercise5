using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    //Start point for Application.
    internal class Manager
    {
        private Handler _handler;
        //private Garage<> _garage;
        private Garage<Vehicle> _garage;

        //Menus
        private List<Action> _garageMenu;

        public Manager()
        {
            _handler = new Handler();
            _garageMenu =
            [
                ExitProgram, 
                ParkVehicle, 
                RemoveVehicle, 
                PopulateGarage
            ];
            CreateGarage();
            ShowGarageMenu();
        }

        private void GarageInfo()
        {
            //TODO fix "free capacity"
            UI.Clear();
            UI.WriteLine($"Garage info: total capacity = {_garage.Capacity}, free capacity: {_garage.Capacity}");
        }

        private void ShowGarageMenu()
        {
            GarageInfo();
            UI.GarageMenu();
            int val = UI.ReadInt($"Error, Valid numers are 0-{_garageMenu.Count-1}", _garageMenu.Count-1);
            _garageMenu[val].Invoke();
        }

        private void CreateGarage()
        {
            UI.CreateGarageMenu();
            int capacity = UI.ReadInt("Error, Valid numbers are 1-1000", 1000, 1);
            _garage = new Garage<Vehicle>(capacity);
        }

        private void ParkVehicle()
        {
            UI.WriteLine("Park");
        }

        private void RemoveVehicle()
        {
            UI.WriteLine("Remove");
        }

        private void PopulateGarage()
        {
            UI.WriteLine("Populate");
        }

        private void ExitProgram()
        {
            UI.WriteLine("Exit");
        }
    }
}