using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.API.Config
{
    public static class DependenciesContainer
    {
        public static void AddMyDependencies(
        this IServiceCollection services,
        IConfiguration configuration
         )
        {
            #region Current User
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentUserFactory, CurrentUserFactory>();
            #endregion

            #region My services
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<ICategoriaAlmacenService, CategoriaAlmacenService>();
            services.AddScoped<ICategoriaProductoService, CategoriaProductoService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ICompraService, CompraService>();
            services.AddScoped<ISolicitudService, SolicitudService>();
            #endregion
        }
    }
}
