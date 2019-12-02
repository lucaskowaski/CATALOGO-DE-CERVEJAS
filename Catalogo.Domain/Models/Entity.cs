using Catalogo.Domain.Validations;
using FluentValidation;
using System;

namespace Catalogo.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public void ValidateAndThrow<TValidator, TEntity>(TEntity Entity) where TValidator : AbstractValidator<TEntity>
        {
            var validator = Activator.CreateInstance<TValidator>();
            validator.ValidateAndThrow(Entity);
        }
        public abstract void ValidateAndThrowToAdd();
        public abstract void ValidateAndThrowToUpdate();
    }
}
