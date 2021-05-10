using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Product
{
    public class ProductListItem
    {
        [Required]
        public int ProductId { get; set; }

        [Required, MinLength(2, ErrorMessage = "Please enter at least 2 characters."), MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        public int Inventory { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }

        [Required, Display(Name="Active?")]
        public bool IsActive { get; set; }
    }
}
