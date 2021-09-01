using Problems.Chapter09_Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter09_Stacks
{
    public class BinaryTreeNodesInOrderOfIncreasingDepthTests
    {
        BinaryTreeNodesInOrderOfIncreasingDepth<int> traversal = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void GetBinaryTreeLevelsTest(BinaryTreeNode<int> binaryTree, int[][] expectedArrayOfNodes)
        {
            var actual = traversal.GetBinaryTreeLevels(binaryTree);
            Assert.Equal(expectedArrayOfNodes, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return TwoLevelTree();
            yield return ThreeLevelTree();
            yield return ThreeLevelTreeThatIsNotFull();
        }

        private static object[] TwoLevelTree()
        {
            var tree = new BinaryTreeNode<int>(1);
            tree.Left = new BinaryTreeNode<int>(2);
            tree.Right = new BinaryTreeNode<int>(3);

            return new object[]
            {
                tree,
                new int[][] { new int[] { 1 }, new int[] { 2,3 } }
            };
        }

        private static object[] ThreeLevelTree()
        {
            var tree = new BinaryTreeNode<int>(1);
            tree.Left = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(4),
                Right = new BinaryTreeNode<int>(5)
            };
            tree.Right = new BinaryTreeNode<int>(3)
            {
                Left = new BinaryTreeNode<int>(6),
                Right = new BinaryTreeNode<int>(7)
            };

            return new object[]
            {
                tree,
                new int[][] { new int[] { 1 }, new int[] { 2,3 }, new int[] { 4,5,6,7 } }
            };
        }

        private static object[] ThreeLevelTreeThatIsNotFull()
        {
            var tree = new BinaryTreeNode<int>(1);
            tree.Left = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(4),
            };
            tree.Right = new BinaryTreeNode<int>(3)
            {
                Right = new BinaryTreeNode<int>(7)
            };

            return new object[]
            {
                tree,
                new int[][] { new int[] { 1 }, new int[] { 2,3 }, new int[] { 4,7 } }
            };
        }
    }
}
