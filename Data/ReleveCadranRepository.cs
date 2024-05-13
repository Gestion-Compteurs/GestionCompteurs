using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Data;

using Model.Entities;
using Model.Interfaces;
using Microsoft.EntityFrameworkCore;


public class ReleveCadranRepository : IReleveCadranRepository
{
    private readonly ApplicationDbContext _context;

    public ReleveCadranRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReleveCadran>> GetAllAsync()
    {
        return await _context.ReleveCadrans.AsNoTracking().ToListAsync();
    }

    public async Task<ReleveCadran?> GetByIdAsync(int id)
    {
        var releveCadran = await _context.ReleveCadrans.FirstOrDefaultAsync(c => c.ReleveCadranId == id);
        return releveCadran;
    }


    // Ajouter une relève d'un cadran
    public async Task<ReleveCadran?> CreateAsync(ReleveCadran releveCadranModel)
    {
        await _context.ReleveCadrans.AddAsync(releveCadranModel);
        await _context.SaveChangesAsync();
        return releveCadranModel;
    }

    // Créer une relève pour une instance cadran
    public async Task<ReleveCadran?> AjouterReleveCadran(CreateReleveCadranRequestDto createReleveCadranRequestDto)
    {
        throw new NotImplementedException();
    }

    // Modifier une relève d'un cadran
    public async Task<ReleveCadran?> ModifierReleveCadran(ModifierReleveCadranRequestDto modifierReleveCadranRequestDto)
    {
        try
        {
            await _context.ReleveCadrans
                    .Where(r => r.ReleveCadranId == modifierReleveCadranRequestDto.ReleveCadranId)
                    .ExecuteUpdateAsync(r =>
                        r.SetProperty(p => p.IndexRoues, modifierReleveCadranRequestDto.IndexRoues)
                            .SetProperty(p => p.PrixWatt, modifierReleveCadranRequestDto.PrixWatt)
                    );
            return await _context.ReleveCadrans
                .Where(r => r.ReleveCadranId == modifierReleveCadranRequestDto.ReleveCadranId).FirstOrDefaultAsync();
        }
        catch(Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans le repository relève cadran au niveau de la modification : " + exception.Message);
            throw;
        }
    }

    public async Task<bool> ReleveCadranExists(int id)
    {
        return await _context.ReleveCadrans.AnyAsync(s => s.ReleveCadranId == id);
    }
}