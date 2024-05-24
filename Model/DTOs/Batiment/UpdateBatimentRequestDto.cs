using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;

public class UpdateBatimentRequestDto
{

    [Required] public string Adresse { get; set; }= Constants.UnknownString;
    public int NombreEtages { get; set; }
    public string TypeBatiment { get; set; } = Constants.UnknownString;
    
}