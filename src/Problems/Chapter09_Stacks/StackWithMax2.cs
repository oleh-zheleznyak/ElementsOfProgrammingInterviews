using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter09_Stacks
{
    public class StackWithMax2<T>
        where T : IComparable<T>
    {
        private const int InitialStorageSize = 1;

        public StackWithMax2(IComparer<T> comparer) => this.comparer = comparer;

        public StackWithMax2() : this(Comparer<T>.Default) { }

        private readonly IComparer<T> comparer;
        private ValueTuple<T, T>[] storage = new ValueTuple<T, T>[InitialStorageSize];
        private int elementCount = 0;

        private void EnsureEnoughStorage()
        {
            if (elementCount == storage.Length)
            {
                var newStorageSize = GetNewStorageSize(storage.Length);
                var newStorage = new ValueTuple<T, T>[newStorageSize];
                Array.Copy(storage, newStorage, storage.Length);
                storage = newStorage;
            }
        }

        private int GetNewStorageSize(int currentStorageSize) => currentStorageSize * 2;

        public void Push(T value)
        {
            EnsureEnoughStorage();
            T newMax;
            if (elementCount == 0) newMax = value;
            else
            {
                var (_, max) = storage[elementCount - 1];
                newMax = comparer.Compare(value, max) < 0 ? max : value;
            }
            storage[elementCount++] = (value, newMax);
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return storage[elementCount - 1].Item1;
        }

        private void EnsureNotEmpty()
        {
            if (elementCount == 0) throw new InvalidOperationException("Stack is empty");
        }

        public T Pop()
        {
            EnsureNotEmpty();
            return storage[--elementCount].Item1;

        }

        public T Max()
        {
            EnsureNotEmpty();
            return storage[elementCount - 1].Item2;
        }
    }
}
