using Catalogo.Application.Interfaces;
using Catalogo.Application.Services;
using Catalogo.Application.Tests.Services.IngredientTests;
using Catalogo.Domain.Interfaces.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Tests.Services.RecipesTests
{
    public class RecipeApplicationTests : ApplicationBaseTets
    {
        private IRecipeApplication _recipeApplication;
        private IRecipeService _recipeService;
        private readonly int BeerId = 1;

        [SetUp]
        public void Setup()
        {
            _recipeService = Substitute.For<IRecipeService>();
            _recipeService.GetByBeer(BeerId).Returns(RecipesFake.Receitas.Where(r => r.BeerId == BeerId));
            _recipeApplication = new RecipeApplication(_recipeService, _mapperConfiguration.CreateMapper());
        }
        [Test]
        public void Quando_buscar_receitas_por_cerveja_deve_mapear_corretamente()
        {
            _recipeApplication.GetByBeer(BeerId).Should().BeEquivalentTo(RecipesFake.ReceitasViewModel.Where(r => r.BeerId == BeerId));
        }
    }
}
