using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCadransElectriquesMoyenneTension.Model.Interfaces;


public interface IInstanceCadranRepository
{

    
    Task<List<InstanceCadran>> GetAllAsync();
    Task<InstanceCadran?> GetByIdAsync(int id);
    Task<InstanceCadran?> CreateAsync(InstanceCadran commentModel);
    
}