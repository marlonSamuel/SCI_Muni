using Microsoft.AspNetCore.Identity;
using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Domain
{
    public class ApplicationUser : IdentityUser, ISoftDeleted
    {
        public string Foto { get; set; }

        //[NotMapped]
        //public Empleado Empleado { get; set; }
        //public int EmpleadoId { get; set; }

        //implementado IsoftDeleted automatico
        public bool Deleted { get; set; }
    }
}
