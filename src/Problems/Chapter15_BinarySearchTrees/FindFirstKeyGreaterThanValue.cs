using System;
using System.Collections.Generic;
using Problems.Chapter_10_BinaryTree;

namespace Problems.Chapter15_BinarySearchTrees
{
    public class FindFirstKeyGreaterThanValue<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public FindFirstKeyGreaterThanValue(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        /// <summary>
        /// Finds the minimum key that is greater than the value provided, or null.
        /// The tree passed in the argument MUST be a BST
        /// </summary>
        /// <param name="binarySearchTree">binary search tree is ASSUMED</param>
        /// <param name="valueToFind">value to look for</param>
        /// <returns>minimum value in the tree that is greater than value or null</returns>
        public T? FindMinGreaterThan(BinaryTree<T> binarySearchTree, T valueToFind)
        {
            if (binarySearchTree is null) throw new ArgumentNullException(nameof(binarySearchTree));

            var current = binarySearchTree;
            T? min = default;
            while (current != null)
            {
                var comparison = comparer.Compare(current.Value, valueToFind);
                if (comparison <= 0) current = current.Right;
                else
                {
                    if (comparer.Compare(min, default) == 0) min = current.Value;
                    else min = comparer.Compare(min, current.Value) < 0 ? min : current.Value;
                    current = current.Left;
                }
            }

            return min;
        }
    }
}