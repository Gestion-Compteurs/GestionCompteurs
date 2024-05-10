
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionCompteursElectriquesMoyenneTension.Model.Repositories
{
    public class OperateurRepository : IOperateurRepository
    {
        private readonly ApplicationDbContext _context;

        public OperateurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Operateur>> GetAllAsync()
        {
            return await _context.Operateurs.ToListAsync();
        }

        public async Task<Operateur> GetByIdAsync(int id)
        {
            return await _context.Operateurs.FindAsync(id);
        }

        public async Task CreateAsync(Operateur operateur)
        {
            _context.Operateurs.Add(operateur);
            await _context.SaveChangesAsync();
        }

        public async Task<Operateur> UpdateAsync(int id, UpdateOperateurRequestDto updateDto)
        {
            var operateur = await _context.Operateurs.FindAsync(id);
            if (operateur == null)
                return null;

            // Mettre à jour les propriétés nécessaires avec les valeurs du DTO
            operateur.Nom = updateDto.Nom;
            operateur.Prenom = updateDto.Prenom;
            operateur.CIN = updateDto.CIN;
            operateur.Email = updateDto.Email;
            operateur.DateDeNaissance = updateDto.DateDeNaissance;
            await _context.SaveChangesAsync();
            return operateur;
        }

        public async Task<Operateur> DeleteAsync(int id)
        {
            var operateur = await _context.Operateurs.FindAsync(id);
            if (operateur == null)
                return null;

            _context.Operateurs.Remove(operateur);
            await _context.SaveChangesAsync();
            return operateur;
        }
    }
}

