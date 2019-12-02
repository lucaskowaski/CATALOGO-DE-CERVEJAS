using Catalodo.Infra.Data.Context;
using Catalogo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Catalodo.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly CatalogoContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public RepositoryBase(CatalogoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }
        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
