using MockInterview.Recursion;
using System;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateBinaryTreesViaDirectedIterationTest
    {
        GenerateBinaryTreesViaDirectedIteration<int> generateBinaryTrees = new();

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
                new BinaryTree<int>() { Left = new() },
                new BinaryTree<int>() { Right = new() },
            } };
            yield return new object[] { 3, new[]
            {
                new BinaryTree<int>() { Left = new() { Left=new() } },
                new BinaryTree<int>() { Left = new() { Right=new() } },
                new BinaryTree<int>() { Left=new(), Right=new()  },
                new BinaryTree<int>() { Right=new() { Left=new() } },
                new BinaryTree<int>() { Right=new() { Right=new() } },
            } };
        }

        private static BinaryTree<int> node() => new BinaryTree<int>();
    }
}
