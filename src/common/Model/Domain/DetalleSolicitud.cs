using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class DetalleSolicitud : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public int Cantidad_Solicitada { get; set; }
        public int Cantidad_Entregada { get; set; }
        public string UnidadMedida { get; set; }
        public string Estado { get; set; }

        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public Solicitud Solicitud { get; set; }
        public int SolicitudId { get; set; }

        public bool Deleted { get; set; }
    }
}
