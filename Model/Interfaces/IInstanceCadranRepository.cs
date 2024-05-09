using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;


public interface IInstanceCadranRepository
{

    
    Task<List<InstanceCadran>> GetAllAsync();
    Task<InstanceCadran?> GetByIdAsync(int id);
    Task<InstanceCadran?> CreateAsync(InstanceCadran commentModel);
    Task<bool> InstanceCadranExists(int id );
    
}