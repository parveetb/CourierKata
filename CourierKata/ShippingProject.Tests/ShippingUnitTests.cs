using NUnit.Framework;
using Newtonsoft.Json;
using ShippingProject;

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
        [TestCase(2, 2, 2, 3)]
        [TestCase(10, 10, 10, 8)]
        [TestCase(25, 25, 25, 15)]
        [TestCase(50, 50, 50, 25)]
        [TestCase(50, 25, 25, 25)]
        public void ReturnCorrectDeliveryCostForParcelsSize(double length, double height, double width, double expectedTotal)
        {
            //Arrange

            //Act
            double result = ShippingService.CalculateDeliveryDimensions(length, height, width);

            //Assert
            Assert.AreEqual(expectedTotal, result);
        }
    }
}