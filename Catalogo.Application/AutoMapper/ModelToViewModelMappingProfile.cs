using AutoMapper;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Beer, BeerViewModel>();
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Ingredient, IngredientViewModel>();
            CreateMap<BeerIngredient, BeerIngredientViewModel>();
            CreateMap<RecipeIngredient, RecipeIngredientViewModel>();
        }
    }
}
