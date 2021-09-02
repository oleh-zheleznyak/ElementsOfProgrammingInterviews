using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter10_BinaryTree
{
    public class HeightBalancedTest
    {
        HeightBalanced<int> heightBalanced = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void IsHeightBalancedTest(BinaryTree<int> binaryTree, bool expectedIsBalanced)
        {
            var actualIsBalanced = heightBalanced.IsHeightBalanced(binaryTree);
            Assert.Equal(expectedIsBalanced, actualIsBalanced);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return RightSkewedTree();
            yield return BalancedTree();
        }

        private static object[] RightSkewedTree()
        {
            var tree = new BinaryTree<int>(1)
            {
                Right = new BinaryTree<int>(2)
                {
                    Right = new BinaryTree<int>(3)
                }
            };

            return new object[]
            {
                tree,
                false
            };
        }

        private static object[] BalancedTree()
        {
            var tree = new BinaryTree<int>(1)
            {
                Right = new BinaryTree<int>(2),
                Left = new BinaryTree<int>(3)
            };

            return new object[]
            {
                tree,
                true
            };
        }
    }
}
