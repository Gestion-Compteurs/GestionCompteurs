using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class ReleveRepository(ApplicationDbContext context): IReleveRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Releve> ModifierReleve(ModifierReleveRequestDto modifierReleveRequestDto)
    {
        try
        {
            await _context.Releves
                .Where(r => r.ReleveId == modifierReleveRequestDto.ReleveId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.BatimentId, modifierReleveRequestDto.BatimentId));
            return _context.Releves.Where(r => r.ReleveId == modifierReleveRequestDto.ReleveId).FirstOrDefaultAsync();
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

        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository de la relève au niveau du listage : " + exception.Message);
            throw;
        }
    }
}