using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class PalindromicDecompositions
    {
        public IReadOnlyCollection<ICollection<string>> ComputeAllPalindromicDecompositions(string input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input));
            if (input.Length == 0) return Array.Empty<string[]>();
            if (input.Length == 1) return new[] { new[] { input } };

            var results = new List<List<string>>();

            ComputeDecompositions(input, 0, input.Length - 1, new List<string>(), results);

            return results;
        }

        private void ComputeDecompositions(string input, int startIndex, int endIndex, List<string> currentDecomposition, List<List<string>> results)
        {
            if (startIndex > endIndex)
            {
                results.Add(currentDecomposition.ToList());
                return;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (isPalindrome(input, startIndex, i))
                {
                    var length = i - startIndex + 1;
                    var prefix = input.Substring(startIndex, length);
                    currentDecomposition.Add(prefix);
                    ComputeDecompositions(input, i + 1, endIndex, currentDecomposition, results);
                    currentDecomposition.RemoveAt(currentDecomposition.Count - 1);
                }
            }
        }

        private bool isPalindrome(string input, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex) return true;
            for (int i = 0; i < (endIndex - startIndex + 1) / 2; i++)
            {
                if (input[startIndex + i] != input[endIndex - i]) return false;
            }
            return true;
        }
    }
}
