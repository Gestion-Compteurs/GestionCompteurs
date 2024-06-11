using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RegieController(IRegieRepository regieRepository) : ControllerBase
{
    private readonly IRegieRepository _regieRepository = regieRepository;
    
    [HttpPost("Authenticate")]
    public async Task<IActionResult> AuthenticateRegie(
        [FromBody] LoginRequest loginRequest
    )
    {
        try
        {
            var authenticateRequestBody = await _regieRepository.Authenticate(loginRequest);
            if (authenticateRequestBody is not null) return Ok(authenticateRequestBody);
            return NotFound("Mot de passe ou nom d'utilisateur incorrect");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de AuthenticateRegie {exception}");
            throw;
        }
    }
    
    [HttpPut("UnlockAdministrateur/{administrateurId:int:min(0)}/{regieId:int:min(0)}")]
    public async Task<IActionResult> UnlockAdministrateur(
        [FromRoute] int administrateurId,
        [FromRoute] int regieId
    )
    {
        try
        {
            var adminUnlocked = await _regieRepository.UnlockAdministrateur(administrateurId, regieId);
            if (adminUnlocked is true) return Ok(true);
            return StatusCode(StatusCodes.Status417ExpectationFailed);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de UnlockAdministrateur {exception}");
            throw;
        }
    }
    
    [HttpPut("lockAdministrateur/{administrateurId:int:min(0)}/{regieId:int:min(0)}")]
    public async Task<IActionResult> LockAdministrateur(
        [FromRoute] int administrateurId,
        [FromRoute] int regieId
    )
    {
        try
        {
            var adminUnlocked = await _regieRepository.LockAdministrateur(administrateurId, regieId);
            if (adminUnlocked is true) return Ok(true);
            return StatusCode(StatusCodes.Status417ExpectationFailed);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de LockAdministrateur {exception}");
            throw;
        }
    }
    
    [HttpGet("ListAllAdministrateurs/{regieId:int:min(0)}")]
    public async Task<IActionResult> ListAllAdministrateurs(
        [FromRoute] int regieId
    )
    {
        try
        {
            var administrateurs = await _regieRepository.ListAllAdministrateurs(regieId);
            return Ok(administrateurs);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de ListAllAdministrateurs {exception}");
            throw;
        }
    }
    
    [HttpGet("ListAllAgents/{regieId:int:min(0)}")]
    public async Task<IActionResult> ListAllAgents(
        [FromRoute] int regieId
    )
    {
        try
        {
            var agents = await _regieRepository.ListAllAgents(regieId);
            return Ok(agents);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de ListAllAgents {exception}");
            throw;
        }
    }
    
}