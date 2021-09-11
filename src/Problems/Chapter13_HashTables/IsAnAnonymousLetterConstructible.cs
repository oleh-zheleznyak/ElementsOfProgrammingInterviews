using System;
using System.Collections.Generic;
using System.Globalization;

namespace Problems.Chapter13_HashTables
{
    public class IsAnAnonymousLetterConstructible
    {
        public bool IsConstructibleFromText(string anonymousLetter, string magazine)
        {
            if (anonymousLetter is null) throw new ArgumentNullException(nameof(anonymousLetter));
            if (magazine is null) throw new ArgumentNullException(nameof(magazine));

            var graphemeCounts = getGraphemeCounts(anonymousLetter);

            var textEnumerator = StringInfo.GetTextElementEnumerator(magazine);
            while (textEnumerator.MoveNext())
            {
                var textElement = textEnumerator.GetTextElement();
                if (graphemeCounts.TryGetValue(textElement, out var counter))
                {
                    if (counter > 1)
                        graphemeCounts[textElement] = --counter;
                    else
                        graphemeCounts.Remove(textElement);
                }
            }

            return graphemeCounts.Count == 0;
        }

        private Dictionary<string, int> getGraphemeCounts(string magazine)
        {
            var graphemeCounts = new Dictionary<string, int>();
            var textEnumerator = StringInfo.GetTextElementEnumerator(magazine);
            while (textEnumerator.MoveNext())
            {
                var textElement = textEnumerator.GetTextElement();
                graphemeCounts[textElement] =
                    graphemeCounts.TryGetValue(textElement, out var count) ? ++count : 1;
            }

            return graphemeCounts;
        }
    }
}