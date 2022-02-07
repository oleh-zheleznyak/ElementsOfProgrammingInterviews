using MockInterview.Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateBinaryTreesTest : GenerateBinaryTreesTestBase
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
    }
}
