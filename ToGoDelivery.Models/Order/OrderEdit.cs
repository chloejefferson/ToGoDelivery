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
    public class OrderEdit
    {
        //This may be built out to change order details such as the driver and bool statuses
        [Key, Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }

        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Created Date")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}"), Display(Name = "Final Total Cost")]
        public decimal FinalTotalCost { get; set; }

        [Display(Name = "Favorite?")]
        public bool IsFavorite { get; set; }

        [Display(Name = "Prepared?")]
        public bool IsPrepared { get; set; }

        [Display(Name = "Finalized?")]
        public bool IsFinalized { get; set; }

        [Display(Name = "Finalized Date")]
        public DateTime? DateFinalized { get; set; }
    }
}
