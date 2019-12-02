using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Tests.Services.RecipeTest
{
    public class RecipesFake
    {
        static public IQueryable<Recipe> Receitas => new List<Recipe>()
        {
            new Recipe(){Id = 1, BeerId = 5, BottleSize = 600, RecipeIngredients = new List<RecipeIngredient>()}
        }.AsQueryable();
    }
}
