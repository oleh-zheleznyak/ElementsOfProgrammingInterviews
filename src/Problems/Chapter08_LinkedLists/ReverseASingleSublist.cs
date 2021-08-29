using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter08_LinkedLists
{
    public class ReverseASingleSublist
    {
        public Node<T> ReverseSublistBetweenIndices<T>(Node<T> node, int start, int end)
        {
            if (node is null) throw new ArgumentNullException(nameof(node));
            if (start > end) throw new ArgumentException($"{nameof(start)}>{nameof(end)}");
            if (start < 1) throw new ArgumentOutOfRangeException(nameof(start));

            if (node.Next is null) return node;
            if (start == end) return node;

            return ReverseSublistBetweenIndices_BookImpl(node, start, end);
        }

        private Node<T> ReverseSublistBetweenIndices_Impl<T>(Node<T> node, int start, int end)
        {
            Node<T>? prev = null, next, before_start, at_start, current = node;

            // move to start position
            for (int i = 1; i < start; i++)
            {
                prev = current;
                current = current.Next;
            }
            before_start = prev;
            at_start = current;

            prev = current;
            current = current.Next;

            for (int j = start + 1; j <= end; j++)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            at_start.Next = current;
            if (before_start != null)
            {
                before_start.Next = prev;
                return node;
            }
            return prev;
        }

        private Node<T> ReverseSublistBetweenIndices_BookImpl<T>(Node<T> node, int start, int end)
        {
            var dummyHead = new Node<T>(default, node); // 11->3->5->7->2
            var sublistHead = dummyHead;
            int k = 1;
            while (k++ < start) sublistHead = sublistHead.Next;

            var sublistIter = sublistHead.Next;

            while(start++<end)
            {
                var temp = sublistIter.Next; // 5                               // 7
                sublistIter.Next = temp.Next; // 11->3 (->7) 5 ->7->2           // 11->5->3 (->2) 7->2
                temp.Next = sublistHead.Next; // 11->3 (->7) 5 (->3) 7->2       // 11->5->3 (->2) 7 (->5) 2
                sublistHead.Next = temp;    // 11 (->5) 3 (->7) 5 (->3) 7->2 // 11->5->3->7->2 // 11(->7)  5->3 (->2) 7 (->5) 2 // 11->7->5->3->2
            }
            return dummyHead.Next;
        }
    }
}
