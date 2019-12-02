using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Tests.Services.RecipesTests
{
    public class RecipesFake
    {
        static public IQueryable<Recipe> Receitas => new List<Recipe>()
        {
            new Recipe(){Id = 1, BeerId = 5, BottleSize = 600, RecipeIngredients = new List<RecipeIngredient>()}
        }.AsQueryable();
        public static IList<RecipeViewModel> ReceitasViewModel => Receitas.Select(i => new RecipeViewModel
        {
            Id = i.Id,
            BeerId = i.BeerId,
            BottleSize = i.BottleSize,
            RecipeIngredients = new List<RecipeIngredientViewModel>()
        }).ToList();
        public static Recipe ReceitasParaAlterar
        {
            get => Receitas.ToList().First();
        }
        public static RecipeViewModel ReceitaViewModelParaAlterar
        {
            get => new RecipeViewModel
            {
                Id = ReceitasParaAlterar.Id,
                BeerId = ReceitasParaAlterar.BeerId,
                BottleSize = ReceitasParaAlterar.BottleSize,
                RecipeIngredients = new List<RecipeIngredientViewModel>()
            };
        }
    }
}
