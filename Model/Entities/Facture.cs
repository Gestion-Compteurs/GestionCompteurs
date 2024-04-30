namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Facture
{
    public int FactureId { get; set; }
    public DateOnly DateEmission { get; set; } = DateOnly.FromDateTime(new DateTime());
    public DateOnly DateLimite { get; set; } 
    //one to one avec releve 
    public int ReleveId { get; set; } = 0;
}