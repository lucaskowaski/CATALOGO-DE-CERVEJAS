using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalodo.Infra.Data.Mappings
{
    public class RecipeIngredientMap : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(c => new { c.IngredientId, c.RecipeId });
            builder.Property(c => c.Quantity);
        }
    }
}
