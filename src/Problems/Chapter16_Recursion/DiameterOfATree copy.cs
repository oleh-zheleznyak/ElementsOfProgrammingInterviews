using System;
using System.Collections.Generic;

namespace Problems.Chapter16_Recursion.BookSolution
{
    public class Edge
    {
        public Edge(int height, Node root)
        {
            Height = height;
            Root = root;
        }

        public int Height { get; }
        public Node Root { get; }
    }

    public readonly record struct HeightAndDiameter(int Height, int Diameter);

    public class Node
    {
        public Node(params Edge[] children)
        {
            Children = children;
        }

        public IReadOnlyList<Edge> Children { get; }

        public int Diameter()
        {
            return CalculateDiameterRecursively().Diameter;
        }

        private HeightAndDiameter CalculateDiameterRecursively()
        {
            (int max, int secondMax) height = (0, 0);
            var maxDiameter = int.MinValue;

            foreach (var child in Children)
            {
                var heightAndDiameter = child.Root.CalculateDiameterRecursively();
                maxDiameter = Math.Max(maxDiameter, heightAndDiameter.Diameter);
                var childHeight = heightAndDiameter.Height + child.Height;

                if (childHeight > height.max)
                {
                    height.secondMax = height.max;
                    height.max = heightAndDiameter.Height;
                }
                else if (childHeight > height.secondMax)
                {
                    height.secondMax = heightAndDiameter.Height;
                }
            }
            return new HeightAndDiameter(height.max, Math.Max(height.max + height.secondMax, maxDiameter));
        }
    }
}