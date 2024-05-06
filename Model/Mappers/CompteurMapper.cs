using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class CompteurMapper
{
    public static CompteurDto ToCompteurDto(this Compteur compteurModel)
    {
        var instanceCompteurDtos = new List<InstanceCompteurDto>();
        // var instanceCompteurDtos = compteurModel.InstanceCompteurs.Select(obj => obj.ToInstanceCompteurDto()).ToList(); // TODO test this

        foreach (var obj in compteurModel.InstanceCompteurs)
        {
            instanceCompteurDtos.Add(obj.ToInstanceCompteurDto());
        }
        return new CompteurDto
        {
            CompteurId = compteurModel.CompteurId,
            Modele = compteurModel.Modele,
            Marque = compteurModel.Marque,
            VoltageMax = compteurModel.VoltageMax,
            AnneeCreation = compteurModel.AnneeCreation,
            InstanceCompteursDtos = instanceCompteurDtos
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