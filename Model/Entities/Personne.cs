using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Personne
{
    [Required] public string? Cin { get; set; } 
    [Required]
    public string? Nom { get; set; }
    [Required]
    public string? Prenom { get; set; }
    [Required]
    public DateTime DateDeNaissance { get; set; }
    
}