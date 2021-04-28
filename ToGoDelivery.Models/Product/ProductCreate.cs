using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Product
{
    public class ProductCreate
    {
        [Required]
        public string Name { get; set; }

        public int Inventory { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
