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
            var actual = traversal.GetBinaryTreeLevels(binaryTree).ToArray();
            Assert.Equal(expectedArrayOfNodes, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return TwoLevelTree();
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
    }
}
