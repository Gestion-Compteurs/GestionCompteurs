using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Administrateur: IdentityUser
{
    [StringLength(40,ErrorMessage="NomAdmin trop long",MinimumLength=8)]
    public string? NomAdmin { get; set; }
    [StringLength(40,ErrorMessage="Prenom trop long",MinimumLength=8)]
    public string? Prenom { get; set; }
    public DateOnly DateDeNaissance { get; set; }
    
   
}