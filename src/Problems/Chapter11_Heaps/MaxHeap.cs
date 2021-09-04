using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Problems.Chapter11_Heaps
{
    public class MaxHeap<T>
        where T : notnull, IComparable<T>
    {
        private T[] storage;
        private int elementCount;
        private IComparer<T> comparer = Comparer<T>.Default;

        public MaxHeap()
        {
            storage = new T[1];
            elementCount = 0;
        }

        public MaxHeap(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            storage = new T[array.Length];
            Array.Copy(array, storage, array.Length);
            elementCount = array.Length;

            var nonLeaf = array.Length / 2 - 1;
            for (int i = nonLeaf; i >= 0; i--)
                MaxHeapify(i);
        }

        public void Push(T value)
        {
            storage[elementCount] = value;
            storage.Swap(0, elementCount++);
            MaxHeapify(0);
        }
        public T Peek()
        {
            EnsureNotEmpty();
            return storage[0];
        }

        public T Pop()
        {
            EnsureNotEmpty();
            var max = storage[0];
            storage[0] = storage[--elementCount];
            MaxHeapify(0);

            return max;
        }

        private void MaxHeapify(int index)
        {
            var left = MaxHeap<T>.LeftChild(index);
            var right = MaxHeap<T>.RightChild(index);
            var largest = index;

            if (left < elementCount && Compare(index, left) < 0) largest = left;
            if (right < elementCount && Compare(largest, right) < 0) largest = right;

            if (largest != index)
            {
                storage.Swap(largest,index);
                MaxHeapify(largest);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int Compare(int i, int j) => comparer.Compare(storage[i], storage[j]);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int LeftChild(int i) => i << 1 | 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int RightChild(int i) => 2 * i + 2; // TODO: how to optimize?

        public int Count => elementCount;

        private void EnsureNotEmpty()
        {
            if (storage.Length == 0) throw new InvalidOperationException("Heap is empty");
        }
    }
}
