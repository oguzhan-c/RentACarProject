using Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstruct
{
    public interface IEntityRepository<Tip> where Tip : class, IEntity, new()//in this way, it was only possible to work with entities
    {
        List<Tip> GetAll(Expression<Func<Tip, bool>> filter = null);
        Tip Get(Expression<Func<Tip, bool>> filter);
        void Add(Tip entity);
        void Update(Tip entity);
        void Delete(Tip entity);
    }
}
