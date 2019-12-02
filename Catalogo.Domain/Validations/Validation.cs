using Catalogo.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class Validation<T> : AbstractValidator<T> where T : Entity
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Informe o ID")
                .GreaterThan(0).WithMessage("O id deve ser maior que 0");
        }
    }
}
