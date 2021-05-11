using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Service
{
    public class ServiceEdit
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}
