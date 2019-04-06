using System;
using System.Collections.Generic;
using ComputershareCodingChallenge.Objects;

namespace ComputershareCodingChallenge
{
    /// <summary>
    /// Stock object builder
    /// </summary>
    public static class StockBuilder
    {
        /// <summary>
        /// Builds stock objects from a list of strings
        /// </summary>
        /// <param name="stockPrices">The stock prices.</param>
        /// <returns>A list of stocks</returns>
        public static List<Stock> BuildStocks(string[] stockPrices)
        {
            List<Stock> monthlyStocks = new List<Stock>();

            for (int i = 0; i < stockPrices.Length; i++)
            {
                bool isDouble = double.TryParse(stockPrices[i], out double stockPrice);
                monthlyStocks.Add(new Stock { Day = i + 1, Price = isDouble ? stockPrice : HandleInvalidInput(stockPrices[i]) });
            }

            return monthlyStocks;
        }

        /// <summary>
        /// Handles the invalid input if a stock price cannot be parsed as a double 
        /// </summary>
        /// <param name="stockPrice">The stock price.</param>
        /// <returns>An expection to the user</returns>
        /// <exception cref="Exception">Input validation failed. The following value: {stockPrice}</exception>
        private static double HandleInvalidInput(string stockPrice)
        {
            throw new Exception($"Input validation failed. The following value: {stockPrice} is not valid. Please ensure the input file contains comma seperated decimals only.");
        }
    }
}
