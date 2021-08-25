using System;
using System.Collections.Generic;

namespace Problems.Chapter07_Strings
{
    public class BaseConversion
    {
        public string ConvertBase(string numberBaseFrom, byte baseFrom, byte baseTo)
        {
            if (numberBaseFrom is null) throw new ArgumentNullException(nameof(numberBaseFrom));
            if (string.IsNullOrWhiteSpace(numberBaseFrom)) throw new ArgumentException(nameof(numberBaseFrom));
            if (baseFrom < 2 || baseFrom > 16) throw new ArgumentException(nameof(baseFrom));
            if (baseTo < 2 || baseTo > 16) throw new ArgumentException(nameof(baseTo));

            if (baseTo == baseFrom) return numberBaseFrom;
            if (numberBaseFrom == "1" || numberBaseFrom == "0") return numberBaseFrom;

            var numberBaseTen = ConvertToBaseTen(numberBaseFrom, baseFrom);

            var result = FormatInBaseFromMostSignificant(numberBaseTen, baseTo);

            return result;
        }

        private int ConvertToBaseTen(string numberBaseFrom, byte baseFrom)
        {
            var power = 1;
            var total = 0;
            for (int i = numberBaseFrom.Length - 1; i >= 0; i--)
            {
                total += CharToDigit(numberBaseFrom[i]) * power;
                power *= baseFrom;
            }
            return total;
        }

        /// <summary>
        /// Solution in the book uses string concatenation
        /// In many programming languages strings are immutable, and string concatenation
        /// creates a new string every time, copying old string, extra O(n) time, space 
        /// + pressure on GC
        /// (That is why .NET and Java have StringBuilder)
        /// </summary>
        private string FormatInBaseFromMostSignificant(int number, byte baseTo)
        {
            var (maxPower, baseToMaxPower) = CalculateMaxPower(number, baseTo);
            var charArray = new char[maxPower];
            var remainder = number;

            for (int i = 0; i < charArray.Length; i++)
            {
                baseToMaxPower /= baseTo;
                var multiplier = remainder / baseToMaxPower;
                charArray[i] = FormatIntAsChar(multiplier);
                remainder -= multiplier * baseToMaxPower;
            }
            return new string(charArray);
        }

        public string FormatInBaseFromLeastSignificant(int number, byte baseTo)
        {
            // not using linked list here to avoid object allocations (per LinkedListNode)
            // stack and queue are based on array, and increase size by a factor of two, just like list
            var numberAsString = new List<char>(); // no good approximation for capacity - we can't use number.ToString().Length
            int remainder = number;
            do
            {
                var least = remainder % baseTo;
                remainder /= baseTo;
                var c = FormatIntAsChar(least); 
                numberAsString.Add(c); // with List, adding at the end is most efficient, no shifting (or use linked list, queue)
            }
            while (remainder > 0);

            numberAsString.Reverse(); // additional pass
            
            return new string(numberAsString.ToArray()); // meh, two copies of string, one with .ToArray(), other inside string class
        }

        private char FormatIntAsChar(int number) =>
        number switch
        {
            (>= 0) and (< 10) => (char)('0' + number),
            (>= 10) and (<= 15) => (char)('A' + number - 10),
            _ => throw new ArgumentOutOfRangeException(),
        };

        private (int, int) CalculateMaxPower(int number, byte baseTo)
        {
            var counter = 0;
            var power = 1;
            while (number >= power)
            {
                power *= baseTo; // sub-optimal power calc, see Power.cs
                counter++;
            }
            return (counter, power);
        }

        private int CharToDigit(char c)
        {
            if (char.IsDigit(c))
            {
                return c - '0';
            }
            else if (c>='A' && c<='F')
            {
                return c - 'A' + 10;
            }
            throw new ArgumentException(nameof(c));
        }
    }
}
