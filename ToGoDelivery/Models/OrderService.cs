using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Models
{
    public class OrderService
    {
        [Key, ForeignKey(nameof(Order))]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Key, ForeignKey(nameof(Service))]
        [Column(Order = 2)]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public decimal Cost { get; set; }
    }
}