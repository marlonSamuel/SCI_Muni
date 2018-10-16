using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class CompraConfig
    {
        public CompraConfig(EntityTypeBuilder<Compra> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Fecha).IsRequired();
            entityBuilder.Property(x => x.No_Serie).IsRequired().HasMaxLength(25);
            entityBuilder.Property(x => x.Total_Compra).IsRequired();
            entityBuilder.Property(x => x.Estado).IsRequired().HasMaxLength(1);
            entityBuilder.Property(x => x.Tipo).HasMaxLength(1);
        }
    }
}
