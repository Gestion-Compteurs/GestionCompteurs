using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;

    public class OperateurDto
    {
        public int OperateurId { get; set; }
        public string? Nom { get; set; }= string.Empty;
        public string? Prenom { get; set; }= string.Empty;
        
        public int? RegieId { get; set; }
        public string? CIN { get; set; }= string.Empty;
        public DateTime DateDeNaissance { get; set; }
        public string? Civilite { get; set; }= string.Empty;
        public DateTime DateEmbauche { get; set; }
        public string? Photo { get; set; }
        
    }

