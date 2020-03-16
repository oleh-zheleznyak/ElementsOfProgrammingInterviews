using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter08_LinkedLists
{
    public static partial class LinkedListExtensions
    {
        public static ISinglyLinkedListNode<T>? FindFirstNodeInCycle<T>(this ISinglyLinkedList<T> linkedList)
            where T : IEquatable<T>
        {
            if (linkedList.Head is null) return null;

            var slow = linkedList.Head;
            var fast = linkedList.Head;

            while (fast != null)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;

                // 1 -> 2 -> 1

                if (ReferenceEquals(slow, fast))
                {
                    var cycleLenght = 0;
                    do
                    {
                        slow = slow.Next;
                        cycleLenght++;
                    }
                    while (!ReferenceEquals(slow, fast));

                    slow = linkedList.Head;
                    fast = linkedList.Head;
                    for (int i = 0; i < cycleLenght; i++)
                        slow = slow.Next;

                    while (!ReferenceEquals(slow, fast))
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }

                    return slow;
                }
            }
            return null;
        }
    }
}
