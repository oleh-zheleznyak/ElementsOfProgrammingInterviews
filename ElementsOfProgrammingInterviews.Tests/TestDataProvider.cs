using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsOfProgrammingInterviews.Tests
{
    class TestDataProvider
    {
        public static IEnumerable<int> GeneratePowersOfTwo(int start, int end)
        {
            return Enumerable.Range(start, end).Select(x => (1 << x));
        }
    }
}
