using LexiconExercise5.Vehicles;
using LexiconExercise5.Interfaces;

namespace LexiconExercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mgr = new Manager();
            var ui = new UI();
            var handler = new Handler();
            IGarage<Vehicle> grg = new Garage<Vehicle>(10);
            int a = grg.Count;
            Console.WriteLine(a.ToString());
            Vehicle bt = new Boat();
            grg.Park(bt);
            foreach (var item in grg)
            {
                Console.WriteLine($"Nummer {item.UnitSize}");
            }
            Console.WriteLine(grg.Count.ToString());
        }
    }
}
