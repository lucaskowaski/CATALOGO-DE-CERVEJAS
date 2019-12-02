using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using Catalogo.Domain.Services;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Tests.Services.IngredientTest
{
    public class IngredientServiceTest
    {
        private IIngredientService _ingredientService;
        private IIngredientRepository _ingredientRepository;
        private readonly string SearchTerm = "malt";

        [SetUp]
        public void Setup()
        {
            _ingredientRepository = Substitute.For<IIngredientRepository>();
            _ingredientRepository.Get(IngredientsFake.IngredientParaAlterar.Id).Returns(IngredientsFake.IngredientParaAlterar);
            _ingredientRepository.GetAll().Returns(IngredientsFake.Ingredients);
            _ingredientRepository.SearchByDescription(SearchTerm).Returns(IngredientsFake.Ingredients.Where(i => i.Description.Contains(SearchTerm)));
            _ingredientService = new IngredientService(_ingredientRepository);
        }
        [Test]
        public void Quando_adicionar_o_ingrediente_deve_retornar_corretamente()
        {
            _ingredientRepository.When(l => l.Add(Arg.Any<Ingredient>())).Do(x =>
            {
                x.Arg<Ingredient>().Should().BeEquivalentTo(IngredientsFake.IngredientParaInserir);
            });
            _ingredientService.Add(IngredientsFake.IngredientParaInserir);
        }

        [Test]
        public void Quando_adicionar_o_ingredient_deve_lancar_excecao_se_model_for_invalida()
        {
            Assert.Throws<ValidationException>(() => _ingredientService.Add(new Ingredient()));
        }

        [Test]
        public void Quando_alterar_o_ingredient_deve_retornar_corretamente()
        {
            _ingredientRepository.When(l => l.Update(Arg.Any<Ingredient>())).Do(x =>
            {
                x.Arg<Ingredient>().Should().BeEquivalentTo(IngredientsFake.IngredientParaAlterar);
            });
            _ingredientService.Add(IngredientsFake.IngredientParaAlterar);
        }

        [Test]
        public void Quando_alterar_deve_lancar_excecao_se_model_for_invalida()
        {
            Assert.Throws<ValidationException>(() => _ingredientService.Update(new Ingredient { Id = 0 }));
        }

        [Test]
        public void Quando_obter_um_ingredient_por_id_deve_retornar_corretamente()
        {
            _ingredientService.Get(IngredientsFake.IngredientParaAlterar.Id).Should()
                .BeEquivalentTo(IngredientsFake.IngredientParaAlterar);
        }

        [Test]
        public void Quando_obter_um_ingredient_por_id_deve_lancar_erro_se_o_parametro_estiver_incorreto()
        {
            Assert.Throws<ArgumentException>(() => _ingredientService.Get(0));
        }

        [Test]
        public void Quando_obter_todos_os_ingredientes_deve_retornar_corretamente()
        {
            _ingredientService.GetAll().Should().BeEquivalentTo(IngredientsFake.Ingredients);
        }

        [Test]
        public void Quando_deletar_ingredient_deve_lancar_excecao_se_id_for_invalido()
        {
            Assert.Throws<ArgumentException>(() => _ingredientService.Remove(0));
        }
        [Test]
        public void Quando_deletar_ingredient_deve_passar_o_id_corretamente()
        {
            int id = 1;
            _ingredientRepository.When(l => l.Remove(Arg.Any<int>())).Do(x =>
            {
                x.Arg<int>().Should().Be(id);
            });
            _ingredientService.Remove(id);
        }
        [Test]
        public void Quando_pesquisar_ingredientes_pelo_nome_deve_retornar_corretamente()
        {
            _ingredientService.SearchByDescription(SearchTerm).Should().BeEquivalentTo(IngredientsFake.Ingredients.Where(i => i.Description.Contains(SearchTerm)));
        }
    }
}
