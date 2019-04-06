using System;
using System.Collections.Generic;
using ComputershareCodingChallenge;
using ComputershareCodingChallenge.Objects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputershareCodingChallengeTests
{
    /// <summary>
    /// Tests for the StockBuilder class
    /// </summary>
    [TestClass]
    public class StockBuilderTests
    {
        /// <summary>
        /// Populates the stocks - valid.
        /// </summary>
        [TestMethod]
        public void PopulateStocks_Valid()
        {
            // Arrange
            string stockPrice = "1.0";
            string[] stockPrices = { stockPrice };

            List<Stock> expectedstocks = new List<Stock>
            {
                new Stock
                {
                    Day = 1,
                    Price = 1.0
                }
            };

            // Act
            List<Stock> actualStocks = StockBuilder.BuildStocks(stockPrices);

            // Assert
            expectedstocks.Should().BeEquivalentTo(actualStocks);
        }

        /// <summary>
        /// Populates the stocks when an the empty array is passed in.
        /// </summary>
        [TestMethod]
        public void PopulateStocks_EmptyArray()
        {
            // Arrange
            string[] stockPrices = new string[0];

            // Act
            List<Stock> stocksOutput = StockBuilder.BuildStocks(stockPrices);

            // Assert
            stocksOutput.Count.Should().Be(0);
        }

        /// <summary>
        /// Populates the stocks when an empty string array is passed in.
        /// </summary>
        [TestMethod]
        public void PopulateStocks_EmptyStringArray()
        {
            // Arrange
            // Simulate empty file being loaded
            string[] stockPrices = new string[] { "" };

            try
            {
                // Act
                StockBuilder.BuildStocks(stockPrices);
            }
            catch (Exception e)
            {
                // Assert
                e.Message.Should().Contain("The following value:  is not valid");
            }
        }

        /// <summary>
        /// Populates the stocks when an invalid decimal is passed in.
        /// </summary>
        [TestMethod]
        public void PopulateStocks_InvalidDecimal()
        {
            // Arrange
            // Value that can't be parsed as a double 
            string invalidInput = "Test";

            string[] stockPrices = new string[] { invalidInput };

            try
            {
                // Act
                StockBuilder.BuildStocks(stockPrices);
            }
            catch (Exception e)
            {
                // Assert
                e.Message.Should().Contain($"The following value: {invalidInput} is not valid");
            }
        }
    }
}
