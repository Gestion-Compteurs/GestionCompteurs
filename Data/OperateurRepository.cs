
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GestionCompteursElectriquesMoyenneTension.Data;

public class OperateurRepository : IOperateurRepository
{
        private readonly ApplicationDbContext _context;

        public OperateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Operateur>> GetAllAsync()
        {
            return await _context.Operateurs.ToListAsync();
        }

         
        public async Task<Operateur?> GetByIdAsync(int id)
        {
            return await _context.Operateurs.Where(x=>x.OperateurId==id).FirstOrDefaultAsync();
        }

        public async Task<Operateur> CreateAsync(Operateur operateurModel)
        {
            await _context.Operateurs.AddAsync(operateurModel);
            await _context.SaveChangesAsync();
            return operateurModel;
        }

        

        public async Task<Operateur?> UpdateAsync(int id, UpdateOperateurRequestDto updateDto)
        {
            var operateurModel = await _context.Operateurs.Where(x=>x.OperateurId==id).FirstOrDefaultAsync();
            if (operateurModel == null)
                return null;

            operateurModel.Nom = updateDto.Nom;
            operateurModel.Prenom = updateDto.Prenom;
            operateurModel.Cin = updateDto.CIN;
            operateurModel.DateDeNaissance = updateDto.DateDeNaissance;
            operateurModel.Civilite=updateDto.Civilite;
            operateurModel.DateEmbauche=updateDto.DateEmbauche;
            await _context.SaveChangesAsync();
            return operateurModel;
        }


        public async Task<Operateur?> DeleteAsync(int id)
        {
            var operateurModel = await _context.Operateurs.Where(x=>x.OperateurId==id).FirstOrDefaultAsync();
            if (operateurModel == null)
                return null;

            _context.Operateurs.Remove(operateurModel);
            await _context.SaveChangesAsync();
            return operateurModel;
        }

        

         
            public async Task<bool> OperateurExists(int id)
            {
                return await _context.Operateurs.AnyAsync(s => s.OperateurId == id);
            }         
            
    }


