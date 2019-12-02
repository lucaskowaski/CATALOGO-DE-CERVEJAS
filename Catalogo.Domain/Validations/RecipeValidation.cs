using Catalogo.Domain.Models;
using FluentValidation;

namespace Catalogo.Domain.Validations
{
    public class RecipeValidation : Validation<Recipe>
    {
        protected void ValidateBottleSize()
        {
            RuleFor(c => c.BottleSize)
                .NotEmpty().WithMessage("Informe o tamanho da garrafa")
                .GreaterThan(0).WithMessage("O tamanho da garrafa deve ser maior que 0");
        }
    }
}
