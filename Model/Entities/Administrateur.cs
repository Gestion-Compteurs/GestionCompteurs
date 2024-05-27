using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Administrateur: IdentityUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AdminId { get; set; }
    public int RegieId { get; set; }
    [StringLength(40,ErrorMessage="Nom trop long",MinimumLength=8)]
    public string? NomAdmin { get; set; }
    [StringLength(40,ErrorMessage="Prenom trop long",MinimumLength=8)]
    public string? Prenom { get; set; }
    [Required]
    [StringLength(20,ErrorMessage = "Le mot de passe doit avoir entre 8 et 20 caractères",MinimumLength = 8)]
    public required string Password { get; set; }
    public DateOnly DateDeNaissance { get; set; }
    
   
}