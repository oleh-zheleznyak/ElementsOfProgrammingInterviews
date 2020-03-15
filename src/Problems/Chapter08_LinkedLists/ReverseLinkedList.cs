using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter08_LinkedLists
{
    public static class LinkedListExtensions
    {
        public static void Reverse<T>(this SinglyLinkedList<T> list)
            where T : IEquatable<T>
        {
            if (list.Count == 0) return;

            var current = list.Head;
            list.Tail = current;
            SinglyLinkedList<T>.Node previous = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }

            list.Head = previous;
        }
    }
}
