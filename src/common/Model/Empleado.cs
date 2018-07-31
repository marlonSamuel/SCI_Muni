using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Cargo Cargo { get; set; }
        public string CargoId { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
    }
}
