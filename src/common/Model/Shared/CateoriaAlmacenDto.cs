using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    class CateoriaAlmacenDto
    {
    }

    public class CreateCategoriaAlmacenDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
