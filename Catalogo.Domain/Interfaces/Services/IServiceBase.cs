using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(int entity);
    }
}
