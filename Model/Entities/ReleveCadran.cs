using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class ReleveCadran
{
    [Key] public int ReleveCadranId { get; set; }
    [Required] public int IndexRoues { get; set; }= 0;
    [Required] public int InstanceCadranId { get; set; }
    [Required] public double PrixWatt{ get; set; } 
}