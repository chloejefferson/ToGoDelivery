using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.OrderProduct;

namespace ToGoDelivery.Services
{
    public class OrderProductService
    {
        private readonly Guid _userId;
        public OrderProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrderProduct(int orderId, int productId)
        {
            var entity = new OrderProduct()
            {
               OrderId = orderId,
               ProductId = productId,
               ProductCount = 1,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrderProducts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        ////this info is already displayed in orderdetail
        //public IEnumerable<OrderProductListItem> GetOrderProductsByOrderId(int orderId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .OrderProducts
        //            .Include("Product")
        //            .Include("Order")
        //            //.Where(e => e.Order.CustomerId == _userId.ToString())
        //            .Where(e => e.OrderId == orderId)
        //            .Select(
        //                    e =>
        //                        new OrderProductListItem
        //                        {
        //                            OrderId = e.OrderId,
        //                            CustomerEmail = e.Order.Customer.Email,
        //                            ProductId = e.ProductId,
        //                            ProductName = e.Product.Name,
        //                            ProductCount = e.ProductCount,
        //                            Cost = e.Product.Cost * e.ProductCount
        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}

        public bool DeleteOrderProduct(int orderId, int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OrderProducts
                        .Single(e => e.OrderId == orderId && e.ProductId == productId);

                ctx.OrderProducts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public int GetCurrentOrderId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Orders
                    .Where(e => e.CustomerId == _userId.ToString() && !e.IsFinalized)
                    .OrderByDescending(e => e.DateCreated)
                    .First();

                int orderId = entity.OrderId;

                return orderId;
            }
        }

        public bool CheckForCurrentOrderProduct(int orderId, int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if(ctx.OrderProducts.Where(x => x.OrderId == orderId && x.ProductId ==productId).Any())
                {
                    return true;
                }
                return false;
            }
        }

        public bool AddProduct(int orderId, int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .OrderProducts
                    .Single(e => e.OrderId == orderId && e.ProductId == productId);

                entity.ProductCount++;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
