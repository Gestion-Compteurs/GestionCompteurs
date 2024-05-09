using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;


public static class ReleveMapper
{
    /*public static ReleveDto ToReleveDto(this Releve releveModel)
    {
        return new ReleveDto
        {
            ReleveId = releveModel.ReleveId,
            NombreRoues = releveModel.NombreRoues,
            PrixWatt = releveModel.PrixWatt,
            HeureArret = releveModel.HeureArret,
            HeureActivation = releveModel.HeureActivation,
            ReleveModel = releveModel.ReleveModel,
        };
    }*/

    public static Releve ToReleveFromCreateDto(this CreateReleveRequestDto releveDto)
    {
        var releves = new List<ReleveCadran>();
        ReleveCadran releveCadran;
        foreach (var releve in releveDto.ReleveCadrans)
        {
            releveCadran = releve.ToReleveCadranFromCreateDto();
            releves.Add(releveCadran);
        }
        return new Releve
        {
            OperateurId = releveDto.OperateurId,
            InstanceCompteurId = releveDto.InstanceCompteurId,
            ReleveCadrans = releves
            
        };
    }
}