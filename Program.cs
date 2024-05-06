using GestionBatimentsElectriquesMoyenneTension.Data;
using GestionCadransElectriquesMoyenneTension.Data;
using GestionCadransElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlitedb")));
var iServiceCollection = builder.Services;
// Add services to the container.

iServiceCollection.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
iServiceCollection.AddEndpointsApiExplorer();
iServiceCollection.AddSwaggerGen();


builder.Services.AddScoped<ICompteurRepository, CompteurRepository>();
builder.Services.AddScoped<ICadranRepository, CadranRepository>();
builder.Services.AddScoped<IBatimentRepository, BatimentRepository>();
builder.Services.AddScoped<IInstanceCompteurRepository, InstanceCompteurRepository>();
builder.Services.AddScoped<IInstanceCadranRepository, InstanceCadranRepository>();


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