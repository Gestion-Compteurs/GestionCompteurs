namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Facture
{
    public int FactureId { get; set; }
    public DateOnly DateEmission { get; set; }
    public DateOnly DateLimite { get; set; }
    //one to one avec releve TODO
}