using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Services
{
    public class IngredientService : ServiceBase<Ingredient>, IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository repository) : base(repository) 
        {
            _ingredientRepository = repository;
        }

        public IQueryable<Ingredient> SearchByDescription(string description)
        {
            return _ingredientRepository.SearchByDescription(description);
        }
    }
}
