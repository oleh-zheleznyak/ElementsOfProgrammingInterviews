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

        public bool IsABst_ViaInorderTraversal(BinaryTree<T> binaryTree)
        {
            if (binaryTree is null) throw new ArgumentNullException(nameof(binaryTree));

            T prev = default; // this can be value type, with a "valid" default value, like 0 for int
            bool hasPrevious = false;
            foreach (var node in binaryTree.Inorder())
            {
                if (hasPrevious)
                {
                    var comparison = comparer.Compare(prev, node);
                    if (comparison > 0) return false;
                }
                prev = node;
                hasPrevious = true;
            }

            return true;
        }

        public bool IsABst(BinaryTree<T> binaryTree)
        {
            if (binaryTree is null) throw new ArgumentNullException(nameof(binaryTree));

            return NodeSatisfiesBstPropertyRecursive(binaryTree, default, default); // subtle bug for tree of numbers with zero
        }


        private bool NodeSatisfiesBstPropertyRecursive(BinaryTree<T> binaryTree, T? min, T? max)
        {
            var valueMoreThanMinimum = comparer.Compare(min, default) == 0 ? true : comparer.Compare(binaryTree.Value, min) >= 0;
            var valueLessThanMaximum = comparer.Compare(max, default) == 0 ? true : comparer.Compare(binaryTree.Value, max) <= 0;

            if (!valueLessThanMaximum || !valueMoreThanMinimum) return false;

            var leftSubtreeIsBst = binaryTree.Left is null ? true : NodeSatisfiesBstPropertyRecursive(binaryTree.Left, min, binaryTree.Value);
            var rightSubtreeIsBst = binaryTree.Right is null ? true : NodeSatisfiesBstPropertyRecursive(binaryTree.Right, binaryTree.Value, max);

            return leftSubtreeIsBst && rightSubtreeIsBst;
        }
    }
}
