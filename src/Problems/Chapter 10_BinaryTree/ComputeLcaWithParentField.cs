using System;
using System.Collections.Generic;

namespace Problems.Chapter_10_BinaryTree
{
    public class ComputeLcaWithParentField<T>
    {
        public BinaryTreeWithParent<T>? ComputeLowestCommonAncestor(BinaryTreeWithParent<T>? node1, BinaryTreeWithParent<T>? node2)
        {
            if (node1 == null) throw new ArgumentNullException(nameof(node1));
            if (node2 == null) throw new ArgumentNullException(nameof(node2));
            if (ReferenceEquals(node1, node2)) return node1; // node can be a descendant of itself, and so the LCA as well

            var node1Depth = GetDepth(node1);
            var node2Depth = GetDepth(node2);

            if (node2Depth > node1Depth)
                node2 = TraverseUp(node2, node2Depth - node1Depth);
            else
                node1 = TraverseUp(node1, node1Depth - node2Depth);

            while (node1 != node2)
            {
                node1 = node1?.Parent;
                node2 = node2?.Parent;
            }

            return node1;
        }

        private BinaryTreeWithParent<T>? TraverseUp(BinaryTreeWithParent<T>? node, int steps)
        {
            for (int i = 0; i < steps; i++)
                node = node?.Parent;
            return node;
        }

        private int GetDepth(BinaryTreeWithParent<T> node)
        {
            var depth = 0;
            while (node?.Parent != null)
            {
                depth++;
                node = node.Parent;
            }
            return depth;
        }
    }
}
