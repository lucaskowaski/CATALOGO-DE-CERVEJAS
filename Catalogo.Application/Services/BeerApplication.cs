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
    public class BeerApplication : ApplicationBase<BeerViewModel, Beer>, IBeerApplication
    {
        private readonly IBeerService _beerService;
        public BeerApplication(IBeerService service, IMapper mapper) : base(service, mapper)
        {
            _beerService = service;
        }
        public IEnumerable<BeerViewModel> SearchByName(string name)
        {
            return _beerService.SearchByName(name)
                .ProjectTo<BeerViewModel>(_mapper.ConfigurationProvider);
        }
        public Beer GetIncludeIngredients(int id)
        {
            return _beerService.GetIncludeIngredients(id);
        }
    }
}
