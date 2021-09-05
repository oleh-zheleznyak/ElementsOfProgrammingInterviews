using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter11_Heaps
{
    public class ComputeKClosestStars<T>
        where T : notnull, IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public ComputeKClosestStars(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public IReadOnlyCollection<T> ComputeKClosestDataPoints(byte K, IReadOnlyList<T> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (K > data.Count) throw new ArgumentException("Cluster size greater then the sample size");

            if (K == byte.MinValue) return Array.Empty<T>();

            var maxHeap = new MaxHeap<T>(data.Take(K).ToArray(), comparer);

            for (int i = K; i < data.Count; i++)
            {
                maxHeap.Push(data[i]);
                maxHeap.Pop();
            }

            return maxHeap;
        }
    }
}
