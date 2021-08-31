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
        public IEnumerable<T[]> GetBinaryTreeLevels(BinaryTreeNode<T> root)
        {
            if (root == null) throw new ArgumentNullException(nameof(root));

            // BFT - breadth first traversal
            var depth = 0;
            var index = 0;
            var storage = new T[1];
            foreach (var item in BreadthFirstTraversal(root))
            {
                if (item.Depth != depth)
                {
                    yield return storage;
                    depth++;
                    index = 0;
                    var maxStorageSize = (int)Math.Pow(2, depth); // this allocates more than needed (only full levels)
                    storage = new T[maxStorageSize];
                }
                storage[index++] = item.Node.Value;
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
    }
}
