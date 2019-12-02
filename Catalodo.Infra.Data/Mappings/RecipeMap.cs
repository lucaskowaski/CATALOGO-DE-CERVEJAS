using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalodo.Infra.Data.Mappings
{
    public class RecipeMap: IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.BottleSize).IsRequired();
        }
    }
}
