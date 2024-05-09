using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IReleveCadranRepository
{
    Task<List<ReleveCadran>> GetAllAsync();
    Task<ReleveCadran?> GetByIdAsync(int id);
    Task<ReleveCadran?> CreateAsync(ReleveCadran releveCadranModel);
}