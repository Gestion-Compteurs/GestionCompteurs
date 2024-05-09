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


    public async Task<ReleveCadran?> CreateAsync(ReleveCadran releveCadranModel)
    {
        await _context.ReleveCadrans.AddAsync(releveCadranModel);
        await _context.SaveChangesAsync();
        return releveCadranModel;
    }

    public async Task<bool> ReleveCadranExists(int id)
    {
        return await _context.ReleveCadrans.AnyAsync(s => s.ReleveCadranId == id);
    }
}