using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;

    public class OperateurDto
    {
        public int OperateurId { get; set; }
        public string? Nom { get; set; }= Constants.UnknownString;
        public string? Prenom { get; set; }= Constants.UnknownString;
        public int? RegieId { get; set; }
        public string? CIN { get; set; }= Constants.UnknownString;
        public DateTime DateDeNaissance { get; set; }
        public string? Civilite { get; set; }= Constants.UnknownString;
        public DateTime DateEmbauche { get; set; }
        public byte[]? Photo { get; set; }
        
    }

