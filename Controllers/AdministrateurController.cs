using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdministrateurController(IAdministrateurRepository administrateurRepository) : ControllerBase
{
    private readonly IAdministrateurRepository _administrateurRepository = administrateurRepository;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAdmin(
        [FromBody] RegisterRequest registerRequest
    )
    {
        try
        {
            var registerRequestBody = await _administrateurRepository.Register(registerRequest);
            if (registerRequestBody is not null) return Ok(registerRequestBody);
            return StatusCode(StatusCodes.Status417ExpectationFailed);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de l'administrateur au niveau de RegisterAdmin {exception}");
            throw;
        }
    }
}