using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Compteur> Compteurs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
