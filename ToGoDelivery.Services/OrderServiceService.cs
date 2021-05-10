using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.OrderService;

namespace ToGoDelivery.Services
{
    public class OrderServiceService
    {
        private readonly Guid _userId;
        public OrderServiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrderService(int orderId, int productId)
        {
            var entity = new Data.OrderService()
            {
                OrderId = orderId,
                ServiceId = productId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.OrderServices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderServiceListItem> GetOrderServicesByOrderId(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .OrderServices
                    .Include("Service")
                    .Include("Order")
                    .Where(e => e.OrderId == orderId)
                    .Select(
                            e =>
                                new OrderServiceListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerEmail = e.Order.Customer.Email,
                                    ServiceId = e.ServiceId,
                                    ServiceName = e.Service.Name,
                                    Cost = e.Service.Cost,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool DeleteOrderService(int orderId, int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .OrderServices
                        .Single(e => e.OrderId == orderId && e.ServiceId == serviceId);

                ctx.OrderServices.Remove(entity);

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
    }
}
