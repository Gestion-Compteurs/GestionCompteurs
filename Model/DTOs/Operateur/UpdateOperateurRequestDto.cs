namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;

public class UpdateOperateurRequestDto
{
    
}

using GestionCompteursElectriquesMoyenneTension.Model.Entities;


{
    [Required] public string Adresse { get; set; }= Constants.UnknownString;
}

using System;
using System.ComponentModel.DataAnnotations;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur
{
    public class UpdateOperateurRequestDto
    {
        [Required]
        public string Nom { get; set; }= Constants.UnknownString;

        [Required]
        public string Prenom { get; set; }= Constants.UnknownString;

        [Required]
        public string Cin { get; set; }= Constants.UnknownString;

        [Required]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }= Constants.UnknownString;

        [Required]
        public DateTime DateDeNaissance { get; set; }
        
        
    }
}
