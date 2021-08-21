using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Chapter06_Arrays
{
    public class BuyAndSellAStockOnce
    {
        public double MaximumProfit(double[] stockPrices)
        {
            if (stockPrices is null) throw new ArgumentNullException(nameof(stockPrices));
            if (stockPrices.Length <=1) return 0;

            var maxProfit = 0D;
            var minPrice = double.MaxValue;

            for (int i = 0; i < stockPrices.Length; i++)
            {
                if (stockPrices[i] < minPrice) minPrice = stockPrices[i];

                var profit = stockPrices[i] - minPrice;
                if (profit > maxProfit) maxProfit = profit;
            }

            return maxProfit;
        }
    }
}
