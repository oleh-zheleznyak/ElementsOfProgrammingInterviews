using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter4
{
    public class PrimitiveTypes
    {
        public byte ComputeNumberOfBitsSetTo1(int number)
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
    }
}
