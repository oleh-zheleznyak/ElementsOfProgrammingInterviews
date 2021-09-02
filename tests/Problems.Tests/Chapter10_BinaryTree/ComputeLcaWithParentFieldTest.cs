using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems.Chapter_10_BinaryTree;
using Xunit;

namespace Problems.Tests.Chapter10_BinaryTree
{
    public class ComputeLcaWithParentFieldTests
    {
        private ComputeLcaWithParentField<int> computeLcaWithParentField = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeLowestCommonAncestorTest(BinaryTreeWithParent<int> node1, BinaryTreeWithParent<int> node2, BinaryTreeWithParent<int> lca)
        {
            var actual = computeLcaWithParentField.ComputeLowestCommonAncestor(node1, node2);
            Assert.Equal(lca, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return BalancedTree();
        }

        private static object[] BalancedTree()
        {
            var tree = new BinaryTreeWithParent<int>(1)
            {
                Right = new BinaryTreeWithParent<int>(2),
                Left = new BinaryTreeWithParent<int>(3)
            };

            return new object[]
            {
                tree.Left,
                tree.Right,
                tree,
            };
        }
    }
}
