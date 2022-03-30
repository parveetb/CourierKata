using NUnit.Framework;
using Newtonsoft.Json;
using ShippingProject;
using ShippingProject.Models;

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
            var result = ShippingService.CalculateCostFromParcelSize(parcelSize);

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
            var result = ShippingService.CalculateDimensions(length, height, width);

            //Assert
            Assert.AreEqual(expectedTotal, result);

        }

        [Test]
        [TestCase(2, 2, 2, 3, ParcelSize.Small)]
        [TestCase(10, 10, 10, 8, ParcelSize.Medium)]
        [TestCase(25, 25, 25, 15, ParcelSize.Large)]
        [TestCase(50, 50, 50, 25, ParcelSize.XL)]
        [TestCase(50, 25, 25, 25, ParcelSize.XL)]
        public void ReturnShippingCosts(double length, double height, double width, double expectedTotal, ParcelSize parcelSize)
        {
            //Arrange
            Shipping shipping = new Shipping()
            {
                ParcelCost = expectedTotal,
                ParcelSize = parcelSize,
                TotalCost = expectedTotal
            };

            var expectedResult = JsonConvert.SerializeObject(shipping);

            //Act
            var result = JsonConvert.SerializeObject(ShippingService.GetShippingCost(length, height, width));

            //Assert
            Assert.AreEqual(expectedResult, result);

        }



    }
}