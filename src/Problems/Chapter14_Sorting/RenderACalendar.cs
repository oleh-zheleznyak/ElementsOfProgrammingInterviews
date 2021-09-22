using System;

namespace Problems.Chapter14_Sorting
{
    public class RenderACalendar
    {
        /// <summary>
        /// Render a calendar
        /// </summary>
        /// <remarks>
        /// Time complexity O(NlgN) - because of sorting
        /// Space complexity O(N) - because of storing dates
        /// </remarks>
        /// <param name="events">
        /// Array of events, could be easily extended to IReadonlyCollection of CalendarEvent
        /// </param>
        public int ComputeMaximumConcurrentEvents(CalendarEvent[] events)
        {
            if (events is null) throw new ArgumentNullException(nameof(events));
            if (events.Length < 2) return events.Length;

            (DateTime date, bool isStart)[] dateArray = ExtractEventTimesToArray(events);

            int max = ComputeMaximumSubsequentStarts(dateArray);

            return max;
        }

        private static (DateTime date, bool isStart)[] ExtractEventTimesToArray(CalendarEvent[] events)
        {
            var dateArray = new (DateTime date, bool isStart)[events.Length * 2];
            for (var i = 0; i < events.Length; i++)
            {
                dateArray[2 * i] = (events[i].StartDate, true);
                dateArray[2 * i + 1] = (events[i].EndDate, false);
            }
            Array.Sort(dateArray);
            return dateArray;
        }

        private static int ComputeMaximumSubsequentStarts((DateTime date, bool isStart)[] dateArray)
        {
            var sum = 0;
            var max = int.MinValue;
            for (int i = 0; i < dateArray.Length; i++)
            {
                if (dateArray[i].isStart) sum++;
                else sum--;

                if (sum > max) max = sum;
            }

            return max;
        }
    }
}
