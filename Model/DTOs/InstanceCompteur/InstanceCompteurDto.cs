namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;

public class InstanceCompteurDto
{
    public int InstanceCompteurId { get; set; }
    public int CompteurId { get; set; }
    public int BatimentId { get; set; }
    public DateOnly DateInstallation { get; set; }
}