using IntelutionsTest.Data.ModelDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace IntelutionsTest.Svc.GenericDataService
{
    public class GenericSvc<TEntity> : IGenericSvc<TEntity>, IDisposable
        where TEntity : class
    {
        private DBContext _context;
        protected DBContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new DBContext();
                }
                return _context;
            }
        }

        public virtual TEntity CreateEntity(TEntity entity)
        {
            TEntity newentity = Context.Set<TEntity>().Add(entity).Entity;

            try
            {
                this.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }

            return newentity;
        }

        public virtual TEntity UpdateEntity(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

            try
            {
                this.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }

            return entity;
        }

        public virtual void DeleteById(int id)
        {
            var item = Load(id);
            Context.Set<TEntity>().Remove(item);

            try
            {
                this.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual TEntity Load(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        public virtual IQueryable<TEntity> LoadAll(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> rdo = where != null ? Context.Set<TEntity>().Where(where) : Context.Set<TEntity>();
            return rdo;
        }

        protected virtual bool SaveChanges()
        {
            try
            {
                return 0 < Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (null != Context)
                Context.Dispose();
        }
    }
}
