using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class InstanceCompteurRepository:IInstanceCompteurRepository
{
    private readonly ApplicationDbContext _context;
    public InstanceCompteurRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<InstanceCompteur>> GetAllAsync()
    {
        return await _context.InstanceCompteurs.AsNoTracking().ToListAsync();
    }

    public async Task<InstanceCompteur?> GetByIdAsync(int id)
    {
        var instanceCompteur = await _context.InstanceCompteurs.Include(c=>c.Cadrans).FirstOrDefaultAsync(c=>c.InstanceCompteurId == id);
        return instanceCompteur ;
    }

    
    public async Task<InstanceCompteur?> CreateAsync(InstanceCompteur instanceCompteurModel)
    {
        await _context.InstanceCompteurs.AddAsync(instanceCompteurModel);
        await _context.SaveChangesAsync();
        return instanceCompteurModel;
    }
}