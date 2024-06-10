
using System.ComponentModel.DataAnnotations;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;

    public class CreateOperateurRequestDto
    {
        [Required]
        public string? Nom { get; set; }= string.Empty;

        [Required]
        public string? Prenom { get; set; }= string.Empty;
        [Required]
        public int? RegieId { get; set; }
        [Required]
        public string? CIN { get; set; }= string.Empty;
        [Required]
        public DateTime DateDeNaissance { get; set; }
        [Required]
        public string? Civilite { get; set; }= string.Empty;
        [Required]
        public DateTime DateEmbauche { get; set; }
        [Required]
        public string? Photo { get; set; }
    }





