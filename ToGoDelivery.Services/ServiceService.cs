using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToGoDelivery.Data;
using ToGoDelivery.Models.Service;

namespace ToGoDelivery.Services
{
    public class ServiceService
    {
        private readonly Guid _userId;

        public ServiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateService(ServiceCreate model)
        {
            var entity = new Service()
            {
                Name = model.Name,
                Cost = model.Cost,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Services
                    .Select(
                            e =>
                                new ServiceListItem
                                {
                                    ServiceId = e.ServiceId,
                                    Name = e.Name,
                                    Cost = e.Cost,
                                    IsActive = e.IsActive,
                                }
                        );

                return query.ToArray();
            }
        }

        public ServiceDetail GetServiceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == id);
                return
                new ServiceDetail
                {
                    ServiceId = entity.ServiceId,
                    Name = entity.Name,
                    Cost = entity.Cost,
                    CreatedDate = entity.CreatedDate,
                    IsActive = entity.IsActive
                };
            }
        }

        public bool UpdateService(ServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == model.ServiceId);
                entity.Name = model.Name;
                entity.Cost = model.Cost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool SoftDeleteService(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == id);

                entity.IsActive = false;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
