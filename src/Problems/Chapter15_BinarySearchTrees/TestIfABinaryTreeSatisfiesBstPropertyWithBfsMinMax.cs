using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;

namespace Problems.Chapter15_BinarySearchTrees
{
    public class TestIfABinaryTreeSatisfiesBstPropertyWithBfsMinMax<T> : ITestIfABinaryTreeSatisfiesBstProperty<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public TestIfABinaryTreeSatisfiesBstPropertyWithBfsMinMax(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public bool IsABst(BinaryTree<T> binaryTree)
        {
            if (binaryTree is null) throw new ArgumentNullException(nameof(binaryTree));

            Queue<(BinaryTree<T> node, T? min, T? max)> queue = new();
            queue.Enqueue((binaryTree, default, default));

            while (queue.Count > 0)
            {
                var nodeMinMax = queue.Dequeue();

                if (!NodeValueSatisfiesMinMax(nodeMinMax)) return false;

                var (node, min, max) = nodeMinMax;
                if (node.Left != null) queue.Enqueue((node.Left, min, node.Value));
                if (node.Right != null) queue.Enqueue((node.Right, node.Value, max));
            }
            return true;
        }

        private bool NodeValueSatisfiesMinMax((BinaryTree<T> binaryTree, T? min, T? max) nodeMinMax)
        {
            var (binaryTree, min, max) = nodeMinMax;

            var valueMoreThanMinimum = comparer.Compare(min, default) == 0 ? true : comparer.Compare(binaryTree.Value, min) >= 0;
            var valueLessThanMaximum = comparer.Compare(max, default) == 0 ? true : comparer.Compare(binaryTree.Value, max) <= 0;

            return valueMoreThanMinimum && valueLessThanMaximum;
        }
    }
}
