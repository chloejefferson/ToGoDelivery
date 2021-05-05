﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToGoDelivery.Models.Product
{
    public class ProductCreate
    {
        [Required, MinLength(2, ErrorMessage = "Please enter at least 2 characters."), MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        public int Inventory { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}
