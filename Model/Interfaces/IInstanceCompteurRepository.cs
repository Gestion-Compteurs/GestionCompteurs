using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IInstanceCompteurRepository
{

    
        Task<List<InstanceCompteur>> GetAllAsync();
        Task<InstanceCompteur?> GetByIdAsync(int id);
        Task<InstanceCompteur?> CreateAsync(InstanceCompteur commentModel);
    
}