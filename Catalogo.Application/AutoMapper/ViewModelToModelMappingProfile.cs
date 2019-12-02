using AutoMapper;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<BeerViewModel, Beer>();
            CreateMap<RecipeViewModel, Recipe>();
            CreateMap<IngredientViewModel, Ingredient>();
            CreateMap<BeerIngredientViewModel, BeerIngredient>();
            CreateMap<RecipeIngredientViewModel, RecipeIngredient>();
        }
    }
}
