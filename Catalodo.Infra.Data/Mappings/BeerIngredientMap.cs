using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalodo.Infra.Data.Mappings
{
    class BeerIngredientMap : IEntityTypeConfiguration<BeerIngredient>
    {
        public void Configure(EntityTypeBuilder<BeerIngredient> builder)
        {
            builder.HasKey(p => new { p.BeerId, p.IngredientId });
        }
    }
}
