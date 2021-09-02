using System;
using System.Collections.Generic;

namespace Problems.Chapter_10_BinaryTree
{
    public class ComputeLcaWithParentField<T>
    {
        public BinaryTreeWithParent<T>? ComputeLowestCommonAncestor(BinaryTreeWithParent<T> node1, BinaryTreeWithParent<T> node2)
        {
            if (node1 == null) throw new ArgumentNullException(nameof(node1));
            if (node2 == null) throw new ArgumentNullException(nameof(node2));
            if (ReferenceEquals(node1, node2)) return node1;

            var visitedNodes = new HashSet<BinaryTreeWithParent<T>>();

            while (node1.Parent!=null)
            {
                node1 = node1.Parent;
                visitedNodes.Add(node1);
            }

            while (node2.Parent!=null)
            {
                node2 = node2.Parent;
                if (visitedNodes.Contains(node2)) return node2;
            }
            return null;
        }
    }
}
