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
        public string No_serie { get; set; }
        public decimal TotalCompra { get; set; }
        public string Proveedor { get; set; }
        public int ProveedorId { get; set; }
        public string DireccionProveedor { get; set; }
        public string Tipo { get; set; }
        public string Factura { get; set; }
        public string Estado { get; set; }
    }

    public class CompraCreateDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public decimal TotalCompra { get; set; }
        public string No_Serie { get; set; }
        public string Estado { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Tipo { get; set; }
        public string Factura { get; set; }


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
