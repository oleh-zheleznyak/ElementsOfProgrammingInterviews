using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter4
{
    public class PrimitiveTypes
    {
        /// <summary>
        /// Computes number of bits that are set to one in a number
        /// Uses inefficient approach, with worst case performance of O(N) - evaluates all bits in an integer
        /// </summary>
        public byte ComputeNumberOfBitsSetTo1_Inefficient(int number)
        {
            const int one = 1, intSize = 32;
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
            const int intSize = 32;
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
    }
}
