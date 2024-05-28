using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Security.StaticDatas;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace GestionCompteursElectriquesMoyenneTension.Security.Methods;

public class AdminPasswordHasher : IPasswordHasher<Administrateur>
{
    public string HashPassword(Administrateur administrateur, string password)
    {
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,  
            salt: StaticSecurityDatas.FixedSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 16));
        return hashed; 
    }

    public PasswordVerificationResult VerifyHashedPassword(Administrateur administrateur, string hashedPassword, string providedPassword)
    {
        var providedHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: providedPassword!,
            salt: StaticSecurityDatas.FixedSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 16));
        Console.WriteLine(providedPassword);
        Console.WriteLine(providedHash);
        Console.WriteLine(hashedPassword);
        var passwordAreEqual = string.Compare(hashedPassword, providedHash);
        return passwordAreEqual == 0 ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
    }
}