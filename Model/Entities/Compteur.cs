using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Compteur
{
    public int CompteurId { get; set; }
    [Required]
    public string Marque { get; set; } = string.Empty;
    [Required]
    public string Modele { get; set; } = string.Empty;
    [Required]
    public int AnneeCreation { get; set; } = 0;
    public int VoltageMax { get; set; }
    //public IEnumerable<InstanceCadran> Cadrans { get; set; } = new List<InstanceCadran>();
    public IEnumerable<Cadran> TypesCadrans { get; set; } = new List<Cadran>();
    public IEnumerable<InstanceCompteur> InstanceCompteurs { get; set; } = new List<InstanceCompteur>();

    /*
     Deplacer vers le controlleur
     public double getMontantAPayerFacture()
    {
        return 0.0f;
    }*/
}