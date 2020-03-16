using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter08_LinkedLists
{
    public static partial class LinkedListExtensions
    {
        public static SinglyLinkedList<T> MergeSortedAscending<T>(this SinglyLinkedList<T> first, SinglyLinkedList<T>? second)
            where T : IEquatable<T>, IComparable<T>
            => MergeSortedAscending(first, second, Comparer<T>.Default);

        public static SinglyLinkedList<T> MergeSortedAscending<T>(this SinglyLinkedList<T> first, SinglyLinkedList<T>? second, IComparer<T>? comparer)
            where T : IEquatable<T>
        {
            if (comparer is null) throw new ArgumentNullException(nameof(comparer));

            return MergeSortedAscending(first, second, (x, y) => comparer.Compare(x, y));
        }

        public static SinglyLinkedList<T> MergeSortedAscending<T>(this SinglyLinkedList<T> first, SinglyLinkedList<T>? second, Comparison<T> comparison)
            where T : IEquatable<T>
        {
            if (second is null) throw new ArgumentNullException(nameof(second));
            if (comparison is null) throw new ArgumentNullException(nameof(comparison));

            var merged = new SinglyLinkedList<T>();

            var firstCurrent = first.Head;
            var secondCurrent = second.Head;

            while (firstCurrent != null && secondCurrent != null)
            {
                if (comparison(firstCurrent.Value, secondCurrent.Value) <= 0)
                {
                    merged.Add(firstCurrent.Value);
                    firstCurrent = firstCurrent.Next;
                }
                else
                {
                    merged.Add(secondCurrent.Value);
                    secondCurrent = secondCurrent.Next;
                }
            }

            while (firstCurrent != null)
            {
                merged.Add(firstCurrent.Value);
                firstCurrent = firstCurrent.Next;
            }

            while (secondCurrent != null)
            {
                merged.Add(secondCurrent.Value);
                secondCurrent = secondCurrent.Next;
            }

            return merged;
        }
    }
}
