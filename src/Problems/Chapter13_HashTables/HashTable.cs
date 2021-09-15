using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter13_HashTables
{
    /// <summary>
    /// Generic hash table.
    /// Use Dictionary<typeparamref name="TKey"/><typeparamref name="TValue"/> instead!
    /// This is just for practice, exercise and fun!
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class HashTable<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey,TValue>>
        where TKey : IEquatable<TKey>
    {
        public HashTable()
        {
            count = 0;
            storage = new LinkedList<KeyValuePair<TKey, TValue>>[3];
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => GetEnumeratorOf(storage);

        private IEnumerator<KeyValuePair<TKey, TValue>> GetEnumeratorOf(LinkedList<KeyValuePair<TKey, TValue>>[] array)
        {
            foreach (var linkedList in array)
            {
                if (linkedList == null) continue;
                foreach (var keyValue in linkedList)
                {
                    yield return keyValue;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => count;
        public bool IsReadOnly { get; }

        public void Add(TKey key, TValue value)
        {
            EnsureKeyNotNull(key);
            var hashCode = key.GetHashCode();
            var slotIndex = getSlotIndex(hashCode);
            AddToSlot(slotIndex, key, value);
        }

        private static void EnsureKeyNotNull(TKey key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));
        }


        /// <summary>
        /// NOTE: the linked list implementation is only good enough for a CS textbook
        /// In practice, however, such a linked list is too "allocatey"
        /// An additional object is allocated for each linked list, and for EVERY node in it
        /// FOr this reason Dictionary uses an array for this, with linked list nodes implemented as structs
        /// </summary>
        private LinkedList<KeyValuePair<TKey, TValue>>[] storage;

        private void AddToSlot(int slotIndex, TKey key, TValue value)
        {
            EnsureCapacity();

            var linkedList = storage[slotIndex];
            if (linkedList == null)
            {
                storage[slotIndex] = new LinkedList<KeyValuePair<TKey, TValue>>();
                storage[slotIndex].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                foreach (var keyValuePair in linkedList)
                {
                    if (key.Equals(keyValuePair.Key)) throw new ArgumentException("Key already present", nameof(key));
                }

                linkedList.AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        private void EnsureCapacity()
        {
            if (FillFactor() < 1) return;
            var newStorageSize = GetNextStorageSize();
            var newStorage = new LinkedList<KeyValuePair<TKey, TValue>>[newStorageSize];

            var tempStorage = storage;
            storage = newStorage;

            var enumerator = GetEnumeratorOf(tempStorage);
            while (enumerator.MoveNext())
            {
                var keyValue = enumerator.Current;
                Add(keyValue.Key, keyValue.Value);
            }
        }

        public static readonly int[] Primes = new int[] {3, 7, 11, 23, 41, 83, 167, 313, 631, 1277, 2569, 5099};

        private int GetNextStorageSize()
        {
            var index = Array.BinarySearch(Primes, storage.Length);
            var newSize =
                index + 1 < Primes.Length ? Primes[index + 1] : Primes[Primes.Length - 1] * 3; // how to do this better?
            return newSize;
        }

        private double FillFactor() => count / (double) storage.Length;

        private int count;

        private int getSlotIndex(int hashCode)
        {
            var value = hashCode % storage.Length;
            return value >= 0 ? value : value + storage.Length;
        }

        public bool ContainsKey(TKey key) => TryGetValue(key, out var _);

        public bool Remove(TKey key)
        {
            EnsureKeyNotNull(key);
            if (!TryFind(key, out var linkedList, out var node)) return false;
            linkedList.Remove(node);
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            EnsureKeyNotNull(key);
            value = default;
            if (!TryFind(key, out var linkedList, out var node)) return false;
            value = node.Value.Value;
            return true;
        }

        private bool TryFind(TKey key, out LinkedList<KeyValuePair<TKey,TValue>> linkedList, out LinkedListNode<KeyValuePair<TKey,TValue>> node)
        {
            EnsureKeyNotNull(key);
            var slotIndex = getSlotIndex(key.GetHashCode());
            linkedList = storage[slotIndex];
            node = default;
            if (linkedList is null) return false;
            var current = linkedList.First;
            while (current!=null)
            {
                var keyValuePair = current.Value;
                if (key.Equals(keyValuePair.Key))
                {
                    node = current;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}