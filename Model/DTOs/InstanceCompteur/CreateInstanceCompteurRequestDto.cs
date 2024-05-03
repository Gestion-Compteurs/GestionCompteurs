using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;

public class CreateInstanceCompteurRequestDto
{
    // [Required]
    // public int CompteurId { get; set; }
    // [Required]
    // public int BatimentId { get; set; }
    // [Required]
    public DateOnly DateInstallation { get; set; }
}