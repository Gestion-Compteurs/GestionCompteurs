using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class RegieRepository(
    ApplicationDbContext context
    ): IRegieRepository
{
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
    public async Task<bool?> UnlockAdministrateur(LoginRequest loginRequest)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le repository de la régie au niveau de UnlockAdministrateur {exception.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Administrateur?>?> ListAllAdministrateurs()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le repository de la régie au niveau de ListAllAdministrateurs {exception.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Administrateur?>?> ListAllAgents()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le repository de la régie au niveau de ListAllAgents {exception.Message}");
            throw;
        }
    }
}