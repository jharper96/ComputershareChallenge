using System;
using System.Collections.Generic;
using System.IO;
using ComputershareCodingChallenge.Objects;

namespace ComputershareCodingChallenge
{
    /// <summary>
    /// The Coding Challenge
    /// </summary>
    public static class CodingChallenge
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            string[] stockPricesInput = File.ReadAllText(@"L:\StockPriceInputFiles\ChallengeSampleDataSet1.txt").Split(',');

            List<Stock> monthlyStocks = StockBuilder.BuildStocks(stockPricesInput);

            MostProfitableStocks mostProfitableMonthlystocks = ProfitableStockFinder.FindMostProfitableStocks(monthlyStocks);

            if (mostProfitableMonthlystocks != null)
            {
                OutputMostProfitableStocks.OutputStocks(mostProfitableMonthlystocks);
            }
            else
            {
                Console.WriteLine("No stock prices found in file. Please ensure the input file contains comma seperated decimals only.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
