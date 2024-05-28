using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Security.Identity;
using GestionCompteursElectriquesMoyenneTension.Security.Models;
using GestionCompteursElectriquesMoyenneTension.Security.StaticDatas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GestionCompteursElectriquesMoyenneTension.Security.Controllers;

public class IdentityController(
    IAdministrateurRepository administrateurRepository,
    IRegieRepository regieRepository
    ) : ControllerBase
{
    private readonly IAdministrateurRepository _administrateurRepository = administrateurRepository;
    private readonly IRegieRepository _regieRepository = regieRepository;
    
    // Méthode d'authentification des clients, accessible par tout le monde
    [AllowAnonymous]
    [HttpPost("authenticateAdminAndGetAccessToken")]
    public async Task<IActionResult> GenerateTokenForAdmin([FromBody] LoginRequest tokenGenerationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Il y'a une erreur dans la requête, réessayez plus tard");
        }
        var adminFound = await _administrateurRepository.Authenticate(tokenGenerationRequest);
        
        // S'il n'existe pas ou son email est null ( c'est pas possible mais bon ...)
        if (adminFound is null or {Email:null}) 
            return NotFound("Le nom d'utilisateur ou mot de passe est incorrecte");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(StaticSecurityDatas.SecretKey);

        
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, adminFound.Email),
            new (JwtRegisteredClaimNames.Email, adminFound.Email),
            new ("userid", adminFound.AdminId.ToString())
        };
    
        // On utilise un seul Claim pour toutes les méthodes de l'administrateur
        var claim = new Claim(IdentityData.AdminPolicyName, IdentityData.AdminClaimValue, ClaimValueTypes.String);
        claims.Add(claim);
    
        // Le descripteur de jeton
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(StaticSecurityDatas.TokenLifeTime),
            Issuer = StaticSecurityDatas.Issuer,
            Audience = StaticSecurityDatas.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),StaticSecurityDatas.SecurityAlgorithmForAdmins)

        };
    
        // Génération du token à partir du descripteur
        var token = tokenHandler.CreateToken(tokenDescriptor);
    
        // Ecrire le token au handler
        var jwt = tokenHandler.WriteToken(token);
    
        // Créer la réponse au client
        var response = new LoginResponseForAdmin()
        {
            Administrator = adminFound,
            AccessToken = jwt,
        };
    
        // Retourner la reponse
        return Ok(response);
    }
    
    // Méthode d'authentification des régies, accessible par tout le monde
    [AllowAnonymous]
    [HttpPost("authenticateRegieAndGetAccessToken")]
    public async Task<IActionResult> GenerateTokenForRegie([FromBody] LoginRequest tokenGenerationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Il y'a une erreur dans la requête, réessayez plus tard");
        }
        var regieFound = await _regieRepository.Authenticate(tokenGenerationRequest);
        
        if (regieFound is null or { EmailRegie: null }) 
            return NotFound("Le nom d'entreprise ou mot de passe est incorrecte");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(StaticSecurityDatas.SecretKey);

        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Sub, regieFound.EmailRegie),
            new (JwtRegisteredClaimNames.Email, regieFound.EmailRegie),
            new ("userid", regieFound.RegieId.ToString())
        };
        
        // On utilise un seul Claim pour toutes les méthodes des régies
        var claim = new Claim(IdentityData.RegieClaimValue, IdentityData.RegieClaimValue, ClaimValueTypes.String);
        claims.Add(claim);
        
        // Le descripteur de jeton
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(StaticSecurityDatas.TokenLifeTime),
            Issuer = StaticSecurityDatas.Issuer,
            Audience = StaticSecurityDatas.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),StaticSecurityDatas.SecurityAlgorithmForRegies)
        };
        
        // Génération du token à partir du descripteur
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        // Ecrire le token au handler
        var jwt = tokenHandler.WriteToken(token);
        
        // Créer la réponse à la régie
        var response = new LoginResponseForRegie
        {
            Regie = regieFound,
            AccessToken = jwt,
        };
        
        // Retourner la reponse
        return Ok(response);
    }
}