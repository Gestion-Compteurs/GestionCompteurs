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
    public int IndexRoues { get; set; } // calculer le prix avec les params cadrans
    // public Cadran Cadran { get; set; } // le cadran donne ses paramètres
    
    public ReleveCadran GetReleveCadran()
    {
        return new ReleveCadran(IndexRoues);
    }
}