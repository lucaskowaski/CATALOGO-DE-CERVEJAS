using Catalodo.Infra.Data.Context;
using Catalogo.Domain.Interfaces.Repositories;
using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalodo.Infra.Data.Repository
{
    public class BeerRepository : RepositoryBase<Beer>, IBeerRepository
    {
        public BeerRepository(CatalogoContext context) : base(context)
        {
        }
        public IQueryable<Beer> SearchByName(string name)
        {
            return DbSet.Where(c => c.Name.Contains(name));
        }
        public Beer GetIncludeIngredients(int id)
        {
            return DbSet.Include(b => b.BeerIngredient).ThenInclude(bi=>bi.Ingredient)
                .AsNoTracking().SingleOrDefault(b => b.Id == id);
        }
        public override void Update(Beer entity)
        {
            var beer = DbSet.Include(b => b.BeerIngredient).SingleOrDefault(b => b.Id == entity.Id);
            beer.Name = entity.Name;
            beer.Brand = entity.Brand;
            beer.Family = entity.Family;
            beer.Style = entity.Style;
            beer.ABV = entity.IBU;
            beer.IBU = entity.IBU;
            var beerIngredients = beer.BeerIngredient.ToList();
            var removeds = beerIngredients.Where(b => !entity.BeerIngredient.Any(x => x.IngredientId == b.IngredientId));
            var added = entity.BeerIngredient.Where(b => !beerIngredients.Any(x => x.IngredientId == b.IngredientId));
            foreach (var i in removeds)
            {
                Db.Entry(i).State = EntityState.Deleted;
            };
            foreach (var i in added)
            {
                beerIngredients.Add(i);
            }
            beer.BeerIngredient = beerIngredients;
            base.Update(beer);
        }
    }
}
