using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;

public class InstanceCompteurDto
{
    public int InstanceCompteurId { get; set; }
    public int CompteurId { get; set; }
    public int BatimentId { get; set; }
    public DateOnly DateInstallation { get; set; }
    public IEnumerable<InstanceCadranDto> InstanceCadrans { get; set; } = new List<InstanceCadranDto>();
    public IEnumerable<ReleveDto> Releves { get; set; } = new List<ReleveDto>();
}