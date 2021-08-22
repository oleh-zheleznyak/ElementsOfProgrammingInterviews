using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter07_Strings
{
    /// <summary>
    /// 7.1 Interconvert strings and integers
    /// </summary>
    /// <remarks>
    /// Cannot use library functions
    /// </remarks>
    public class IntercovertStringsAndIntegers
    {
        private const char Zero = '0'; // charcode 048
        private const char Nine = '9'; // charcode 057
        /// <summary>
        /// Converts string to integer
        /// </summary>
        /// <remarks>
        /// Cannot use Int.Parse or Convert.ToInt32
        /// Will NOT support IFormatProviders or NumberStyles in this excersise
        /// </remarks>
        public int StringToInteger(string input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input));
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException(nameof(input));

            int result = 0;
            int power = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char c = input[i];
                if (char.IsDigit(c)) // trivial to check by ASCII char code
                {
                    result += (c - Zero) * power;
                }
                else if (c == '-' && i == 0)
                {
                    result = -result;
                }
                power *= 10;
            }
            return result;
        }

        /// <summary>
        /// Converts int to string
        /// </summary>
        /// <remarks>
        /// Cannot use overload of Int.ToString or Convert.ToString
        /// Here, we can either use StringBuilder, List(array list) or LinkedList
        /// </remarks>
        public string IntegerToString(int input)
        {
            if (input == 0) return "0";
            int power = 10;
            bool neagative = input < 0;
            if (neagative) input = -input; // or Math.Abs
            var inputCopy = input;

            // count the number of characters
            var counter = 0;
            while (inputCopy > 0)
            {
                inputCopy /= 10;
                counter++;
            }
            var charArray = new char[counter + (neagative ? 1 : 0)];

            while (input > 0)
            {
                int lastDigit = input - (input / power) * power;
                char digitChar = (char)(Zero + lastDigit);
                charArray[--counter + (neagative ? 1 : 0)] =digitChar;
                input = input / 10;
            }
            if (neagative) charArray[0] = '-';
            var result = new string(charArray);
            return result;
        }
    }
}
