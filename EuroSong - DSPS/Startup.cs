using Jacobs_Kevin_3IMS_BackEnd.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace Jacobs_Kevin_3IMS_BackEnd
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

            services.AddControllers();

            services.AddSingleton(typeof(IEuroSongDataContext), new EuroSongDataBase());

            #region JWT
            //JWT
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,
            //                ValidIssuer = Configuration["JwtToken:Issuer"],
            //                ValidAudience = Configuration["JwtToken:Issuer"],
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecuredKey"]))
            //            };
            //        });

            #endregion

            //adjust ConfigureServices-method
            services.AddCors(s => s.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin()
                                              .AllowAnyMethod()
                                              .AllowAnyHeader()));
            #region Basic
            //ConfigureServices
            services
              .AddAuthentication()
              .AddScheme<AuthenticationSchemeOptions,
                      BasicAuthenticationHandler>("BasicAuthenticationScheme", options => { });



            services.AddAuthorization(options =>
            {
             options.AddPolicy("BasicAuthentication",
                        new AuthorizationPolicyBuilder("BasicAuthenticationScheme").RequireAuthenticatedUser().Build());
            });
            #endregion
            #region OATUH
            string clientId = "1031480954694-lqbmnhelt81im57an8ig8o8o0pds84rr.apps.googleusercontent.com";
            string redirectUrl = "https://localhost:5001/swagger/index.html";

            string authorizelink = "https://accounts.google.com/o/oauth2/auth?scope=https://www.googleapis.com/auth/drive&response" +
                "_type=code&access_type=offline&redirect_uri=" + redirectUrl + "&client_id=" + clientId;

            string auth2 = "https://accounts.google.com/o/oauth2/auth";
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jacobs_Kevin_3IMS_BackEnd", Version = "v1" });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "oauth2",
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme,Id = "oauth2"}
                        },
                        new[] {"email", "profile" }
                    }
                });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "oauth2",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri(auth2),
                            //TokenUrl = new Uri("https://login.microsoftonline.com/7493ef9e-db24-45d8-91b5-9c36018d6d52/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                             {
                                 { "email", "users email" },
                                 {"Profile", "users profile" }
                             }
                         }

                    }
             });

                #endregion
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jacobs_Kevin_3IMS_BackEnd v1"));
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jacobs_Kevin_3IMS_BackEnd v1");
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            //  app.UseMvc();

            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
