using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems.Chapter08_LinkedLists
{
    public class Node<T> : IEnumerable<T>
    {
        public Node(T value, Node<T>? next = null)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            var node = Next;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class MergeTwoSortedLists2
    {
        public Node<T> MergeSorted<T>(Node<T> list1, Node<T> list2, IComparer<T>? comparer = null)
            where T : struct, IComparable<T>
        {
            if (list1 is null) throw new ArgumentNullException(nameof(list1));
            if (list2 is null) throw new ArgumentNullException(nameof(list2));
            if (list1 == list2) return list1;
            comparer ??= Comparer<T>.Default;

            var node1 = list1;
            var node2 = list2;

            Node<T> head = GetSmallerAndAdvance(comparer, ref node1, ref node2);
            Node<T> current = head;

            do
            {
                current.Next = GetSmallerAndAdvance(comparer, ref node1, ref node2);
                current = current.Next;
            }
            while (node1 is not null || node2 is not null);

            return head;

        }

        private static Node<T> GetSmallerAndAdvance<T>(IComparer<T> comparer, ref Node<T> node1, ref Node<T> node2) where T : struct, IComparable<T>
        {
            Node<T> smaller;
            if (node1 is not null && node2 is not null)
            {
                var comparison = comparer.Compare(node1.Value, node2.Value);
                if (comparison < 0)
                {
                    smaller = node1;
                    node1 = node1.Next;
                }
                else if (comparison > 0)
                {
                    smaller = node2;
                    node2 = node2.Next;
                }
                else
                {
                    smaller = node1;
                    node1 = node1.Next;
                }
            }
            else if (node1 is not null)
            {
                smaller = node1;
                node1 = node1.Next;
            }
            else if (node2 is not null)
            {
                smaller = node2;
                node2 = node2.Next;
            }
            else
            {
                throw new InvalidOperationException("cannot find bigger of two null values");
            }
            return smaller;
        }
    }
}
