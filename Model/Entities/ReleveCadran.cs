using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class ReleveCadran
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReleveCadranId { get; set; }
    // Relève correspondante
    public int ReleveId { get; set; }
    [Required] public int IndexRoues { get; set; }= 0;
    [Required] public int InstanceCadranId { get; set; }
    [Required] public double PrixWatt{ get; set; } 
}