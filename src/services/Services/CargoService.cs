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
    public interface ICargoService
    {
        Task<DataGridResponse> ListarCargos(DataGrid grid);
        Task<Cargo> ObtenerCargo(int Id);
        Task<bool> CrearCargo(CargoCreateDto model);
        Task<bool> EliminarCargo(int id);
    }

    public class CargoService : ICargoService
    {
        private readonly ApplicationDbContext _context;

        public CargoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataGridResponse> ListarCargos(DataGrid grid)
        {
            grid.Initialize();

            try
            {
                var query = _context.Cargo.AsQueryable();



                //var query1 = (
                //    from u in _context.
                //    select new
                //    {
                //        User = $"{u.Lastname}, {u.Name}",
                //        Likes = _context.LikesPerPhoto.Count(x => x.UserId == u.Id),
                //        Comments = _context.CommentsPerPhoto.Count(x => x.UserId == u.Id),
                //        Photos = _context.Photos.Count(x => x.UserId == u.Id)
                //    }
                //).Select(x => new GreaterUsersParticipationDto
                //{
                //    User = x.User,
                //    Likes = x.Likes,
                //    Comments = x.Comments,
                //    Photos = x.Photos,
                //    // Esta es una pequeña lógica para generar un score a cada usuario
                //    // En el cual mayor prioridad le doy a los que suben fotos y dan like
                //    Score = Convert.ToDecimal(x.Photos * 0.5 + x.Likes * 0.3 + x.Comments * 0.2)
                //}).OrderByDescending(x => x.Score).AsQueryable();

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

        //obtene cargo por id
        public async Task<Cargo> ObtenerCargo(int Id)
        {
            var result = new Cargo();

            try
            {
                result = await _context.Cargo.Where(x => x.Id == Id).SingleAsync();


            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        //insertar o actualizar nuevo cargo
        public async Task<bool> CrearCargo(CargoCreateDto model)
        {
            var result = false;

            try
            {
                if (model.Id > 0)
                {
                    _context.Cargo.Update(new Cargo
                    {
                        Id = model.Id,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion
                    });
                }
                else
                {
                    _context.Cargo.Add(new Cargo
                    {
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
        public async Task<bool> EliminarCargo(int id)
        {
            var result = false;

            try
            {
                var originalEntry = await _context.Cargo.SingleOrDefaultAsync(x =>
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
