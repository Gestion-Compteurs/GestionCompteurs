using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class InstanceCompteur
{
    public int InstanceCompteurId { get; set; }
    public int CompteurId { get; set; }
    [Required]
    public int BatimentId { get; set; }
    [Required]
    public DateOnly DateInstallation { get; set; }
}