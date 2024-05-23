﻿// <auto-generated />
using System;
using GestionCompteursElectriquesMoyenneTension.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCompteursElectriquesMoyenneTension.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240523101347_m7")]
    partial class m7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", b =>
                {
                    b.HasOne("GestionCompteursElectriquesMoyenneTension.Model.Entities.InstanceCompteur", null)
                        .WithMany("Releves")
                        .HasForeignKey("InstanceCompteurId")
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

            modelBuilder.Entity("GestionCompteursElectriquesMoyenneTension.Model.Entities.Releve", b =>
                {
                    b.Navigation("ReleveCadrans");
                });
#pragma warning restore 612, 618
        }
    }
}
