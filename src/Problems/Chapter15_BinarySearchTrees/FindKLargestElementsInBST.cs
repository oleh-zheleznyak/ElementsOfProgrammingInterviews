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
            if (numberOfElementsToFind == 0) yield break;

            var inorder = Inorder(bst).ToList();
            if (numberOfElementsToFind > inorder.Count) 
                throw new ArgumentException($"{nameof(numberOfElementsToFind)} is greater than the amount of elements in the collection {nameof(bst)}");

            for (var i = 0; i < numberOfElementsToFind; i++)
                yield return inorder[inorder.Count - 1 - i];
        }

        /// <remarks>
        /// This particular implementation of inorder traversal does not return the count of elements,
        /// as it is lazily evaluated
        /// This traversal is LESS elegant then existing in BinaryTree.Inorder - specifically to show
        /// that we cannot rely on any particular implementation
        /// </remarks>
        private IEnumerable<T> Inorder(BinaryTree<T>? bst)
        {
            if (bst is null) return Enumerable.Empty<T>();
            return Inorder(bst.Left)
                .Concat(Enumerable.Repeat(bst.Value, 1))
                .Concat(Inorder(bst.Right));
        }
    }
}