using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.OrderProduct;
using ToGoDelivery.Models.OrderService;

namespace ToGoDelivery.Models.Order
{
    public class OrderDetail
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public virtual IEnumerable<OrderProductListItem> OrderProducts { get; set; } = new List<OrderProductListItem>();
        public virtual IEnumerable<OrderServiceListItem> OrderServices { get; set; } = new List<OrderServiceListItem>();

        public decimal FinalTotalCost { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsPrepared { get; set; }

        public bool IsFinalized { get; set; }

        public DateTime? DateFinalized { get; set; }
    }
}
