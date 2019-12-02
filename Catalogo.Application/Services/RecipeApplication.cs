using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalogo.Application.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.Services
{
    public class RecipeApplication : ApplicationBase<RecipeViewModel, Recipe>, IRecipeApplication
    {
        private readonly IRecipeService _recipeService;
        public RecipeApplication(IRecipeService service, IMapper mapper) : base(service, mapper)
        {
            _recipeService = service;
        }

        public IEnumerable<RecipeViewModel> GetByBeer(int beerId)
        {
            return _recipeService.GetByBeer(beerId)
                    .ProjectTo<RecipeViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
