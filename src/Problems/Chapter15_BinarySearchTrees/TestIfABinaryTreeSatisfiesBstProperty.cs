using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;

namespace Problems.Chapter15_BinarySearchTrees
{
    public class TestIfABinaryTreeSatisfiesBstProperty<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public TestIfABinaryTreeSatisfiesBstProperty(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public bool IsABst(BinaryTree<T> binaryTree)
        {
            if (binaryTree is null) throw new ArgumentNullException(nameof(binaryTree));

            return NodeSatisfiesBstPropertyRecursive(binaryTree);
        }


        private bool NodeSatisfiesBstPropertyRecursive(BinaryTree<T> binaryTree)
        {
            var satisfiesBstAtThisLevel = NodeSatisfiesBstProperty(binaryTree);

            if (!satisfiesBstAtThisLevel) return false;

            var satisfiesBstRecursively =
                satisfiesBstAtThisLevel &&
                binaryTree.Left is null ? true : NodeSatisfiesBstPropertyRecursive(binaryTree.Left) &&
                binaryTree.Right is null ? true : NodeSatisfiesBstPropertyRecursive(binaryTree.Right);

            return satisfiesBstRecursively;
        }

        private bool NodeSatisfiesBstProperty(BinaryTree<T> node) =>
            node.Left is null ? true : comparer.Compare(node.Left.Value, node.Value) <= 0 &&
            node.Right is null ? true : comparer.Compare(node.Right.Value, node.Value) >= 0;
    }
}
