using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces
{
    public interface IEntityRepository<EntityTip> where EntityTip : class, IEntity, new()//in this way, it was only possible to work with entities
    {
        List<EntityTip> GetAll(Expression<Func<EntityTip, bool>> filter = null);
        EntityTip Get(Expression<Func<EntityTip, bool>> filter);
        void Add(EntityTip entity);
        void Update(EntityTip entity);
        void Delete(EntityTip entity);
    }
}
