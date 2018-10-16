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
    public interface ISolicitudService
    {
        Task<DataGridResponse> ListarSolicitudes(DataGrid grid, string estado);
        Task<IEnumerable<DetalleSolicitudListDto>> ListarDetalleSolicitud(int id);
        Task<Solicitud> ObtenerSolicitud(int Id);
        Task<bool> CrearSolicitud(SolicitudCreateDto model);
        Task<bool> AnularSolicitud(int id);
        Task<bool> CambiarEstado(int id, string estado);
        Task<CorrelativosDto> GetCorrrelativos();
    }

    public class SolicitudService : ISolicitudService
    {
        private readonly ApplicationDbContext _context;

        public SolicitudService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<DataGridResponse> ListarSolicitudes(DataGrid grid, string estado)
        {
            grid.Initialize();

            try
            {
                var query = (
                    from s in _context.Solicitud
                    join e in _context.Empleado on s.EmpleadoId equals e.Id
                    join d in _context.Departamento on e.DepartamentoId equals d.Id
                    where s.Estado_Solicitud == estado
                    orderby s.Fecha_Solicitud descending
                    select new
                    {
                        id = s.Id,
                        fecha = s.Fecha_Solicitud,
                        no_serie = s.No_Serie,
                        codigo = s.Codigo,
                        no_orden = s.No_Orden,
                        total = s.Total,
                        empleado = e.Primer_nombre +" "+ e.Primer_apellido,
                        empleadoId = e.Id,
                        departamento = d.Nombre,
                        departamentoId = d.Id,
                        direccion = e.Direccion,
                        tipo = s.Tipo,
                        estado = s.Estado_Solicitud,
                        codigo_programatico = s.Codigo_Programatico,
                        fecha_entrega = s.Fecha_Entrega,
                        observacion = s.Observaciones
                    }
                ).Select(x => new SolicitudListDto
                {
                    Id = x.id,
                    Fecha_solicitud = x.fecha,
                    No_orden = x.no_orden,
                    No_serie = x.no_serie,
                    Total = x.total,
                    Empleado = x.empleado,
                    EmpleadoId = x.empleadoId,
                    Departamento = x.departamento,
                    DepartamentoId = x.departamentoId,
                    Direccion = x.direccion,
                    Tipo = x.tipo,
                    Estado = x.estado,
                    CodigoProgramatico = x.codigo_programatico,
                    FechaEntrega = x.fecha_entrega,
                    Codigo = x.codigo,
                    Observacion = x.observacion
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

        public async Task<IEnumerable<DetalleSolicitudListDto>> ListarDetalleSolicitud(int id)
        {
            var list = new List<DetalleSolicitudListDto>();

            try
            {
                var query = (
                    from d in _context.DetalleSolicitud
                    join p in _context.Producto on d.ProductoId equals p.Id
                    join s in _context.Solicitud on d.SolicitudId equals s.Id
                    join a in _context.Almacen on p.Id equals a.ProductoId
                    where d.SolicitudId == id
                    select new
                    {
                        id = d.Id,
                        solicitudId = s.Id,
                        productoId = d.ProductoId,
                        producto = p.Nombre,
                        unidad_medida = d.UnidadMedida,
                        cantidad_solicitada = d.Cantidad_Solicitada,
                        cantidad_entregada = d.Cantidad_Entregada,
                        estado = d.Estado,
                        precio = a.Precio,
                        stock = a.Stock
                        
                    }
                ).Select(x => new DetalleSolicitudListDto
                {
                    Id = x.id,
                    ProductoId = x.productoId,
                    Nombre = x.producto,
                    UnidadMedida = x.unidad_medida,
                    Cantidad_entregada = x.cantidad_entregada,
                    Cantidad_solicitada = x.cantidad_solicitada,
                    Estado = x.estado,
                    Precio = x.precio,
                    SolicitudId = x.solicitudId,
                    Stock = x.stock
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
        public async Task<Solicitud> ObtenerSolicitud(int Id)
        {
            var result = new Solicitud();

            try
            {
                result = await _context.Solicitud.Where(x => x.Id == Id).SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar empleado
        public async Task<bool> CrearSolicitud(SolicitudCreateDto model)
        {
            var result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var solicitud = new Solicitud
                    {
                        Id = model.Id,
                        EmpleadoId = model.EmpleadoId,
                        Codigo = model.Codigo,
                        No_Orden = model.No_Orden,
                        No_Serie = model.No_Serie,
                        Codigo_Programatico = model.Codigo_Programatico,
                        Fecha_Solicitud = model.Fecha_solicitud,
                        Fecha_Entrega = model.Fecha_Entrega,
                        Tipo = model.Tipo,
                        Estado_Solicitud = model.Estado_Solicitud,
                        Observaciones = model.Observaciones,
                        Total = model.Total
                    };

                    if (solicitud.Id > 0) _context.Solicitud.Update(solicitud);
                    else _context.Solicitud.Add(solicitud);

                    await _context.SaveChangesAsync();

                    int solicitudId = solicitud.Id;
                    try
                    {
                        foreach (var d in model.detalle)
                        {
                            var detalle = new DetalleSolicitud
                            {
                                Id = d.Id,
                                SolicitudId = solicitudId,
                                Cantidad_Solicitada = d.Cantidad_Solicitada,
                                Cantidad_Entregada = d.Cantidad_Entregada,
                                UnidadMedida = d.UnidadMedida,
                                ProductoId = d.ProductoId
                            };

                            if (detalle.Id > 0) _context.DetalleSolicitud.Update(detalle);
                            else _context.DetalleSolicitud.Add(detalle);

                            await _context.SaveChangesAsync();

                            //si cantidad entregada es mayor que cero
                            if(d.Cantidad_Entregada > 0)
                            {
                                var soli = await _context.Solicitud.Where(x => x.Id == d.SolicitudId).SingleOrDefaultAsync();

                                if(soli != null)
                                {
                                    soli.Fecha_Entrega = DateTime.Today;
                                    _context.Solicitud.Update(soli);
                                    
                                }
                                var producto = await _context.Almacen.Where(x => x.ProductoId == d.ProductoId).SingleOrDefaultAsync();

                                if(producto != null)
                                {
                                    producto.Stock = producto.Stock - d.Cantidad_Entregada;
                                    _context.Almacen.Update(producto);

                                    await _context.SaveChangesAsync();
                                }
                            }
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

        //Eliminar solicitud a nivel logico
        public async Task<bool> AnularSolicitud(int id)
        {
            var result = false;
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        //delete a nivel logico de producto
                        var originalEntrySolicitud = await _context.Solicitud.SingleOrDefaultAsync(x => x.Id == id);
                        if (originalEntrySolicitud != null)
                        {
                            originalEntrySolicitud.Deleted = true;
                            _context.Update(originalEntrySolicitud);

                            await _context.SaveChangesAsync();
                        }

                        var list = _context.DetalleSolicitud.Where(x => x.SolicitudId == id).ToList();

                        foreach (var detalle in list)
                        {
                           //var detalle = _context.DetalleSolicitud.Where(x => x.SolicitudId == l.Id).SingleOrDefault();
                                 detalle.Deleted = true;
                                _context.Update(detalle);

                                await _context.SaveChangesAsync();
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

        //Cambiar estado solicitud
        public async Task<bool> CambiarEstado(int id, string estado)
        {
            var result = false;

            try
            {
                var solicitud = await _context.Solicitud.SingleOrDefaultAsync(x => x.Id == id);

                solicitud.Estado_Solicitud = estado;

                _context.Update(solicitud);

                await _context.SaveChangesAsync();

            }catch(Exception e)
            {
                //error log
            }

            return result;
        }

        public async Task<CorrelativosDto> GetCorrrelativos()
        {
            var correlativos = new CorrelativosDto();
            var id = 1;

            try
            {
                var query = await _context.Solicitud.Where(x=>x.Id > 0).ToListAsync();

                if(query != null)
                {
                    var query2 = await _context.Solicitud.OrderByDescending(x => x.Id).FirstAsync();
                    id = query2.Id + 1;
                }

                correlativos = new CorrelativosDto
                {
                    no_serie = "C-00" + id,
                    no_orden = "O-00" + id,
                    codigo_programatico = "P-00" + id,
                    codigo_solicitud = "S-00" + id
                };
            }
            catch(Exception e)
            {
                throw e;
            }

            return correlativos;
        }
        
    }
}
