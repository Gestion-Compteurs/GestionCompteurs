namespace GestionCompteursElectriquesMoyenneTension.Security.Identity;

public class IdentityData
{
    // Pour les administrateurs
    public const string AdminPolicyName = "Admin";
    public const string AdminClaimValue = "true";
    
    // Pour les régies
    public const string RegiePolicyName = "Regie";
    public const string RegieClaimValue = "true";
}