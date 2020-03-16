using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter08_LinkedLists
{
    public static partial class LinkedListExtensions
    {
        public static ISinglyLinkedListNode<T>? FindFirstOverlappingNode<T>(this ISinglyLinkedList<T> first, ISinglyLinkedList<T>? second)
            where T : IEquatable<T>
        {
            if (second is null) throw new ArgumentNullException(nameof(second));

            var firstLength = first.Count();
            var secondLength = second.Count();
            if (firstLength == 0 || secondLength == 0) return null;

            var lengthDifference = Math.Abs(firstLength - secondLength);

            var longest = firstLength > secondLength ? first : second;
            var shortest = firstLength > secondLength ? second : first;

            var nodeInLongest = longest.Head.AdvanceBy(lengthDifference);
            var nodeInShortest = shortest.Head;

            while (nodeInLongest != null && nodeInShortest != null && !ReferenceEquals(nodeInLongest, nodeInShortest))
            {
                nodeInLongest = nodeInLongest.Next;
                nodeInShortest = nodeInShortest.Next;
            }

            return nodeInLongest;
        }

        private static ISinglyLinkedListNode<T>? AdvanceBy<T>(this ISinglyLinkedListNode<T> node, int steps)
        {
            for (int i = 0; i < steps; i++)
                node = node?.Next;
            return node;
        }

        private static int Count<T>(this ISinglyLinkedList<T> list)
        {
            var count = 0;
            var node = list.Head;
            while (node != null)
            {
                node = node.Next;
                count++;
            }
            return count;
        }
    }
}
