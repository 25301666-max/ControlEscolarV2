using ControlEscolar.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

//Registrar contexto  para que puedan inyectarse en los controladores
builder.Services.AddDbContext<ControlEscolarBDContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException(
                                  "No se encontro la conexion DefaultConnection."
                                   );
    options.UseSqlServer(connectionString);
});


//Configurar que otros sitios puedan acceder a la api
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirWeb", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("PermitirWeb");

app.UseAuthorization();

app.MapControllers();

app.Run();