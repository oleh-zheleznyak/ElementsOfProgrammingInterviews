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
                // this won't work since the numbers are stored as 2s complement
                // and we get a negative number instead of a positive one
                var previousComplement = ~((number - 1));

                if ((number & previousComplement) > 0)
                {
                    number = number ^ previousComplement;
                    result++;
                }

                count++;
            }

            return result;
        }
    }
}
