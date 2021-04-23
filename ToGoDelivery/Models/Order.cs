using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Models
{
    public class Order
    {
        [Key, Required]
        public int OrderId { get; set; }

        //https://entityframework.net/knowledge-base/41274794/how-do-i-add-a-foreign-key-to-identity-user-in-ef-core-
        //[Required, ForeignKey(nameof(ApplicationUser))]
        //public Guid CustomerId { get; set; }
        //public virtual ApplicationUser Customer { get; set; }
        [Required]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public ApplicationUser Customer { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public decimal FinalTotalCost { get; set; }

        public bool IsFavorite { get; set; }
        
        //[ForeignKey(nameof(ApplicationUser))]
        //public ApplicationUser DriverId { get; set; }

        //public virtual ApplicationUser Driver { get; set; }

        //public string DriverId { get; set; }

        //[ForeignKey("DriverId")]
        //public ApplicationUser Driver { get; set; }

        public bool IsPrepared { get; set; }

        public bool IsFinalized { get; set; }

        public DateTime DateFinalized { get; set; }



    }
}