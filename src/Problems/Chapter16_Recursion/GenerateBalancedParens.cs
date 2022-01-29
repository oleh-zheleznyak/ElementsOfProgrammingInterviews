using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter16_Recursion
{
    public class GenerateBalancedParens : IGenerateStringsOfMatchedParens
    {
        public IReadOnlyCollection<string> AllStringsWithMachedNumberOfParens(uint numberOfMatchedParensPairs)
        {
            if (numberOfMatchedParensPairs == 0) return new[] { string.Empty };

            var result = new List<string>();

            GenerateBalancedParensStrings(numberOfMatchedParensPairs, numberOfMatchedParensPairs, new StringBuilder(), result);

            return result;
        }

        private void GenerateBalancedParensStrings(uint leftParensNeeded, uint rightParensNeeded, StringBuilder prefix, ICollection<string> results)
        {
            if (leftParensNeeded == 0 && rightParensNeeded == 0)
            {
                results.Add(prefix.ToString());
                return;
            }

            if (leftParensNeeded > 0)
            {
                prefix.Append('(');
                GenerateBalancedParensStrings(leftParensNeeded - 1, rightParensNeeded, prefix, results);
                prefix.Remove(prefix.Length - 1, 1);
            }

            if (leftParensNeeded < rightParensNeeded)
            {
                prefix.Append(')');
                GenerateBalancedParensStrings(leftParensNeeded, rightParensNeeded - 1, prefix, results);
                prefix.Remove(prefix.Length - 1, 1);
            }
        }
    }
}
