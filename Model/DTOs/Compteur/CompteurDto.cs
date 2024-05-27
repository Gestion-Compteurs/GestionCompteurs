using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;

public class CompteurDto
{
    public int CompteurId { get; set; }
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int AnneeCreation { get; set; } = 0;
    public int VoltageMax { get; set; } = 0;
    public IEnumerable<InstanceCompteurDto> InstanceCompteursDtos { get; set; } = new List<InstanceCompteurDto>();
}