using System;
using System.Linq;
using System.Linq.Expressions;

namespace IntelutionsTest.Svc.GenericDataService
{
    public interface IGenericSvc<TEntity>
    {
        TEntity CreateEntity(TEntity entity);

        TEntity UpdateEntity(TEntity entity);

        void DeleteById(int id);

        TEntity Load(int id);

        IQueryable<TEntity> LoadAll(Expression<Func<TEntity, bool>> where = null);
    }
}
