using MockInterview.Recursion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateBinaryTreesTest
    {
        GenerateBinaryTrees<int> generateBinaryTrees = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void GenerateAllBinaryTreesTest(int numberOfNodes, BinaryTree<int>[] expectedResults)
        {
            var comparer = new BinaryTreeEqualityComparer<int>(EqualityComparer<int>.Default);
            var allBinaryTrees = generateBinaryTrees.GenerateAllBinaryTrees(numberOfNodes);
            TestUtils.AssertEquivalent(expectedResults, allBinaryTrees, comparer);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 0, Array.Empty<BinaryTree<int>>() };
            yield return new object[] { 1, new[] { new BinaryTree<int>() } };
            yield return new object[] { 2, new[]
            {
                new BinaryTree<int>() { Left = new BinaryTree<int>() },
                new BinaryTree<int>() { Right = new BinaryTree<int>() },
            } };
        }
    }

    public class BinaryTreeEqualityComparer<T> : IEqualityComparer<BinaryTree<T>>
         where T : IComparable<T>
    {
        private readonly IEqualityComparer<T> equalityComparer;

        public BinaryTreeEqualityComparer(IEqualityComparer<T> equalityComparer)
        {
            this.equalityComparer = equalityComparer;
        }

        public bool Equals(BinaryTree<T> x, BinaryTree<T> y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            var valuesEqual = equalityComparer.Equals(x.Value, y.Value);

            return
                valuesEqual &&
                Equals(x.Left, y.Left) &&
                Equals(x.Right, y.Right);
        }

        public int GetHashCode([DisallowNull] BinaryTree<T> obj)
        {
            int hash = equalityComparer.GetHashCode(obj.Value);

            if (obj.Left is not null) hash = HashCode.Combine(GetHashCode(obj.Left));
            if (obj.Right is not null) hash = HashCode.Combine(GetHashCode(obj.Right));

            return hash;
        }
    }
}
