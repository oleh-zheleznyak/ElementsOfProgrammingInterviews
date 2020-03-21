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
        /// </summary>
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

        /// <summary>
        /// traverse left subtree, traverse right subtree, visit the root
        /// </summary>
        public IEnumerable<T> Postorder()
        {
            var queue = new Queue<T>();

            Postorder(this, queue);

            return queue;
        }

        private void Postorder(BinaryTree<T> node, Queue<T> values)
        {
            if (node is null) return;

            Postorder(node.Left, values);

            Postorder(node.Right, values);

            values.Enqueue(node.Value);
        }

        /// <summary>
        /// traverse left subtree, visit the root, traverse right subtree
        /// </summary>
        public IEnumerable<T> Inorder()
        {
            var queue = new Queue<T>();

            Inorder(this, queue);

            return queue;
        }

        private void Inorder(BinaryTree<T> node, Queue<T> values)
        {
            if (node is null) return;

            Inorder(node.Left, values);

            values.Enqueue(node.Value);

            Inorder(node.Right, values);
        }
    }
}
