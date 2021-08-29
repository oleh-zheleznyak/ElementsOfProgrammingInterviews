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

            return ReverseSublistBetweenIndices_Impl(node, start, end);
        }

        private Node<T> ReverseSublistBetweenIndices_Impl<T>(Node<T> node, int start, int end)
        {
            var dummyHead = new Node<T>(default, node);
            var sublistStart = dummyHead;

            for (int i = 1; i < start; i++) sublistStart = sublistStart.Next;
            var iterator = sublistStart.Next;

            for (int j = start; j < end; j++)
            {
                var temp = iterator.Next;
                iterator.Next = temp.Next;
                temp.Next = sublistStart.Next;
                sublistStart.Next = temp;

            }
            return dummyHead.Next;
        }
    }
}
