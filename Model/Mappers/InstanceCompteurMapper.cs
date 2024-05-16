using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class InstanceCompteurMapper
{
    public static InstanceCompteurDto ToInstanceCompteurDto(this InstanceCompteur instanceCompteurModel)
    {
        var cadranDtos = instanceCompteurModel.InstanceCadrans
            .Select(obj => obj.ToInstanceCadranDto()).ToList();
        var relevesDtos = instanceCompteurModel.Releves
            .Select(releve => releve.ToReleveDtoFromReleveEntity()).ToList();
        return new InstanceCompteurDto
        {
            InstanceCompteurId = instanceCompteurModel.InstanceCompteurId,
            CompteurId = instanceCompteurModel.CompteurId,
            DateInstallation = instanceCompteurModel.DateInstallation,
            BatimentId = instanceCompteurModel.BatimentId,
            InstanceCadrans = cadranDtos,
            Releves = relevesDtos
        };
    }

    public static InstanceCompteur ToInstanceCompteurFromCreateDto(
        this CreateInstanceCompteurRequestDto instanceCompteurModel, int compteurId,int batimentId)

    {
        return new InstanceCompteur
        {
            CompteurId = compteurId,
            DateInstallation = instanceCompteurModel.DateInstallation,
            BatimentId = batimentId,
        };
    }
}