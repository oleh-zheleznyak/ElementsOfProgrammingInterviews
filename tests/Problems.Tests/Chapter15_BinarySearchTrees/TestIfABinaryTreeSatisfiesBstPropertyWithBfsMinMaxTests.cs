using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class TestIfABinaryTreeSatisfiesBstPropertyWithBfsMinMaxTests
    {
        private readonly TestIfABinaryTreeSatisfiesBstPropertyWithBfsMinMax<int> testForBst = new();

        [Theory]
        [ClassData(typeof(TestIfABinaryTreeSatisfiesBstPropertyTestData))]
        public void IsABstTest(BinaryTree<int> binaryTree, bool expectedIsBinary)
        {
            var actual = testForBst.IsABst(binaryTree);
            Assert.Equal(expectedIsBinary, actual);
        }
    }
}
