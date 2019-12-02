using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        protected readonly IRepositoryBase<TEntity> _repositorio;
        public ServiceBase(IRepositoryBase<TEntity> repositorioBase)
        {
            _repositorio = repositorioBase;
        }
        public void Add(TEntity entity)
        {
            entity.ValidateAndThrowToAdd();
            _repositorio.Add(entity);
            _repositorio.SaveChanges();
        }
        virtual public void Update(TEntity entity)
        {
            entity.ValidateAndThrowToUpdate();
            _repositorio.Update(entity);
            _repositorio.SaveChanges();
        }
        public TEntity Get(int id)
        {
            ValidateId(id);
            return _repositorio.Get(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repositorio.GetAll();
        }

        public void Remove(int id)
        {
            ValidateId(id);
            _repositorio.Remove(id);
            _repositorio.SaveChanges();
        }
        protected void ValidateId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O id deve ser maior que 0");
        }
    }
}
