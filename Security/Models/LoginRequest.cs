
using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Security.Models;

public class LoginRequest
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    
    public int? RegieId { get; set; }
    //public bool RememberMe { get; set; }
    
}