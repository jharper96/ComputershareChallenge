using System;
using System.Diagnostics.CodeAnalysis;
using ComputershareCodingChallenge.Objects;

namespace ComputershareCodingChallenge
{
    /// <summary>
    /// Used to output the most profitable stocks of the month
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class OutputMostProfitableStocks
    {
        /// <summary>
        /// Outputs the 2 most profitable stocks of the month to buy and sell to the user
        /// </summary>
        /// <param name="mostProfitableStocks"></param>
        public static void OutputStocks(MostProfitableStocks mostProfitableStocks)
        {
            Console.WriteLine($"{mostProfitableStocks.StockToBuy.Day}({mostProfitableStocks.StockToBuy.Price}), {mostProfitableStocks.StockToSell.Day}({mostProfitableStocks.StockToSell.Price})");

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
