


namespace LexiconExercise5
{
    public static class UI
    {
        const string GARAGE_CREATE_INFO = "Please enter the capacaty of your new garage:";
        const string GARAGE_MENU = @"
        1. Park a vehicle
        2. Remove a vehicle
        3. Populate garage with vehicles
        0. Exit program";

        public static int ReadInt(string errorText, int max = 100, int min = 0)
        {
            do
            {
                int value;
                string? raw = Console.ReadLine();
                if (raw == null)
                    continue;
                if (int.TryParse(raw, out value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        Console.WriteLine(errorText);
                }
                else
                {
                    Console.WriteLine(errorText);
                }
            } while (true);

        }

        public static void CreateGarageMenu()
        {
            Console.WriteLine(GARAGE_CREATE_INFO);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Write(string text)
        {
            Console.Write(text);
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public static string? ReadLine()
        {
            return Console.ReadLine();
        }

        internal static void GarageMenu(Dictionary<int, MenuItem> menu)
        {
            //WriteLine(GARAGE_MENU);
            foreach (var item in menu)
            {
                WriteLine(item.Value.Text);
            }
        }

        internal static string ReadString(string errorText, int max = 100, int min = 0)
        {
            do
            {
                string? input = Console.ReadLine();
                if (input == null)
                    Console.WriteLine(errorText);
                if (input.Length < min || input.Length > max)
                    Console.WriteLine(errorText);
                else
                    return input;
            } while (true);
        }
    }
}