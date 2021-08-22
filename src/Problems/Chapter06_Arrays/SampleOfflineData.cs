using System;

namespace Problems.Chapter06_Arrays
{
    /// <summary>
    /// 6.11 Sample offline data
    /// </summary>
    public class SampleOfflineData<T>
    {
        /// <summary>
        /// Selects a random sample from input array. Every subset is equally likely
        /// Mutates input array in place, to keep algorithm O(1) in terms of memory
        /// </summary>
        /// <param name="elements">collection of elements to select a sample from. Know to be unique</param>
        /// <param name="sampleSize">size of the sample</param>
        public void Sample(T[] elements, int sampleSize)
        {
            if (elements is null) throw new ArgumentNullException(nameof(elements));
            if (sampleSize < 0 || sampleSize > elements.Length) throw new ArgumentException(nameof(sampleSize));
            if (sampleSize == 0) return;

            var random = new Random();
            for (int i = 0; i < sampleSize; i++)
            {
                var index = random.Next(i, elements.Length - i);
                elements.Swap(i, index);
            }
        }
    }
}
