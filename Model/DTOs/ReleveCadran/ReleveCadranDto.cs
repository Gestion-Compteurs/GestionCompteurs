namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;

public class ReleveCadranDto
{
    public int ReleveCadranId { get; set; }
    public int? ReleveId { get; set; }
    public int IndexRoues { get; set; }
    public int InstanceCadranId{ get; set; }
    public double PrixWatt { get; set; }
}