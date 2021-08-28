using Problems.Chapter08_LinkedLists;
using System;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public static class TestHelpers
    {
        public static Node<T> ToSinglyLinkedList<T>(params T[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) throw new ArgumentException("Cannot convert empty array to Linked List", nameof(array));

            var dummyHead = new Node<T>(default);
            var current = dummyHead;
            for (int i = 0; i < array.Length; i++)
            {
                current.Next = new Node<T>(array[i]);
                current = current.Next;
            }
            return dummyHead.Next;
        }
    }
}
