using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdministrateurController(IAdministrateurRepository administrateurRepository) : ControllerBase
{
    private readonly IAdministrateurRepository _administrateurRepository = administrateurRepository;

    [HttpPost("Authenticate")]
    public async Task<IActionResult> AuthenticateAdmin(
        [FromBody] LoginRequest loginRequest
    )
    {
        try
        {
            var authenticateRequestBody = await _administrateurRepository.Authenticate(loginRequest);
            if (authenticateRequestBody is not null) return Ok(authenticateRequestBody);
            return NotFound("Mot de passe ou nom d'utilisateur incorrect");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de l'administrateur au niveau de AuthenticateAdmin {exception}");
            throw;
        }
    }
}