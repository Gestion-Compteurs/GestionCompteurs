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