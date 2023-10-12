using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class ModuloMaestrosConfiguration : IEntityTypeConfiguration<ModulosMaestros>
    {
        public void Configure(EntityTypeBuilder<ModulosMaestros> builder)
        {
            builder.ToTable("ModulosMaestros");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreModulo)
            .IsRequired()
            .HasMaxLength(100);
        }
    }
}