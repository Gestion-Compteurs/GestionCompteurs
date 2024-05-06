namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;

public class CadranDto
{
    public int CadranId { get; set; }
    public int NombreRoues { get; set; }
    public float PrixMetreCube { get; set; }
    public TimeOnly HeureActivation { get; set; }
    public TimeOnly HeureArret { get; set; }
    public string CadranModel { get; set; }
}