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
        //Weight Limits
        private static readonly double SmallWeightLimit = 1;

        private static readonly double MediumWeightLimit = 3;

        private static readonly double LargeWeightLimit = 6;

        private static readonly double XLWeightLimit = 10;

        private static readonly double HeavyWeightLimit = 50;


        //Charge Per KG over weight
        private static readonly double CostPerKgOverWeight = 2;
        private static readonly double HeavyParcelCostPerKgOverWeight = 1;


        // ParcelSize Costs
        private static readonly double SmallParcelCost = 3;
        private static readonly double MediumParcelCost = 8;
        private static readonly double LargeParcelCost = 15;
        private static readonly double XLParcelCost = 25;
        private static readonly double HeavyParcelCost = 50;

        public static double CalculateCostFromParcelSize(ParcelSize parcelSize)
        {
            switch (parcelSize)
            {
                case ParcelSize.Small:
                    return SmallParcelCost;
                case ParcelSize.Medium:
                    return MediumParcelCost;
                case ParcelSize.Large:
                    return LargeParcelCost;
                case ParcelSize.XL:
                    return XLParcelCost;
                default:
                    return HeavyParcelCost;
            }
        }

        public static double CalculateDimensions(double length, double height, double width)
        {
            double dimensions = length + height + width;

            return dimensions;
        }

        public static ParcelSize CalculateParcelSize(double dimensions, double weight)
        {
            if (dimensions < 10 & weight < MediumWeightLimit)
                return ParcelSize.Small;
            if (dimensions < 50 & weight < LargeWeightLimit)
                return ParcelSize.Medium;
            if (dimensions < 100 & weight < XLWeightLimit)
                return ParcelSize.Large;
            if (dimensions > 100 & weight < HeavyWeightLimit)
                return ParcelSize.XL;
            return ParcelSize.Heavy;

        }

        public static double CalculateOverweightCharge(ParcelSize parcelSize, double weight)
        {
            double overWeightCost;

            switch (parcelSize)
            {
                case ParcelSize.Small:
                    if (weight > SmallWeightLimit)
                    {
                        return overWeightCost = (weight - SmallWeightLimit) * CostPerKgOverWeight;
                    }
                    break;
                case ParcelSize.Medium:
                    if (weight > MediumWeightLimit)
                    {
                        return overWeightCost = (weight - MediumWeightLimit) * CostPerKgOverWeight;
                    }
                    break;
                case ParcelSize.Large:
                    if (weight > LargeWeightLimit)
                    {
                        return overWeightCost = (weight - LargeWeightLimit) * CostPerKgOverWeight;
                    }
                    break;
                case ParcelSize.XL:
                    if (weight > XLWeightLimit)
                    {
                        return overWeightCost = (weight - XLWeightLimit) * CostPerKgOverWeight;
                    }
                    break;
                case ParcelSize.Heavy:
                    if (weight > HeavyWeightLimit)
                    {
                        return overWeightCost = (weight - HeavyWeightLimit) * HeavyParcelCostPerKgOverWeight;
                    }
                    break;
            }

            return 0;
        }

    }
}
