using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Chapter09_Stacks
{
    /// <summary>
    /// Queue that uses an array as a backing store, with a "wrap-around"
    /// </summary>
    /// <remarks>
    /// Same idea as in https://github.com/microsoft/referencesource/blob/master/System/compmod/system/collections/generic/queue.cs
    /// </remarks>
    /// <see cref="System.Collections.Generic.Queue{T}"/>
    public class CircularQueue<T> : IReadOnlyCollection<T>
    {
        public CircularQueue() : this(DefaultCapacity) { }

        public CircularQueue(IReadOnlyCollection<T> collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));
            if (collection.Count == 0) return;

            storage = collection.ToArray();
            head = 0;
            tail = storage.Length - 1;
            count = storage.Length;
        }

        public CircularQueue(int capacity = DefaultCapacity)
        {
            storage = new T[capacity];
            head = 0;
            tail = 0;
            count = 0;
        }

        private T[] storage;

        private int head;
        private int tail;
        private int count;

        const int DefaultCapacity = 4;
        const int DefaultGrowthFactor = 2;

        public int Count => count;

        public void Enqueue(T value)
        {
            GrowCollectionIfNeeded();

            tail = (tail + 1) % storage.Length;
            count++;

            storage[tail] = value;
        }

        private void GrowCollectionIfNeeded()
        {
            if (count < storage.Length) return;

            var newStorage = new T[storage.Length * DefaultGrowthFactor];

            if (head < tail)
                storage.CopyTo(newStorage, 0);
            else
            {
                Array.Copy(storage, head, newStorage, 0, count - head);
                Array.Copy(storage, 0, newStorage, count - head + 1, tail);

                head = 0;
                tail = count - 1;
            }
            storage = newStorage;
        }

        public T Dequeue()
        {
            if (count == 0) throw new InvalidOperationException("Queue is empty");

            var value = storage[head];

            count--;
            head = (head + 1) % storage.Length;

            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = head; i <= (tail < head ? storage.Length - 1 : tail); i++)
                yield return storage[i];

            if (tail < head)
                for (var i = 0; i <= tail; i++)
                    yield return storage[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
