using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;
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

    // Aller du l'entité de la relève vers le DTO de la relève, qui contient des DTO de relèves des cadrans
    public static ReleveDto ToReleveDtoFromReleveEntity(this Releve releveModel)
    {
        var relevesCadransForDto = releveModel.ReleveCadrans.Select(releveCadran => ReleveCadranMapper.ToReleveCadranDto(releveCadran)).ToList();
        return new ReleveDto
        {
            ReleveId = releveModel.ReleveId,
            // BatimentId = releveModel.BatimentId,
            AgentId = releveModel.OperateurId,
            DateReleve = releveModel.DateReleve,
            InstanceCompteurId = releveModel.InstanceCompteurId,
            ReleveCadrans = relevesCadransForDto,
        };
    }

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