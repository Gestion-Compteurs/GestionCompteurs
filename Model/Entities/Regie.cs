using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Regie
{
    public int RegieId { get; set; }
    [Required]
    public string NomRegion { get; set; }  = Constants.UnknownString;
    public IEnumerable<Administrateur> Administrateurs { get; set; } = new List<Administrateur>();
}