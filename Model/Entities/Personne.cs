using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Personne
{
    [Required] public string CIN { get; set; } = Constants.UnknownString;
    [Required]
    public string Nom { get; set; }= Constants.UnknownString;
    [Required]
    public string Prenom { get; set; }= Constants.UnknownString;
}