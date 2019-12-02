using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Tests.Services.IngredientTests
{
    public class IngredientFakes
    {
        static public IQueryable<Ingredient> Ingredients => new List<Ingredient>()
        {
            new Ingredient(){Description = "Malte", Id = 2, BeerIngredient = new List<BeerIngredient>()},
            new Ingredient(){Description = "Lupulo", Id = 3, BeerIngredient = new List<BeerIngredient>()},
            new Ingredient(){Description = "água", Id = 4, BeerIngredient = new List<BeerIngredient>()}
        }.AsQueryable();
        public static IList<IngredientViewModel> IngredientsViewModel => Ingredients.Select(i => new IngredientViewModel
        {
            Id = i.Id,
            Description = i.Description,
            BeerIngredient = new List<BeerIngredientViewModel>()
        }).ToList();
        static public IngredientViewModel IngredientViewModelInvalida => new IngredientViewModel()
        {
            Description = "",
            Id = 0
        };
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
        public static IngredientViewModel IngredientViewModelParaAlterar
        {
            get => new IngredientViewModel
            {
                Id = IngredientParaAlterar.Id,
                Description = IngredientParaAlterar.Description,
                BeerIngredient = new List<BeerIngredientViewModel>()
            };
        }
        public static IngredientViewModel IngredientViewModelParaInserir
        {
            get => new IngredientViewModel
            {
                Description = IngredientViewModelParaAlterar.Description,
                BeerIngredient = new List<BeerIngredientViewModel>()
            };
        }
    }
}
