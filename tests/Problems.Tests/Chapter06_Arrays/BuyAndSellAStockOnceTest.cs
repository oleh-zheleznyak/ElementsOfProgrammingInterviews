using Problems.Chapter06_Arrays;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class BuyAndSellAStockOnceTest
    {
        BuyAndSellAStockOnce buyAndSellAStockOnce = new BuyAndSellAStockOnce();

        [Theory]
        [InlineData(new double[] { 310, 315, 275, 295, 260, 270, 290, 230, 255, 250 }, 30)]
        [InlineData(new double[] { 5, 4, 3, 2, 1, 6 }, 5)]
        [InlineData(new double[] { 4, 5, 6, 2 }, 2)]
        [InlineData(new double[] { 1, 1, 1 }, 0)]
        public void MaxProfitTest(double[] stockPrices, double expectedMaxProfit)
        {
            var actualProfit = buyAndSellAStockOnce.MaximumProfit(stockPrices);
            Assert.Equal(expectedMaxProfit, actualProfit);
        }
    }
}
