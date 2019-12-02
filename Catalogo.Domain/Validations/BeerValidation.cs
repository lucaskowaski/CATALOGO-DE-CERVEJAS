using Catalogo.Domain.Models;
using FluentValidation;

namespace Catalogo.Domain.Validations
{
    public class BeerValidation : Validation<Beer>
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(3).WithMessage("Nome deve ter no minimo 3 cacacteres")
                .MaximumLength(100).WithMessage("Nome dever ter no máximo 100 caracteres");
        }
        protected void ValidateBrand()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Informe o marca")
                .MinimumLength(3).WithMessage("A marca deve ter no minimo 3 cacacteres")
                .MaximumLength(100).WithMessage("A marca dever ter no máximo 100 caracteres");
        }
        protected void ValidateFamily()
        {
            RuleFor(c => c.Family)
                .NotEmpty().WithMessage("Informe o familia")
                .MinimumLength(3).WithMessage("A familia deve ter no minimo 3 cacacteres")
                .MaximumLength(100).WithMessage("A familia dever ter no máximo 100 caracteres");
        }
        protected void ValidateStyle()
        {
            RuleFor(c => c.Style)
                .NotEmpty().WithMessage("informe o estilo")
                .MinimumLength(3).WithMessage("O estilo deve ter no minimo 3 cacacteres")
                .MaximumLength(100).WithMessage("O estilo dever ter no máximo 100 caracteres");
        }
        protected void ValidateABV()
        {
            RuleFor(c => c.ABV)
                .NotEmpty().WithMessage("informe o ABV")
                .GreaterThan(0).WithMessage("O ABV deve ser maior que 0");
        }
        protected void ValidateIBU()
        {
            RuleFor(c => c.IBU)
                .NotEmpty().WithMessage("informe o IBU")
                .GreaterThan(0).WithMessage("O IBU deve ser maior que 0");
        }
    }
}
