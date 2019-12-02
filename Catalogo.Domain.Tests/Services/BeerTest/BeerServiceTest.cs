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

namespace Catalogo.Domain.Tests.Services.BeerTest
{
    public class BeerServiceTest
    {
        private IBeerService _beerService;
        private IBeerRepository _beerRepository;
        private readonly string searchTerm = "Bram";
        [SetUp]
        public void Setup()
        {
            _beerRepository = Substitute.For<IBeerRepository>();
            _beerRepository.SearchByName(searchTerm).Returns(BeersFake.Beers.Where(b=>b.Name.Contains(searchTerm)));
            _beerService = new BeerService(_beerRepository);
        }
        [Test]
        public void Quando_pesquisar_cervejas_pelo_nome_deve_mapear_corretamente()
        {
            _beerService.SearchByName(searchTerm).Should().BeEquivalentTo(BeersFake.Beers.Where(b => b.Name.Contains(searchTerm)));
        }
    }
}
