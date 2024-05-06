using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface ICadranRepository
{
    Task<List<Cadran>> GetAllAsync();
    Task<Cadran?> GetByIdAsync(int id);
    Task<Cadran> CreateAsync(Cadran compteurModel);
    Task<Cadran?> UpdateAsync(int id,UpdateCadranRequestDto compteurModel);
    Task<Cadran?> DeleteAsync(int id);
    Task<bool> CadranExists(int id);
}