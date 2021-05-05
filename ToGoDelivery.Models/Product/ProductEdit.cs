using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Product
{
    public class ProductEdit
    {
        [Display(Name="Product ID")]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public int Inventory { get; set; }

        public decimal Cost { get; set; }
    }
}
