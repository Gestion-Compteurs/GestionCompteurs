using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IRegieRepository
{
    Task<bool?> UnlockAdministrateur(int administrateurId, int regieId);
    Task<IEnumerable<Administrateur?>?> ListAllAdministrateurs(int regieId);
    Task<IEnumerable<Operateur?>?> ListAllAgents(int regieId);
    Task<Regie?> Authenticate(LoginRequest tokenGenerationRequest);
}