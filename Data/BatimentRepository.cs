
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionBatimentsElectriquesMoyenneTension.Data;

public class BatimentRepository:IBatimentRepository
{
            private readonly ApplicationDbContext _context;
            public BatimentRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Batiment>> GetAllAsync()
            {
                return await _context.Batiments.ToListAsync();
            }
    
            public async Task<Batiment?> GetByIdAsync(int id)
            {
                return await _context.Batiments.FirstOrDefaultAsync(x=>x.BatimentId==id);
            }
    
            public async Task<Batiment> CreateAsync(Batiment batimentModel)
            {
                await _context.Batiments.AddAsync(batimentModel);
                await _context.SaveChangesAsync();
                return batimentModel;
            }
    
            public async Task<Batiment?> UpdateAsync(int id,UpdateBatimentRequestDto updateDto)
            {
                var batimentModel = await _context.Batiments.FirstOrDefaultAsync(x=>x.BatimentId==id);
                if (batimentModel == null) return null;
                batimentModel.Adresse= updateDto.Adresse;
                await _context.SaveChangesAsync();
                return batimentModel;
            }
    
            public async Task<Batiment?> DeleteAsync(int id)
            {
                var batimentModel = await _context.Batiments.FirstOrDefaultAsync(x=>x.BatimentId==id);
                if (batimentModel == null)
                    return null;
                _context.Batiments.Remove(batimentModel);
                await _context.SaveChangesAsync();
                return batimentModel;
            }
    
            public async Task<bool> BatimentExists(int id)
            {
                return await _context.Batiments.AnyAsync(s => s.BatimentId == id);
            }

}