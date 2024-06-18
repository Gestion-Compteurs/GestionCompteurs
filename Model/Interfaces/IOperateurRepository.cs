
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;


namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

   public interface IOperateurRepository
    {
        Task<List<Operateur>> GetAllAsync();
        Task<Operateur?> GetByIdAsync(int id);
        Task<Operateur> CreateAsync(Operateur operateurModel);
        Task<Operateur?> UpdateAsync(int id, UpdateOperateurRequestDto operateurModel);
        Task<Operateur?> DeleteAsync(int id);
        Task<bool> OperateurExists(int id);
        
        
        
    }






    

