namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Compteur
{
    public int CompteurId { get; set; }
    public IEnumerable<Cadran> Cadrans { get; set; }
    // public IEnumerable<InstanceCompteur> InstanceCompteurs { get; set; } ? besoin ou pas

    public double getMontantAPayerFacture()
    {
        return 0.0f;
    }
}