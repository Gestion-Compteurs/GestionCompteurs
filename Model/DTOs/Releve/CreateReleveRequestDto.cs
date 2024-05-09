using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;

public class CreateReleveRequestDto
{
    public int InstanceCompteurId { get; set; }
    public int OperateurId { get; set; }
    public IEnumerable<CreateReleveCadranRequestDto> ReleveCadrans = new List<CreateReleveCadranRequestDto>();
}