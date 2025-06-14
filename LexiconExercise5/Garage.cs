using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace LexiconExercise5
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : class
    {
        private T[] _items;
        private int currIndex = 0;
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public Garage(int size)
        {
            _items = new T[size];
            Count = size;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i] != null)
                    yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Departing(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));
        }

        public void Park(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));

            //Todo: Check this
            if (CanVehicleFit(vehicle))
            {
                _items[currIndex] = (T)(object)vehicle;
                currIndex++;
                Count -= vehicle.UnitSize;
            }

        }

        private bool CanVehicleFit(Vehicle vehicle) => vehicle.UnitSize < Count;
    }
}