using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class TheTowersOfHanoi
    {
        public enum Peg : byte
        {
            Source = 0,
            Destination = 1,
            Helper = 2,
        }

        private const byte NumberOfPegs = 3;
        private readonly IReadOnlyCollection<int> ringsForFirstPeg;
        private readonly Stack<int>[] pegs;

        public TheTowersOfHanoi(IReadOnlyCollection<int> ringsForFirstPeg)
        {
            this.pegs = new Stack<int>[NumberOfPegs];
            this.ringsForFirstPeg = InitializePegs(NumberOfPegs, ringsForFirstPeg);
        }

        public IReadOnlyCollection<int> GetPeg(Peg peg) => pegs[(int)peg];

        private Stack<int> this[Peg peg] => this.pegs[(int) peg];

        private IReadOnlyCollection<int> InitializePegs(byte numberOfPegs, IReadOnlyCollection<int> ringsForFirstPeg)
        {
            var ordered = ringsForFirstPeg.OrderByDescending(x => x).ToList();
            this.pegs[0] = new Stack<int>(ordered);
            for (int i = 1; i < numberOfPegs; i++)
                this.pegs[i] = new Stack<int>();
            return ordered;
        }

        public void MoveRingsToAnotherPeg()
        {
            var maxRingSize = ringsForFirstPeg.First();
            MoveRingsOfSizeAndSmaller(maxRingSize - 1, Peg.Source, Peg.Helper);
            MoveSingleRing(maxRingSize, Peg.Source, Peg.Destination);
            MoveRingsOfSizeAndSmaller(maxRingSize - 1, Peg.Helper, Peg.Destination);
        }

        private void MoveSingleRing(int ringSize, Peg sourcePeg, Peg destinationPeg)
        {
            var sourceRing = this[sourcePeg].Peek();
            var canMoveToDestination = this[destinationPeg].Count == 0 || this[destinationPeg].Peek() >= ringSize;
            if (sourceRing != ringSize || !canMoveToDestination)
            {
                var helperPeg = Enum.GetValues<Peg>().Where(x => x != sourcePeg && x != destinationPeg).Single();
                //MoveRingsOfSizeAndSmaller(ringSize - 1, sourcePeg, helperPeg);
                MoveRingsOfSizeAndSmaller(ringSize - 1, destinationPeg, helperPeg);
            }

            var ring = Take(sourcePeg);
            if (ring != ringSize) throw new InvalidOperationException("unexpected ring size");

            Emplace(ring, destinationPeg); // how do we know we can do this????
        }

        private void MoveRingsOfSizeAndSmaller(int ringSize, Peg sourcePeg, Peg destinationPeg)
        {
            if (ringSize == 0) return;
            if (pegs[(int)sourcePeg].Count == 0) return;
            if (ringSize == 1)
            {
                Move(ringSize, sourcePeg, destinationPeg);
                return;
            }

            var helperPeg = Enum.GetValues<Peg>().Where(x => x != sourcePeg && x != destinationPeg).Single();

            MoveRingsOfSizeAndSmaller(ringSize - 1, sourcePeg, helperPeg);
            MoveSingleRing(ringSize, sourcePeg, destinationPeg);
            MoveRingsOfSizeAndSmaller(ringSize - 1, helperPeg, destinationPeg);
        }

        private void Move(int ringSize, Peg source, Peg destination)
        {
            var peg = pegs[(int)source];
            if (peg.Count == 0) return;
            var ring = peg.Peek();

            if (ring <= ringSize)
            {
                peg.Pop();
                Emplace(ring, destination);
            }
        }

        private int Take(Peg pegName)
        {
            var peg = pegs[(int)pegName];
            if (peg.Count == 0) throw new InvalidOperationException("pet empty");
            return peg.Pop();
        }

        private void Emplace(int ring, Peg pegName)
        {
            var peg = pegs[(int)pegName];
            if (peg.Count == 0)
            {
                peg.Push(ring);
                return;
            }
            var ringOnTop = peg.Peek();
            if (ring > ringOnTop) throw new InvalidOperationException("cannot place a bigger ring on top of a smaller one");
            peg.Push(ring);
        }
    }
}
