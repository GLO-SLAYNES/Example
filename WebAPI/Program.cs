using Application.Service;
using Domain.Model;
using Domain.Persistence;
using Domain.Service;
using InfrastructureInMemory.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Persona>, PersonaRepository>();
builder.Services.AddScoped<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddScoped<IRepository<Movimiento>, MovimientoRepository>();
builder.Services.AddScoped<IRepository<Cuenta>, CuentaRepository>();

builder.Services.AddScoped<IService<Persona>, PersonaService>();
builder.Services.AddScoped<IService<Cliente>, ClienteService>();
builder.Services.AddScoped<IService<Movimiento>, MovimientoService>();
builder.Services.AddScoped<IService<Cuenta>, CuentaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
