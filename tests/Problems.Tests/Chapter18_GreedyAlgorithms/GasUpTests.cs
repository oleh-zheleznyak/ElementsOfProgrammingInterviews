using Problems.Chapter18_GreedyAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter18_GreedyAlgorithms;

public class GasUpTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindAmpleCityTest(City circularCityRoad, uint milesPerGallon, City expectedAmpleCity)
    {
        var sut = new GasUp();
        var actualAmpleCity = sut.FindAmpleCity(circularCityRoad, milesPerGallon);
        Assert.Equal(expectedAmpleCity, actualAmpleCity);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return Basic();
    }

    private static object[] Basic()
    {
        var first = new City("A", 10 + 1, 100,
            new City("B", 5, 50 + 1,
                        new City("C", 1, 10 + 1, null)));
        return new object[] { first, 10, first };
    }
}
