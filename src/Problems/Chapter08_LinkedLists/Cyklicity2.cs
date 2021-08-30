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

            // detect cycle
            while (fast != null && !hasCyckle)
            {
                slow = slow.Next;
                fast = fast.Next?.Next;

                if (slow == fast)
                    hasCyckle = true;
            }
            if (!hasCyckle) return null;

            // measure cycle length C
            var cycleLength = 0;
            do
            {
                slow = slow.Next;
                cycleLength++;
            }
            while (slow != fast);

            // two iterators cycle length C apart
            slow = head;
            fast = head;
            for (int i = 0; i < cycleLength; i++) fast = fast.Next;

            // advance in tandem to meet at cycle start
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow;
        }
    }
}
