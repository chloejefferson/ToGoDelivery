using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToGoDelivery.Models
{
    public class Product
    {
        [Key, Required]
        public int ProductId { get; set; }
        
        public int Inventory { get; set; }
        
        [Required]
        public decimal Cost{ get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }

    //public class ProductDbContext : DbContext
    //{
    //    public DbSet<Product> Products { get; set; }
    //}
}