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
        [TestCase(2, 2, 2, 3, 0, ParcelSize.Small, false)]
        [TestCase(10, 10, 10, 8, 0, ParcelSize.Medium, false)]
        [TestCase(25, 25, 25, 15, 0, ParcelSize.Large, false)]
        [TestCase(50, 50, 50, 25, 0, ParcelSize.XL, false)]
        [TestCase(2, 2, 2, 3, 3, ParcelSize.Small, true)]
        [TestCase(10, 10, 10, 8, 8, ParcelSize.Medium, true)]
        [TestCase(25, 25, 25, 15, 15, ParcelSize.Large, true)]
        [TestCase(50, 50, 50, 25, 25, ParcelSize.XL, true)]
        public void ReturnShippingCosts(double length, double height, double width, double expectedTotal, double speedyShippingCost, ParcelSize parcelSize, bool speedyShipping)
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
            var result = JsonConvert.SerializeObject(ShippingService.GetShippingCost(length, height, width, speedyShipping));

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        // Task 3 - apply an weight charge based on parcels

        [Test]
        [TestCase(2, ParcelSize.Small, 2)]

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