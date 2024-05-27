using System.Diagnostics;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Data;

public class AdministrateurRepository(
    UserManager<Administrateur> userManager,
    SignInManager<Administrateur> signInManager
        ) : IAdministrateurRepository
{
    public async Task<IdentityResult?> Register(RegisterRequest registerRequest)
    {
        try
        {
            var user = new Administrateur
            {
                UserName = registerRequest.Email,
                NomAdmin = registerRequest.Nom,
                Prenom = registerRequest.Prenom,
                DateDeNaissance = registerRequest.DateDeNaissance
            };

            Debug.Assert(registerRequest.Password != null, "registerRequest.Password != null");
            var result = await userManager.CreateAsync(user, registerRequest.Password);
            return result;

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de l'administrateur au niveau du register : {exception}");
            throw;
        }
        
    }

    public async Task<SignInResult?> Login(LoginRequest loginRequest)
    {
        try
        {
            Debug.Assert(loginRequest.Email != null, "loginRequest.Email != null");
            Debug.Assert(loginRequest.Password != null, "loginRequest.Password != null");
            var result = await signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, false, false);
            return result;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une exception s'est produite dans le repository de l'administrateur au niveau du login : {exception}");
            throw;
        }
    }

    public async Task<Administrateur> Authenticate(LoginRequest tokenGenerationRequest)
    {
        throw new NotImplementedException();
    }
}