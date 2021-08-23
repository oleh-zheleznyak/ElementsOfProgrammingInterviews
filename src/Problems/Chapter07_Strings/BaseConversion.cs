using System;

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
            if (numberBaseFrom == "1") return "1";

            var numberBaseTen = ConvertToBaseTen(numberBaseFrom, baseFrom);

            var result = FormatInBase(numberBaseTen, baseTo);

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

        private string FormatInBase(int number, byte baseTo)
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
            if (c>='A' && c<='F')
            {
                return c - 'A' + 10;
            }
            throw new ArgumentException(nameof(c));
        }
    }
}
