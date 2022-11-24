using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using KSPTECHNOLOGY.Infrastructure.Extensions;
using KSPTECHNOLOGY.Infrastructure.Filters;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se agrega AutoMapper para poder mapear los DTOS con las propiedades de las tablas ::: NOTA => REQUERIDO
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Agrega una implementación predeterminada para el servicio IHttpContextAccessor ::: Nota => REQUERIDO
builder.Services.AddHttpContextAccessor();

// Corrigiendo el error “A possible object cycle was detected” ::: NOTA => Ignora referencias circulares de entidades
builder.Services.AddControllers(o =>
{
    o.Filters.Add<GlobalExceptionFilter>();
}).AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Permite la conexion a la Base de Datos ::: NOTA => REQUERIDO
builder.Services.AddDbContexts(builder.Configuration);

// Permite el mapeo de los servicios con sus interfases y el mapeo de los repositorios con sus interfases ::: NOTA => REQUERIDO
builder.Services.AddServices();

// Se integra y configura el documentado de apis con swagger ::: NOTA => REQUERIDO 
builder.Services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();

// Damos soporte para CORS
app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseExceptionHandler(builder =>
    {
        builder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string mensaje = "{\"Respuesta\": false," +
                                  "\"Data\": \"" + error.Error.Message + "\"}";
                await context.Response.WriteAsync(mensaje);
            }
        });
    });

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("Empresa/swagger.json", "Empresa");
    });
}
else
{
    app.UseExceptionHandler(builder =>
    {
        builder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                string mensaje = "{\"Respuesta\": false," +
                                  "\"Data\": \"" + error.Error.Message + "\"}";
                await context.Response.WriteAsync(mensaje);
            }
        });
    });

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("Empresa/swagger.json", "Empresa");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();