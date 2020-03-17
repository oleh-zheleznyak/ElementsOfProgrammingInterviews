using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter09_Stacks
{
    public class StackWithMax<T> : IReadOnlyCollection<T>
        where T : notnull, IComparable<T>
    {
        private readonly Stack<T> mainStorage;
        private readonly Stack<T> maxStorage;
        private readonly IComparer<T> comparer = Comparer<T>.Default;

        public StackWithMax()
        {
            mainStorage = new Stack<T>();
            maxStorage = new Stack<T>();
        }
        public StackWithMax(IReadOnlyCollection<T> collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));

            mainStorage = new Stack<T>(collection.Count);
            maxStorage = new Stack<T>(collection.Count);

            foreach (var item in collection)
                Push(item);
        }

        public int Count => mainStorage.Count;

        public T Max => maxStorage.Peek();

        public void Push(T value)
        {
            if (mainStorage.Count == 0)
            {
                mainStorage.Push(value);
                maxStorage.Push(value);
            }
            else
            {
                var currentMax = maxStorage.Peek();
                var newMax = comparer.Compare(value, currentMax) < 0 ? currentMax : value;

                mainStorage.Push(value);
                maxStorage.Push(newMax);
            }
        }

        public T Peek() => mainStorage.Peek();

        public T Pop()
        {
            maxStorage.Pop();
            return mainStorage.Pop();
        }

        public IEnumerator<T> GetEnumerator() => mainStorage.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}