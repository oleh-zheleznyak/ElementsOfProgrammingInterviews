using System;

namespace Problems.Chapter17_DynamicProgramming
{
    public class NumberOfScoreCombinations
    {
        public uint[,] NumberOfCombinations(uint finalScore, uint[] scores)
        {
            // TODO: validate arguments
            // positive scores
            if (scores is null) throw new ArgumentNullException(nameof(scores));

            var combinations = new uint[scores.Length, finalScore + 1];

            // A[i+1,j] = A[i,j] + A[i+1,j-W(i+1)]
            for (var i = 0; i < scores.Length; i++)
            {
                var score = scores[i];
                combinations[i, 0] = 1; // one way to reach zero
                for (var j = 1; j <= finalScore; j++)
                {
                    var without_this_score = i < 1 ? 0 : combinations[i - 1, j];
                    var with_this_score = j < score ? 0 : combinations[i, j - score];

                    combinations[i, j] = without_this_score + with_this_score;
                }
            }
            return combinations;
        }
    }
}