using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    class ProveedorDto
    {
    }

    public class CreateProveedorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
    }
}
