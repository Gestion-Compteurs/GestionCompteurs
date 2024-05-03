using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class CompteurRepository:ICompteurRepository
    {
        private readonly ApplicationDbContext _context;
        public CompteurRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Compteur>> GetAllAsync()
        {
            return await _context.Compteurs.Include(c=>c.InstanceCompteurs).ToListAsync();
        }

        public async Task<Compteur?> GetByIdAsync(int id)
        {
            return await _context.Compteurs.Include(c=>c.InstanceCompteurs).FirstOrDefaultAsync(x=>x.CompteurId==id);
        }

        public async Task<Compteur> CreateAsync(Compteur compteurModel)
        {
            await _context.Compteurs.AddAsync(compteurModel);
            await _context.SaveChangesAsync();
            return compteurModel;
        }

        public async Task<Compteur?> UpdateAsync(int id,UpdateCompteurRequestDto updateDto)
        {
            var compteurModel = await _context.Compteurs.FirstOrDefaultAsync(x=>x.CompteurId==id);
            if (compteurModel == null) return null;
            compteurModel.Marque = updateDto.Marque;
            compteurModel.Modele = updateDto.Modele;
            compteurModel.AnneeCreation = updateDto.AnneeCreation;
            compteurModel.VoltageMax = updateDto.VoltageMax;
        
            await _context.SaveChangesAsync();
            return compteurModel;
        }

        public async Task<Compteur?> DeleteAsync(int id)
        {
            var compteurModel = await _context.Compteurs.FirstOrDefaultAsync(x=>x.CompteurId==id);
            if (compteurModel == null)
                return null;
            _context.Compteurs.Remove(compteurModel);
            await _context.SaveChangesAsync();
            return compteurModel;
        }

        public async Task<bool> CompteurExists(int id)
        {
            return await _context.Compteurs.AnyAsync(s => s.CompteurId == id);
        }
    }
