using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter17_DynamicProgramming
{
    /// <summary>
    /// 17.8 Find the minimum weight path in a triangle
    /// </summary>
    public class MinimumWeightPathInATriangle
    {
		public int FindMinimumWeightPath(int[][] triangle)
		{
			if (triangle is null) throw new ArgumentNullException(nameof(triangle));
			if (!IsProperTriangle(triangle)) throw new ArgumentException(triangle));

			var cache = CreateCacheSameSizeAs(triangle); // or rectangular, but more memory
			var min = int.MaxValue;
			var level = triangle.Length - 1;
			for (int i = 0; i < triangle[level].Length; i++)
			{
				var weight = FindMinimumWeightPath(triangle, i, level, cache);
				min = Math.Min(min, weight);
			}
			return min;
		}

		private int FindMinimumWeightPath(int[][] triangle, int startingPoint, int level, int?[][] cache)
		{
			if (level == 0) return triangle[0][0];
			if (cache[level][startingPoint].HasValue) return cache[level][startingPoint].Value;

			var sameIndex = startingPoint < triangle[level].Length ? FindMinimumWeightPath(triangle, startingPoint, level - 1, cache) : int.MaxValue;
			var smallerIndex = startingPoint > 0 ? FindMinimumWeightPath(triangle, startingPoint - 1, level - 1, cache) : int.MaxValue; // not very elegant

			var weight = Math.Min(sameIndex, smallerIndex) + triangle[level, startingPoint];
			cache[level][startingPoint] = weight;
			return weight;
		}

		private bool IsProperTriangle(int[][] triangle) => true; //TODO
		private int?[][] CreateCacheSameSizeAs(int[][] triangle) => // TODO;



	}
}
