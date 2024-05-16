using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;

public class AjouterCompteurRequestDto
{
    public int CompteurId { get; set; }
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int AnneeCreation { get; set; } = 0;
    public int VoltageMax { get; set; }
    public IEnumerable<CreateCadranRequestDto> TypesCadrans { get; set; } = new List<CreateCadranRequestDto>();
    // public IEnumerable<InstanceCompteurDto> InstanceCompteurs { get; set; } = new List<InstanceCompteurDto>();
}