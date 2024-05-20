using GestionBatimentsElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlitedb")));
*/

// Configurer l'injection de dépendances pour le contexte de la base de données
var connectionString = builder.Configuration.GetConnectionString("sql_server_hassane");
builder.Services.AddSqlServer<ApplicationDbContext>(connectionString);
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
builder.Services.AddScoped<IReleveCadranRepository, ReleveCadranRepository>();
builder.Services.AddScoped<IReleveRepository, ReleveRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Politique des origines
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();