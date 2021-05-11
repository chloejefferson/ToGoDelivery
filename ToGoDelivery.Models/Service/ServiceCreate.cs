using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Service
{
    public class ServiceCreate
    {
        [Required, MinLength(2, ErrorMessage = "Please enter at least 2 characters."), MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}