using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Tests.Services.BeerTests
{
    public class BeersFake
    {
        static public IQueryable<Beer> Beers => new List<Beer>()
        {
            new Beer{ Id = 1, Name = "Stela", Brand = "Stela", Family = "Stela", ABV = 21, IBU = 63, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()},
            new Beer{ Id = 2, Name = "Brahma Chopp", Brand = "Brahma", Family = "Brahma", ABV = 23, IBU = 53, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()},
            new Beer{ Id = 2, Name = "Brahma Extra Red large", Brand = "Brahma", Family = "Brahma", ABV = 21, IBU = 33, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()}
        }.AsQueryable();
        public static IList<BeerViewModel> BeersViewModel => Beers.Select(i => new BeerViewModel
        {
            Id = i.Id,
            Name = i.Name,
            Brand = i.Brand,
            Family = i.Family,
            ABV = i.ABV,
            IBU = i.IBU,
            BeerIngredient = new List<BeerIngredientViewModel>(),
            Style = i.Style
        }).ToList();
        static public BeerViewModel BeerViewModelInvalida => new BeerViewModel()
        {
            Id = 0,
            Name = "",
            Brand = "",
            Family = "",
            Style = ""
        };
        public static Beer BeerParaAlterar
        {
            get => Beers.ToList().First();

        }
        public static Beer BeerParaInserir
        {
            get => new Beer
            {
                Name = BeerParaAlterar.Name,
                Brand = BeerParaAlterar.Brand,
                Family = BeerParaAlterar.Family,
                ABV = BeerParaAlterar.ABV,
                IBU = BeerParaAlterar.IBU,
                BeerIngredient = new List<BeerIngredient>(),
                Style = BeerParaAlterar.Style
            };
        }
        public static BeerViewModel IngredientViewModelParaAlterar
        {
            get => new BeerViewModel
            {
                Name = BeerParaAlterar.Name,
                Brand = BeerParaAlterar.Brand,
                Family = BeerParaAlterar.Family,
                ABV = BeerParaAlterar.ABV,
                IBU = BeerParaAlterar.IBU,
                BeerIngredient = new List<BeerIngredientViewModel>(),
                Style = BeerParaAlterar.Style
            };
        }
        public static BeerViewModel IngredientViewModelParaInserir
        {
            get => new BeerViewModel
            {
                Name = IngredientViewModelParaAlterar.Name,
                Brand = IngredientViewModelParaAlterar.Brand,
                Family = IngredientViewModelParaAlterar.Family,
                ABV = IngredientViewModelParaAlterar.ABV,
                IBU = IngredientViewModelParaAlterar.IBU,
                BeerIngredient = new List<BeerIngredientViewModel>(),
                Style = IngredientViewModelParaAlterar.Style
            };
        }
    }
}
