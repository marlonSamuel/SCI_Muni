using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class HuellaDactilarConfig
    {
        public HuellaDactilarConfig(EntityTypeBuilder<HuellaDactilar> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Huella).IsRequired();
        }
    }
}
