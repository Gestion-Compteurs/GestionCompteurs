using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;

public class ReleveDto
{
    public int ReleveId { get; set; }
    public DateOnly DateReleve { get; set; } 
    public int InstanceCompteurId { get; set; }
    // public int BatimentId { get; set; }
    public int OperateurId { get; set; }
    public IEnumerable<ReleveCadranDto> ReleveCadrans = new List<ReleveCadranDto>();
}