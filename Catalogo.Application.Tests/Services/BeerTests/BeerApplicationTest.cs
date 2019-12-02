using Catalogo.Application.Interfaces;
using Catalogo.Application.Services;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Tests.Services.BeerTests
{
    public class BeerApplicationTest : ApplicationBaseTets
    {
        private IBeerApplication _beerApplication;
        private IBeerService _beerService;
        private readonly string searchTerm = "Bram";
        [SetUp]
        public void Setup()
        {
            _beerService = Substitute.For<IBeerService>();
            _beerService.Get(BeersFake.BeerParaAlterar.Id).Returns(BeersFake.BeerParaAlterar);
            _beerService.GetAll().Returns(BeersFake.Beers);
            _beerService.SearchByName(searchTerm).Returns(new List<Beer> { BeersFake.Beers.ToList()[0] }.AsQueryable());
            _beerApplication = new BeerApplication(_beerService, _mapperConfiguration.CreateMapper());
        }
        [Test]
        public void Quando_pesquisar_cervejas_pelo_nome_deve_mapear_corretamente()
        {
            _beerApplication.SearchByName(searchTerm).Should().BeEquivalentTo(new List<BeerViewModel> { BeersFake.BeersViewModel[0] });
        }
    }
}
