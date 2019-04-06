using System.Collections.Generic;
using System.Linq;
using ComputershareCodingChallenge.Objects;

namespace ComputershareCodingChallenge
{
    /// <summary>
    /// The Profitable Stock Finder
    /// </summary>
    public static class ProfitableStockFinder
    {
        /// <summary>
        /// Finds the 2 most profitable days to trade on by comparing the highest and lowest stock prices for the month.
        /// </summary>
        /// <param name="monthlyStocks"></param>
        /// <returns>The two best trading days to buy and sell on.</returns>
        public static MostProfitableStocks FindMostProfitableStocks(List<Stock> monthlyStocks)
        {
            double largestStockPriceDifference = 0;

            MostProfitableStocks mostProfitableMonthlyStocks = null;

            foreach (Stock stockToBuy in monthlyStocks)
            {
                foreach (Stock stockToSell in monthlyStocks.Where(x => x.Day > stockToBuy.Day))
                {
                    double stockPriceDifference = stockToSell.Price - stockToBuy.Price;

                    if (mostProfitableMonthlyStocks == null || stockPriceDifference >= largestStockPriceDifference)
                    {
                        largestStockPriceDifference = stockPriceDifference;

                        mostProfitableMonthlyStocks = new MostProfitableStocks { StockToBuy = stockToBuy, StockToSell = stockToSell };
                    }
                }
            }

            return mostProfitableMonthlyStocks;
        }
    }
}
