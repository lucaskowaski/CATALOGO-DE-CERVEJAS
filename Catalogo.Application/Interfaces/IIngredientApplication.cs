using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.Interfaces
{
    public interface IIngredientApplication : IApplicationBase<IngredientViewModel, Ingredient>
    {
        IEnumerable<IngredientViewModel> SearchByDescription(string description);
    }
}
