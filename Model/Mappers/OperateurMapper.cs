using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

    public static class OperateurMapper
    {
        public static OperateurDto ToOperateurDto(this Operateur operateurModel)
        {
            return new OperateurDto
            {
                OperateurId = operateurModel.OperateurId,
                Nom = operateurModel.Nom,
                Prenom = operateurModel.Prenom,
                RegieId = operateurModel.RegieId,
                CIN = operateurModel.Cin,
                DateDeNaissance = operateurModel.DateDeNaissance,
                Civilite = operateurModel.Civilite,
                DateEmbauche = operateurModel.DateEmbauche,
                Photo = operateurModel.Photo 
            };
        }

        public static Operateur ToOperateurFromCreateDto(this CreateOperateurRequestDto createOperateurDto)
        {
            var operateur = new Operateur
            {
                Nom = createOperateurDto.Nom,
                Prenom = createOperateurDto.Prenom,
                RegieId = createOperateurDto.RegieId,
                Cin = createOperateurDto.CIN,
                DateDeNaissance = createOperateurDto.DateDeNaissance,
                Civilite = createOperateurDto.Civilite,
                DateEmbauche = createOperateurDto.DateEmbauche
            };

            if (createOperateurDto.PhotoFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    createOperateurDto.PhotoFile.CopyTo(memoryStream);
                    operateur.Photo = memoryStream.ToArray();  // Convertir IFormFile en byte[]
                }
            }

            return operateur;
            
        }

        public static Operateur UpdateOperateurFromUpdateDto(this Operateur operateurModel, UpdateOperateurRequestDto updateOperateurDto)
        {
            operateurModel.Nom = updateOperateurDto.Nom;
            operateurModel.Prenom = updateOperateurDto.Prenom;
            operateurModel.Cin = updateOperateurDto.CIN;
            operateurModel.RegieId = updateOperateurDto.RegieId;
            operateurModel.DateDeNaissance = updateOperateurDto.DateDeNaissance;
            operateurModel.Civilite = updateOperateurDto.Civilite;
            operateurModel.DateEmbauche = updateOperateurDto.DateEmbauche;

            if (updateOperateurDto.PhotoFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    updateOperateurDto.PhotoFile.CopyTo(memoryStream);
                    operateurModel.Photo = memoryStream.ToArray();  // Convertir IFormFile en byte[]
                }
            }

            return operateurModel;
        }
    }

