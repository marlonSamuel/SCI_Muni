using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Config
{
    public static class IdentityConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("SCI.API", "Mi api para el control de inventarios")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = configuration.GetValue<string>("ClientSCI:ClientId"),
                    ClientName = "Back-office client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    // Este valor esta expresado en segundos, lo setamos a 4 horas
                    AccessTokenLifetime = 3600 * 4,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret(configuration.GetValue<string>("ClientSCI:SecretKey").Sha256())
                    },

                    RedirectUris           = { $"{configuration.GetValue<string>("ClientSCI:Url")}signin-oidc" },
                    PostLogoutRedirectUris = { $"{configuration.GetValue<string>("ClientSCI:Url")}signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SCI.API",
                    },

                    AllowOfflineAccess = true,

                    // Envía el token por defecto
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}
