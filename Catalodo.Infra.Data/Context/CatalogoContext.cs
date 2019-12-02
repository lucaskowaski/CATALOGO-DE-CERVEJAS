using Catalodo.Infra.Data.Mappings;
using Catalogo.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Catalodo.Infra.Data.Context
{
    public class CatalogoContext: DbContext
    {
        private readonly IHostingEnvironment _env;
        public CatalogoContext(IHostingEnvironment env)
        {
            _env = env;
        }
        public CatalogoContext()
        {

        }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BeerMap());
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
            modelBuilder.ApplyConfiguration(new BeerIngredientMap());
            modelBuilder.ApplyConfiguration(new RecipeIngredientMap());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var config = new ConfigurationBuilder().SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CatalogoCerveja;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
