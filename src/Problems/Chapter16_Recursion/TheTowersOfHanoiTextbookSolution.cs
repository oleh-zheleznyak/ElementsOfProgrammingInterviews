using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public class TheTowersOfHanoiTextbookSolution
    {
        private readonly int numberOfRings;
        private readonly Action<string>? logCallback;
        public const int NumberOfPegs = 3;
        private readonly Stack<int>[] pegs = new Stack<int>[NumberOfPegs];

        public TheTowersOfHanoiTextbookSolution(int numberOfRings, Action<string>? logCallback)
        {
            this.numberOfRings = numberOfRings;
            this.logCallback = logCallback;
            InitPegs();
            InitRingsOnFirstPeg();
        }

        public IReadOnlyCollection<int> GetPeg(int index) => pegs[index];
        
        private void InitPegs()
        {
            for (var i = 0; i < pegs.Length; i++)
                pegs[i] = new Stack<int>();
        }

        private void InitRingsOnFirstPeg()
        {
            for (var i = numberOfRings; i > 0; i--)
                pegs[0].Push(i);
        }

        public void MoveAllRingsToSecondPeg()
        {
            MoveNRingsToPeg(numberOfRings, 0, 1, 2);
        }

        private void MoveNRingsToPeg(int numberOfRings, int from, int to, int helper)
        {
            if (numberOfRings == 0) return;
            MoveNRingsToPeg(numberOfRings - 1, from, helper, to);
            MoveSingleRing(from, to);
            MoveNRingsToPeg(numberOfRings - 1, helper, to, from);
        }

        private void MoveSingleRing(int from, int to)
        {
            var ring = pegs[from].Pop();
            pegs[to].Push(ring);
            Log(from, to, ring);
        }

        private void Log(int fromPeg, int toPeg, int ringSize)
        {
            logCallback?.Invoke($"Moving ring of size {ringSize} from peg {fromPeg} to peg {toPeg}");
        }
    }
}