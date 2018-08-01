using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class SolicitudConfig
    {
        public SolicitudConfig(EntityTypeBuilder<Solicitud> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Codigo).IsRequired();
            entityBuilder.Property(x => x.No_Serie).IsRequired();
            entityBuilder.Property(x => x.No_Orden).IsRequired();
            entityBuilder.Property(x => x.Unidad_Administrativa).HasMaxLength(100);
            entityBuilder.Property(x => x.Tipo).IsRequired().HasMaxLength(1);
            entityBuilder.Property(x => x.Estado_Solicitud).IsRequired().HasMaxLength(1);
            entityBuilder.Property(x => x.Total).IsRequired();
            entityBuilder.Property(x => x.Observaciones).HasMaxLength(500);
        }
    }
}
