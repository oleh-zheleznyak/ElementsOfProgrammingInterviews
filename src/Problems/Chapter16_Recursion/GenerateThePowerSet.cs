﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    /// <summary>
    /// 16.4 Generate the power set
    /// </summary>
    public class GenerateThePowerSet<T>
    {
        public IReadOnlyCollection<ISet<T>> PowerSetOf(ISet<T> set)
        {
            if (set is null) throw new ArgumentNullException(nameof(set));

            var setSize = set.Count;
            var emptyWordToStartWith = new bool[setSize];

            var powerSetSize = Math.Pow(2, setSize);
            if (powerSetSize > int.MaxValue) throw new ArgumentException("Set too large, cannot compute more than int.MaxValue permutations");
            var allNbitWords = new List<bool[]>((int)powerSetSize);

            AddAllPossibleNbitWordsTo(allNbitWords, emptyWordToStartWith, 0);

            var result = TranslateWordsToSets(set, allNbitWords);

            return result;
        }

        private IReadOnlyCollection<ISet<T>> TranslateWordsToSets(ISet<T> set, List<bool[]> words)
        {
            var elements = set.ToArray();
            var result = new List<ISet<T>>(words.Count);

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
        /// <summary>
        /// Recurrence C(n)=2C(n-1) => C(n)=2^n
        /// </summary>
        private void AddAllPossibleNbitWordsTo(ICollection<bool[]> results, bool[] word, int index)
        {
            if (index == word.Length)
            {
                results.Add(word.ToArray());
                return;
            }

            AddAllPossibleNbitWordsWithIndexBitSet(results, word, index, true);
            AddAllPossibleNbitWordsWithIndexBitSet(results, word, index, false);
        }

        private void AddAllPossibleNbitWordsWithIndexBitSet(ICollection<bool[]> results, bool[] wordToModify, int index, bool bitValueToSet)
        {
            wordToModify[index] = bitValueToSet;
            AddAllPossibleNbitWordsTo(results, wordToModify, index + 1);
        }
    }
}
