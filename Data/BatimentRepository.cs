
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

    public async Task<Batiment?> AjouterInstanceCompteur(AjouterInstanceCompteurRequestDto ajouterInstanceCompteurRequestDto)
    {
        try
        {
            var batiment = await _context.Batiments
                .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId)
                .Include(b => b.InstanceCompteurs).FirstOrDefaultAsync();
            if (batiment is null)
                return await _context.Batiments
                    .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId).FirstOrDefaultAsync();
            var instanceCompteur = new InstanceCompteur
            {
                BatimentId = ajouterInstanceCompteurRequestDto.BatimentId,
                CompteurId = ajouterInstanceCompteurRequestDto.CompteurId,
                DateInstallation = ajouterInstanceCompteurRequestDto.DateInstallation,
                InstanceCadrans = new List<InstanceCadran>()
            };
            batiment.InstanceCompteurs = batiment.InstanceCompteurs.Append(instanceCompteur);
            _context.Update(batiment);
            await _context.SaveChangesAsync();
            /*
                await _context.Batiments.Where( b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId)
                    .ExecuteUpdateAsync(b =>
                    b.SetProperty(p => p.InstanceCompteurs, batiment.InstanceCompteurs.Append(instanceCompteur)));
                */
            return await _context.Batiments
                .Where(b => b.BatimentId == ajouterInstanceCompteurRequestDto.BatimentId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine("Une erreur s'est produite lors de l'ajout de l'instance compteur " + exception.Message);
            throw;
        }
    }

    public async Task<Batiment?> ModifierAdresseBatiment(int idBatiment, string nouvelleAdresse)
    {
        try
        {
            var batiment = await _context.Batiments.Where(b => b.BatimentId == idBatiment).FirstOrDefaultAsync();
            if (batiment is not null)
            {
                batiment.Adresse = nouvelleAdresse;
                _context.Update(batiment);
                await _context.SaveChangesAsync();
            }
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
}