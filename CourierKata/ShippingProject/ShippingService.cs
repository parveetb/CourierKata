﻿using ShippingProject.Helper;
using ShippingProject.Models;
using System;

namespace ShippingProject
{
    public class ShippingService
    {
        public static Shipping GetParcelCost(double length, double height, double width)
        {
            Shipping shipping = new Shipping();

            var dimensions = Calculate.CalculateDimensions(length, height, width);

            shipping.ParcelSize = Calculate.CalculateParcelSize(dimensions);
            shipping.ParcelCost = Calculate.CalculateCostFromParcelSize(shipping.ParcelSize);

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
    }
}
