using Catalodo.Infra.Data.Context;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalodo.Infra.Data.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(CatalogoContext context) : base(context)
        {
          
        }
        public IQueryable<Ingredient> SearchByDescription(string description)
        {
            return DbSet.Where(c => c.Description.Contains(description));
        }
    }
}
