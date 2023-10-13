using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration
{
    public class TipoNotificacionConfiguration : IEntityTypeConfiguration<TipoNotificaciones>
    {
        public void Configure(EntityTypeBuilder<TipoNotificaciones> builder)
        {
            builder.ToTable("TipoNotificaciones");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombreTipo)
            .IsRequired()
            .HasMaxLength(80);
        }
    }
}