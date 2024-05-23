using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;

public class ReleveDto
{
    public int ReleveId { get; set; }
    public DateOnly DateReleve { get; set; } 
    public int InstanceCompteurId { get; set; }
    public int AgentId { get; set; }
    public IEnumerable<ReleveCadranDto> ReleveCadrans { get; set; } = new List<ReleveCadranDto>();
}