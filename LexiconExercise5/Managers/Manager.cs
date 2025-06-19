using LexiconExercise5.Interfaces;
using LexiconExercise5.UserInterface;
using LexiconExercise5.Vehicles;
using System.Linq.Expressions;

namespace LexiconExercise5
{
    //Start point for Application.
    //internal class Manager
    internal partial class Manager
    {
        private IHandler _handler;

        //Menus
        //private List<Action> _garageMenu;
        private Dictionary<int,MenuItem> _garageMenu;
        private Dictionary<int, MenuItem> _parkMenu;
        private Dictionary<int, MenuItem> _populateMenu;
        private Dictionary<int, MenuItem> _searchMenu;
        private string _lastMessage;
        //TODO skicka vidare till handlern
        //TODO Använd dictionary for UI
        //TODO använd IndexOf för att leta en ledig plats

        public Manager()
        {
            _handler = new Handler();

            _garageMenu = new Dictionary<int, MenuItem>();
            _garageMenu.Add(0, new MenuItem("0. Exit", 0, ExitProgram));
            _garageMenu.Add(1, new MenuItem("1. Park a vehicle", 1, ParkVehicleMenu));
            _garageMenu.Add(2, new MenuItem("2. Remove a vehicle", 2, RemoveVehicleMenu));
            _garageMenu.Add(3, new MenuItem("3. Search for a vehicle", 3, SearchMenu));
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

        private void SearchReg()
        {
            UI.WriteLine("Test");
            UI.Write("Enter registration to search for:");
            string reg = UI.ReadString("Error, Enter registration to seach for: ");
            VehicleBase? vehicle =_handler.SearchReg(reg);
            if (vehicle == null)
                UI.WriteLine("Result: Nothing matched");
            else
                UI.WriteLine($"Result: found {vehicle}");
        }

        private void SearchMenu()
        {
            GarageInfo();
            UI.PrintMenu(_searchMenu);
            int sel = UI.ReadInt("Selection: ", _searchMenu.Count - 1);

            _searchMenu[sel].Caller.Invoke();

        }

        private Action<VehicleType> DosomeThing(VehicleType car)
        {
            throw new NotImplementedException();
        }

        //TODO Registration check. May not be unique.
        private void PopulateRandom()
        {
            int nrOfVehicles = UI.ReadInt("How many vehicles would you like to create and park?:",100,1);

            Random rnd = new Random();
            VehicleBase vehicle = null;

            for (int i = 0; i < nrOfVehicles; i++)
            {
                int sel = rnd.Next(0, 5);
                vehicle = null;

                switch (sel)
                {
                    case 0: vehicle = new Airplane(rnd.Next(1000,10001).ToString(), rnd.Next(Airplane.SEATS_MIN, Airplane.SEATS_MAX+1));
                        break;
                    case 1:
                        vehicle = new Boat(rnd.Next(1000, 10001).ToString(), Convert.ToBoolean(rnd.Next(0,2)));
                        break;
                    case 2:
                        vehicle = new Bus(rnd.Next(1000, 10001).ToString(), Convert.ToBoolean(rnd.Next(0, 2)));
                        break;
                    case 3:
                        //TODO Fix this.
                        vehicle = new Car(rnd.Next(1000, 10001).ToString(), rnd.Next(Car.DOORS_MIN,Car.DOORS_MAX+1));
                        break;
                    case 4:
                        vehicle = new Motorcycle(rnd.Next(1000, 10001).ToString(), rnd.Next(Motorcycle.WHEELS_MIN, Motorcycle.WHEELS_MAX+1));
                        break;
                    default:
                        break;
                }

                bool res = _handler.ParkVehicle(vehicle);
                if (res == true)
                    UI.WriteLine($"The {vehicle.Details()} has been parked.");
                else
                    UI.WriteLine($"The {vehicle.Details()} could NOT be parked.");
            }

            //This will always be zero. Reading and in is jsut for a "pause moment".
            UI.ReadInt("Input 0 to go back:", 0, 0);
            GarageMenu();
        }

        private void ViewVehicles()
        {
            GarageInfo();
            //Initiate counters for vehicletypes with 0 to avoid exceptions
            Dictionary<VehicleType, int>  vehicleCounter = Enum.GetValues<VehicleType>()
                .ToDictionary(key => key, value => 0);

            List<VehicleBase> vehicles = _handler.GetVehicles();

            foreach (var vehicle in vehicles)
            {
                if (!Enum.TryParse<VehicleType>(vehicle.GetType().Name, false, out var tp))
                    throw new NotSupportedException($"Vehicle type '{vehicle.GetType().Name}' is not supported.");

                if (!vehicleCounter.ContainsKey(tp))
                    throw new NotSupportedException($"Vehicle type '{vehicle.GetType().Name}' is not supported.");

                vehicleCounter[tp]++;

                UI.WriteLine($"{vehicles.IndexOf(vehicle) + 1} {vehicle.Details()}");
            }

            UI.WriteLine("");
            //Loop and print out counter for each VehicleType
            Enum.GetValues<VehicleType>()
                .ToList()
                .ForEach(type => UI.WriteLine($"Nr {type}s: {vehicleCounter[type]}"));

            //This will always return 0. So just for a pause effect.
            UI.WriteLine("");
            UI.ReadInt("Enter 0 to go back:", 0, 0);
            GarageMenu();
        }

        //TODO implement a menu back method
        private Action MenuBack()
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
            UI.PrintMenu(_garageMenu);
            int val = UI.ReadInt("Selection: ",_garageMenu.Count-1,0);
            _garageMenu[val].Caller.Invoke();
        }

        private void CreateGarage()
        {
            //UI.CreateGarageMenu();
            int capacity = UI.ReadInt(UI.GARAGE_CREATE_INFO, 1000, 1);
            _handler.CreateGarage(capacity);
        }

        private string GetRegNumber()
        {
            do
            {
                string reg = UI.ReadString("Enter Registration number 1-6 characters:", 6, 1);
                //Check that it is unique.
                if (_handler.IsRegUnique(reg))
                {
                    return reg;
                }
                else
                {
                    UI.WriteLine($"Error, There is already a vehicle with reg={reg}");
                    continue;
                }
            } while(true);
        }

        private void ParkVehicleMenu()
        {
            GarageInfo();
            UI.PrintMenu(_parkMenu);
            UI.WriteLine(_lastMessage);
            _lastMessage = "";
            int val = UI.ReadInt("Selection:",_parkMenu.Count - 1);
            _parkMenu[val].Caller.Invoke();
        }

        private void RemoveVehicleMenu()
        {
            GarageInfo();
            UI.WriteLine("0 Back");
            List<VehicleBase> vehicles = PrintVehicles();
            PrintLastMessage();
            int sel = UI.ReadInt($"Select a vehicle to remove or 0 to go back:", vehicles.Count, 0);
            if (sel == 0)
            {
                GarageMenu();
                return;
            }

            VehicleBase vehicle = _handler.DepartVehicle(vehicles[sel - 1]);
            if (vehicle == null)
                _lastMessage = $"{vehicle} could NOT be removed";
            else
                _lastMessage = $"{vehicle} has been removed";

            RemoveVehicleMenu();
        }

        private void PrintLastMessage()
        {
            if (_lastMessage != "")
            {
                UI.WriteLine(_lastMessage);
                _lastMessage = "";
            }
        }

        private List<VehicleBase> PrintVehicles()
        {
            List<VehicleBase> vehicles = _handler.GetVehicles();
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
            Environment.Exit(0);
        }
    }
}