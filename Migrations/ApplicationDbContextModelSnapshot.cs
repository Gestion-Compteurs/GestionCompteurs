﻿// <auto-generated />
using System;
using GestionCompteursElectriquesMoyenneTension.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<bool?>("CompteActif")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateDeNaissance")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("RegieId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RegieId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Batiment", b =>
                {
                    b.Property<int>("BatimentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatimentId"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreEtages")
                        .HasColumnType("int");

                    b.Property<string>("TypeBatiment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BatimentId");

                    b.ToTable("Batiments");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Cadran", b =>
                {
                    b.Property<int>("CadranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CadranId"));

                    b.Property<string>("CadranModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeOnly>("HeureActivation")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HeureArret")
                        .HasColumnType("time");

                    b.Property<int>("NombreRoues")
                        .HasColumnType("int");

                    b.Property<double>("PrixWatt")
                        .HasColumnType("float");

                    b.HasKey("CadranId");

                    b.ToTable("Cadrans");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Compteur", b =>
                {
                    b.Property<int>("CompteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompteurId"));

                    b.Property<int>("AnneeCreation")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoltageMax")
                        .HasColumnType("int");

                    b.HasKey("CompteurId");

                    b.ToTable("Compteurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.CompteurCadran", b =>
                {
                    b.Property<int>("CadranId")
                        .HasColumnType("int");

                    b.Property<int>("CompteurId")
                        .HasColumnType("int");

                    b.HasKey("CadranId", "CompteurId");

                    b.HasIndex("CompteurId");

                    b.ToTable("CompteurCadrans");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCadran", b =>
                {
                    b.Property<int>("InstanceCadranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstanceCadranId"));

                    b.Property<int>("CadranId")
                        .HasColumnType("int");

                    b.Property<int>("IndexRoues")
                        .HasColumnType("int");

                    b.Property<int>("InstanceCompteurId")
                        .HasColumnType("int");

                    b.HasKey("InstanceCadranId");

                    b.HasIndex("CadranId");

                    b.HasIndex("InstanceCompteurId");

                    b.ToTable("InstanceCadrans");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", b =>
                {
                    b.Property<int>("InstanceCompteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstanceCompteurId"));

                    b.Property<int>("BatimentId")
                        .HasColumnType("int");

                    b.Property<int>("CompteurId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateInstallation")
                        .HasColumnType("date");

                    b.HasKey("InstanceCompteurId");

                    b.HasIndex("BatimentId");

                    b.HasIndex("CompteurId");

                    b.ToTable("InstanceCompteurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Operateur", b =>
                {
                    b.Property<int>("OperateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperateurId"));

                    b.Property<string>("Cin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Civilite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEmbauche")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegieId")
                        .HasColumnType("int");

                    b.HasKey("OperateurId");

                    b.HasIndex("RegieId");

                    b.ToTable("Operateurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Regie", b =>
                {
                    b.Property<int>("RegieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegieId"));

                    b.Property<string>("EmailRegie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordRegie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegieId");

                    b.ToTable("Regies");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", b =>
                {
                    b.Property<int>("ReleveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReleveId"));

                    b.Property<DateOnly>("DateReleve")
                        .HasColumnType("date");

                    b.Property<int>("InstanceCompteurId")
                        .HasColumnType("int");

                    b.Property<int>("OperateurId")
                        .HasColumnType("int");

                    b.HasKey("ReleveId");

                    b.HasIndex("InstanceCompteurId");

                    b.HasIndex("OperateurId");

                    b.ToTable("Releves");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.ReleveCadran", b =>
                {
                    b.Property<int>("ReleveCadranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReleveCadranId"));

                    b.Property<int>("IndexRoues")
                        .HasColumnType("int");

                    b.Property<int>("InstanceCadranId")
                        .HasColumnType("int");

                    b.Property<double>("PrixWatt")
                        .HasColumnType("float");

                    b.Property<int?>("ReleveId")
                        .HasColumnType("int");

                    b.HasKey("ReleveCadranId");

                    b.HasIndex("InstanceCadranId");

                    b.HasIndex("ReleveId");

                    b.ToTable("ReleveCadrans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Regie", null)
                        .WithMany("Administrateurs")
                        .HasForeignKey("RegieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.CompteurCadran", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Cadran", null)
                        .WithMany()
                        .HasForeignKey("CadranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Compteur", null)
                        .WithMany()
                        .HasForeignKey("CompteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCadran", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Cadran", null)
                        .WithMany("InstancesCadran")
                        .HasForeignKey("CadranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", null)
                        .WithMany("InstanceCadrans")
                        .HasForeignKey("InstanceCompteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Batiment", null)
                        .WithMany("InstanceCompteurs")
                        .HasForeignKey("BatimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Compteur", null)
                        .WithMany("InstanceCompteurs")
                        .HasForeignKey("CompteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Operateur", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Regie", null)
                        .WithMany("Operateurs")
                        .HasForeignKey("RegieId");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", null)
                        .WithMany("Releves")
                        .HasForeignKey("InstanceCompteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Operateur", null)
                        .WithMany("releves")
                        .HasForeignKey("OperateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.ReleveCadran", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCadran", null)
                        .WithMany("ReleveCadrans")
                        .HasForeignKey("InstanceCadranId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", null)
                        .WithMany("ReleveCadrans")
                        .HasForeignKey("ReleveId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.Administrateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Batiment", b =>
                {
                    b.Navigation("InstanceCompteurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Cadran", b =>
                {
                    b.Navigation("InstancesCadran");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Compteur", b =>
                {
                    b.Navigation("InstanceCompteurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCadran", b =>
                {
                    b.Navigation("ReleveCadrans");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", b =>
                {
                    b.Navigation("InstanceCadrans");

                    b.Navigation("Releves");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Operateur", b =>
                {
                    b.Navigation("releves");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Regie", b =>
                {
                    b.Navigation("Administrateurs");

                    b.Navigation("Operateurs");
                });

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", b =>
                {
                    b.Navigation("ReleveCadrans");
                });
#pragma warning restore 612, 618
        }
    }
}
