using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.Order;
using ToGoDelivery.Models.OrderProduct;
using ToGoDelivery.Models.OrderService;

namespace ToGoDelivery.Services
{
    public class OrderService
    {
        private readonly Guid _userId;
        public static int? _currentOrderId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder()
        {
            var entity = new Order()
            {
                CustomerId = _userId.ToString(),
                DateCreated = DateTime.Now,
                IsActive = true,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                _currentOrderId = entity.OrderId;
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetAllOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Orders
                    .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerId = e.CustomerId,
                                    Customer = e.Customer,
                                    DateCreated = e.DateCreated,
                                    FinalTotalCost = e.FinalTotalCost
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<OrderListItem> GetOrdersByCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Orders
                    .Where(e => e.CustomerId == _userId.ToString())
                    .Select(
                            e =>
                                new OrderListItem
                                {
                                    OrderId = e.OrderId,
                                    CustomerId = e.CustomerId,
                                    Customer = e.Customer,
                                    DateCreated = e.DateCreated,
                                    FinalTotalCost = e.FinalTotalCost
                                }
                        );

                return query.ToArray();
            }
        }

        public OrderDetail GetMostRecentOrder()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Orders
                    .Where(e => e.CustomerId == _userId.ToString() && !e.IsFinalized)
                    .OrderByDescending(e => e.DateCreated)
                    .First();

                _currentOrderId = entity.OrderId;
                return
                                new OrderDetail
                                {
                                    OrderId = entity.OrderId,
                                    OrderProducts = HelperConvertOrderProductsToOPListItem(entity.OrderProducts),
                                    OrderServices = HelperConvertOrderServiceToOSListItem(entity.OrderServices)
                                };
            }
        }

        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Orders
                    .Include("Customer")
                    .Single (e => e.OrderId == id);

                return
                new OrderDetail
                {
                    OrderId = entity.OrderId,
                    CustomerId = entity.CustomerId,
                    Customer = entity.Customer,
                    CustomerEmail = entity.Customer.Email,
                    DateCreated = entity.DateCreated,
                    DateFinalized = entity.DateFinalized,
                    FinalTotalCost = entity.FinalTotalCost,
                    IsActive = entity.IsActive,
                    IsFavorite = entity.IsFavorite,
                    IsFinalized = entity.IsFinalized,
                    IsPrepared = entity.IsPrepared,
                    TotalCostCalculator = entity.TotalCostCalculator,
                };
            }
        }

        //public bool UpdateOrder(OrderEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .Orders
        //            .Single(e => e.OrderId == model.OrderId);
        //        entity.Name = model.Name;
        //        entity.Inventory = model.Inventory;
        //        entity.Cost = model.Cost;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        public bool SoftDeleteOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Orders
                    .Single(e => e.OrderId == id);

                entity.IsActive = false;

                return ctx.SaveChanges() == 1;
            }
        }

        public List<OrderProductListItem> HelperConvertOrderProductsToOPListItem(List<OrderProduct> orderProducts)
        {
            List<OrderProductListItem> newList = new List<OrderProductListItem>();
            foreach (var op in orderProducts)
            {
                var listItem = new OrderProductListItem
                {
                    ProductCount = op.ProductCount,
                    ProductName = op.Product.Name,
                    Cost = op.Product.Cost * decimal.Parse(op.ProductCount.ToString())
                };
                newList.Add(listItem);
            }
            return newList;
        }

        public List<OrderServiceListItem> HelperConvertOrderServiceToOSListItem(List<Data.OrderService> orderServices)
        {
            List<OrderServiceListItem> newList = new List<OrderServiceListItem>();
            foreach (var os in orderServices)
            {
                var listItem = new OrderServiceListItem
                {
                    ServiceName = os.Service.Name,
                    Cost = os.Cost,
                };
                newList.Add(listItem);
            }
            return newList;
        }
    }
}

