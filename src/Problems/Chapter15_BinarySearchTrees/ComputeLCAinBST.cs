using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter15_BinarySearchTrees
{
    /// <summary>
    /// 15.4 Compute LCA in a BST
    /// </summary>
    /// <assumptions>
    /// All keys are distinct
    /// Nodes do not have reference to parent
    /// </assumptions>
    public class ComputeLCAinBST<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public ComputeLCAinBST(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public BinaryTree<T>? LowestCommonAncestor(BinaryTree<T> tree, BinaryTree<T> first, BinaryTree<T> second)
        {
            if (tree is null) throw new ArgumentNullException(nameof(tree));
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            return LowestCommonAncestor(tree, first.Value, second.Value);
        }

        public BinaryTree<T>? LowestCommonAncestor(BinaryTree<T> tree, T firstValue, T secondValue)
        {
            if (tree is null) throw new ArgumentNullException(nameof(tree));

            var current = tree;
            while (current != null)
            {
                var firstComparison = comparer.Compare(firstValue, current.Value);
                var secondComparison = comparer.Compare(secondValue, current.Value);

                var firstIsSmaller = firstComparison < 0;
                var secondIsSmaller = secondComparison < 0;

                if (firstIsSmaller && secondIsSmaller)
                    current = current.Left;
                else if (firstIsSmaller ^ secondIsSmaller)
                    return current;
                else if (!firstIsSmaller && !secondIsSmaller)
                {
                    if (firstComparison == 0 || secondComparison == 0)
                        return current;
                    else
                        current = current.Right;
                }
            }

            return current;
        }
    }
}
