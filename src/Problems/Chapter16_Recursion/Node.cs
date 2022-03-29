using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public abstract class Node
    {
        public Node(params Edge[] children)
        {
            Children = children;
        }

        public IReadOnlyList<Edge> Children { get; }

        public abstract int Diameter();
    }
}