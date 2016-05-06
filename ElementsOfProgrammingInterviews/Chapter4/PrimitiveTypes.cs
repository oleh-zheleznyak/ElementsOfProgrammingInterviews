using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter4
{
    public class PrimitiveTypes
    {
        private const int intSize = 32;
        /// <summary>
        /// Computes number of bits that are set to one in a number
        /// Uses inefficient approach, with worst case performance of O(N) - evaluates all bits in an integer
        /// </summary>
        public byte ComputeNumberOfBitsSetTo1_Inefficient(int number)
        {
            const int one = 1;
            byte result = 0, count = 0;

            while (number > 0 && count < intSize)
            {
                if ((number & one) == one) result++;

                number = number >> 1;
                count++;
            }

            return result;
        }

        public byte ComputeNumberOfBitsSetTo1(int number)
        {
            byte result = 0, count = 0;

            while (number > 0 && count < intSize)
            {
                var previousComplement = ~((number - 1));

                var leastSignificantBit = number & previousComplement;

                if (leastSignificantBit > 0)
                {
                    number = number ^ leastSignificantBit;
                    result++;
                }

                count++;
            }

            return result;
        }

        public int RightPropagateRightmostBit(int number)
        {
            if (number == 0) return number;
            byte count = 0;
            int controlBit = 1, result = number;

            while ((result & controlBit) == 0 && count < intSize)
            {
                result = result | controlBit;
                controlBit = controlBit << 1;
                count++;
            }

            return result;
        }

        public bool IsPowerOfTwo(int number)
        {
            return ComputeNumberOfBitsSetTo1(number) == 1;
        }

        public int ModuloPowerOfTwo(int number, byte powerOfTwo)
        {
            if (powerOfTwo == 0) return 0;

            int computedPowerOfTwo = 1 << powerOfTwo;

            if (computedPowerOfTwo > number) return number;
            if (computedPowerOfTwo == number) return 0;

            byte count = 0;
            int eraser = 1;

            // eraser contains 1 in all positons up to, but not including the computedPowerOfTwo
            while ((eraser & computedPowerOfTwo) == 0 && count < intSize)
            {
                eraser = (eraser << 1) + 1;
            }
            eraser = eraser >> 1;

            int result = number & eraser;

            return result;
        }
    }
}
