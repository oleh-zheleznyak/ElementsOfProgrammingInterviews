using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter11_Heaps
{
    public class MergeSortedFiles<T>
        where T : IComparable<T>
    {
        /// <remarks>
        /// One might argue that to adhere to C# method signature should use IEnumerable or IReadonlyCollection
        /// To sort the elements, we need to consume the whole sequence, however, so concept of "lazyness" is not applicable
        /// </remarks>
        public IEnumerable<T> MergeSortedSequences(T[][] sequences)
        {
            if (sequences == null) throw new ArgumentNullException(nameof(sequences));
            if (sequences.Length == 0) yield break;

            var comparer = new IteratorComparer(sequences, Comparer<T>.Default);
            var maxHeap = new MaxHeap<(int Next, int Index)>((ushort)sequences.Length, comparer);


            for (int i = 0; i < sequences.Length; i++)
            {
                if (sequences[i] != null && sequences[i].Length > 0)
                {
                    maxHeap.Push((Next: 0, Index: i));
                }
            }

            while (maxHeap.Count > 0)
            {
                var max = maxHeap.Pop();
                yield return sequences[max.Index][max.Next];

                if (max.Next + 1 < sequences[max.Index].Length)
                    maxHeap.Push((max.Next + 1, max.Index));
            }
        }

        private class IteratorComparer : IComparer<(int Next, int Index)>
        {
            private readonly T[][] valuesLookup;
            private readonly IComparer<T> comparer;

            public IteratorComparer(T[][] valuesLookup, IComparer<T> comparer)
            {
                this.valuesLookup = valuesLookup;
                this.comparer = comparer;
            }

            public int Compare((int Next, int Index) x, (int Next, int Index) y)
            {
                var value_x = valuesLookup[x.Index][x.Next];
                var value_y = valuesLookup[y.Index][y.Next];

                return comparer.Compare(value_x, value_y);
            }
        }
    }
}
