using System;
using System.Collections.Generic;

namespace Problems.Chapter08_LinkedLists
{
    public class Cyklicity2
    {
        public Node<T>? FindCycleStart<T>(Node<T> head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));
            if (head.Next == null) return null;

            var slow = head;
            var fast = head;
            var hasCyckle = false;

            while (fast != null && !hasCyckle)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;

                if (slow == fast)
                    hasCyckle = true;
            }

            if (!hasCyckle) return null;

            var nodesInCycle = new HashSet<Node<T>>();
            do
            {
                nodesInCycle.Add(slow); // last step will try to add fast, and will return false
                slow = slow.Next;

            } while (slow != fast);

            slow = head;
            while (!nodesInCycle.Contains(slow))
            {
                slow = slow.Next;
            }
            return slow;
        }
    }
}
