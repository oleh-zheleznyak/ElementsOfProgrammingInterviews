using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class Edge
    {
        public Edge(int cost, Node root)
        {
            Cost = cost;
            Root = root;
        }

        public int Cost { get; }
        public Node Root { get; }
    }

    public class Diameter
    {
        public int PathIsolatedInSubtree { get; }

        public int PathViaParent { get; }

        public Diameter(int pathIsolatedInSubTree, int pathViaParent)
        {
            PathIsolatedInSubtree = pathIsolatedInSubTree;
            PathViaParent = pathViaParent;
        }

        public int Max => Math.Max(PathIsolatedInSubtree, PathViaParent);
    }

    public class Node
    {
        public Node(IReadOnlyList<Edge> children)
        {
            Children = children; // Consider copy
        }

        public bool IsLeaf => Children.Count == 0;

        public IReadOnlyList<Edge> Children { get; }

        public int Diameter()
        {
            return CalculateDiameterRecursively().Max;
        }

        private Diameter CalculateDiameterRecursively()
        {
            if (Children.Count == 0)
                return new Diameter(0, 0); // cost - the node does not have it - it is now in edge

            var diameters = Children.Select(x => x.Root.CalculateDiameterRecursively()).ToArray();
            var maxDiameterIsolatedInSubTree = diameters.Max(x => x.PathIsolatedInSubtree);
            var maxDiameterViaParent = FindMaxAndIndex(out var maxIndex, diameters);
            var secondMaxDiameterViaParent = FindMaxAndIndex(out var _, diameters, maxIndex);
            var result = new Diameter(
                Math.Max(maxDiameterViaParent + secondMaxDiameterViaParent, maxDiameterIsolatedInSubTree),
                maxDiameterViaParent
                );
            return result;
        }

        private int FindMaxAndIndex(out int maxIndex, Diameter[] diameters, int skipIndex = -1)
        {
            var maxDiameterViaParent = int.MinValue;
            maxIndex = -1;
            for (var i = 0; i < Children.Count; i++)
            {
                if (i == skipIndex) continue;
                var cost = diameters[i].PathViaParent + Children[i].Cost;
                if (cost > maxDiameterViaParent)
                {
                    maxIndex = i;
                    maxDiameterViaParent = cost;
                }
            }
            return maxDiameterViaParent;
        }
    }
}