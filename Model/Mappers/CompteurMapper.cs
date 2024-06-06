using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class CompteurMapper
{
    public static CompteurDto ToCompteurDto(this Compteur? compteurModel)
    {
        var instanceCompteurDtos = new List<InstanceCompteurDto>();
        var typeCadranDtos = new List<CadranDto>();
        // var instanceCompteurDtos = compteurModel.InstanceCompteurs.Select(obj => obj.ToInstanceCompteurDto()).ToList(); // TODO test this

        foreach (var obj in compteurModel.InstanceCompteurs)
        {
            instanceCompteurDtos.Add(obj.ToInstanceCompteurDto());
        }
        foreach (var obj in compteurModel.TypesCadrans)
        {
            typeCadranDtos.Add(obj.ToCadranDto());
        }
        return new CompteurDto
        {
            CompteurId = compteurModel.CompteurId,
            Modele = compteurModel.Modele,
            Marque = compteurModel.Marque,
            VoltageMax = compteurModel.VoltageMax,
            AnneeCreation = compteurModel.AnneeCreation,
            InstanceCompteurs = instanceCompteurDtos,
            TypesCadrans = typeCadranDtos,
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

    public static Compteur ToCompteurDtoFromAjouterCompteurRequestDto(
        this AjouterCompteurRequestDto ajouterCompteurRequestDto)
    {
        // var typesCadransARenseigner = ajouterCompteurRequestDto.TypesCadrans
        //    .Select(typeCadran => CadranMapper.ToCadranFromCreateDto(typeCadran)).ToList();
        return new Compteur
        {
            Marque = ajouterCompteurRequestDto.Marque,
            Modele = ajouterCompteurRequestDto.Modele,
            AnneeCreation = ajouterCompteurRequestDto.AnneeCreation,
            VoltageMax = ajouterCompteurRequestDto.VoltageMax,
            // TypesCadrans = typesCadransARenseigner,
        };
    }
}