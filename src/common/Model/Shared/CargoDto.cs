using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    public class CargoDto
    {
    }

    public class CargoCreateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
