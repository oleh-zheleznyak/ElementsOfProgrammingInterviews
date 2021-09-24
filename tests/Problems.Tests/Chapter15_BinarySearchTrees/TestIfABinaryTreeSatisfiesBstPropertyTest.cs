using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class TestIfABinaryTreeSatisfiesBstPropertyTest
    {
        private readonly TestIfABinaryTreeSatisfiesBstProperty<int> testForBst = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void IsABstTest(BinaryTree<int> binaryTree, bool expectedIsBinary)
        {
            var actual = testForBst.IsABst(binaryTree);
            Assert.Equal(expectedIsBinary, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void IsABst_ViaInorderTraversalTest(BinaryTree<int> binaryTree, bool expectedIsBinary)
        {
            var actual = testForBst.IsABst_ViaInorderTraversal(binaryTree);
            Assert.Equal(expectedIsBinary, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return PerfectTwoLevelBst();
            yield return TrivialSingleNode();
            yield return PerfectTwoLevelNotABst();
            yield return PerfectTwoLevelAllEqual();
            yield return ThreeLevelBst();
            yield return BstAtEachNodeButNotBstOverall();
        }

        private static object[] PerfectTwoLevelBst() =>
            new object[]
            {
                new BinaryTree<int>(2)
                {
                    Left = new BinaryTree<int>(1),
                    Right = new BinaryTree<int>(3)
                },
                true
            };

        private static object[] TrivialSingleNode() =>
            new object[]
            {
                        new BinaryTree<int>(42),
                        true
            };
        private static object[] PerfectTwoLevelNotABst() =>
            new object[]
            {
                new BinaryTree<int>(2)
                {
                    Left = new BinaryTree<int>(3),
                    Right = new BinaryTree<int>(1)
                },
                false
            };

        private static object[] PerfectTwoLevelAllEqual() =>
            new object[]
            {
                new BinaryTree<int>(1)
                {
                    Left = new BinaryTree<int>(1),
                    Right = new BinaryTree<int>(1)
                },
                true
            };
        private static object[] ThreeLevelBst() =>
            new object[]
            {
                new BinaryTree<int>(2)
                {
                    Left = new BinaryTree<int>(1),
                    Right = new BinaryTree<int>(4)
                    {
                        Left = new BinaryTree<int>(3),
                        Right = new BinaryTree<int>(5)
                    }
                },
                true
            };

        private static object[] BstAtEachNodeButNotBstOverall() =>
            new object[]
            {
                new BinaryTree<int>(7)
                {
                    Left = new BinaryTree<int>(3)
                    {
                        Left = new BinaryTree<int>(1),
                        Right = new BinaryTree<int>(8)
                    },
                    Right = new BinaryTree<int>(9)
                    {
                        Left = new BinaryTree<int>(2),
                        Right = new BinaryTree<int>(10)
                    }
                },
                false
            };
    }
}
