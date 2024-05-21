using GestionBatimentsElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
/*
// Configuration for accessing the Oracle database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();*/

var connectionString = builder.Configuration.GetConnectionString("sql_server_nihad");
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
builder.Services.AddScoped<IOperateurRepository, OperateurRepository>();
builder.Services.AddIdentity<Administrateur,IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    }
   
    ).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


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