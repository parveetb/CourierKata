using NUnit.Framework;
using Newtonsoft.Json;
using ShippingProject;
using ShippingProject.Models;
using ShippingProject.Helper;

namespace ShippingProject.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test Case 1, Ensure Method returns correct parcel size and cost based on dimensions

        [Test]
        [TestCase(ParcelSize.Small, 3)]
        [TestCase(ParcelSize.Medium, 8)]
        [TestCase(ParcelSize.Large, 15)]
        [TestCase(ParcelSize.XL, 25)]
        [TestCase(ParcelSize.XL, 25)]
        public void ReturnCorrectDeliveryCostForParcelSize(ParcelSize parcelSize, double expectedTotal)
        {
            //Arrange
            //Act
            var result = Calculate.CalculateCostFromParcelSize(parcelSize);

            //Assert
            Assert.AreEqual(expectedTotal, result);
        }


        [Test]
        [TestCase(2, 2, 2, 6)]
        [TestCase(10, 10, 10, 30)]
        [TestCase(25, 25, 25, 75)]
        [TestCase(50, 50, 50, 150)]
        [TestCase(50, 25, 25, 100)]
        public void ReturnCorrectDimenions(double length, double height, double width, double expectedTotal)
        {
            //Arrange

            //Act
            var result = Calculate.CalculateDimensions(length, height, width);

            //Assert
            Assert.AreEqual(expectedTotal, result);

        }

        [Test]
        [TestCase(6, 2, ParcelSize.Small)]
        [TestCase(9, 4, ParcelSize.Medium)]
        [TestCase(6, 8, ParcelSize.Large)]

        [TestCase(30, 7, ParcelSize.Large)]
        [TestCase(30, 3, ParcelSize.Medium)]

        [TestCase(75, 5, ParcelSize.Large)]
        [TestCase(75, 8, ParcelSize.Large)]
        public void ReturnCorrectParzelSize(double dimensions, double weight, ParcelSize expectedParcelSize)
        {
            //Arrange

            //Act
            var result = Calculate.CalculateParcelSize(dimensions, weight);

            //Assert
            Assert.AreEqual(expectedParcelSize, result);

        }

        [Test]
        [TestCase(2, 2, 2, 1, 3, 0, ParcelSize.Small, false)]
        [TestCase(10, 10, 10, 2, 8, 0, ParcelSize.Medium, false)]
        [TestCase(25, 25, 25, 5, 15, 0, ParcelSize.Large, false)]
        [TestCase(50, 50, 50, 9, 25, 0, ParcelSize.XL, false)]
        [TestCase(2, 2, 2, 1, 3, 3, ParcelSize.Small, true)]
        [TestCase(10, 10, 10, 2, 8, 8, ParcelSize.Medium, true)]
        [TestCase(25, 25, 25, 5, 15, 15, ParcelSize.Large, true)]
        [TestCase(50, 50, 50, 9, 25, 25, ParcelSize.XL, true)]
        public void ReturnShippingCosts(double length, double height, double width, double weight, double expectedTotal, double speedyShippingCost, ParcelSize parcelSize, bool speedyShipping)
        {
            //Arrange
            Shipping shipping = new Shipping()
            {
                ParcelCost = expectedTotal,
                ParcelSize = parcelSize,
                SpeedyShippingCost = speedyShippingCost,
                TotalCost = expectedTotal + speedyShippingCost,
                IsSpeedyShipping = speedyShipping
            };

            var expectedResult = JsonConvert.SerializeObject(shipping);

            //Act
            var result = JsonConvert.SerializeObject(ShippingService.GetShippingCost(length, height, width, weight, speedyShipping));

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // Task 3 - apply an weight charge based on parcels

        [Test]
        [TestCase(2, ParcelSize.Small, 2)]
        [TestCase(1, ParcelSize.Small, 0)]

        [TestCase(5, ParcelSize.Medium, 4)]
        [TestCase(2, ParcelSize.Medium, 0)]

        [TestCase(9, ParcelSize.Large, 6)]
        [TestCase(5, ParcelSize.Large, 0)]

        [TestCase(15, ParcelSize.XL, 10)]
        [TestCase(9, ParcelSize.XL, 0)]

        public void ReturnCorrectWeightCharge(double weight, ParcelSize parcelSize, double expectedOverWeightCharge)
        {
            //Arrange

            //Act
            var result = Calculate.CalculateOverweightCharge(parcelSize, weight);

            //Assert
            Assert.AreEqual(expectedOverWeightCharge, result);
        }
    }
}