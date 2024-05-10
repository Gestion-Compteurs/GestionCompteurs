
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionBatimentsElectriquesMoyenneTension.Model.Mappers
{
    public static class OperateurMapper
    {
        public static OperateurDto ToOperateurDto(this Operateur operateurModel)
        {
            return new OperateurDto
            {
                OperateurId = operateurModel.OperateurId,
                Nom = operateurModel.Nom,
                Prenom = operateurModel.Prenom,
                Cin = operateurModel.Cin,
                Email = operateurModel.Email,
                DateDeNaissance = operateurModel.DateDeNaissance,
                Civilite = operateurModel.Civilite,
                DateEmbauche = operateurModel.DateEmbauche
            };
        }

        public static Operateur ToOperateurFromCreateDto(this CreateOperateurRequestDto createOperateurDto)
        {
            return new Operateur
            {
                Nom = createOperateurDto.Nom,
                Prenom = createOperateurDto.Prenom,
                Cin = createOperateurDto.Cin,
                Email = createOperateurDto.Email,
                DateDeNaissance = createOperateurDto.DateDeNaissance,
                Civilite = createOperateurDto.Civilite,
                DateEmbauche = createOperateurDto.DateEmbauche
            };
        }

        public static Operateur UpdateOperateurFromUpdateDto(this Operateur operateurModel, UpdateOperateurRequestDto updateOperateurDto)
        {
            
            operateurModel.Nom = updateOperateurDto.Nom;
            operateurModel.Prenom = updateOperateurDto.Prenom;
            operateurModel.Cin = updateOperateurDto.Cin;
            operateurModel.Email = updateOperateurDto.Email;
            operateurModel.DateDeNaissance = updateOperateurDto.DateDeNaissance;
            operateurModel.Civilite = updateOperateurDto.Civilite;
            operateurModel.DateEmbauche = updateOperateurDto.DateEmbauche;

            return operateurModel;
        }
    }
}
