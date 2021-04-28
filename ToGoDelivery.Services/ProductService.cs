using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.Product;

namespace ToGoDelivery.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate product)
        {
            var entity = new Product()
            {
                Name = product.Name,
                Inventory = product.Inventory,
                Cost = product.Cost,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Select(
                            e =>
                                new ProductListItem
                                {
                                   ProductId = e.ProductId,
                                   Name = e.Name,
                                   Inventory = e.Inventory,
                                   Cost = e.Cost,
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
