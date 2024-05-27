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
    ApplicationDbContext context
        ) : IAdministrateurRepository
{
    public async Task<Administrateur?> Register(RegisterRequest registerRequest)
    {
        try
        {
            if (registerRequest is { Password: null })
                return null;
            var administrateur = new Administrateur
            {
                UserName = registerRequest.Email,
                Password = SecurityMethods.HashPassword(registerRequest.Password),
                Nom = registerRequest.Nom,
                Prenom = registerRequest.Prenom,
                DateDeNaissance = registerRequest.DateDeNaissance
            };
            await context.Administrateurs.AddAsync(administrateur);
            await context.SaveChangesAsync();
            return administrateur;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de l'administrateur au niveau du register : {exception}");
            throw;
        }
    }

    public async Task<Administrateur?> Authenticate(LoginRequest tokenGenerationRequest)
    {
        try
        {
            if (tokenGenerationRequest is { Password: null })
                return null;
            var hashedPassword = SecurityMethods.HashPassword(tokenGenerationRequest.Password);
            var administrateur = await context.Administrateurs
                .Where(a => a.Email == tokenGenerationRequest.Email 
                            && 
                            a.PasswordHash == hashedPassword).FirstOrDefaultAsync();
            return administrateur is { CompteActif: true } ? administrateur : null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de l'administrateur au niveau de l'authentification : {exception}");
            throw;
        }
    }
}