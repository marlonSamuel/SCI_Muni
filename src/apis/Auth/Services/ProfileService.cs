using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfileService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            var empleado =  _context.Empleado.SingleOrDefault(x => x.Id == user.EmpleadoId);

            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id),
                new Claim("EmpleadoId", user.EmpleadoId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, empleado.Primer_nombre),
                new Claim(ClaimTypes.Surname, empleado.Primer_apellido),
                new Claim("Foto", empleado.Foto ?? ""),
            };

            context.IssuedClaims.AddRange(claims);

            return Task.FromResult(0);

        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            // Su lógica para validar si el usuario tiene acceso al sistema o no
            /*
             context.IsActive = !user.IsBanned;
             */

            context.IsActive = true;

            return Task.FromResult(0);
        }
    }
}
