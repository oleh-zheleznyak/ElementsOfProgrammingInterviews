﻿using System;
using System.Collections.Generic;

namespace Problems.Chapter06_Arrays
{
    /// <summary>
    /// 6.1 Dutch National Flag Problem
    /// </summary>
    public class DutchNationalFlagPartition
    {
        public void Partition<T>(T[] data, int pivotIndex, IComparer<T>? comparerImpl = null)
            where T : struct, IComparable<T>
        {
            if (data is null) throw new ArgumentNullException(nameof(data));
            if (data.Length == 0) return;
            if (pivotIndex < 0 || pivotIndex > data.Length - 1) throw new ArgumentOutOfRangeException(nameof(pivotIndex));

            var comparer = comparerImpl ?? Comparer<T>.Default;

            var pivot = data[pivotIndex];
            var smaller = 0;
            var greater = data.Length - 1;

            data.Swap(smaller, pivotIndex);

            var i = 1;
            while (i <= greater)
            {
                var compared = comparer.Compare(data[i], pivot);
                if (compared < 0) // data[i] < pivot
                {
                    data.Swap(smaller, i);
                    smaller++;
                    i++;
                }
                else if (compared > 0) // data[i] > pivot
                {
                    data.Swap(greater, i);
                    greater--;
                }
                else // data[i] == pivot
                {
                    i++;
                }
            }

        }
    }
}
