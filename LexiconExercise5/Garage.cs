using LexiconExercise5.Interfaces;
using System.Collections;

namespace LexiconExercise5
{
    internal class Garage<T> : IGarage<T>, IEnumerable<T> where T : class
    {
        private T[] _items;
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
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}