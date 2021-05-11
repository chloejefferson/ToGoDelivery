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
                    .OrderBy(e => e.Name)
                    .Select(
                            e =>
                                new ProductListItem
                                {
                                   ProductId = e.ProductId,
                                   Name = e.Name,
                                   Inventory = e.Inventory,
                                   Cost = e.Cost,
                                   IsActive = e.IsActive,
                                }
                        );

                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == id);
                return
                new ProductDetail
                {
                    ProductId = entity.ProductId,
                    Name = entity.Name,
                    Inventory = entity.Inventory,
                    Cost = entity.Cost,
                    CreatedDate = entity.CreatedDate,
                    IsActive = entity.IsActive
                };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == model.ProductId);
                entity.Name = model.Name;
                entity.Inventory = model.Inventory;
                entity.Cost = model.Cost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool SoftDeleteProduct(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == id);

                entity.IsActive = false;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
