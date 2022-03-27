using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public readonly record struct Diameter(int PathIsolatedInSubTree, int PathViaParent);

    public class Node
    {
        public Node(params Edge[] children)
        {
            Children = children;
        }

        public IReadOnlyList<Edge> Children { get; }

        public int Diameter()
        {
            var diameter = CalculateDiameterRecursively();
            return Math.Max(diameter.PathIsolatedInSubTree, diameter.PathViaParent);
        }

        private Diameter CalculateDiameterRecursively()
        {
            if (Children.Count == 0)
                return new Diameter(0, 0);

            var diameters = Children.Select(x => x.Root.CalculateDiameterRecursively()).ToArray();
            var maxDiameterIsolatedInSubTree = diameters.Max(x => x.PathIsolatedInSubTree);
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
                var cost = diameters[i].PathViaParent + Children[i].Length;
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