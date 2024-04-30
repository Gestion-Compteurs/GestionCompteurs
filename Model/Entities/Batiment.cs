using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Batiment
{
    public int BatimentId { get; set; }
    [Required] public string Adresse { get; set; } = Constants.UnknownString;
}