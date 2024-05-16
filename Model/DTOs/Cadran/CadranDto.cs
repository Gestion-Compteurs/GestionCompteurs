using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;

public class CadranDto
{
    public int CadranId { get; set; }
    public int NombreRoues { get; set; }
    public double PrixWatt { get; set; }
    public TimeOnly HeureActivation { get; set; }
    public TimeOnly HeureArret { get; set; }
    public string CadranModel { get; set; } = Constants.UnknownString;
    public IEnumerable<CompteurDto> CompteursLePossedant { get; set; } = new List<CompteurDto>();
}