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
        /// This is as required in the task, but not at all C#-ish, signature should use IEnumerable or IReadonlyCollection
        /// </remarks>
        public IEnumerable<T> MergeSortedSequences(T[][] sequences)
        {
            if (sequences == null) throw new ArgumentNullException(nameof(sequences));
            if (sequences.Length == 0) return Array.Empty<T>();
            if (sequences.Length == 1) return sequences[0];

            var maxHeap = new MaxHeap<T>(sequences[0]);

            for (int i = 1; i < sequences.Length; i++)
            {
                for (int j = 0; j < sequences[i].Length; j++)
                {
                    maxHeap.Push(sequences[i][j]);
                }
            }

            return maxHeap.Sort();
        }
    }
}
