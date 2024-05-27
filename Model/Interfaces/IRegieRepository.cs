using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IRegieRepository
{
    Task<IdentityResult?> Register(RegisterRequest registerRequest);
    Task<SignInResult?> Login(LoginRequest loginRequest);
    Task<Regie> Authenticate(RegisterRequest tokenGenerationRequest);
}