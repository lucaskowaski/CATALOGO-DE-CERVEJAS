using Catalodo.Infra.Data.Context;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalodo.Infra.Data.Repository
{
    public class BeerIngredientRepository : RepositoryBase<BeerIngredient>, IBeerIngredientRepository
    {
        public BeerIngredientRepository(CatalogoContext context) : base(context)
        {

        }
    }
}
