namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

public class ModifierReleveCadranRequestDto
{
    public int ReleveCadranId { get; set; }
    public int IndexRoues { get; set; }
    public double PrixWatt { get; set; }
}