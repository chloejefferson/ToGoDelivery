using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Data
{
    public class Product
    {
        [Key, Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Inventory { get; set; }
        
        [Required]
        public decimal Cost{ get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }

    //public class ProductDbContext : DbContext
    //{
    //    public DbSet<Product> Products { get; set; }
    //}
}