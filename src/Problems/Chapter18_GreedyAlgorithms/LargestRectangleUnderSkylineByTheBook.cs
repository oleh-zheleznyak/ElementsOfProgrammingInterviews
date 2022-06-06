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

            var pillarIndices = new Stack<uint>();
            return ComputeLargest(heights, pillarIndices);
        }

        private Rectangle ComputeLargest(uint[] heights, Stack<uint> pillarIndices)
        {
            var maxRectangle = new Rectangle(0, 0, 0);

            pillarIndices.Push(0);
            for (uint i = 1; i <= heights.Length; i++)
            {
                ReplaceDuplicateWithLatest(heights, pillarIndices, i);

                while (IsNewPillarOrEndOfLine(heights, pillarIndices,i))
                {
                    var candidate = CandidateRectangle(heights, pillarIndices, i);

                    if (candidate.Area > maxRectangle.Area)
                        maxRectangle = candidate;
                }
                
                pillarIndices.Push(i);
            }
            
            return maxRectangle;
        }

        private Rectangle CandidateRectangle(uint[] heights, Stack<uint> pillarIndices, uint index)
        {
            var height = heights[pillarIndices.Peek()];
            pillarIndices.Pop();
            var start = pillarIndices.Count > 0 ? pillarIndices.Peek() + 1 : 0;
            var end = index;
            return new Rectangle(start, end, height);
        }

        private bool IsNewPillarOrEndOfLine(uint[] heights, Stack<uint> pillarIndices, uint index) =>
            pillarIndices.Count>0 
            &&
            (index < heights.Length
                ? heights[index] < heights[pillarIndices.Peek()]
                : true);

        private void ReplaceDuplicateWithLatest(uint[] heights, Stack<uint> pillarIndices, uint index)
        {
            if (index < heights.Length && pillarIndices.Count > 0 && heights[index] == heights[pillarIndices.Peek()])
            {
                pillarIndices.Pop();
                pillarIndices.Push(index);
            }
        }
    }
}