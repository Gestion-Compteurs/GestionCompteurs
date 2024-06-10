using System.Diagnostics;
using System.Security.Cryptography;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Methods;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class AdministrateurRepository(
    ApplicationDbContext context,
    IPasswordHasher<Administrateur> passwordHasher
    ) : IAdministrateurRepository
{
     public async Task<Administrateur?> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (registerRequest?.RegieId is null)
                    return null;

                // Check if RegieId exists in the Regies table
                var regieExists = await context.Regies.AnyAsync(r => r.RegieId == registerRequest.RegieId);
                if (!regieExists)
                {
                    // Return a meaningful error response or handle as needed
                    throw new ArgumentException("Invalid RegieId. The specified Regie does not exist.");
                }

                var administrateur = new Administrateur
                {
                    UserName = registerRequest.Email,
                    Email = registerRequest.Email,
                    Password = registerRequest.Password,
                    PasswordHash = "",
                    RegieId = registerRequest.RegieId,
                    Nom = registerRequest.Nom,
                    Prenom = registerRequest.Prenom,
                    DateDeNaissance = registerRequest.DateDeNaissance
                };

                if (registerRequest.Password != null)
                    administrateur.PasswordHash = passwordHasher.HashPassword(administrateur, registerRequest.Password);

                await context.Administrateurs.AddAsync(administrateur);
                await context.SaveChangesAsync();

                return administrateur;
            }
            catch (DbUpdateException dbEx)
            {
                // Log the exception and return a meaningful error response
                Console.WriteLine($"A database update exception occurred in the Administrateur repository during register: {dbEx.InnerException?.Message ?? dbEx.Message}");
                throw new Exception("A database error occurred while saving the administrator. Please ensure all foreign key constraints are met.");
            }
            catch (ArgumentException argEx)
            {
                // Handle specific argument exceptions
                Console.WriteLine(argEx.Message);
                return null; // or rethrow if you prefer to handle it upstream
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An exception occurred in the Administrateur repository during register: {exception}");
                throw;
            }
        }
    public async Task<Administrateur?> Authenticate(LoginRequest tokenGenerationRequest)
    {
        try
        {
            if (tokenGenerationRequest is { Password: null })
                return null;
            var administrateur = await context.Administrateurs
                .Where(a => a.Email == tokenGenerationRequest.Email 
                            || a.UserName == tokenGenerationRequest.Email
                            &&
                            a.RegieId == tokenGenerationRequest.RegieId
                            ).FirstOrDefaultAsync(); 
            var passwordCorrect = passwordHasher.VerifyHashedPassword(administrateur, administrateur.PasswordHash, tokenGenerationRequest.Password);
            Console.WriteLine(passwordCorrect);
            if(passwordCorrect>0)  return administrateur is { CompteActif: true } ? administrateur : null;
            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de l'administrateur au niveau de l'authentification : {exception}");
            throw;
        }
    }
}