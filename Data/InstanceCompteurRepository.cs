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
        // return await _context.InstanceCompteurs.Include(c=>c.InstanceCadrans).AsNoTracking().ToListAsync();//did not include cadrans instances here
         var instanceCompteurs = await _context.InstanceCompteurs.Include(c=>c.InstanceCadrans).ToListAsync();//did not include cadrans instances here
         return instanceCompteurs;
    }

    public async Task<InstanceCompteur?> GetByIdAsync(int id)
    {
        var instanceCompteur = await _context.InstanceCompteurs.Include(c=>c.InstanceCadrans).FirstOrDefaultAsync(c=>c.InstanceCompteurId == id);
        return instanceCompteur ;
    }

    
    public async Task<InstanceCompteur?> CreateAsync(InstanceCompteur instanceCompteurModel)
    {
        await _context.InstanceCompteurs.AddAsync(instanceCompteurModel);
        await _context.SaveChangesAsync();
        return instanceCompteurModel;
    }

    public async Task<bool> InstanceCompteurExists(int id)
    {
        return await _context.InstanceCompteurs.AnyAsync(s => s.InstanceCompteurId == id);
    }

    /*public async Task<InstanceCompteur?> CreateInstanceCadranAsync(InstanceCadran commentModel)
    {
        throw new NotImplementedException();
    }*/
}