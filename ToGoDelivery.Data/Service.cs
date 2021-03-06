using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Data
{ 
    public class Service
    {
        [Key, Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public bool IsActive { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}