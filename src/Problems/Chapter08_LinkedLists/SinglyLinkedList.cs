using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problems.Chapter08_LinkedLists
{
    public class SinglyLinkedList<T> : ICollection<T>
        where T : IEquatable<T>
    {
        public SinglyLinkedList() { }

        public SinglyLinkedList(IReadOnlyCollection<T> collection)
        {
            if (collection is null) throw new ArgumentNullException(nameof(collection));

            Node current = null;
            Node previous = null;

            foreach (var element in collection)
            {
                current = new Node(element);

                if (previous is null)
                {
                    Head = current;
                }
                else
                {
                    previous.Next = current;
                }

                previous = current;
            }
            Tail = current;
            Count = collection.Count;
        }

        public Node? Head { get; set; }
        public Node? Tail { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            var node = new Node() { Value = item };
            if (Tail is null) // count == 0
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item) => ((IEnumerable<T>)this).Contains(item);

        public void CopyTo(T[]? array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex >= array.Length) throw new ArgumentException(nameof(arrayIndex));
            if (arrayIndex + Count > array.Length) throw new ArgumentException("Linked list contents won't fit into the array");

            foreach (var item in this)
                array[arrayIndex++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (Count == 0) return false;

            var comparer = EqualityComparer<T>.Default;

            Node? current = Head;
            Node? previous = null;

            while (current != null)
            {
                if (comparer.Equals(item, current.Value))
                {
                    if (previous is null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    Count--;
                    return true;
                }


                previous = current;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();

        public class Node
        {
            public Node() { }

            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
