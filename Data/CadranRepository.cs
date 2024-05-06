using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class CadranRepository:ICadranRepository
{
    private readonly ApplicationDbContext _context;
    public CadranRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Cadran>> GetAllAsync()
    {
        return await _context.Cadrans.Include(c=>c.InstancesCadran).ToListAsync();
    }

    public async Task<Cadran?> GetByIdAsync(int id)
    {
        return await _context.Cadrans.Include(c=>c.InstancesCadran).FirstOrDefaultAsync(x=>x.CadranId==id);
    }

    public async Task<Cadran> CreateAsync(Cadran cadranModel)
    {
        await _context.Cadrans.AddAsync(cadranModel);
        await _context.SaveChangesAsync();
        return cadranModel;
    }

    public async Task<Cadran?> UpdateAsync(int id,UpdateCadranRequestDto updateDto)
    {
        var cadranModel = await _context.Cadrans.FirstOrDefaultAsync(x=>x.CadranId==id);
        if (cadranModel == null) return null;
        cadranModel.HeureActivation = updateDto.HeureActivation;
        cadranModel.HeureArret = updateDto.HeureArret;
        cadranModel.NombreRoues = updateDto.NombreRoues;
        cadranModel.PrixMetreCube = updateDto.PrixMetreCube;
     
        
        await _context.SaveChangesAsync();
        return cadranModel;
    }

    public async Task<Cadran?> DeleteAsync(int id)
    {
        var cadranModel = await _context.Cadrans.FirstOrDefaultAsync(x=>x.CadranId==id);
        if (cadranModel == null)
            return null;
        _context.Cadrans.Remove(cadranModel);
        await _context.SaveChangesAsync();
        return cadranModel;
    }

    public async Task<bool> CadranExists(int id)
    {
        return await _context.Cadrans.AnyAsync(s => s.CadranId == id);
    }
}
