﻿using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class Solicitud : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string No_Serie { get; set; }
        public string No_Orden { get; set; }
        public string Codigo_Programatico { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Tipo { get; set; }
        public string Estado_Solicitud { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }

        public Empleado Empleado { get; set; }
        public int EmpleadoId { get; set; }

        public bool Deleted { get; set; }
    }
}
