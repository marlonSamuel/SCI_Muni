﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InventarioApp.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventarioApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMyDependencies(Configuration);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(opts =>
            {
                opts.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = "oidc";
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddOpenIdConnect("oidc", options =>
              {
                  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                  options.Authority = Configuration["Auth:Url"];
                  options.RequireHttpsMetadata = false;
                  options.GetClaimsFromUserInfoEndpoint = true;

                  options.ClientId = Configuration["Auth:ClientId"];
                  options.ClientSecret = Configuration["Auth:SecretKey"];
                  options.ResponseType = "code id_token";

                  options.Scope.Add("SCI.API");

                  options.SaveTokens = true;


                  // Esto ya no es necesario, me percaté que el ProfileService esta seteando correctamente los claims
                  /*
                  options.ClaimActions.Add(new JsonKeyClaimAction("ImageProfile", "ImageProfile", "ImageProfile"));
                  options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Name, ClaimTypes.Name, ClaimTypes.Name));
                  options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Surname, ClaimTypes.Surname, ClaimTypes.Surname));
                  options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Uri, ClaimTypes.Uri, ClaimTypes.Uri));
                  options.ClaimActions.Add(new JsonKeyClaimAction(ClaimTypes.Email, ClaimTypes.Email, ClaimTypes.Email));
                  options.ClaimActions.Add(new JsonKeyClaimAction("ImageProfile", "ImageProfile", "ImageProfile"));
                  */


                  options.Events = new OpenIdConnectEvents
                  {
                      OnUserInformationReceived = async context =>
                      {
                          var claims = new List<Claim>();

                          if (context.Properties.Items.Keys.Contains(".Token.access_token"))
                          {
                              var token = context.Properties.Items[".Token.access_token"].ToString();
                              claims.Add(new Claim("access_token", token));

                              var id = context.Principal.Identity as ClaimsIdentity;
                              id.AddClaims(claims);
                          }

                          await Task.FromResult(0);
                      }
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
