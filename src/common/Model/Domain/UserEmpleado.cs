using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class UserEmpleado
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }

        public Empleado Empleado { get; set; }
        public string EmpleadoId { get; set; }
    }
}
