using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public static class ExtensionMethods
    {
        public static void Swap<T>(this IList<T> collection, int i, int j)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (i<0 || i>=collection.Count) throw new ArgumentOutOfRangeException(nameof(i));
            if (j<0 || j>=collection.Count) throw new ArgumentOutOfRangeException(nameof(j));

            if (i == j) return;

            var temp = collection[i];
            collection[i] = collection[j];
            collection[j] = temp;
        }
    }
}
