using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IRegieRepository
{
    Task<bool?> UnlockAdministrateur(LoginRequest loginRequest);
    Task<IEnumerable<Administrateur?>?> ListAllAdministrateurs();
    Task<IEnumerable<Administrateur?>?> ListAllAgents();
    Task<Regie?> Authenticate(RegisterRequest tokenGenerationRequest);
}