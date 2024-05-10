
using System;
using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur
{
    public class CreateOperateurRequestDto
    {
        [Required]
        public string Nom { get; set; }= Constants.UnknownString;

        [Required]
        public string Prenom { get; set; }= Constants.UnknownString;

        [Required]
        public string Cin { get; set; }= Constants.UnknownString;

        [Required]
        [EmailAddress]
        public string Email { get; set; }= Constants.UnknownString;

        [Required]
        public DateTime DateDeNaissance { get; set; }

        
    }
}




