using System.Text;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Methods;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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

// Ajouter l'authentification
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
} );
// Ajouter l'autorisation
builder.Services.AddAuthorization();

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
builder.Services.AddScoped<IAdministrateurRepository, AdministrateurRepository>();
builder.Services.AddScoped<IRegieRepository, RegieRepository>();
builder.Services.AddScoped<IPasswordHasher<Administrateur>, AdminPasswordHasher>();

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