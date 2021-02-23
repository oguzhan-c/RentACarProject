using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces.EntitiyFramework
{
    public class EfEntitiyRepositoryBase<EntityTip, ContextTip> : IEntityRepository<EntityTip>
        where EntityTip : class , IEntity , new()
        where ContextTip : DbContext , new()
    { 
        public void Add(EntityTip entity)
        {
            using (ContextTip context = new ContextTip())
            {
                var addedToEntity = context.Entry(entity);
                addedToEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(EntityTip entity)
        {
            using (ContextTip context = new ContextTip())
            {
                var deletedToEntity = context.Entry(entity);
                deletedToEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public EntityTip Get(Expression<Func<EntityTip, bool>> filter)
        {
            using (ContextTip context = new ContextTip())
            {
                return context.Set<EntityTip>().SingleOrDefault();
            }
        }

        public List<EntityTip> GetAll(Expression<Func<EntityTip, bool>> filter = null)
        {
            using (ContextTip context = new ContextTip())
            {
                if (filter == null)
                {
                    return context.Set<EntityTip>().ToList();
                }
                else
                {
                    return context.Set<EntityTip>().Where(filter).ToList();
                }
            }
        }

        public void Update(EntityTip entity)
        {
            using (ContextTip context = new ContextTip())
            {
                var updatedToEntity = context.Entry(entity);
                updatedToEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
