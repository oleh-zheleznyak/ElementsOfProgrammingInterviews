using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Xsl;
using Problems.Chapter11_Heaps;

namespace Problems.Chapter12_Searching
{
    /// <summary>
    /// Find the kth largest element
    /// Assume entries are distinct 
    /// </summary>
    public class FindKthLargestElement<T>
        where T : IComparable<T>
    {
        private Random random = new Random();
        private IComparer<T> comparer = Comparer<T>.Default;
        public T findKthLargestElement(int k, T[] input) // 123
        {
            if (input is null) throw new ArgumentNullException(nameof(input));
            if (k < 1) throw new ArgumentException("k has to be > 1");
            if (input.Length < k) throw new ArgumentException("k has to be smaller then the size of input array");

            var left = 0; //0
            var right = input.Length - 1; //2
            var newIndex = -1;
            while (left < right)
            {
                var randomIndex = random.Next(left, right + 1); // 1
                newIndex = Partition(randomIndex, left, right, input);
                if (newIndex == k - 1) return input[k - 1];
                if (newIndex < k - 1)
                    left = newIndex + 1;
                else
                    right = newIndex-1;
            }
            return input[left]; // verify
        }

        private int Partition(int randomIndex, int left, int right, T[] input)
        {
            var partitionValue = input[randomIndex]; //2
            var newIndex = left;
            input.Swap(randomIndex,right); // 132

            for (var i = left; i <= right; i++)
            {
                if (comparer.Compare(partitionValue, input[i])<0)//  input[i] > partitionValue
                    input.Swap(newIndex++,i);
            }
            input.Swap(newIndex,right);
            
            return newIndex;
        }
    }
}