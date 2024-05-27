using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Security.Models;

public class LoginResponseForRegie
{
    public Regie? Regie { get; set; }
    public string? AccessToken { get; set; }
}