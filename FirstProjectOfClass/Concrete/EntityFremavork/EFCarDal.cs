using DataAccess.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Entities.Concrute;

namespace DataAccess.Concrete.EntityFremavork
{
    //NuGet
    public class EFCarDal : ICarDal
    {
        public void Add(Cars entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Cars entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Cars Get(Expression<Func<Cars, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Cars>().SingleOrDefault(filter);
            }

        }

        public List<Cars> GetAll(Expression<Func<Cars, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                if (filter == null)
                {
                    return context.Set<Cars>().ToList();
                }
                else
                {
                    return context.Set<Cars>().Where(filter).ToList();
                }
            }
        }

        public void Update(Cars entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
