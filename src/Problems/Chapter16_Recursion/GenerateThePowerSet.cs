using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    /// <summary>
    /// 16.4 Generate the power set
    /// </summary>
    public class GenerateThePowerSet<T>
    {
        public IEnumerable<ISet<T>> PowerSetOf(ISet<T> set)
        {
            if (set is null) throw new ArgumentNullException(nameof(set));

            var allNbitWords = new List<bool[]>();
            var emptyWordToStartWith = new bool[set.Count];

            AddAllPossibleNbitWordsTo(allNbitWords, emptyWordToStartWith, 0);

            var result = TranslateWordsToSets(set, allNbitWords);

            return result;
        }

        private IEnumerable<ISet<T>> TranslateWordsToSets(ISet<T> set, List<bool[]> words)
        {
            var elements = set.ToArray();
            var result = new List<ISet<T>>();

            foreach (var word in words)
            {
                var setForWord = new HashSet<T>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i]) setForWord.Add(elements[i]);
                }
                result.Add(setForWord);
            }

            return result;
        }

        private void AddAllPossibleNbitWordsTo(ICollection<bool[]> results, bool[] word, int index)
        {
            if (index == word.Length)
            {
                results.Add(word);
                return;
            }

            AddAllPossibleNbitWordsWithIndexBitSet(results, word, index, true);
            AddAllPossibleNbitWordsWithIndexBitSet(results, word, index, false);
        }

        private void AddAllPossibleNbitWordsWithIndexBitSet(ICollection<bool[]> results, bool[] wordToModify, int index, bool bitValueToSet)
        {
            var copyOfWord = wordToModify.ToArray();
            copyOfWord[index] = bitValueToSet;
            AddAllPossibleNbitWordsTo(results, copyOfWord, index + 1);
        }
    }
}
