using Problems.Chapter11_Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter11_Heaps
{
    public class ComputeKClosestStarsTests
    {
        // NOTE I did not want to add assembly reference just for point struct 
        // System.Windows.Media.Media3D.Point3D
        // Design would be better with with specific point class
        ComputeKClosestStars<(double x, double y, double z)> closestStars;

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeKClosestDataPointsTest(byte clusterSize, (double x, double y, double z)[] dataPoints, (double x, double y, double z)[] expectedCluster)
        {
            var comparer = new DistanceComparer();
            closestStars = new(comparer);

            var actual = closestStars.ComputeKClosestDataPoints(clusterSize, dataPoints);
            Assert.Equal(expectedCluster.OrderByDescending(x => x, comparer), actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                1,
                ToArray((1,1,1), (2,2,2)),
                ToArray((1,1,1)),
            };
            yield return new object[]
            {
                2,
                ToArray((1,1,1), (2,2,2), (1,1,2), (1,2,2)),
                ToArray((1,1,1), (1,1,2))
            };
        }

        public static (double x, double y, double z)[] ToArray(params (double x, double y, double z)[] points) => points;

        public class DistanceComparer : IComparer<(double x, double y, double z)>
        {
            public int Compare((double x, double y, double z) point1, (double x, double y, double z) point2) =>
                // possible overflow,
                // rounding makes some points appear as equal
                (int)Math.Round(distanceFromOrigin(point1) - distanceFromOrigin(point2));

            private double distanceFromOrigin((double x, double y, double z) point) =>
                Math.Sqrt(point.x * point.x + point.y * point.y + point.z * point.z); // possible overflow
        }
    }
}
