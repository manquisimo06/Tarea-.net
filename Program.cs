using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE CORS
// Permite que la aplicación Blazor se comunique con la API sin ser bloqueada por el navegador
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirBlazor", policy =>
    {
        policy.AllowAnyOrigin()   // Permite solicitudes desde cualquier origen
              .AllowAnyHeader()   // Permite cualquier encabezado (JSON, etc.)
              .AllowAnyMethod();  // Permite GET, POST, PUT, DELETE, etc.
    });
});

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseMySQL(builder.Configuration.GetConnectionString("ConexionMySQL") ?? "otracadena"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

// 2. ACTIVAR EL MIDDLEWARE DE CORS
// IMPORTANTE: Debe colocarse ANTES de UseAuthorization y MapControllers
app.UseCors("PermitirBlazor");

app.UseAuthorization();

app.MapControllers();

app.Run();