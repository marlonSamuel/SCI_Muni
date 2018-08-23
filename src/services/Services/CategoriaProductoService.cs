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
    public interface ICategoriaProductoService
    {
        Task<DataGridResponse> ListarCategorias(DataGrid grid);
        Task<IEnumerable<CategoriaProducto>> ListarCategoriasPorAlmacen(int id);
        Task<CategoriaProducto> ObtenerCategoria(int Id);
        Task<bool> CrearCategoria(CreateCategoriaProductoDto model);
        Task<bool> EliminarCategoria(int id);
    }

    public class CategoriaProductoService : ICategoriaProductoService
    {
        private readonly ApplicationDbContext _context;

        public CategoriaProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //listar categorias de producto
        public async Task<DataGridResponse> ListarCategorias(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = _context.CategoriaProducto.AsQueryable();

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

        //listar categorias por almacencategoria
        //metodo para obtener registros 
        public async Task<IEnumerable<CategoriaProducto>> ListarCategoriasPorAlmacen(int id)
        {
            var list = new List<CategoriaProducto>();

            try
            {
                var query = _context.CategoriaProducto.Where(x=>x.CategoriaAlmacenId == id);

                list = await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        //obtene categoria por id
        public async Task<CategoriaProducto> ObtenerCategoria(int Id)
        {
            var result = new CategoriaProducto();

            try
            {
                result = await _context.CategoriaProducto.Where(x => x.Id == Id).SingleAsync();


            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar nuevo cargo
        public async Task<bool> CrearCategoria(CreateCategoriaProductoDto model)
        {
            var result = false;

            try
            {
                if (model.Id > 0)
                {
                    _context.CategoriaProducto.Update(new CategoriaProducto
                    {
                        Id = model.Id,
                        CategoriaAlmacenId = model.CategoriaAlmacenId,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
                    });
                }
                else
                {
                    _context.CategoriaProducto.Add(new CategoriaProducto
                    {
                        CategoriaAlmacenId = model.CategoriaAlmacenId,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
                    });
                }

                await _context.SaveChangesAsync();

                result = true;
            }
            catch (Exception)
            {

            }

            return result;
        }

        //Eliminar cargo a nivel logico
        public async Task<bool> EliminarCategoria(int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.CategoriaProducto.SingleOrDefaultAsync(x =>
                    x.Id == id
                );

                /*
                 * Aplicamos softdeleted para hacer borrado solo a nivel lógico.
                 * En nuestro ApplicationDbContext aplicamos filtros, estos excluirán
                 * cualquier consulta donde el Deleted = True
                 */

                if (originalEntry != null)
                {
                    originalEntry.Deleted = true;
                    _context.Update(originalEntry);

                    await _context.SaveChangesAsync();

                    result = true;
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
