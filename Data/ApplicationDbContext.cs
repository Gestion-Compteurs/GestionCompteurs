using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Compteur> Compteurs { get; set; }
    public DbSet<InstanceCompteur> InstanceCompteurs { get; set; }
    public DbSet<InstanceCadran> InstanceCadrans{ get; set; }
    public DbSet<Cadran> Cadrans { get; set; }
    public DbSet<Batiment> Batiments { get; set; }
    public DbSet<ReleveCadran> ReleveCadrans { get; set; }
    public DbSet<Releve?> Releves { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
