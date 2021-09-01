using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter09_Stacks
{
    /// <summary>
    /// 9.7 Compute binary tree nodes in order of increasing depth
    /// </summary>
    public class BinaryTreeNodesInOrderOfIncreasingDepth<T>
    {
        public IEnumerable<IEnumerable<T>> GetBinaryTreeLevels(BinaryTreeNode<T> root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));

            // BFT - breadth first traversal
            var depth = 0;
            var storage = new Queue<T>();
            foreach (var (Node, Depth) in BreadthFirstTraversal(root))
            {
                if (Depth != depth)
                {
                    yield return storage;
                    depth++;
                    storage.Clear();
                }
                storage.Enqueue(Node.Value);
            }
            yield return storage;
        }

        public IEnumerable<(BinaryTreeNode<T> Node, int Depth)> BreadthFirstTraversal(BinaryTreeNode<T> root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));

            // BFT - breadth first traversal
            var queue = new Queue<(BinaryTreeNode<T> Node, int Depth)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Node.Left != null) queue.Enqueue((current.Node.Left, current.Depth + 1));
                if (current.Node.Right != null) queue.Enqueue((current.Node.Right, current.Depth + 1));

                yield return current;
            }
        }

        /// <summary>
        /// The solution from the book, implemented below is more elegant, since it does not deal with depth explicitly
        /// However, it is also less efficient
        ///  - as it specifically allocates collections for every tree level
        ///  - uses eager execution (not lazy)
        /// </summary>
        public IList<IList<T>> GetBinaryTreeLevels_SolutionFromTextbook(BinaryTreeNode<T> root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));
            var thisLevelQueue = new Queue<BinaryTreeNode<T>>();
            var result = new List<IList<T>>();

            thisLevelQueue.Enqueue(root);
            while (thisLevelQueue.Count > 0)
            {
                var thisLevel = new List<T>();
                var nextLevelQueue = new Queue<BinaryTreeNode<T>>();
                while (thisLevelQueue.Count > 0)
                {
                    var node = thisLevelQueue.Dequeue();
                    thisLevel.Add(node.Value);

                    if (node.Left != null) nextLevelQueue.Enqueue(node.Left);
                    if (node.Right != null) nextLevelQueue.Enqueue(node.Right);
                }
                result.Add(thisLevel);
                thisLevelQueue = nextLevelQueue;
            }
            return result;
        }
    }
}
