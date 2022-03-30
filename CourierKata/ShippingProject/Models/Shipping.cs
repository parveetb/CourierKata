using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingProject.Models
{
    public class Shipping
    {
        public double TotalCost { get; set; }

        public ParcelSize ParcelSize { get; set; }
        public double ParcelCost { get; set; }
    }


    public enum ParcelSize
    {
        Small,
        Medium,
        Large,
        XL
    }
}
