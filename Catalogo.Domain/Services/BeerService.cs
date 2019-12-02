using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Services
{
    public class BeerService : ServiceBase<Beer>, IBeerService
    {
        private readonly IBeerRepository _beerRepository;
        public BeerService(IBeerRepository beerRepository) : base(beerRepository)
        {
            _beerRepository = beerRepository;
        }
        public IQueryable<Beer> SearchByName(string name)
        {
            return _beerRepository.SearchByName(name);
        }
        public Beer GetIncludeIngredients(int id)
        {
            ValidateId(id);
            var beer = _beerRepository.GetIncludeIngredients(id);
            beer.BeerIngredient = beer.BeerIngredient.Select(i => new BeerIngredient()
            {
                IngredientId = i.IngredientId,
                Ingredient = new Ingredient() { Id = i.Ingredient.Id, Description = i.Ingredient.Description }
            });
            return beer;
        }
    }
}
