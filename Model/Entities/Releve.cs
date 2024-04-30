using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Releve
{
    
    public int ReleveId { get; set; }
    [Required]
    public DateTime DateReleve { get; set; }
    [Required]
    public int Index { get; set; }
    
    [Required]
    public int InstanceCompteurId { get; set; }
    [Required]
    public int BatimentId { get; set; }
    
    [Required]
    public int OperateurId { get; set; }
    // public Operateur Operateur { get;set;}
}