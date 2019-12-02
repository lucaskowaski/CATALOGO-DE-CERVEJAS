using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Tests.Services.IngredientTest
{
    public class IngredientsFake
    {
        static public IQueryable<Ingredient> Ingredients => new List<Ingredient>()
        {
            new Ingredient(){Description = "Malte", Id = 2, BeerIngredient = new List<BeerIngredient>()},
            new Ingredient(){Description = "Lupulo", Id = 3, BeerIngredient = new List<BeerIngredient>()},
            new Ingredient(){Description = "água", Id = 4, BeerIngredient = new List<BeerIngredient>()}
        }.AsQueryable();
        public static Ingredient IngredientParaAlterar
        {
            get => Ingredients.ToList().First();

        }
        public static Ingredient IngredientParaInserir
        {
            get => new Ingredient
            {
                Description = IngredientParaAlterar.Description,
                BeerIngredient = new List<BeerIngredient>()
            };
        }
    }
}
