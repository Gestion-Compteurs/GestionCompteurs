using System.Diagnostics;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministrateurController : ControllerBase
{
    private readonly UserManager<Administrateur> _userManager;
    private readonly SignInManager<Administrateur> _signInManager;

    public AdministrateurController(UserManager<Administrateur> userManager, SignInManager<Administrateur> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterVM model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new Administrateur
        {
            UserName = model.Email,
            NomAdmin = model.Nom,
            Prenom = model.Prenom,
            DateDeNaissance = model.DateDeNaissance
        };

        Debug.Assert(model.Password != null, "model.Password != null");
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok(new { Message = "User registered successfully" });
        }

        return BadRequest(result.Errors);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginVM model)
    {
        Debug.Assert(model.Email != null, "model.Email != null");
        Debug.Assert(model.Password != null, "model.Password != null");
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (result.Succeeded)
        {
            return Ok(new { Message = "User logged in successfully" });
        }

        return Unauthorized();
    }
}