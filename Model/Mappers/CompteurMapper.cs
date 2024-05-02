using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class CompteurMapper
{
    public static CompteurDto ToCompteurDto(this Compteur compteurModel)
    {
        return new CompteurDto
        {
            CompteurId = compteurModel.CompteurId,
            Modele = compteurModel.Modele,
            Marque = compteurModel.Marque,
            VoltageMax = compteurModel.VoltageMax,
            AnneeCreation = compteurModel.AnneeCreation,
        };
    }

    public static Compteur ToCompteurFromCreateDto(this CreateCompteurRequestDto compteurDto)
    {
        return new Compteur
        {
            Modele = compteurDto.Modele,
            Marque = compteurDto.Marque,
            VoltageMax = compteurDto.VoltageMax,
            AnneeCreation = compteurDto.AnneeCreation,
        };
    }
}