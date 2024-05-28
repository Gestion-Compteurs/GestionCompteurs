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

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de l'administrateur au niveau de AuthenticateAdmin");
            throw;
        }
    }
}