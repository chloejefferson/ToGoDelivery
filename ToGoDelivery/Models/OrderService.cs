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
        [Key, Required, ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Key, Required, ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}