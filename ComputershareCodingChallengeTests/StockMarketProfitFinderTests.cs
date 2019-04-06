using System.Collections.Generic;
using System.Linq;
using ComputershareCodingChallenge;
using ComputershareCodingChallenge.Objects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputershareCodingChallengeTests
{
    /// <summary>
    /// Tests the ProfitableStockFinder
    /// </summary>
    [TestClass]
    public class StockMarketProfitFinderTests
    {
        /// <summary>
        /// Finds the best days to trade on - valid.
        /// </summary>
        [TestMethod]
        public void FindBestDaysToTradeOn_Valid()
        {
            // Arrange
            List<Stock> stocks = new List<Stock>
            {
                new Stock
                {
                    Day = 1,
                    Price = 1.00
                },
                new Stock
                {
                    Day = 2,
                    Price = 2.00
                }
            };

            // Act
            MostProfitableStocks mostProfitableStocks = ProfitableStockFinder.FindMostProfitableStocks(stocks);

            // Assert
            mostProfitableStocks.StockToBuy.Should().BeEquivalentTo(stocks.First());
            mostProfitableStocks.StockToSell.Should().BeEquivalentTo(stocks.Last());
        }

        /// <summary>
        /// Finds the best days to trade on - no stocks.
        /// </summary>
        [TestMethod]
        public void FindBestDaysToTradeOn_NoStocks()
        {
            // Arrange
            List<Stock> stocks = new List<Stock>();

            // Act
            MostProfitableStocks mostProfitableStocks = ProfitableStockFinder.FindMostProfitableStocks(stocks);

            // Assert
            mostProfitableStocks.Should().BeNull();
        }

        /// <summary>
        /// Finds the best days to trade on when there is no difference in stock price
        /// </summary>
        [TestMethod]
        public void FindBestDaysToTradeOn_NoDifferenceInMonthlystockPrice()
        {
            // Arrange
            List<Stock> stocks = new List<Stock>
            {
                new Stock
                {
                    Day = 1,
                    Price = 1.00
                },
                new Stock
                {
                    Day = 2,
                    Price = 1.00
                },
                new Stock
                {
                    Day = 3,
                    Price = 1.00
                },
                new Stock
                {
                    Day = 4,
                    Price = 1.00
                },
                new Stock
                {
                    Day = 5,
                    Price = 1.00
                },
            };

            // Act
            MostProfitableStocks mostProfitableStocks = ProfitableStockFinder.FindMostProfitableStocks(stocks);

            // Assert
            mostProfitableStocks.StockToBuy.Day.Should().Be(stocks[3].Day);
            mostProfitableStocks.StockToSell.Day.Should().Be(stocks[4].Day);
        }

        /// <summary>
        /// Finds the best days to trade on when the highest price is at the start of the month
        /// </summary>
        [TestMethod]
        public void FindBestDaysToTradeOn_StartOfMonthPeak()
        {
            // Arrange
            List<Stock> stocks = new List<Stock>
            {
                new Stock
                {
                    Day = 1,
                    Price = 10.00
                },
                new Stock
                {
                    Day = 2,
                    Price = 1.00
                }
            };

            // Act
            MostProfitableStocks mostProfitableStocks = ProfitableStockFinder.FindMostProfitableStocks(stocks);

            // Assert
            mostProfitableStocks.StockToBuy.Should().BeEquivalentTo(stocks.First());
            mostProfitableStocks.StockToSell.Should().BeEquivalentTo(stocks.Last());
        }
    }
}
