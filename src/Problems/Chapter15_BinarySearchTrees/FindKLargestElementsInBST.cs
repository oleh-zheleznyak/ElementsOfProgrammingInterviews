using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Problems.Chapter_10_BinaryTree;

namespace Problems.Chapter15_BinarySearchTrees
{
    /// <summary>
    /// 15.3 Find the k largest elements in a BST
    /// </summary>
    public class FindKLargestElementsInBST<T>
        where T : IComparable<T>
    {
        public IEnumerable<T> FindLargestElements(BinaryTree<T> bst, ushort numberOfElementsToFind)
        {
            if (bst is null) throw new ArgumentNullException(nameof(bst));
            if (numberOfElementsToFind == 0) return Enumerable.Empty<T>();

            return ReverseInorderTraversal(bst).Take(numberOfElementsToFind);
        }

        private IEnumerable<T> ReverseInorderTraversal(BinaryTree<T>? bst)
        {
            if (bst is null) return Enumerable.Empty<T>();
            return ReverseInorderTraversal(bst.Right)
                .Concat(Enumerable.Repeat(bst.Value, 1))
                .Concat(ReverseInorderTraversal(bst.Left));
        }
    }
}