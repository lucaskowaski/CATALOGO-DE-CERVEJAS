using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Interfaces.Repositories
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {
        IQueryable<Ingredient> SearchByDescription(string description);
    }
}
