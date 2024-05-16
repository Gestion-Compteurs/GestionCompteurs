using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface ICompteurRepository
{
    Task<List<Compteur>> GetAllAsync();
    Task<Compteur?> GetByIdAsync(int id);
    Task<Compteur> CreateAsync(Compteur compteurModel);
    Task<Compteur?> UpdateAsync(int id,UpdateCompteurRequestDto compteurModel);
    Task<bool> DeleteAsync(int id);
    Task<bool> CompteurExists(int id);
    Task<Compteur?> AjouterCompteurEtTypesCadrans(AjouterCompteurRequestDto ajouterCompteurRequestDto);
}