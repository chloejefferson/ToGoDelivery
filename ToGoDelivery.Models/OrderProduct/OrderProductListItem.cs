using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.OrderProduct
{
    public class OrderProductListItem
    {
        public int OrderId { get; set; }

        public string CustomerEmail { get; set; }

        public int ProductId { get; set; }

        public string ProductName{ get; set; }

        public int ProductCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}
