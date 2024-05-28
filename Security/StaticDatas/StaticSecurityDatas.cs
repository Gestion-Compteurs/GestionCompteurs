using Microsoft.IdentityModel.Tokens;

namespace GestionCompteursElectriquesMoyenneTension.Security.StaticDatas;

public static class StaticSecurityDatas 
{
    // La clé secrète 
    public const string SecretKey = "CetteCleDoitNormalementEtreSurAzureKeyvaultOuAWSSecretManager";
    // Le salt fixe   
    public static readonly byte[] FixedSalt = new byte[]
        { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xF0, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xF0 };

    // L'algorithme de cryptage utilisé pour les clients
    public const string SecurityAlgorithmForAdmins = SecurityAlgorithms.HmacSha256;
    
    // L'algorithme de cryptage utilisé pour les administrateurs
    public const string SecurityAlgorithmForRegies = SecurityAlgorithms.HmacSha384;
    
    // Le temps de vie d'un JSON Web Token pour l'ensemble de l'application : 30 minutes ici
    public static readonly TimeSpan TokenLifeTime = TimeSpan.FromMinutes(30);
    
    // L'adresse du Issuer
    public const string Issuer = "https://thegoat.MamaneHassane.com";
    
    // L'adresse de l'audience
    public const string Audience = "https://www.HotOrCold.com";
}