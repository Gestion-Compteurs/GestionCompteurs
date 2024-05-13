
using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;

    public class CreateOperateurRequestDto
    {
        [Required]
        public string Nom { get; set; }= Constants.UnknownString;

        [Required]
        public string Prenom { get; set; }= Constants.UnknownString;

        [Required]
        public string CIN { get; set; }= Constants.UnknownString;
        [Required]
        public DateTime DateDeNaissance { get; set; }
        [Required]
        public string Civilite { get; set; }= Constants.UnknownString;
        [Required]
        public DateTime DateEmbauche { get; set; }
    }





