using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class InstanceCompteurRepository:IInstanceCompteurRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IReleveRepository _releveRepository;
    public InstanceCompteurRepository(ApplicationDbContext context, IReleveRepository releveRepository)
    {
        _context = context;
        _releveRepository = releveRepository;
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
    
    // Trouver une instance compteur et ses relèves
    public async Task<InstanceCompteur?> TrouverInstanceEtReleves(int idInstanceCompteur)
    {
        try
        {
            return await _context.InstanceCompteurs
                .Where(i => i.InstanceCompteurId == idInstanceCompteur)
                .Include(i => i.Releves)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite dans  le repository de l'instance compteur " + exception.Message);
            throw;
        }
    }

    // TODO : Ajouter au front-end
    public async Task<bool> SupprimerInstanceCompteur(int idInstanceCompteur)
    {
        // Retrouver l'instance compteur concernée
        var instanceCompteurConcernee = await _context.InstanceCompteurs
            .Where(i => i.InstanceCompteurId == idInstanceCompteur)
            .Include(i => i.InstanceCadrans)
            .Include(i => i.Releves)
            .FirstOrDefaultAsync();
        // Si elle n'existe pas, retourner false
        if (instanceCompteurConcernee is null) return false;
        // Sinon si elle existe
        
        // Supprimer toutes les relèves et relèves cadrans concernées
        foreach (var releve in instanceCompteurConcernee.Releves)
        {
            await _releveRepository.DeleteReleve(releve.ReleveId);
        }
        // Supprimer toutes ses instances cadrans concernées
        await _context
            .InstanceCadrans
            .Where(ic => ic.InstanceCompteurId == instanceCompteurConcernee.InstanceCompteurId)
            .ExecuteDeleteAsync();
        // Supprimer l'instance compteur concernée
        var deletedRows = _context
            .InstanceCompteurs
            .Where(ic => ic.InstanceCompteurId == idInstanceCompteur)
            .ExecuteDelete();
        // Retouner true ou false
        return deletedRows > 0 ;
    }
    
    /*public async Task<InstanceCompteur?> CreateInstanceCadranAsync(InstanceCadran commentModel)
    {
        throw new NotImplementedException();
    }*/
}