using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Services
{
    public class RecipeService : ServiceBase<Recipe>, IRecipeService
    {
        public RecipeService(IRecipeRepository repository) : base(repository)
        {
        }

        public IQueryable<Recipe> GetByBeer(int beerId)
        {
            return _repositorio.GetAll().Where(r => r.BeerId == beerId);
        }
    }
}
