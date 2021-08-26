using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter07_Strings
{
    /// <summary>
    /// 7.2 Replace and remove
    /// </summary>
    /// <remarks>
    /// We can assume there is enough space in the array to hold the final result
    /// </remarks>
    public class ReplaceAndRemove
    {
        public char[] Process_WithLinearMemory(char[] array, int numberOfElementsToProcess)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (numberOfElementsToProcess < 0 || numberOfElementsToProcess > array.Length) throw new ArgumentException(nameof(numberOfElementsToProcess));

            if (numberOfElementsToProcess == 0) return Array.Empty<char>();

            var (count_a, count_b) = CountOccurrences(array, numberOfElementsToProcess);
            if (count_a == 0 && count_b == 0) return array;

            var finalLength = numberOfElementsToProcess + count_a - count_b;

            var newArray = new char[finalLength];
            var j = 0;
            for (int i = 0; i < numberOfElementsToProcess; i++)
            {
                if (array[i] == 'a')
                {
                    newArray[j] = 'd';
                    j++;
                    newArray[j] = 'd';
                    j++;

                }
                else if (array[i] == 'b')
                {
                    // do nothing
                }
                else
                {
                    newArray[j] = array[i];
                    j++;
                }
            }
            return newArray;
        }

        public char[] Process_WithConstantMemory(char[] array, int numberOfElementsToProcess)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (numberOfElementsToProcess < 0 || numberOfElementsToProcess > array.Length) throw new ArgumentException(nameof(numberOfElementsToProcess));

            if (numberOfElementsToProcess == 0) return Array.Empty<char>();

            var (count_a, count_b) = CountOccurrences(array, numberOfElementsToProcess);
            if (count_a == 0 && count_b == 0) return array;

            if (count_b > 0) HandleRemovals(array, numberOfElementsToProcess);

            if (count_a > 0) HandleAdditions(array, numberOfElementsToProcess - count_b, count_a);

            return array;
        }

        private void HandleAdditions(char[] array, int numberOfElementsAfterRemovals, int count_a)
        {
            // Note: at this point the array is ONLY going to grow
            var tail = numberOfElementsAfterRemovals + count_a - 1;
            for (int i = numberOfElementsAfterRemovals - 1; i >= 0; i--)
            {
                if (array[i] == 'a')
                {
                    array[i] = 'd';
                    array[tail] = 'd';
                    tail--;
                }
                array[tail] = array[i];
                tail--;
            }
        }

        // TODO: how to handle cases when array becomes shorter? {b}->{}
        private static void HandleRemovals(char[] array, int numberOfElementsToProcess)
        {
            var shift = 0;
            for (int i = 0; i < numberOfElementsToProcess; i++)
            {
                if (array[i] == 'b')
                {
                    shift++;
                }
                if (shift > 0)
                {
                    array[i] = i + shift < array.Length ? array[i + shift] : char.MinValue; // in C# we could use Nullable<char>
                }
            }
        }

        private static (int, int) CountOccurrences(char[] array, int numberOfElementsToProcess)
        {
            var (count_a, count_b) = (0, 0);
            for (int i = 0; i < numberOfElementsToProcess; i++)
            {
                if (array[i] == 'a') count_a++;
                if (array[i] == 'b') count_b++;
            }
            return (count_a, count_b);
        }
    }
}
