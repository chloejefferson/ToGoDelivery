using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;

namespace ToGoDelivery.Models.Order
{
    public class OrderListItem
    {
        [Required, Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Required, Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }

        [Required, Display(Name = "Created Date")]
        public DateTime DateCreated { get; set; }

        //[Required]
        //public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}"), Display(Name = "Final Total Cost")]
        public decimal FinalTotalCost { get; set; }

        //public bool IsFavorite { get; set; }

        //public bool IsPrepared { get; set; }

        //public bool IsFinalized { get; set; }

        //public DateTime DateFinalized { get; set; }
    }
}
