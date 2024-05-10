
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces
{
    public interface IOperateurRepository
    {
        Task<IEnumerable<Operateur>> GetAllAsync();
        Task<Operateur> GetByIdAsync(int id);
        Task CreateAsync(Operateur operateur);
        Task<Operateur> UpdateAsync(int id, UpdateOperateurRequestDto updateDto);
        Task<Operateur> DeleteAsync(int id);
    }
}





    

