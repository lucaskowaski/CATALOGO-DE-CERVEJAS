using Catalogo.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class IngredientValidation : Validation<Ingredient>
    {
        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                 .NotEmpty().WithMessage("Informe a descrição")
                 .MinimumLength(3).WithMessage("A descrição deve ter no minimo 3 cacacteres")
                 .MaximumLength(100).WithMessage("A descrição ter no máximo 100 caracteres");
        }
    }
}
