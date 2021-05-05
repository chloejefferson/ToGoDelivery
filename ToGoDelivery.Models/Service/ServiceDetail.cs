using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Service
{
    public class ServiceDetail
    {
        [Required]
        [Display(Name = "Service ID")]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required, Display(Name = "Active?")]
        public bool IsActive { get; set; }

        [Required, Display(Name = "Created")]
        public DateTime CreatedDate { get; set; }
    }
}

