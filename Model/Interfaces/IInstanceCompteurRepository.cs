using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IInstanceCompteurRepository
{

    
        Task<List<InstanceCompteur>> GetAllAsync();
        Task<InstanceCompteur?> GetByIdAsync(int id);
        Task<InstanceCompteur?> CreateAsync(InstanceCompteur instance);
        Task<bool> InstanceCompteurExists(int id);
        Task<InstanceCompteur?>  TrouverInstanceEtReleves(int idInstanceCompteur);

    //Task<InstanceCompteur?> CreateInstanceCadranAsync(InstanceCadran commentModel);

}