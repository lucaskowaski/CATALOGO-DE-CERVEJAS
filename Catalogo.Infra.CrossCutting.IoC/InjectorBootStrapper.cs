using Catalodo.Infra.Data.Context;
using Catalodo.Infra.Data.Repository;
using Catalogo.Application.Interfaces;
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Services;
using Catalogo.Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Infra.CrossCutting.IoC
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //application
            services.AddScoped<IBeerApplication, BeerApplication>();
            services.AddScoped<IIngredientApplication, IngredientApplication>();
            services.AddScoped<IRecipeApplication, RecipeApplication>();
            //domain
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            // infra
            services.AddScoped<CatalogoContext>();
            services.AddScoped<IBeerRepository, BeerRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IBeerIngredientRepository, BeerIngredientRepository>();
        }
    }
}
