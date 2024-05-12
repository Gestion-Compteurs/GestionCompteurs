namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;

public class AjouterInstanceCompteurRequestDto
{
    public int BatimentId { get; set; }
    public int CompteurId { get; set; }
    public DateOnly DateInstallation { get; set; }
}