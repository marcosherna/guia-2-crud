using guia_2.database;
using guia_2.interfaces;
using guia_2.models;
using guia_2.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MemoryContext, MemoryContext>();
builder.Services.AddSingleton<IRepository<Profesor>, ProfesorRepository>();
builder.Services.AddSingleton<IRepository<Materia>, MateriaRepository>();
builder.Services.AddSingleton<IRepository<Grupo>, GrupoRepository>();

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
