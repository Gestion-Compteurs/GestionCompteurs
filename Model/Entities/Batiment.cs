using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Batiment
{
    public int BatimentId { get; set; }
    public IEnumerable<InstanceCompteur> InstanceCompteurs { get; set; } = new List<InstanceCompteur>();
    [Required] public string Adresse { get; set; } = Constants.UnknownString;
}