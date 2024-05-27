using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IAdministrateurRepository
{
    Task<Administrateur?> Register(RegisterRequest registerRequest);
    Task<Administrateur?> Authenticate(LoginRequest tokenGenerationRequest);
}