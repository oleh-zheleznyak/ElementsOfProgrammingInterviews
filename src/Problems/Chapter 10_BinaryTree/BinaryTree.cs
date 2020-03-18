using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter_10_BinaryTree
{
    public class BinaryTree<T>
    {
        public BinaryTree() { }
        public BinaryTree(T value) { Value = value; }

        public T Value { get; set; }
        public BinaryTree<T> Left { get; set; }
        public BinaryTree<T> Right { get; set; }

        public bool IsLeaf => (Left is null) && (Right is null);

        /// <summary>
        /// visit the root, traverse left subtree,  traverse right subtree
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Preorder()
        {
            var stack = new Stack<BinaryTree<T>>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;

                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }
    }
}
