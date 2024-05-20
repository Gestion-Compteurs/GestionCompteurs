
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
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
    
    // Ajouter une instance de compteur à un bâtiment
    public async Task<Batiment?> AjouterInstanceCompteur(AjouterInstanceCompteurRequestDto ajouterInstanceCompteurRequestDto)
    {
        try
        {
            // Chercher le bâtiment correspondant
            var batiment = await _context.Batiments
                .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId)
                .Include(b => b.InstanceCompteurs)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            // Chercher le type de compteur correspondant pour avoir les détails
            var compteur = await _context.Compteurs
                .Where(c => c.CompteurId == ajouterInstanceCompteurRequestDto.CompteurId)
                .Include(c => c.TypesCadrans)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (compteur is null || !compteur.TypesCadrans.Any())
                return await _context.Batiments
                    .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId).FirstOrDefaultAsync();
            // Créer et ajouter l'instance compteur au context afin d'obtenir un identifiant
            var instanceCompteur = new InstanceCompteur
            {
                // Reférencer le bâtiment, comme ça dans la liste des instances compteurs du bâtiment on va retrouver notre instance
                BatimentId = ajouterInstanceCompteurRequestDto.BatimentId,
                CompteurId = ajouterInstanceCompteurRequestDto.CompteurId,
                DateInstallation = ajouterInstanceCompteurRequestDto.DateInstallation,
            };
            // Insertion pour obtenir un identifiant
            await _context.InstanceCompteurs.AddAsync(instanceCompteur);
            await _context.SaveChangesAsync();
            // Remplir la liste des instances cadrans en créeant les instances de cadrans correspondantes aux types de cadrans du type de compteur
            foreach (var typeCadran in compteur.TypesCadrans)
            {
                var instanceCadran = new InstanceCadran
                {
                    // InstanceCadranId sera remplie à l'insertion dans la base de données
                    CadranId = typeCadran.CadranId, // La clé étrangère du type de cadran
                    IndexRoues = 0, // Pas encore utilisé
                    // Si l'id n'est pas disponible, je vais faire un SaveChangesAsync puis un FirstOrDefaultAsync
                    InstanceCompteurId = instanceCompteur.CompteurId, // La clé etrangère du type de compteur
                };
                await _context.InstanceCadrans.AddAsync(instanceCadran);
                await _context.SaveChangesAsync();
            }
            // Sauvegarder les changements dans la base de données
            await _context.SaveChangesAsync();
            return await _context.Batiments
                    .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId)
                    .Include(b => b.InstanceCompteurs)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de l'ajout de l'instance compteur " + exception.Message);
            throw;
        }
    }

    // Modifier l'adresse d'un bâtiment
    public async Task<Batiment?> ModifierAdresseBatiment(int idBatiment, string nouvelleAdresse)
    {
        try
        {
            var batiment = await _context.Batiments
                .Where(b => b.BatimentId == idBatiment)
                .FirstOrDefaultAsync();
            if (batiment is null)
                return null;
            batiment.Adresse = nouvelleAdresse;
            await _context.SaveChangesAsync();
            return await _context.Batiments.Where(b => b.BatimentId == idBatiment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de la modification d'adresse de l'instance compteur " + exception.Message);
            throw;
        }
    }
    
    // Retouver un bâtiment et ses instances compteur
    public async Task<Batiment?> RetrouverInstancesCompteurs(int idBatiment)
    {
        try
        {
            return await _context.Batiments.Where(b => b.BatimentId == idBatiment)
                .Include(b => b.InstanceCompteurs)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite lors du listage des instances compteur " + exception.Message);
            throw;
        }
    }

    public async Task<Batiment?> ModifierDetailsBatiment(int idBatiment, UpdateBatimentRequestDto updateBatimentRequestDto)
    {
        try
        {
            var batiment = await _context.Batiments
                .Where(b => b.BatimentId == idBatiment)
                .FirstOrDefaultAsync();
            if (batiment is null)
                return null;
            batiment.Adresse = updateBatimentRequestDto.Adresse;
            batiment.TypeBatiment = updateBatimentRequestDto.TypeBatiment;
            batiment.NombreEtages = updateBatimentRequestDto.NombreEtages;
            await _context.SaveChangesAsync();
            return await _context.Batiments.Where(b => b.BatimentId == idBatiment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de la modification d'adresse de l'instance compteur " + exception.Message);
            throw;
        }
    }
}

