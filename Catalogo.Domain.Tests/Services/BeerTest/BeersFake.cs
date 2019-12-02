using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Tests.Services.BeerTest
{
    public class BeersFake
    {
        static public IQueryable<Beer> Beers => new List<Beer>()
        {
            new Beer{ Id = 1, Name = "Stela", Brand = "Stela", Family = "Stela", ABV = 21, IBU = 63, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()},
            new Beer{ Id = 2, Name = "Brahma Chopp", Brand = "Brahma", Family = "Brahma", ABV = 23, IBU = 53, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()},
            new Beer{ Id = 2, Name = "Brahma Extra Red large", Brand = "Brahma", Family = "Brahma", ABV = 21, IBU = 33, Style = "Normal",  BeerIngredient = new List<BeerIngredient>()}
        }.AsQueryable();
    }
}
