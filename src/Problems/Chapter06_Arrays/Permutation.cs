using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter06_Arrays
{
    public class Permutation : IEquatable<Permutation>, IComparable<Permutation>
    {
        private readonly int[] permutation;

        public Permutation(int[] permutation)
        {
            this.permutation = permutation ?? throw new ArgumentNullException(nameof(permutation));
        }

        public IReadOnlyList<int> IndexMap => permutation;

        public int CompareTo(Permutation? other)
        {
            if (other is null) throw new ArgumentNullException(nameof(other));
            for (int i = 0; i < permutation.Length; i++)
            {
                var diff = permutation[i] - other.permutation[i];
                if (diff != 0) return diff;
            }
            return 0;
        }

        public bool Equals(Permutation? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(other, this)) return true;
            if (ReferenceEquals(other.permutation, permutation)) return true;
            return Enumerable.SequenceEqual(permutation, other.permutation);
        }

        public override bool Equals(object? obj) => Equals(obj as Permutation);
        public override int GetHashCode() => permutation.GetHashCode();
    }
}
