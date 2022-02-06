using System;
using System.Collections.Generic;

namespace MockInterview.Recursion
{
    public class GenerateBinaryTreesViaDirectedIteration<T> where T : IComparable<T>
    {
        public IReadOnlyCollection<BinaryTree<T>> GenerateAllBinaryTrees(int numberOfNodes)
        {
            if (numberOfNodes < 0) throw new ArgumentException(nameof(numberOfNodes));
            if (numberOfNodes == 0) return Array.Empty<BinaryTree<T>>();

            return GenerateAllBinaryTrees_Impl(numberOfNodes);
        }

        public IReadOnlyCollection<BinaryTree<T>> GenerateAllBinaryTrees_Impl(int numberOfNodes)
        {
            var results = new List<BinaryTree<T>>();
            if (numberOfNodes == 0) results.Add(null); ;

            for (var leftNodesCount = 0; leftNodesCount < numberOfNodes; leftNodesCount++)
            {
                var rightNodesCount = numberOfNodes - leftNodesCount - 1;

                var leftSubtrees = GenerateAllBinaryTrees_Impl(leftNodesCount);
                var rightSubtrees = GenerateAllBinaryTrees_Impl(rightNodesCount);

                foreach (var left in leftSubtrees)
                {
                    foreach (var right in rightSubtrees)
                    {
                        var root = new BinaryTree<T>() { Left = left?.Clone(), Right = right?.Clone() };
                        results.Add(root);
                    }
                }

            }
            return results;
        }
    }
}