using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs;

public class ConfirmerCreationNouvelleReleveRequestDto
{
    public int ReleveId { get; set; }
    public IEnumerable<ReleveCadranDto> ReleveCadranDtos { get; set; } = new List<ReleveCadranDto>();
}