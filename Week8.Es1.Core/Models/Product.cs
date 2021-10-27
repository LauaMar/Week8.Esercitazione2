using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8.Es1.Core.Models
{
    public class Product
    {
        public enum Typology {Elettronica, Abbigliamento, Casalinghi};
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public Typology Type { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal BuyingPrice { get; set; }
    }
}
