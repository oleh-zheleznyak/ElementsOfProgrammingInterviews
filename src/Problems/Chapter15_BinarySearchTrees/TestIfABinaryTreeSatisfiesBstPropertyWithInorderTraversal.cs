using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;

namespace Problems.Chapter15_BinarySearchTrees
{
    public class TestIfABinaryTreeSatisfiesBstPropertyWithInorderTraversal<T> : ITestIfABinaryTreeSatisfiesBstProperty<T> where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public TestIfABinaryTreeSatisfiesBstPropertyWithInorderTraversal(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public bool IsABst(BinaryTree<T> binaryTree)
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
    }
}
