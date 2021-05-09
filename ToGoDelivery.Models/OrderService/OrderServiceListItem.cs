using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.OrderService
{
    public class OrderServiceListItem
    {
        public int OrderId { get; set; }

        public string CustomerEmail { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public decimal Cost { get; set; }
    }
}
