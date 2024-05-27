using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class ApplicationDbContext:IdentityDbContext<Administrateur>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options) { }
    public DbSet<Compteur> Compteurs { get; set; }
    public DbSet<InstanceCompteur> InstanceCompteurs { get; set; }
    public DbSet<InstanceCadran> InstanceCadrans{ get; set; }
    public DbSet<Cadran> Cadrans { get; set; }
    public DbSet<Batiment> Batiments { get; set; }
    public DbSet<ReleveCadran> ReleveCadrans { get; set; }
    public DbSet<Releve> Releves { get; set; }
    public DbSet<CompteurCadran> CompteurCadrans { get; set; }
    public DbSet<Operateur> Operateurs { get; set; }
    public DbSet<Administrateur> Administrateurs { get; set; }
    public DbSet<Regie> Regies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Many to many compteur et cadran
        modelBuilder.Entity<Compteur>()
            .HasMany(compteur => compteur.TypesCadrans)
            .WithMany(cadran => cadran.CompteursLePossedant)
            .UsingEntity<CompteurCadran>();
        

        // Define primary keys for Identity entities
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        
        
        /*modelBuilder.Entity<IdentityUser>(b =>
        {
            b.Property(u => u.EmailConfirmed).HasColumnType("NUMBER(1)");
            b.Property(u => u.PhoneNumberConfirmed).HasColumnType("NUMBER(1)");
            b.Property(u => u.TwoFactorEnabled).HasColumnType("NUMBER(1)");
            b.Property(u => u.LockoutEnabled).HasColumnType("NUMBER(1)");
        });*/
    }
}
