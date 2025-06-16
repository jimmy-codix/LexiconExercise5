using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace LexiconExercise5
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : Vehicle
    {
        private readonly T[] _items;
        private int currIndex = 0;
        public int Capacity { get; private set; }
        public int FreeCapacity { get; private set; }
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
            Capacity = size;
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

        /*
        public void Departing(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle, nameof(vehicle));
        }
        */

        public void Park(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            //Todo: Check this
            if (CanVehicleFit(item))
            {
                //_items[currIndex] = (T)(object)vehicle;
                _items[currIndex] = item;
                currIndex++;
                Count -= item.UnitSize;
            }



        }

        private bool CanVehicleFit(Vehicle vehicle) => vehicle.UnitSize < Count;

        public void Departing(T vehicle)
        {
            throw new NotImplementedException();
        }
    }
}