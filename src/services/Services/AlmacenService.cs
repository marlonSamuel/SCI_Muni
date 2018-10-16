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
    public interface IProductoService
    {
        Task<DataGridResponse> ListarProductos(int id, DataGrid grid);
        Task<Almacen> ObtenerProducto(int Id);
        Task<bool> CrearProducto(ProductoCreateDto model);
        Task<bool> EliminarProducto(int id, int almacenId);
    }

    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<DataGridResponse> ListarProductos(int id, DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = (
                    from p in _context.Producto
                    join a in _context.Almacen on p.Id equals a.ProductoId
                    join c in _context.CategoriaProducto on p.CategoriaProductoId equals c.Id
                    join ca in _context.CategoriaAlmacen on c.CategoriaAlmacenId equals ca.Id
                    where c.CategoriaAlmacenId == id
                    select new
                    {
                        id = p.Id,
                        nombre = p.Nombre,
                        stock = a.Stock,
                        stock_minimo = p.Stock_Minimo,
                        stock_maximo = p.Stock_Maximo,
                        precio = a.Precio,
                        categoria = c.Nombre,
                        categoriaId = c.Id,
                        almacenId = a.Id,
                        descripcion = p.Descripcion,
                        estado = a.Estado
                    }
                ).Select(x => new ProductoListDto
                {
                    Id = x.id,
                    Nombre = x.nombre,
                    Stock = x.stock,
                    Stock_Maximo = x.stock_maximo,
                    Stock_Minimo = x.stock_minimo,
                    Precio = x.precio,
                    Categoria = x.categoria,
                    CategoriaId = x.categoriaId,
                    Descripcion = x.descripcion,
                    AlmacenId = x.almacenId,
                    Estado = x.estado
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

        //obtene empleado por id
        public async Task<Almacen> ObtenerProducto(int Id)
        {
            var result = new Almacen();

            try
            {
                result = await _context.Almacen.Where(x => x.ProductoId == Id).SingleAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar empleado
        public async Task<bool> CrearProducto(ProductoCreateDto model)
        {
            var result = false;


            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var producto = new Producto {
                        Id = model.Id,
                        Nombre = model.Nombre,
                        Stock_Maximo = model.Stock_Maximo,
                        Stock_Minimo = model.Stock_Minimo,
                        CategoriaProductoId = model.CategoriaId,
                        Descripcion = model.Descripcion
                       
                        
                    };

                    if (producto.Id > 0) _context.Producto.Update(producto);
                    else  _context.Producto.Add(producto);

                    await _context.SaveChangesAsync();

                    try
                    {
                        var almacen = new Almacen
                        {
                            Id = model.AlmacenId,
                            ProductoId = producto.Id,
                            Stock = model.Stock,
                            Precio = model.Precio,
                            Estado = model.Estado
                        };

                        if (almacen.Id > 0) _context.Almacen.Update(almacen);
                        else _context.Almacen.Add(almacen);

                        await _context.SaveChangesAsync();
                    }
                    catch(Exception e)
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
        public async Task<bool> EliminarProducto(int id, int almacenId)
        {
            var result = false;

            try
            {
               using(var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        //delete a nivel logico de la tabla almacen
                        var originalEntryAlmacen = await _context.Almacen.SingleOrDefaultAsync(x =>
                            x.Id == almacenId
                        );
                        if (originalEntryAlmacen != null)
                        {
                            originalEntryAlmacen.Deleted = true;
                            _context.Update(originalEntryAlmacen);

                            await _context.SaveChangesAsync();
                            
                        }

                        //delete a nivel logico de producto
                        var originalEntryProducto = await _context.Producto.SingleOrDefaultAsync(x => x.Id == id);
                        if(originalEntryProducto != null)
                        {
                            originalEntryProducto.Deleted = true;
                            _context.Update(originalEntryProducto);

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
    }
}
