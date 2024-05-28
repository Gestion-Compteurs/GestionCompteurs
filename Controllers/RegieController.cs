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

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de AuthenticateRegie");
            throw;
        }
    }
    
    [HttpPost("UnlockAdministrateur/{administrateurId:int:min(0)}/{regieId:int:min(0)}")]
    public async Task<IActionResult> UnlockAdministrateur(
        [FromRoute] int administrateurId,
        [FromRoute] int regieId
    )
    {
        try
        {

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de UnlockAdministrateur");
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

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de ListAllAdministrateurs");
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

        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le contrôlleur de la régie au niveau de ListAllAgents");
            throw;
        }
    }
    
}