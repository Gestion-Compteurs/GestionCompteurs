using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IAdministrateurRepository
{
    Task<IdentityResult?> Register(RegisterRequest registerRequest);
    Task<SignInResult?> Login(LoginRequest loginRequest);
    Task<Administrateur> Authenticate(LoginRequest tokenGenerationRequest);
}