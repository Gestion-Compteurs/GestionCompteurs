using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Security.Models;

public class RegisterRequest
{
    public RegisterRequest(string? nom, string? prenom, DateOnly dateDeNaissance, string? confirmPassword)
    {
        Nom = nom;
        Prenom = prenom;
        DateDeNaissance = dateDeNaissance;
        ConfirmPassword = confirmPassword;
    }

    [Required]
    public string? Nom { get; set; }
    [Required]
    public string? Prenom { get; set; }
    public DateOnly DateDeNaissance { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Compare("Password",ErrorMessage = "Passwords don't match.")]
    public string? ConfirmPassword { get; set; }
}