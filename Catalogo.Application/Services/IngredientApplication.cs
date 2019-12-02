using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalogo.Application.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Services
{
    public class IngredientApplication : ApplicationBase<IngredientViewModel, Ingredient>, IIngredientApplication
    {
        private readonly IIngredientService _ingredientService;
        public IngredientApplication(IIngredientService service, IMapper mapper) : base(service, mapper)
        {
            _ingredientService = service;
        }

        public IEnumerable<IngredientViewModel> SearchByDescription(string description)
        {
            return _ingredientService.SearchByDescription(description)
                .ProjectTo<IngredientViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
