using LexiconExercise5.Vehicles;
using System.Linq.Expressions;

namespace LexiconExercise5
{
    //Start point for Application.
    internal class Manager
    {
        private Handler _handler;

        //Menus
        //private List<Action> _garageMenu;
        private Dictionary<int,MenuItem> _garageMenu;
        private Dictionary<int, MenuItem> _parkMenu;
        private Dictionary<int, MenuItem> _populateMenu;
        private Dictionary<int, MenuItem> _searchMenu;
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
            _garageMenu.Add(3, new MenuItem("3. Search for a vehicle", 3, SearchVehicle));
            _garageMenu.Add(4, new MenuItem("4. Populate garage with vehicles", 4, PopulateGarage));
            _garageMenu.Add(5, new MenuItem("5. View all vehicles in the garage", 5, ViewVehicles));

            //TODO this can be solved in a better way
            _parkMenu = new Dictionary<int, MenuItem>();
            _parkMenu.Add(0, new MenuItem("0. Back", 0, GarageMenu));
            _parkMenu.Add(1, new MenuItem("1. Airplane", 1, ParkAirplane));
            _parkMenu.Add(2, new MenuItem("2. Boat", 2, ParkBoat));
            _parkMenu.Add(3, new MenuItem("3. Car", 3, ParkCar));
            _parkMenu.Add(4, new MenuItem("4. Motorcycle", 4, ParkMotorcycle));
            _parkMenu.Add(5, new MenuItem("5. Bus", 5, ParkBus));

            _populateMenu = new Dictionary<int, MenuItem>();
            _populateMenu.Add(0, new MenuItem("0. Back", 0, GarageMenu));
            _populateMenu.Add(1, new MenuItem("1. Random", 1, PopulateRandom));

            _searchMenu = new Dictionary<int, MenuItem>();
            _searchMenu.Add(0, new MenuItem("0. Back", 0, GarageMenu));
            _searchMenu.Add(1, new MenuItem("1. Search Registration number", 1, SearchReg));
            _searchMenu.Add(2, new MenuItem("2. Search for airplane", 2, SearchAirplane));
            _searchMenu.Add(3, new MenuItem("3. Search for boat", 3, SearchBoat));
            _searchMenu.Add(4, new MenuItem("4. Search for bus", 4, SearchBus));
            _searchMenu.Add(5, new MenuItem("5. Search for car", 5, SearchCar));
            _searchMenu.Add(6, new MenuItem("6. Search for motorcycle", 6, SearchMotorcycle));

            CreateGarage();
            GarageMenu();
        }

        private void CreateAndPark(VehicleType type)
        {
            UI.WriteLine(type.ToString());
            UI.ReadLine();
            string reg = GetRegNumber();
            UI.WriteLine($"Does the bus have a toilet? Enter 0 for no or 1 for yes.");
            int nr = UI.ReadInt("Error, Does the bus have a toilet? Enter 0 for no or 1 for yes.", 1, 0);
            bool res = _handler.ParkVehicle(new Bus(reg, Convert.ToBoolean(nr)));
            if (res == true)
                _lastMessage = "The bus has been parked.";
            else
                _lastMessage = "The bus could NOT be parked.";

            ParkVehicleMenu();
        }

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

        private void SearchReg()
        {
            UI.Write("Enter registration to search for:");
            string reg = UI.ReadString("Error, Enter registration to seach for: ");
            Vehicle? vehicle =_handler.SearchReg(reg);
            if (vehicle == null)
                UI.WriteLine("Result: Nothing matched");
            else
                UI.WriteLine($"Result: found {vehicle}");
        }

        private void SearchVehicle()
        {
            GarageInfo();
            UI.PrintMenu(_searchMenu);
            UI.Write("Selection: ");
            int sel = UI.ReadInt("Error, Selection:", _searchMenu.Count - 1);

            _searchMenu[sel].Caller.Invoke();

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
                        vehicle = new Car(rnd.Next(1000, 10001).ToString(), rnd.Next(1,6));
                        break;
                    case 4:
                        vehicle = new Motorcycle(rnd.Next(1000, 10001).ToString(), rnd.Next(2, 5));
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
            GarageInfo();
            List<Vehicle> vehicles = _handler.GetVehicles();
            for (int i = 0; i < vehicles.Count; i++)
            {
                UI.WriteLine($"{i + 1} {vehicles[i].Details()}");
            }

            UI.WriteLine("");
            UI.WriteLine("Enter 0 to go back:");
            //This will be 0 no need to check input.
            UI.ReadInt("Error, Enter 0 to go back:", 0, 0);
            GarageMenu();
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
            string reg = GetRegNumber();
            UI.WriteLine($"How many wheels does this motorcycle have?");
            int nr = UI.ReadInt("Error, How many wheels does this motorcycle have?", 1000, 1);
            bool res = _handler.ParkVehicle(new Motorcycle(reg, nr));
            if (res == true)
                _lastMessage = "The Motorcycle has been parked.";
            else
                _lastMessage = "The Motorcycle could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkCar()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"How many car doors does this car have?");
            int nr = UI.ReadInt("Error, How many car doors does this car have?", 1000, 1);
            bool res = _handler.ParkVehicle(new Car(reg, nr));
            if (res == true)
                _lastMessage = "The Car has been parked.";
            else
                _lastMessage = "The Car could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkBoat()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"Is this boat sinkable (0 for no and 1 for yes)?");
            int nr = UI.ReadInt("Error, Is this boat sinkable (0 for no and 1 for yes)?", 1, 0);
            bool res = _handler.ParkVehicle(new Boat(reg, Convert.ToBoolean(nr)));
            if (res == true)
                _lastMessage = "The Boat has been parked.";
            else
                _lastMessage = "The Boat could NOT be parked.";

            ParkVehicleMenu();
        }

        private void ParkAirplane()
        {
            string reg = GetRegNumber();
            UI.WriteLine($"How many seats are there?");
            int nr = UI.ReadInt("Error, How many seats are there?", 1000, 1);
            bool res = _handler.ParkVehicle(new Airplane(reg, nr));
            if (res == true)
                _lastMessage = "The Airplane has been parked.";
            else
                _lastMessage = "The Airplane could NOT be parked.";

            ParkVehicleMenu();
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
            UI.PrintMenu(_garageMenu);
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
            UI.PrintMenu(_parkMenu);
            UI.WriteLine(_lastMessage);
            _lastMessage = "";
            //if (_menuHistory.Peek != ParkVehicle)
            //    _menuHistory.Push(ParkVehicleMenu);
            int val = UI.ReadInt($"Error, Valid numers are 0-{_parkMenu.Count - 1}", _parkMenu.Count - 1);
            _parkMenu[val].Caller.Invoke();
        }

        private void RemoveVehicle()
        {
            GarageInfo();
            UI.WriteLine("0 Back");
            List<Vehicle> vehicles = PrintVehicles();
            PrintLastMessage();
            UI.Write("Select a vehicle to remove or 0 to go back:");
            int sel = UI.ReadInt($"Error, Select a vehicle to remove ({0}-{vehicles.Count}:", vehicles.Count, 0);
            if (sel == 0)
                GarageMenu();

            Vehicle vehicle = _handler.DepartVehicle(vehicles[sel - 1]);
            if (vehicle == null)
                _lastMessage = $"{vehicle} could NOT be removed";
            else
                _lastMessage = $"{vehicle} has been removed";

            RemoveVehicle();
        }

        private void PrintLastMessage()
        {
            if (_lastMessage != "")
            {
                UI.WriteLine(_lastMessage);
                _lastMessage = "";
            }
        }

        private List<Vehicle> PrintVehicles()
        {
            List<Vehicle> vehicles = _handler.GetVehicles();
            for (int i = 0; i < vehicles.Count; i++)
            {
                UI.WriteLine($"{i + 1} {vehicles[i]}");
            }

            return vehicles;
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