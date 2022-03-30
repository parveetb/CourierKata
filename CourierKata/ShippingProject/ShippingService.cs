using System;

namespace ShippingProject
{
    public class ShippingService
    {
        public static double CalculateDeliveryDimensions(double length, double height, double width)
        {
            var parcelDimensions = length + height + width;

            switch (parcelDimensions)
            {
                case < 10:
                    return 3;
                case < 50:
                    return 8;
                case < 100:
                    return 15;
                default:
                    return 25;
            }
        }
    }
}
