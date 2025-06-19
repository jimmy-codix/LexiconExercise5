namespace LexiconExercise5.UserInterface
{
    public static class UI
    {
        public const string GARAGE_CREATE_INFO = "Please enter the capacaty of your new garage:";
        const string GARAGE_MENU = @"
        1. Park a vehicle
        2. Remove a vehicle
        3. Populate garage with vehicles
        0. Exit program";

        public static int ReadInt(string text, int max = 100, int min = 0)
        {
            text = text.Trim() + " ";
            string errorText = $"Error, valid inputs are numbers ({min}-{max}), {text}";
            Write(text);
            do
            {
                int value;
                string? raw = Console.ReadLine();

                if (raw == null)
                {
                    Write(errorText);
                    continue;
                }

                if (int.TryParse(raw, out value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        Write(errorText);
                }
                else
                {
                        Write(errorText);
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

        internal static void PrintMenu(Dictionary<int, MenuItem> menu)
        {
            foreach (var item in menu)
            {
                WriteLine(item.Value.Text);
            }
        }

        internal static string ReadString(string text, int max = 100, int min = 0)
        {
            text = text.Trim() + " ";
            string errorText = $"Error, valid inputs are numbers ({min}-{max}), {text}";
            Write(text);
            do
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Write(errorText);
                    continue;
                }
                
                if (input.Length < min || input.Length > max)
                    Write(errorText);
                else
                    return input;

            } while (true);
        }
    }
}