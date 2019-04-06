namespace ComputershareCodingChallenge.Objects
{
    /// <summary>
    /// Most profitable stocks contains the 2 best stocks to buy in the month.
    /// </summary>
    public class MostProfitableStocks
    {
        /// <summary>
        /// The stock to buy
        /// </summary>
        public Stock StockToBuy { get; set; }

        /// <summary>
        /// The stock to sell
        /// </summary>
        public Stock StockToSell { get; set; }
    }
}
