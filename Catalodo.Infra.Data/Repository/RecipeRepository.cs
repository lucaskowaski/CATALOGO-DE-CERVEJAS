using Catalodo.Infra.Data.Context;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalodo.Infra.Data.Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CatalogoContext context) : base(context)
        {

        }
        public override IQueryable<Recipe> GetAll()
        {
            return DbSet.Include(r => r.RecipeIngredients);
        }
    }
}
