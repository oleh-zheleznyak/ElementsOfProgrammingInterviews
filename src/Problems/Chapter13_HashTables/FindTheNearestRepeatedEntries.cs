using System;
using System.Collections.Generic;
using System.Globalization;

namespace Problems.Chapter13_HashTables
{
    public class FindTheNearestRepeatedEntries
    {
        public class Repetition
        {
            public Repetition(string word, int lastOccurrence)
            {
                Word = word;
                LastOccurrence = lastOccurrence;
                MinimumDistance = int.MaxValue;
            }

            public string Word { get; init; }
            public int MinimumDistance { get; set; }
            public int LastOccurrence { get; set; }
        };

        public Repetition? Find(string[] arrayOfWords)
        {
            if (arrayOfWords is null) throw new ArgumentNullException(nameof(arrayOfWords));
            if (arrayOfWords.Length == 0) return null;

            var repetitionsByWord = RepetitionsByWord(arrayOfWords);

            var repetitionWithMinDistance = FirstRepetitionWithMinDistance(repetitionsByWord);

            return repetitionWithMinDistance;
        }

        private static Repetition? FirstRepetitionWithMinDistance(Dictionary<string, Repetition>? repetitionsByWord)
        {
            var minDistance = int.MaxValue;
            Repetition? repetitionWithMinDistance = default;
            foreach (var repetition in repetitionsByWord.Values)
            {
                if (repetition.MinimumDistance < minDistance)
                {
                    minDistance = repetition.MinimumDistance;
                    repetitionWithMinDistance = repetition;
                }
            }

            return repetitionWithMinDistance;
        }

        private static Dictionary<string, Repetition>? RepetitionsByWord(string[] arrayOfWords)
        {
            var repetitionsByWord = new Dictionary<string, Repetition>();
            for (var i = 0; i < arrayOfWords.Length; i++)
            {
                var word = arrayOfWords[i];
                if (repetitionsByWord.TryGetValue(word, out var repetition))
                {
                    var distance = i - repetition.LastOccurrence - 1; // assume distance of zero between adjacent words
                    if (distance < repetition.MinimumDistance) repetition.MinimumDistance = distance;
                    repetition.LastOccurrence = i;
                }
                else
                {
                    var newRepetition = new Repetition(word, i);
                    repetitionsByWord[word] = newRepetition;
                }
            }

            return repetitionsByWord;
        }
    }
}