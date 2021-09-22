using Problems.Chapter14_Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter14_Sorting
{
    public class RenderACalendarTests
    {
        private readonly RenderACalendar renderACalendar = new();
        private static readonly DateTime startTime = DateTime.Now;

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeMaximumConcurrentEventsTests(CalendarEvent[] calendarEvents, int expectedMaxConcurrentEvents)
        {
            var actual = renderACalendar.ComputeMaximumConcurrentEvents(calendarEvents);
            Assert.Equal(expectedMaxConcurrentEvents, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return NonOverlappingEvents;
            yield return OverlappingEventsOneIncludesTheOther;
            yield return OverlappingEventsLadder;
        }

        private static object[] NonOverlappingEvents => new object[]
        {
            new CalendarEvent[]
            {
                new(startTime,startTime + TimeSpan.FromHours(1), "one hour meeting"),
                new(startTime + TimeSpan.FromHours(2), startTime + TimeSpan.FromHours(3), "one hour meeting an hour later"),
            },
            1
        };

        private static object[] OverlappingEventsOneIncludesTheOther => new object[]
        {
            new CalendarEvent[]
            {
                new(startTime,startTime + TimeSpan.FromHours(3), "one three hour meeting"),
                new(startTime + TimeSpan.FromHours(1), startTime + TimeSpan.FromHours(2), "one hour meeting inside three hour meeting"),
            },
            2
        };
        private static object[] OverlappingEventsLadder => new object[]
        {
            new CalendarEvent[]
            {
                new(startTime,startTime + TimeSpan.FromHours(2), "first two hours"),
                new(startTime + TimeSpan.FromHours(1), startTime + TimeSpan.FromHours(3), "second two hours"),
                new(startTime + TimeSpan.FromHours(2), startTime + TimeSpan.FromHours(4), "third two hours"),
            },
            2
        };
    }
}
