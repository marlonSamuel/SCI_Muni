using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Common
{
    public interface ICurrentUserFactory
    {
        CurrentUser Get { get; }
    }


    public class CurrentUserFactory : ICurrentUserFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserFactory(
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser Get
        {
            get
            {
                var result = new CurrentUser();

                if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    return result;
                }

                var claims = _httpContextAccessor.HttpContext.User.Claims;

                if (claims.Any(x => x.Type.Equals("UserId")))
                {
                    result.UserId = claims.Where(x => x.Type.Equals("UserId")).First().Value;
                }

                if (claims.Any(x => x.Type.Equals("EmpleadoId")))
                {
                    result.EmpleadoId = claims.Where(x => x.Type.Equals("EmpleadoId")).First().Value;

                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Email)))
                {
                    result.Email = claims.Where(x => x.Type.Equals(ClaimTypes.Email)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Name)))
                {
                    result.Primer_Nombre = claims.Where(x => x.Type.Equals(ClaimTypes.Name)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals(ClaimTypes.Surname)))
                {
                    result.Primer_apellido = claims.Where(x => x.Type.Equals(ClaimTypes.Surname)).First().Value;
                }

                if (claims.Any(x => x.Type.Equals("access_token")))
                {
                    result.Token = claims.Where(x => x.Type.Equals("access_token")).First().Value;
                }

                if (claims.Any(x => x.Type.Equals("Foto")))
                {
                    result.Foto = claims.Where(x => x.Type.Equals("Foto")).First().Value;
                }

                return result;
            }
        }
    }


    public class CurrentUser
    {
        public string UserId { get; set; }
        public string EmpleadoId { get; set; }
        public string Foto { get; set; }
        public string Primer_Nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }

}


