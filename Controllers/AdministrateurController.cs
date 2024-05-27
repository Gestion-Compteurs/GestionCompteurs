using System.Diagnostics;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministrateurController(IAdministrateurRepository administrateurRepository) : ControllerBase
{
    private readonly IAdministrateurRepository _administrateurRepository = administrateurRepository;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _administrateurRepository.Register(model);
            if (result is { Succeeded: true })
            {
                return Ok(new { Message = "User registered successfully" });
            }
            return BadRequest(result?.Errors);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le controlleur de l'administrateur au niveau du login {exception.Message}");
            throw;
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _administrateurRepository.Login(loginRequest);
            if (result is { Succeeded: true })
            {
                return Ok(new { Message = "User logged in successfully" });
            }
            return Unauthorized();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Une erreur s'est produite dans le controlleur de l'administrateur au niveau du register {exception.Message}");
            throw;
        }
    }
}