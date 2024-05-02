using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IBatimentRepository
{
    Task<List<Batiment>> GetAllAsync();
    Task<Batiment?> GetByIdAsync(int id);
    Task<Batiment> CreateAsync(Batiment batimentModel);
    Task<Batiment?> UpdateAsync(int id,UpdateBatimentRequestDto batimentModel);
    Task<Batiment?> DeleteAsync(int id);
    Task<bool> BatimentExists(int id);
}