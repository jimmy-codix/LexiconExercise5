using LexiconExercise5.Vehicles;

namespace LexiconExercise5
{
    //Start point for Application.
    internal class Manager
    {
        private Handler _handler;

        //Menus
        //private List<Action> _garageMenu;
        private Dictionary<int, MenuItem> _garageMenu;
        private Dictionary<int, MenuItemBase> _parkMenu;
        private Dictionary<int, MenuItem> _populateMenu;
        //TODO not implemented correctly
        private Stack<Action> _menuHistory;
        private string _lastMessage;
        //TODO skicka vidare till handlern
        //TODO Använd dictionary for UI
        //TODO använd IndexOf för att leta en ledig plats

        public Manager()
        {
            _handler = new Handler();
            _menuHistory = new Stack<Action>();
            //_garageMenu =
            //[
            //    ExitProgram, 
            //    ParkVehicle, 
            //    RemoveVehicle, 
            //    PopulateGarage
            //];
            _garageMenu = new Dictionary<int, MenuItem>();
            _garageMenu.Add(0, new MenuItem("0. Exit", 0, ExitProgram));
            _garageMenu.Add(1, new MenuItem("1. Park a vehicle", 1, ParkVehicleMenu));
            _garageMenu.Add(2, new MenuItem("2. Remove a vehicle", 2, RemoveVehicle));
            _garageMenu.Add(3, new MenuItem("3. Populate garage with vehicles", 3, PopulateGarage));
            _garageMenu.Add(4, new MenuItem("4. View all vehicles in the garage", 4, ViewVehicles));

            //TODO this can be solved in a better way
            _parkMenu = new Dictionary<int, MenuItemBase>();
            _parkMenu.Add(0, new MenuItem("0. Back", 0, GarageMenu));
            _parkMenu.Add(1, new MenuItemVehicle("1. Airplane", 1, DosomeThing(VehicleType.Car)));
            _parkMenu.Add(2, new MenuItem("2. Boat", 2, ParkBoat));
            _parkMenu.Add(3, new MenuItem("3. Car", 3, ParkCar));
            _parkMenu.Add(4, new MenuItem("4. Motorcycle", 4, ParkMotorcycle));
            _parkMenu.Add(5, new MenuItem("5. Bus", 5, ParkBus));

            _populateMenu = new Dictionary<int, MenuItem>();
            _populateMenu.Add(0, new MenuItem("0. Back", 0, GarageMenu));
            _populateMenu.Add(1, new MenuItem("1. Random", 1, PopulateRandom));
            CreateGarage();
            GarageMenu();
        }

        private Action<VehicleType> DosomeThing(VehicleType car)
        {
            throw new NotImplementedException();
        }

        private void PopulateRandom()
        {
            UI.WriteLine("How many vehicles would you like to create and park (1-100)?");
            int nrOfVehicles = UI.ReadInt("Error, How many vehicles would you like to create and park (1-100)?",100,1);

            Random rnd = new Random();
            Vehicle vehicle = null;

            for (int i = 0; i < nrOfVehicles; i++)
            {
                int sel = rnd.Next(0, 5);
                vehicle = null;

                switch (sel)
                {
                    case 0: vehicle = new Airplane(rnd.Next(1000,10001).ToString(), rnd.Next(100, 201));
                        break;
                    case 1:
                        vehicle = new Boat(rnd.Next(1000, 10001).ToString(), Convert.ToBoolean(rnd.Next(0,2)));
                        break;
                    case 2:
                        vehicle = new Bus(rnd.Next(1000, 10001).ToString(), Convert.ToBoolean(rnd.Next(0, 2)));
                        break;
                    case 3:
                        //TODO Fix this.
                        vehicle = new Car(rnd.Next(1000, 10001).ToString(), CarFuelType.Petrol98);
                        break;
                    case 4:
                        vehicle = new Motorcycle(rnd.Next(1000, 10001).ToString(), rnd.Next(2, 7));
                        break;
                    default:
                        break;
                }

                bool res = _handler.ParkVehicle(vehicle);
                if (res == true)
                    UI.WriteLine($"The {vehicle} has been parked.");
                else
                    UI.WriteLine($"The {vehicle} could NOT be parked.");
            }

            UI.WriteLine("Enter 0 to go back to Garage Menu.");
            if (UI.ReadInt("Error, Enter 0 to go back to Garage Menu.", 0, 0) == 0)
                GarageMenu();
        }

        private void ViewVehicles()
        {
            throw new NotImplementedException();
        }

        //TODO implement a menu back method
        private Action MenuBack()
        {
            throw new NotImplementedException();
        }

        private void ParkBus()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"Does the bus have a toilet? Enter 0 for no or 1 for yes.");
            int nr = UI.ReadInt("Error, Does the bus have a toilet? Enter 0 for no or 1 for yes.",1,0);
            bool res = _handler.ParkVehicle(new Bus(reg, Convert.ToBoolean(nr)));
            if (res == true)
                _lastMessage = "The bus has been parked.";
            else
                _lastMessage = "The bus could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkMotorcycle()
        {
            throw new NotImplementedException();
        }

        private void ParkCar()
        {
            throw new NotImplementedException();
        }

        private void ParkBoat()
        {
            throw new NotImplementedException();
        }

        private void ParkAirplane()
        {
            throw new NotImplementedException();
        }

        private void GarageInfo()
        {
            UI.Clear();
            int capacity= _handler.GetGarageCapacity();
            int freeCapacity = _handler.GetGarageFreeCapacity();
            UI.WriteLine($"Garage info: total capacity = {capacity}, free capacity: {freeCapacity}");
        }

        private void GarageMenu()
        {
            GarageInfo();
            UI.GarageMenu(_garageMenu);
            _menuHistory.Push(GarageMenu);
            int val = UI.ReadInt($"Error, Valid numers are 0-{_garageMenu.Count-1}", _garageMenu.Count-1);
            _garageMenu[val].Caller.Invoke();
        }

        private void CreateGarage()
        {
            UI.CreateGarageMenu();
            int capacity = UI.ReadInt("Error, Valid numbers are 1-1000", 1000, 1);
            _handler.CreateGarage(capacity);
        }

        private string GetRegNumber()
        {
            UI.WriteLine("Enter Registration number 1-6 characters:");
            return UI.ReadString("Error, Enter Registration number 1-6 characters:",6,1);
        }

        private void ParkVehicleMenu()
        {
            GarageInfo();
            UI.GarageMenu(_parkMenu);
            UI.WriteLine(_lastMessage);
            _lastMessage = "";
            //if (_menuHistory.Peek != ParkVehicle)
            //    _menuHistory.Push(ParkVehicleMenu);
            int val = UI.ReadInt($"Error, Valid numers are 0-{_parkMenu.Count - 1}", _parkMenu.Count - 1);
            _parkMenu[val].Caller.Invoke();
        }

        private void RemoveVehicle()
        {
            List<Vehicle> vehicles = _handler.GetVehicles();
            UI.WriteLine("Select a vehicle to remove:");
            for (int i = 0; i < vehicles.Count; i++)
            {
                UI.WriteLine($"{i + 1} {vehicles[i]}");
            }
        }

        private void PopulateGarage()
        {
            GarageInfo();
            PopulateRandom();
        }

        private void ExitProgram()
        {
            UI.WriteLine("Exit");
        }
    }
}