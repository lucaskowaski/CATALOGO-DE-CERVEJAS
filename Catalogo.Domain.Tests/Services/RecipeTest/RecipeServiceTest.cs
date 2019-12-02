using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Tests.Services.RecipeTest
{
    public class RecipeServiceTest
    {
        private IRecipeRepository _recipeRepository;
        private IRecipeService _recipeService;
        private readonly int BeerId = 1;

        [SetUp]
        public void Setup()
        {
            _recipeRepository = Substitute.For<IRecipeRepository>();
            _recipeRepository.GetAll().Returns(RecipesFake.Receitas.Where(r => r.BeerId == BeerId));
            _recipeService = new RecipeService(_recipeRepository);
        }
        [Test]
        public void Quando_buscar_receitas_por_cerveja_deve_mapear_corretamente()
        {
            _recipeService.GetByBeer(BeerId).Should().BeEquivalentTo(RecipesFake.Receitas.Where(r => r.BeerId == BeerId));
        }
    }
}
