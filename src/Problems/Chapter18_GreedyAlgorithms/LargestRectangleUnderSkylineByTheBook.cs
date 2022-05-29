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
            var candidateRectangle = new Rectangle(0, 0, 0);

            pillarInices.Push(0);
            for (uint i = 1; i <= heights.Length; i++)
            {
                if (pillarInices.Count > 0 && i < heights.Length && heights[i] == heights[pillarInices.Peek()])
                {
                    pillarInices.Pop();
                    pillarInices.Push(i);
                }

                while (pillarInices.Count > 0 && IsNewPillarOrReachEnd(heights, i, pillarInices.Peek()))
                {
                    var height = heights[pillarInices.Peek()];
                    pillarInices.Pop();
                    var start = pillarInices.Count > 0 ? pillarInices.Peek() + 1 : 0;
                    var width = i - start;
                    var area = height * width;
                    if (area > candidateRectangle.Area)
                        candidateRectangle = new Rectangle(start, i, height);
                }
                pillarInices.Push(i);
            }
            return candidateRectangle;
        }

        private bool IsNewPillarOrReachEnd(uint[] heights, uint currentIndex, uint lastPillarIndex)
        {
            return currentIndex < heights.Length ?
                heights[currentIndex] < heights[lastPillarIndex]
                : true;
        }
    }
}