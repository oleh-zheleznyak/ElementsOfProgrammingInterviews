using System;

namespace Problems.Chapter16_Recursion.BookSolution
{
    internal readonly record struct HeightAndDiameter(int Height, int Diameter);

    public class Node : Problems.Chapter16_Recursion.Node
    {
        public Node(params Edge[] children) : base(children)
        {
        }

        public override int Diameter()
        {
            return CalculateDiameterRecursively().Diameter;
        }

        private HeightAndDiameter CalculateDiameterRecursively()
        {
            (int max, int secondMax) height = (0, 0);
            var maxDiameter = int.MinValue;

            foreach (var child in Children)
            {
                var heightAndDiameter = ((Node)child.Root).CalculateDiameterRecursively();
                maxDiameter = Math.Max(maxDiameter, heightAndDiameter.Diameter);
                var childHeight = heightAndDiameter.Height + child.Length;

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