using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalodo.Infra.Data.Mappings
{
    class BeerMap : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.Property(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Brand).IsRequired();
            builder.Property(c => c.Style).IsRequired();
            builder.Property(c => c.Family).IsRequired();
            builder.Property(c => c.ABV).IsRequired();
            builder.Property(c => c.IBU).IsRequired();
        }
    }
}
