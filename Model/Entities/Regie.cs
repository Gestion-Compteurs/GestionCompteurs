using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Regie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegieId { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "L'adresse email est incorrecte")]
    public string EmailRegie { get; set; }
    [Required]
    public string NomRegion { get; set; }  = Constants.UnknownString;
    public IEnumerable<Administrateur> Administrateurs { get; set; } = new List<Administrateur>();
    public IEnumerable<Operateur> Operateurs { get; set; } = new List<Operateur>();
}