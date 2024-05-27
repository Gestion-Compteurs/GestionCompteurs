using System.ComponentModel.DataAnnotations;
namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Operateur:Personne
{   
    [Key]
    public int OperateurId { get; set; }
    [Required]
    public DateTime DateEmbauche { get; set; }
    public int? RegieId { get; set; }
    [Required]
    public string? Civilite { get; set; } = string.Empty;
    // est ce qu'on a besoin de naviguer vers les relèves 
    public IEnumerable<Releve> releves { get; set; } = new List<Releve>();
}
