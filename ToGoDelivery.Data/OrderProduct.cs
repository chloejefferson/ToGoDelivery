using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Data
{
    public class OrderProduct
    {
        [Key, ForeignKey(nameof(Order))]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Key, ForeignKey(nameof(Product))]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required, Range(1,Int32.MaxValue)]
        public int ProductCount { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}