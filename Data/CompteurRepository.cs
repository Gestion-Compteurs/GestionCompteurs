using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
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

        public async Task<bool> DeleteAsync(int id)
        {
            var compteurSupprime = await _context.Compteurs.
                Where(compteur=>compteur.CompteurId==id)
                .ExecuteDeleteAsync();
            return compteurSupprime >= 1;
        }

        public async Task<bool> CompteurExists(int id)
        {
            return await _context.Compteurs.AnyAsync(s => s.CompteurId == id);
        }
        
        // Ajouter une instance compteur et les types cadrans nécéssaires directement
        public async Task<Compteur?> AjouterCompteurEtTypesCadrans(AjouterCompteurRequestDto ajouterCompteurRequestDto)
        {
            try
            {
                // Créer l'objet compteur 
                var compteurCree = CompteurMapper.ToCompteurDtoFromAjouterCompteurRequestDto(ajouterCompteurRequestDto);
                // L'ajouter dans la base de données pour avoir un identifiant
                await _context.Compteurs.AddAsync(compteurCree);
                await _context.SaveChangesAsync();
                // Retrouver tous les types cadrans dans le Dto et créer les compteurs nécéssaires associés dans la base de données s'ils n'existent pas
                foreach (var cadranAjoute in ajouterCompteurRequestDto.TypesCadrans)
                {
                    // Vérifier si le cadran existe déja, on le retrouve avec les compteurs le possédant et avec tracking des changements
                    var cadranExiste = await _context.Cadrans
                        .Where(cadran => cadran.CadranModel == cadranAjoute.CadranModel)
                        .Include(cadran => cadran.CompteursLePossedant)
                        .FirstOrDefaultAsync();
                    // S'il n'existe pas, on le crée d'abord
                    if (cadranExiste is null)
                    {
                        // On le crée
                        var cadranCreation = await _context.Cadrans.AddAsync(CadranMapper.ToCadranFromCreateDto(cadranAjoute));
                        await _context.SaveChangesAsync();
                        // Si on arrive pas à le créer, on lance une exception
                        if (cadranCreation is null) throw new Exception("Une erreur s'est produite dans le repository de creéation de compteur, lors de l'ajout d'un nouveau cadran");
                    }
                    // Puis on le lie au compteur
                    var cadranCreeMaintenantOuExistant = await _context.Cadrans
                        .Where(cadran => cadran.CadranModel == cadranAjoute.CadranModel)
                        .Include(cadran => cadran.CompteursLePossedant)
                        .FirstOrDefaultAsync();
                    _context.CompteurCadrans.Add(
                        new CompteurCadran
                        {
                            CompteurId = compteurCree.CompteurId,
                            CadranId = cadranCreeMaintenantOuExistant.CadranId
                        });
                }
                // On sauvegarde tous les changements
                await _context.SaveChangesAsync();
                // Puis on retourne le compteur
                return await _context.Compteurs
                        .Where(compteur => compteur.CompteurId == compteurCree.CompteurId)
                        .FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Une erreur s'est produite dans le repository du compteur au niveau de l'ajout : " + exception.Message);
                throw;
            }
        }
    }
