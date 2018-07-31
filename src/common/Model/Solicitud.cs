using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Solicitud
    {
        public int Id { get; set; }
        public DateTime? Fecha_Solicitud { get; set; }
        public DateTime? Fecha_Entrega { get; set; }
        public string Tipo { get; set; }
        public string Estado_Solicitud { get; set; }
        public decimal Total { get; set; }
        public string Descripcion { get; set; }

        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }
    }
}
