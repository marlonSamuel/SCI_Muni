using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shared
{
    public class CompraListDto
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int No_serie { get; set; }
        public decimal TotalCompra { get; set; }
        public string Proveedor { get; set; }
        public int ProveedorId { get; set; }
        public string Estado { get; set; }
    }

    public class CompraCreateDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public decimal TotalCompra { get; set; }
        public int No_Serie { get; set; }
        public string Estado { get; set; }
        public decimal PrecioCompra { get; set; }

        public List<DetalleCompraCreateDto> detalle { get; set; }
    }

    public class DetalleCompraListDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public string Nombre { get; set; }
        public decimal? Subtotal { get; set; }
        public int Cantidad { get; set; }
        public decimal? PrecioCompra { get; set; }
    }

    public class DetalleCompraCreateDto
    {
        public int Id { get; set; }
        public int CompraId {get; set;}
        public int ProductoId { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
    }
}
