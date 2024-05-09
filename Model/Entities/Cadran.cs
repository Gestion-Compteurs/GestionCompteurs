using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Cadran
{
    public int CadranId { get; set; }
    [Required] [MaxLength(50)] public string CadranModel { get; set; } = Constants.UnknownString;
    [Required]
    public int NombreRoues { get; set; }
    public double PrixWatt { get; set; }
    public TimeOnly HeureActivation { get; set; }
    public TimeOnly HeureArret { get; set; }
    public IEnumerable<InstanceCadran> InstancesCadran { get; set; } = new List<InstanceCadran>();
    
    // public double GetMontantAPayerCadran()
    // {
    //     return 0.0f;
    // }
}