using LexiconExercise5.Vehicles;

namespace LexiconExercise5.Interfaces
{
    //internal interface IGarage<T> where T : class
    internal interface IGarage<T> where T : VehicleBase
    {
        T this[int index] { get; set; }

        int Count { get; }

        IEnumerator<T> GetEnumerator();

        //void Departing(Vehicle vehicle);
        T? Depart(T vehicle);

        //void Park(Vehicle vehicle);
        bool Park(T vehicle);
    }


}