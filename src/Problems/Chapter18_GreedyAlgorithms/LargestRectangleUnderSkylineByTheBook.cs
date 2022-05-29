using System;
using System.Collections.Generic;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public class LargestRectangleUnderSkylineByTheBook
    {
        public Rectangle ComputeLargest(uint[] heights)
        {
            if (heights is null) throw new ArgumentNullException(nameof(heights));
            if (heights.Length < 2) throw new ArgumentException("not enough elements", nameof(heights));

            var pillarInices = new Stack<uint>();
            var candidateRectangle = new Rectangle(0,0,0);

            pillarInices.Push(0);
            for (uint i = 1; i < heights.Length; i++)
            {
                Console.WriteLine('a'+i);
                var current = heights[i];
                long lastRemoved = -1;
                while (pillarInices.Count > 0 && 
                    ((heights[pillarInices.Peek()] >= current) || (i==heights.Length-1))
                    )
                {
                    var start = pillarInices.Pop();
                    var height = heights[start];
                    var index = pillarInices.Count > 0 ? pillarInices.Peek() + 1: 0; // At J we have total shite
                    lastRemoved = start;
                    var area = (i - index) * height; // 12  -- G is counted wrong and K  - we do not consider the pillar C

                    if (area > candidateRectangle.Area)
                        candidateRectangle = new Rectangle(start, i, height);
                }
                if (lastRemoved > 0 && heights[lastRemoved] == current)
                    pillarInices.Push((uint)lastRemoved);
                else pillarInices.Push(i);
            }

            return candidateRectangle;
        }
    }
}