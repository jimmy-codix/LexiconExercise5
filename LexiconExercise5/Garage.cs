using LexiconExercise5.Interfaces;
using LexiconExercise5.Vehicles;
using System.Collections;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace LexiconExercise5
{
    public class Garage<T> : IGarage<T>, IEnumerable<T> where T : VehicleBase
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
            if (size < 0)
                throw new IndexOutOfRangeException();
            _items = new T[size];
            Capacity = size;
            FreeCapacity = size;
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

        //TODO: Better validating
        public bool Park(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            if (!CanVehicleFit(item))
                return false;

            //Find first null to insert vehicle
            int index = Array.IndexOf(_items, null);
            if (index < 0)
                return false;

            _items[index] = item;
            FreeCapacity--;

            return true;
        }

        private bool CanVehicleFit(T vehicle) => vehicle.UnitSize <= FreeCapacity;

        public T? Depart(T item)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == item)
                {
                    _items[i] = null!;
                    FreeCapacity++;
                    return item;
                }
            }

            return null;
        }
    }
}