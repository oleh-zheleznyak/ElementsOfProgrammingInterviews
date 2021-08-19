using System;

namespace Problems.Chapter05_PrimitiveTypes
{
    public class ParityOfAWord
    {
        public ulong CalculateParity_Linear(ulong word)
        {
            ulong parity = 0;
            while (word > 0)
            {
                var bit = word & 1;
                parity = parity ^ bit;
                word >>= 1;
            }

            return parity;
        }

        public ulong CalculateParity_Efficient(ulong word)
        {
            ulong parity = 0;
            while (word > 0)
            {
                parity = parity ^ 1;
                word &= (word - 1);
            }

            return parity;
        }

        public ushort CalculateParity_Efficient(ushort word)
        {
            ushort parity = 0;
            while (word > 0)
            {
                parity = (ushort)(parity ^ 1);
                word &= (ushort)(word - 1);
            }

            return parity;
        }

        public ulong CalculateParity_BruteForce(ulong[] words)
        {
            if (words is null) throw new ArgumentNullException(nameof(words));
            if (words.Length == 0) return 0;

            ulong parity = 0;
            foreach (var word in words)
            {
                parity = parity ^ CalculateParity_Linear(word);
            }

            return parity;
        }

        const byte wordSize = 16;
        public ulong CalculateParity_Cached(ulong[] words)
        {
            if (words is null) throw new ArgumentNullException(nameof(words));
            if (words.Length == 0) return 0;

            ushort?[] cachedParity = new ushort?[ushort.MaxValue];

            ulong parity = 0;
            foreach (var word in words)
            {
                ushort wordParity = 0;
                for (byte i = 0; i < 4; i++)
                {
                    ushort subWord = GetSubWord(word, i);

                    if (!cachedParity[subWord].HasValue)
                    {
                        cachedParity[subWord] = CalculateParity_Efficient(subWord);
                    }
                    wordParity = (ushort)(wordParity ^ cachedParity[subWord]!.Value);
                }
                parity = parity ^ wordParity;
            }

            return parity;
        }

        private ushort GetSubWord(ulong word, byte part)
        {
            return (ushort)((word >> (part * wordSize)) & ushort.MaxValue);
        }
    }
}
