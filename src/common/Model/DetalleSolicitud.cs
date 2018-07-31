using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DetalleSolicitud
    {
        public string Id { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public Solicitud Solicitud { get; set; }
        public int SolicitudId { get; set; }
    }
}
