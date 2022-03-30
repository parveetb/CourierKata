using ShippingProject.Models;
using System;

namespace ShippingProject
{
    public class ShippingService
    {
        public static Shipping GetParcelCost(double length, double height, double width)
        {
            Shipping shipping = new Shipping();

            var dimensions = CalculateDimensions(length, height, width);

            shipping.ParcelSize = CalculateParcelSize(dimensions);
            shipping.ParcelCost = CalculateCostFromParcelSize(shipping.ParcelSize);

            shipping.TotalCost = shipping.ParcelCost;

            return shipping;
        }

        public static Shipping GetShippingCost(double length, double height, double width, bool speedyShipping)
        {
            if (speedyShipping == true)
            {
                Shipping shippingCosts = GetParcelCost(length, height, width);

                shippingCosts.IsSpeedyShipping = true;
                shippingCosts.SpeedyShippingCost = shippingCosts.ParcelCost;
                shippingCosts.TotalCost = shippingCosts.ParcelCost + shippingCosts.SpeedyShippingCost;

                return shippingCosts;
            }
            else
            {
                return GetParcelCost(length, height, width);
            }
        }

            public static double CalculateCostFromParcelSize(ParcelSize parcelSize)
        {
            switch (parcelSize)
            {
                case ParcelSize.Small:
                    return 3;
                case ParcelSize.Medium:
                    return 8;
                case ParcelSize.Large:
                    return 15;
                default:
                    return 25;
            }
        }

        public static double CalculateDimensions(double length, double height, double width)
        {
            double dimensions = length + height + width;

            return dimensions;
        }

        public static ParcelSize CalculateParcelSize(double dimensions)
        {
            if (dimensions < 10)
                return ParcelSize.Small;
            if (dimensions < 50)
                return ParcelSize.Medium;
            if (dimensions < 100)
                return ParcelSize.Large;

            return ParcelSize.XL;

        }
    }
}
