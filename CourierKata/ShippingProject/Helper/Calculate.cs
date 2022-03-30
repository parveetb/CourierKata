using ShippingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingProject.Helper
{
    public class Calculate
    {
        private static readonly double SmallWeightLimit = 1;

        private static readonly double MediumWeightLimit = 3;

        private static readonly double LargeWeightLimit = 6;

        private static readonly double XLWeightLimit = 10;

        private static readonly double CostPerKgOverWeight = 2;

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
