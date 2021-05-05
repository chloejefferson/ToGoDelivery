using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Product
{
    public class ProductDetail
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Inventory { get; set; }

        public decimal Cost { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedDate { get; set; }
    }
}

