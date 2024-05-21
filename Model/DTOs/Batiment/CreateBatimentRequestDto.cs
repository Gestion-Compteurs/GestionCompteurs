using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;

public class CreateBatimentRequestDto
{
    [Required] public string? Adresse { get; set; } = Constants.UnknownString;
}