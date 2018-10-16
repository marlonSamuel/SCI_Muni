using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    public class SolicitudListDto
    {
        public int Id { get; set; }
        public DateTime? Fecha_solicitud { get; set; }
        public string No_serie { get; set; }
        public string No_orden { get; set; }
        public string Codigo { get; set; }
        public decimal Total { get; set; }
        public string Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string CodigoProgramatico { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Observacion { get; set; }
    }

    public class SolicitudCreateDto
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public string Codigo { get; set; }
        public string No_Serie { get; set; }
        public string No_Orden { get; set; }
        public string Codigo_Programatico { get; set; }
        public DateTime Fecha_solicitud { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Tipo { get; set; }
        public string Estado_Solicitud { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }


        public List<DetalleSolicitudCreateDto> detalle { get; set; }
    }

    public class DetalleSolicitudListDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public int SolicitudId { get; set; }
        public int Cantidad_solicitada { get; set; }
        public int Stock { get; set; }
        public int Cantidad_entregada { get; set; }
        public string Estado { get; set; }
        public decimal? Precio { get; set; }
    }

    public class DetalleSolicitudCreateDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int SolicitudId { get; set; }
        public int Cantidad_Solicitada { get; set; }
        public int Cantidad_Entregada { get; set; }
        public string UnidadMedida { get; set; }
        public string Estado { get; set; }
    }

    public class CorrelativosDto
    {
        public string codigo_programatico { get; set; }
        public string codigo_solicitud { get; set; }
        public string no_serie { get; set; }
        public string no_orden { get; set; }
    }
}
