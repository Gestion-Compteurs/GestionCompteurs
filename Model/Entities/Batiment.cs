using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Batiment
{
    public int BatimentId { get; set; }
    public IEnumerable<InstanceCompteur> InstanceCompteurs { get; set; } = new List<InstanceCompteur>();
    [Required] public string Adresse { get; set; } = Constants.UnknownString;
    [Range(1,10,ErrorMessage = "Votre bâtiment nécéssite un traitement spécial, rendez-vous à l'agence s'il vous plaît !")]
    public int NombreEtages { get; set; }
    [AllowedValues("Maison", "Immeuble")] 
    public string TypeBatiment { get; set; } = Constants.UnknownString;
}