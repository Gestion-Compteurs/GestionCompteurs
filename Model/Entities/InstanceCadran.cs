using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class InstanceCadran
{
    [Key]
    public int InstanceCadranId { get; set; }
    [Required,ForeignKey("InstanceCompteur")] //TODO: why I have to force ?
    public int InstanceCompteurId { get; set; }
    // public InstanceCompteur? InstanceCompteur { get; set; }
    [Required]
    public int CadranId { get; set; }
    // public Cadran Cadran { get; set; } // le cadran donne ses paramètres
    public int IndexRoues { get; set; } // calculer le prix avec les params cadrans
    // public double PrixWatt = Cadran.PrixWatt();
    // public ReleveCadran GetReleveCadran(double remise)
    // {
    //     return new ReleveCadran(IndexRoues, InstanceCadranId, PrixWatt*remise);
    // }
    public IEnumerable<ReleveCadran> ReleveCadrans { get; set; } = new List<ReleveCadran>();
}