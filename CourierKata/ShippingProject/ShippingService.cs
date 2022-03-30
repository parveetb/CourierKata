using ShippingProject.Helper;
using ShippingProject.Models;
using System;

namespace ShippingProject
{
    public class ShippingService
    {
        public static Shipping GetParcelCost(double length, double height, double width, double weight)
        {
            Shipping shipping = new Shipping();

            var dimensions = Calculate.CalculateDimensions(length, height, width);

            shipping.ParcelSize = Calculate.CalculateParcelSize(dimensions, weight);
            shipping.ParcelCost = Calculate.CalculateCostFromParcelSize(shipping.ParcelSize);
            shipping.OverWeightCharge = Calculate.CalculateOverweightCharge(shipping.ParcelSize, weight);

            shipping.TotalCost = shipping.ParcelCost + shipping.OverWeightCharge;

            return shipping;
        }

        public static Shipping GetShippingCost(double length, double height, double width, double weight, bool speedyShipping)
        {
            if (speedyShipping == true)
            {
                Shipping shippingCosts = GetParcelCost(length, height, width, weight);

                shippingCosts.IsSpeedyShipping = true;
                shippingCosts.SpeedyShippingCost = shippingCosts.ParcelCost;

                shippingCosts.TotalCost = shippingCosts.TotalCost + shippingCosts.SpeedyShippingCost;

                return shippingCosts;
            }
            else
            {
                return GetParcelCost(length, height, width, weight);
            }
        }
    }
}
