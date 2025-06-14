using LexiconExercise5.Vehicles;

namespace LexiconExercise5.Interfaces
{
    internal interface IGarage<T> where T : class
    {
        T this[int index] { get; set; }

        int Count { get; }

        IEnumerator<T> GetEnumerator();

        void Departing(Vehicle vehicle);

        void Park(Vehicle vehicle);
    }
}