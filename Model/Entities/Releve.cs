using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Releve
{
    
    public int ReleveId { get; set; }
    [Required] public DateOnly DateReleve { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    [Required]
    public int InstanceCompteurId { get; set; }
    // [Required]
    // public int BatimentId { get; set; }
    [Required]
    public int OperateurId { get; set; }
    public IEnumerable<ReleveCadran> ReleveCadrans { get; set; } = new List<ReleveCadran>();
}