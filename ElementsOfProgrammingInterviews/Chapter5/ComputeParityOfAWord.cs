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

        public IEnumerable<bool> ComputeParity(IEnumerable<long> input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var cache = new Dictionary<short, byte>();

            return input.Select(x => ComputeParity(x, cache));
        }

        private bool ComputeParity(long value, Dictionary<short, byte> cache)
        {
            // break up value in 4 pieces using 16 bit shift
            // if cache does not contain the short, then calculate parity and put in cache

            var countOfBitsSetTo1 = 0;
            var shortMask = ushort.MaxValue; // 65535 = (1111 1111 1111 1111)2
            var counter = 1;

            while (value > 0 && counter <= 4)
            {
                short word = (short)(value & shortMask);
                byte bitsInWord;

                //if (!cache.TryGetValue(word, out bitsInWord))
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
