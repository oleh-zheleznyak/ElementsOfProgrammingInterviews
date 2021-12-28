using System;
using System.Collections.Generic;

namespace Problems
{
    public static class ExtensionMethods
    {
        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (i<0 || i>=list.Count) throw new ArgumentOutOfRangeException(nameof(i));
            if (j<0 || j>=list.Count) throw new ArgumentOutOfRangeException(nameof(j));

            if (i == j) return;

            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
