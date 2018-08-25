using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Model.Shared;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICompraService
    {
        Task<DataGridResponse> ListarCompras(DataGrid grid);
        Task<IEnumerable<DetalleCompraListDto>> ListarDetalleCompra(int id);
        Task<Compra> ObtenerCompra(int Id);
        Task<bool> CrearCompra(CompraCreateDto model);
        Task<bool> AnularCompra(int id);
    }

    public class CompraService : ICompraService
    {
        private readonly ApplicationDbContext _context;

        public CompraService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<DataGridResponse> ListarCompras(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = (
                    from c in _context.Compra
                    join p in _context.Proveedor on c.ProveedorId equals p.Id
                    select new
                    {
                        id = c.Id,
                        fecha = c.Fecha,
                        no_serie = c.No_Serie,
                        total_compra = c.Total_Compra,
                        proveedor = p.Nombre,
                        proveedorId = p.Id,
                        estado = c.Estado
                        //compra = _context.DetalleCompra.Where(x => x.CompraId == c.Id).ToList()
                    }
                ).Select(x => new CompraListDto
                {
                    Id = x.id,
                    Fecha = x.fecha,
                    No_serie = x.no_serie,
                    TotalCompra = x.total_compra,
                    Proveedor = x.proveedor,
                    ProveedorId = x.proveedorId,
                    Estado = x.estado
                    //compra = x.compra
                }).AsQueryable();


                var data = await query.Skip(grid.Page)
                                .Take(grid.RowsPerPage)
                                .ToListAsync();

                var total = await query.CountAsync();

                grid.SetData(data, total);
            }
            catch (Exception e)
            {
                // Error logging
            }

            return grid.Response();
        }

        public async Task<IEnumerable<DetalleCompraListDto>> ListarDetalleCompra(int id)
        {
            var list = new List<DetalleCompraListDto>();

            try
            {
                var query = (
                    from d in _context.DetalleCompra
                    join p in _context.Producto on d.ProductoId equals p.Id
                    join c in _context.Compra on d.CompraId equals c.Id
                    where d.CompraId == id
                    select new
                    {
                        id = c.Id,
                        compraId = d.CompraId,
                        productoId = d.ProductoId,
                        nombre = p.Nombre,
                        precioCompra = d.Precio_Compra,
                        cantidad = d.Cantidad,
                        subtotal = d.Cantidad * d.Precio_Compra
                    }
                ).Select(x => new DetalleCompraListDto
                {
                    Id = x.id,
                    CompraId = x.compraId,
                    ProductoId = x.productoId,
                    Nombre = x.nombre,
                    PrecioCompra = x.precioCompra,
                    Cantidad = x.cantidad,
                    Subtotal = x.subtotal
                }).AsQueryable();


                list = await query.ToListAsync();
            }
            catch (Exception e)
            {
                // Error logging
            }

            return list;
        }


        //obtene empleado por id
        public async Task<Compra> ObtenerCompra(int Id)
        {
            var result = new Compra();

            try
            {
                result = await _context.Compra.Where(x => x.Id == Id).SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar empleado
        public async Task<bool> CrearCompra(CompraCreateDto model)
        {
            var result = false;


            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var compra = new Compra
                    {
                        Id = model.Id,
                        Fecha = model.Fecha,
                        Total_Compra = model.TotalCompra,
                        ProveedorId = model.ProveedorId,
                        No_Serie = model.No_Serie,
                        Estado = model.Estado
                    };

                    if (compra.Id > 0) _context.Compra.Update(compra);
                    else _context.Compra.Add(compra);

                    await _context.SaveChangesAsync();

                    int compraId = compra.Id;
                    try
                    {
                        foreach(var d in model.detalle)
                        {
                            var detalle = new DetalleCompra
                            {
                                Id = d.Id,
                                CompraId = compraId,
                                ProductoId = d.ProductoId,
                                Precio_Compra = d.PrecioCompra,
                                Cantidad = d.Cantidad
                            };

                            if (detalle.Id > 0) _context.DetalleCompra.Update(detalle);
                            else _context.DetalleCompra.Add(detalle);

                            await _context.SaveChangesAsync();
                        }
                        
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    transaction.Commit();

                    result = true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    result = false;
                    throw e;
                }

            }

            return result;
        }


        //Eliminar cargo a nivel logico
        public async Task<bool> AnularCompra(int id)
        {
            var result = false;
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        //delete a nivel logico de producto
                        var originalEntryCompra = await _context.Compra.SingleOrDefaultAsync(x => x.Id == id);
                        if (originalEntryCompra != null)
                        {
                            originalEntryCompra.Estado = "R";
                            _context.Update(originalEntryCompra);

                            await _context.SaveChangesAsync();
                        }

                        var list = _context.DetalleCompra.Where(x => x.CompraId == id).ToList();

                        foreach(var l in list)
                        {
                            var producto = _context.Almacen.Where(x => x.ProductoId == l.ProductoId).SingleOrDefault();
                            if(producto != null)
                            {
                                producto.Stock = producto.Stock - l.Cantidad;
                                _context.Update(producto);

                                await _context.SaveChangesAsync();
                            }
                        }

                        transaction.Commit();
                        result = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return result = false;
                    }
                }
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }
    }
}
