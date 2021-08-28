using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter08_LinkedLists
{
    public class ReverseASingleSublist
    {
        public void ReverseSublistBetweenIndices<T>(Node<T> node, int start, int end)
        {
            if (node is null) throw new ArgumentNullException(nameof(node));
            if (start > end) throw new ArgumentException($"{nameof(start)}>{nameof(end)}");

            if (node.Next is null) return;
            if (start == end) return;

            var current = node;
            var prev = node;
            for (int i = 1; i < start; i++)
            {
                if (current is null) throw new ArgumentOutOfRangeException(nameof(start));
                prev = current;
                current = current.Next;
            }

            for (int j = start; j <= end - start + 1; j++)
            {
                if (current is null) throw new ArgumentOutOfRangeException(nameof(end));
                var tmp = current.Next;

                prev.Next = current.Next;
                current.Next = tmp.Next;
                tmp.Next = current;

                prev = tmp;
                current = tmp.Next;
            }
        }
    }
}
