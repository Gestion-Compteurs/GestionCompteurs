using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Security.Models;

public class LoginResponseForAdmin
{
    public Administrateur? Administrator { get; set; }
    public string? AccessToken { get; set; }
}