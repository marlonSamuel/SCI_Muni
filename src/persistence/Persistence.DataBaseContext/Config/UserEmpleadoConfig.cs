﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBaseContext.Config
{
    class UserEmpleadoConfig
    {
        public UserEmpleadoConfig(EntityTypeBuilder<UserEmpleado> entityBuilder)
        {

        }
    }
}