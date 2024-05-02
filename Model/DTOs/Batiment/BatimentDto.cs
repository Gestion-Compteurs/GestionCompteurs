using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;

public class BatimentDto
{
    public int BatimentId { get; set; }
    public string Adresse { get; set; } = Constants.UnknownString;
}