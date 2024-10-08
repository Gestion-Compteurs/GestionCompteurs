﻿using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class ReleveRepository(ApplicationDbContext context): IReleveRepository
{
    private readonly ApplicationDbContext _context = context;
    
    // Fonction lorsque l'utilisateur demande de créer une nouvelle relève à une instance compteur
    public async Task<Releve?> CreerNouvelleReleve(AjouterNouvelleReleveRequestDto ajouterNouvelleReleveRequestDto)
    {
        try
        {
            // Retrouver l'instance compteur pour avoir tous les détails
            var instanceCompteur = await _context.InstanceCompteurs
                .Where(i => i.InstanceCompteurId == ajouterNouvelleReleveRequestDto.InstanceCompteurId)
                .AsNoTracking()
                .Include(instanceCompteur => instanceCompteur.InstanceCadrans)
                .FirstOrDefaultAsync();
            // Créer de nouvelles relèves cadrans pour toutes les instances cadran du compteur correspondant
            if (instanceCompteur is null) return null;
            // Créer une nouvelle relève
            var releve = new Releve
            {
                // L'identifiant sera obtenu lors du AddAsync
                // BatimentId = instanceCompteur.BatimentId,
                // Ajout dans la liste des relèves de son instance compteur
                InstanceCompteurId = instanceCompteur.InstanceCompteurId,
                DateReleve = DateOnly.FromDateTime(DateTime.Today),
                OperateurId = ajouterNouvelleReleveRequestDto.OperateurId,
            };
            await _context.Releves.AddAsync(releve);
            await _context.SaveChangesAsync();
            foreach (var instanceCadran in instanceCompteur.InstanceCadrans)
            {
                var releveCadran = new ReleveCadran
                {
                    // ReleveCadranId sera ajouté lors du AddAsync à la base de données
                    ReleveId = releve.ReleveId,
                    IndexRoues = 0, // IndexRoues sera informé lors de la validation
                    // Ajout dans la liste des relèves cadran de son instance cadran 
                    InstanceCadranId = instanceCadran.InstanceCadranId, // Lier la relève avec l'instance cadran
                    PrixWatt = 0 // Le PrixWatt sera informé lors de la validation
                };
                await _context.ReleveCadrans.AddAsync(releveCadran);
                await _context.SaveChangesAsync();
                // Ajouter pour obtenir un identifiant
            }
            // Retourner la relève
            var releveAjoutee = await _context.Releves
                .Where(r => r.ReleveId == releve.ReleveId)
                .Include(r => r.ReleveCadrans)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return releveAjoutee ?? null;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau de l'ajout : " + exception.Message);
            throw;
        }
    }
    
    // Fonction pour confirmer la création d'une nouvelle relève
    public async Task<Releve?> ConfirmerCreationNouvelleReleve(
        ConfirmerCreationNouvelleReleveRequestDto confirmerCreationNouvelleReleveRequestDto)
    {
        try
        { 
            // Mettre à jours toutes les rèleves cadrans envoyées
            foreach (var releveCadranRenseignee in confirmerCreationNouvelleReleveRequestDto.ReleveCadrans)
            {
                var releveCadranNonRenseignee = await _context.ReleveCadrans
                    .Where(rc => rc.ReleveCadranId == releveCadranRenseignee.ReleveCadranId)
                    .FirstOrDefaultAsync();
                if (releveCadranNonRenseignee is not null) // Si la relève non renseingée existe effectivement dans la base de données
                {
                    releveCadranNonRenseignee.IndexRoues = releveCadranRenseignee.IndexRoues;
                    releveCadranNonRenseignee.PrixWatt = releveCadranRenseignee.PrixWatt;
                }
            }
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
            // Retourner la relève
            var releveRenseignee = await _context.Releves
                .Where(r => r.ReleveId == confirmerCreationNouvelleReleveRequestDto.ReleveId)
                .Include(r => r.ReleveCadrans)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return releveRenseignee ?? null;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau de la confirmation de l'ajout : " + exception.Message);
            throw;
        }
    }
    public async Task<Releve?> ModifierReleve(ModifierReleveRequestDto modifierReleveRequestDto)
    {
        try
        {
            await _context.Releves
                .Where(r => r.ReleveId == modifierReleveRequestDto.ReleveId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.DateReleve, modifierReleveRequestDto.DateReleve)
                    .SetProperty(p => p.OperateurId, modifierReleveRequestDto.OperateurId));
            return await _context.Releves.Where(r => r.ReleveId == modifierReleveRequestDto.ReleveId).FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau de la modification : " + exception.Message);
            throw;
        }
    }

    public async Task<Releve?> TrouverReleveEtRelevesCadran(int idReleve)
    {
        try
        {
            var releve = await _context.Releves
                .Where(r => r.ReleveId == idReleve)
                .Include(r => r.ReleveCadrans)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return releve;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau du listage : " + exception.Message);
            throw;
        }
    }

    public async Task<bool> DeleteReleve(int idReleve)
    {
        try
        {
            // Supprimer les ReleveCadrans 
            var del = await context.ReleveCadrans
                .Where(rc => rc.ReleveId == idReleve)
                .ExecuteDeleteAsync();
            // Supprimer la Releve
            var rowsDeleted = await context.Releves
                .Where(r => r.ReleveId == idReleve)
                .ExecuteDeleteAsync();
            Console.WriteLine(rowsDeleted);
            return rowsDeleted > 0;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau de la suppression de la relève : " + exception.Message);
            throw;
        }
    }
}