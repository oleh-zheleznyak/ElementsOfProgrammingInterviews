using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public readonly record struct Interval(int Start, int End)
    {
        public bool IntersectsWith(Interval other)
        {
            return 
                (other.Start>=this.Start && other.Start<=this.End) ||
                (other.End>=this.Start && other.End<=this.End);
        }

        public bool Contains(int point)
        {
            return point>=this.Start && point<=this.End;
        }
    } // TODO: validation Start<=End

    public class IntervalCovering
    {
        public IReadOnlyCollection<int> FindMinimalCoverage(IReadOnlyCollection<Interval> intervals)
        {
            if (intervals is null) throw new ArgumentNullException(nameof(intervals));
            if (intervals.Count==0) return Array.Empty<int>();
            if (intervals.Count == 1) return new int[] { intervals.First().Start };

            // sort - by start or end ?? 
            var coverage = new List<int>();
            var sortedIntervals = intervals.OrderBy(interval => interval.End).ToList(); // O(nlgn) time, O(n) space
            var prevInterval = sortedIntervals.First();
            var end = prevInterval.End;
            for (int i = 1; i < sortedIntervals.Count; i++)
            {
                var currentInterval = sortedIntervals[i];
                if (!currentInterval.Contains(end))
                { 
                    coverage.Add(end);
                    end = currentInterval.End;
                }
            }
            coverage.Add(end);
            return coverage;
        }
    }
}
