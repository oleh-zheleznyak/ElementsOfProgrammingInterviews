using System;
using System.Collections.Generic;

namespace Problems.Chapter08_LinkedLists
{
    public class MergeTwoSortedLists2
    {
        public Node<T> MergeSorted<T>(Node<T> list1, Node<T> list2, IComparer<T>? comparer = null)
            where T : struct, IComparable<T>
        {
            if (list1 is null) throw new ArgumentNullException(nameof(list1));
            if (list2 is null) throw new ArgumentNullException(nameof(list2));
            if (list1 == list2) return list1;
            comparer ??= Comparer<T>.Default;

            var dummyHead = new Node<T>(default);
            var current = dummyHead;

            do
            {
                current.Next = GetSmallerAndAdvance(comparer, ref list1, ref list2);
                current = current.Next;
            }
            while (list1 is not null && list2 is not null);

            current.Next = list1 ?? list2;

            return dummyHead.Next;

        }

        private static Node<T> GetSmallerAndAdvance<T>(IComparer<T> comparer, ref Node<T> node1, ref Node<T> node2) where T : struct, IComparable<T>
        {
            Node<T> smaller;
            var comparison = comparer.Compare(node1.Value, node2.Value);
            if (comparison < 0)
            {
                smaller = node1;
                node1 = node1.Next;
            }
            else
            {
                smaller = node2;
                node2 = node2.Next;
            }
            return smaller;
        }
    }
}
