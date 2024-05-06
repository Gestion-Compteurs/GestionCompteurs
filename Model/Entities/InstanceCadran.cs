using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class InstanceCadran
{
    [Key]
    public int InstanceCadranId { get; set; }
    [Required]
    public int CadranId { get; set; }
    public int IndexRoues { get; set; } // calculer le prix avec les params cadrans
    // public Cadran Cadran { get; set; } // le cadran donne ses paramètres
    
    public NotImplementedException GetCadranState()
    {
        return new NotImplementedException();
    }
}