using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class RegieRepository : IRegieRepository
{
    public async Task<IdentityResult?> Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<SignInResult?> Login(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<Regie> Authenticate(RegisterRequest tokenGenerationRequest)
    {
        throw new NotImplementedException();
    }
}