using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Interfaces.Services
{
    public interface IIngredientService : IServiceBase<Ingredient>
    {
        IQueryable<Ingredient> SearchByDescription(string description);
    }
}
