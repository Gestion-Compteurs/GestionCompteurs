
using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;


    public class UpdateOperateurRequestDto
    {
        [Required]
        public string? Nom { get; set; }= Constants.UnknownString;
        [Required]
        public string? Prenom { get; set; }= Constants.UnknownString;
        [Required]
        public int? RegieId { get; set; }
        [Required]
        public string? CIN { get; set; }= Constants.UnknownString;

        [Required]
        public DateTime DateDeNaissance { get; set; }

        [Required]
        public string? Civilite { get; set; }= Constants.UnknownString;

        [Required]
        public DateTime DateEmbauche { get; set; }

        [Required]
        public IFormFile? PhotoFile { get; set; }
        
    }

