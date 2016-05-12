using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter5
{
    class ComputeParityOfAWord
    {
        public bool[] ComputeParity(long[] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var cache = new Dictionary<byte, byte>();

            var result = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ComputeParity(input[i], cache);
            }

            return result;
        }

        private bool ComputeParity(long value, Dictionary<byte, byte> cache)
        {
            // break up value in 8 pieces using shift
            // if cache does not contain the byte, then calculate parity and put in cache

            throw new NotImplementedException();
        }
    }
}
