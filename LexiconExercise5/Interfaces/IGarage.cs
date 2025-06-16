using LexiconExercise5.Vehicles;

namespace LexiconExercise5.Interfaces
{
    //internal interface IGarage<T> where T : class
    internal interface IGarage<T> where T : Vehicle
    {
        T this[int index] { get; set; }

        int Count { get; }

        IEnumerator<T> GetEnumerator();

        //void Departing(Vehicle vehicle);
        void Departing(T vehicle);

        //void Park(Vehicle vehicle);
        void Park(T vehicle);
    }
}