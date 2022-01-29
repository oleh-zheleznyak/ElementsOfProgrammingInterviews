using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public class GenerateStringsOfMatchedParens
    {
        private const string onePair = "()";
        public IReadOnlyCollection<string> AllStringsWithMachedNumberOfParens(uint numberOfMatchedParensPairs)
        {
            if (numberOfMatchedParensPairs == 0) return new[] { string.Empty };
            if (numberOfMatchedParensPairs == 1) return new[] { onePair };

            var result = GenerateStringsWithParens(numberOfMatchedParensPairs);

            return result;
        }

        private IReadOnlyCollection<string> GenerateStringsWithParens(uint numberOfMatchedParensPairs)
        {
            if (numberOfMatchedParensPairs == 1) return new[] { onePair };

            var resultForSmallerPair = GenerateStringsWithParens(numberOfMatchedParensPairs - 1U);

            var result = new List<string>(resultForSmallerPair.Count * 3); // possible overflow

            foreach (var item in resultForSmallerPair)
            {
                result.Add(Enclose(item));
                result.Add(item + onePair);
                if (onePair != item) result.Add(onePair + item);
            }

            return result;
        }

        private string Enclose(string item) => $"({item})";
    }
}
