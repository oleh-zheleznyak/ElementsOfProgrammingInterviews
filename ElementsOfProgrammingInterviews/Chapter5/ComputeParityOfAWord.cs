using ElementsOfProgrammingInterviews.Chapter4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Chapter5
{
    public class ComputeParityOfAWord
    {
        public ComputeParityOfAWord(PrimitiveTypes bitCounter)
        {
            _bitCounter = bitCounter;
        }

        private readonly PrimitiveTypes _bitCounter;

        public bool[] ComputeParity(long[] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var cache = new Dictionary<short, byte>();

            var result = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = ComputeParity(input[i], cache);
            }

            return result;
        }

        private bool ComputeParity(long value, Dictionary<short, byte> cache)
        {
            // break up value in 8 pieces using shift
            // if cache does not contain the byte, then calculate parity and put in cache

            var countOfBitsSetTo1 = 0;
            var shortMask = ushort.MaxValue; // 65535 = (1111 1111 1111 1111)2
            var counter = 1;

            while(value > 0 && counter<=4)
            {
                short word = (short)(value & shortMask);
                byte bitsInWord;

                if (!cache.TryGetValue(word, out bitsInWord))
                {
                    bitsInWord = _bitCounter.ComputeNumberOfBitsSetTo1(word);
                    cache[word] = bitsInWord;
                }
                countOfBitsSetTo1 += bitsInWord;

                value = value >> (16 * counter);
                counter++;
            }

            return countOfBitsSetTo1 % 2 == 0;
        }

    }
}
