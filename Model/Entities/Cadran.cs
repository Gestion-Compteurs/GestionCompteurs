using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.Entities;

public class Cadran
{
    public int CadranId { get; set; }
    public int Compteurd { get; set; }
    [Required]
    public int NombreRoues { get; set; }
    public float PrixMetreCube { get; set; }

    public double GetMontantAPayerCadran()
    {
        return 0.0f;

    }
}