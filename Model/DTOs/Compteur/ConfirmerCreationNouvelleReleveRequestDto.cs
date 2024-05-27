using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;

public class ConfirmerCreationNouvelleReleveRequestDto
{
    public int ReleveId { get; set; }
    public IEnumerable<ReleveCadranDto> ReleveCadrans { get; set; } = new List<ReleveCadranDto>();
}