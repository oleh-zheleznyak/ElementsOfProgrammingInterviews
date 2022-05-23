using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter18_GreedyAlgorithms
{
    public record City(string Name, uint GalonsOfFuel,uint DistanceToNextCityInMiles, City NextCity);
    public class GasUp
    {
        // we can assume it exists
        public City FindAmpleCity(City circularCityRoad, uint milesPerGalon)
        {
            if (circularCityRoad is null) throw new ArgumentNullException(nameof(circularCityRoad));

            // brute force - try to start at every city + go full cycle - O(n^2)
            // how to do this is linear time? - precompute? cache?

            // select starting city
            var start = circularCityRoad;
            var current = circularCityRoad;
            while (current.NextCity != start && current.NextCity!=null)
            {
                var mileage = CalculateMileageStartingAt(current, milesPerGalon);
                if (mileage>0) return current;
                current = current.NextCity;
            }
            throw new InvalidOperationException("no ample city exists: precondition broken");
        }

        private long CalculateMileageStartingAt(City city, uint milesPerGalon)
        {
            var start = city;
            var current = city;
            long milesBasedOnFuelInTank = 0;
            while (current.NextCity != start && current.NextCity != null)
            {
                milesBasedOnFuelInTank += city.GalonsOfFuel * milesPerGalon;
                milesBasedOnFuelInTank -= city.DistanceToNextCityInMiles;
                if (milesBasedOnFuelInTank < 0) return milesBasedOnFuelInTank;

                current = current.NextCity;
            }
            return milesBasedOnFuelInTank;
        }
    }
}
