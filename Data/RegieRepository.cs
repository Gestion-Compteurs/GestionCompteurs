using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Methods;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class RegieRepository(
    ApplicationDbContext context
    ): IRegieRepository
{
    public async Task<bool?> UnlockAdministrateur(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Administrateur?>?> ListAllAdministrateurs()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Administrateur?>?> ListAllAgents()
    {
        throw new NotImplementedException();
    }

    public async Task<Regie?> Authenticate(RegisterRequest tokenGenerationRequest)
    {
        try
        {
            if (tokenGenerationRequest.Email is null || tokenGenerationRequest.Password is null)
                return null;
            var regie = await context.Regies
                .Where(r => r.EmailRegie == tokenGenerationRequest.Email 
                            && 
                            r.PasswordRegie == tokenGenerationRequest.Password).FirstOrDefaultAsync();
            return regie ?? null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de la régie au niveau de l'authentification : {exception}");
            throw;
        }
        
    }
}