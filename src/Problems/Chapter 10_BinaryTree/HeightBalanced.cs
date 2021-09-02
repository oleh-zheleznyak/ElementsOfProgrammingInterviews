using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter_10_BinaryTree
{
    public class HeightBalanced<T>
    {
        public bool IsHeightBalanced(BinaryTree<T> tree)
        {
            if (tree == null) throw new ArgumentNullException(nameof(tree));

            var leftDepth = GetDepthIfNotNull(tree.Left, 1);
            var rightDepth = GetDepthIfNotNull(tree.Right, 1);

            var isBalanced = Math.Abs(leftDepth - rightDepth) < 1;
            return isBalanced;
        }

        private int GetDepth(BinaryTree<T> tree, int depth)
        {
            if (tree.IsLeaf) return depth;

            var leftDepth = GetDepthIfNotNull(tree.Left, depth++);
            var rightDepth = GetDepthIfNotNull(tree.Right, depth++);

            return (int)Math.Max(leftDepth, rightDepth);
        }

        private int GetDepthIfNotNull(BinaryTree<T> tree, int depth) => tree is null ? 0 : GetDepth(tree, depth);
    }
}
