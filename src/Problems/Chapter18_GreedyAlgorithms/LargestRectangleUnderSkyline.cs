using System;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public record Rectangle(uint Start, uint End, uint Height)
    {
        public uint Area => Height * (End - Start);
    }
    
    public class LargestRectangleUnderSkyline
    {
        public Rectangle ComputeLargest(uint[] heights)
        {
            if (heights is null) throw new ArgumentNullException(nameof(heights));
            if (heights.Length < 2) throw new ArgumentException("not enough elements", nameof(heights));
            // brute force - loop all pairs, loop from start to finish to find height - O(n^3) time, O(1)
            // brute force + track minimum in inner loop - O(n^2) time, O(1) space
            var maxArea = long.MinValue;
            Rectangle rectangle = null;
            for (uint i = 0; i < heights.Length; i++)
            {
                var min = heights[i];
                for (uint j = i+1; j < heights.Length; j++)
                {
                    var width = j - i + 1;
                    min = Math.Min(min, heights[j]);
                    var area = width * min;
                    if (area > maxArea)
                    {
                        maxArea = area;
                        rectangle = new Rectangle(i, j+1, area);
                    }
                }
            }

            return rectangle;
        }
    }
}