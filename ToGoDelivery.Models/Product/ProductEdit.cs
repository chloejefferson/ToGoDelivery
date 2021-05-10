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
        [Required, Display(Name="Product ID")]
        public int ProductId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}
