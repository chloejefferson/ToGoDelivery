using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Models
{
    public class OrderProduct
    {
        [Key, Required, ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Key, Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required, Range(1,Int32.MaxValue)]
        public int ProductCount { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}