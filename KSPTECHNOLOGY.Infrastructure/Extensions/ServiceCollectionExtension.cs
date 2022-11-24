using KSPTECHNOLOGY.Data.Context;
using KSPTECHNOLOGY.Data.Implements.Common;
using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Services.Interfaces.Empresa;
using KSPTECHNOLOGY.Services.Services.Empresa;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace KSPTECHNOLOGY.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KSPTECHNOLOGYContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("conexion"));
                options.EnableSensitiveDataLogging();
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBeneficiarioService, BeneficiarioService>();
            services.AddTransient<IEmpleadoService, EmpleadoService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            string[] pagesApplication = { "Empresa" };

            services.AddSwaggerGen(c =>
            {
                foreach (string page in pagesApplication)
                {
                    c.SwaggerDoc(page, new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = page.Replace("KSPTECHNOLOGY", "KSPTECHNOLOGY"),
                        Version = "v1",
                        Description = "Backend KSPTECHNOLOGY",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "danielbr.estatus@gmail.com",
                            Name = "DANIEL BENITO ROSALES S.A. de C.V."
                        },
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "DANIEL BENITO ROSALES"
                        }
                    });
                }

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Autenticación JWT (Bearer)",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id= "Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebVisitsManagement.Api", Version = "v1" });
            });

            return services;
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Acccess-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Acccess-Control-Allow-Origin", "*");
        }
    }
}