using AutoMapper;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Services;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using Catalogo.Application.AutoMapper;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Application.Tests.Services.IngredientTests
{
    public class IngredientApplicationTest : ApplicationBaseTets
    {
        private IIngredientApplication _ingredientApplication;
        private IIngredientService _ingredientService;
        private readonly string searchTerm = "lup";

        [SetUp]
        public void Setup()
        {
            ConfigurarAutomapper();
            _ingredientService = Substitute.For<IIngredientService>();
            _ingredientService.Get(IngredientFakes.IngredientParaAlterar.Id).Returns(IngredientFakes.IngredientParaAlterar);
            _ingredientService.GetAll().Returns(IngredientFakes.Ingredients);
            _ingredientService.SearchByDescription(searchTerm).Returns(new List<Ingredient> { IngredientFakes.Ingredients.ToList()[1] }.AsQueryable());
            _ingredientApplication = new IngredientApplication(_ingredientService, _mapperConfiguration.CreateMapper());
        }

        [Test]
        public void Quando_adicionar_o_ingrediente_deve_mapear_corretamente()
        {
            _ingredientService.When(l => l.Add(Arg.Any<Ingredient>())).Do(x =>
            {
                x.Arg<Ingredient>().Should().BeEquivalentTo(IngredientFakes.IngredientParaInserir);
            });
            _ingredientApplication.Add(IngredientFakes.IngredientViewModelParaInserir);
        }

        [Test]
        public void Quando_alterar_o_ingredient_deve_mapear_corretamente()
        {
            _ingredientService.When(l => l.Update(Arg.Any<Ingredient>())).Do(x =>
            {
                x.Arg<Ingredient>().Should().BeEquivalentTo(IngredientFakes.IngredientParaAlterar);
            });
            _ingredientApplication.Add(IngredientFakes.IngredientViewModelParaAlterar);
        }

        [Test]
        public void Quando_obter_um_ingredient_por_id_deve_mapear_corretamente()
        {
            _ingredientApplication.Get(IngredientFakes.IngredientViewModelParaAlterar.Id).Should().BeEquivalentTo(IngredientFakes.IngredientViewModelParaAlterar);
        }

        [Test]
        public void Quando_obter_todos_os_ingredientes_deve_mapear_corretamente()
        {
            _ingredientApplication.GetAll().Should().BeEquivalentTo(IngredientFakes.IngredientsViewModel);
        }

        [Test]
        public void Quando_deletar_ingredient_deve_passar_o_id_corretamente()
        {
            int id = 1;
            _ingredientService.When(l => l.Remove(Arg.Any<int>())).Do(x =>
            {
                x.Arg<int>().Should().Be(id);
            });
            _ingredientApplication.Remove(id);
        }
        [Test]
        public void Quando_pesquisar_ingredientes_pelo_nome_deve_mapear_corretamente()
        {
            _ingredientApplication.SearchByDescription(searchTerm).Should().BeEquivalentTo(new List<IngredientViewModel> { IngredientFakes.IngredientsViewModel[1] });
        }
    }
}
