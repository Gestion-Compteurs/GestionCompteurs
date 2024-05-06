using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class InstanceCompteurMapper
{
    public static InstanceCompteurDto ToInstanceCompteurDto(this InstanceCompteur instanceCompteurModel)
    {
        var cadranDtos = new List<InstanceCadranDto>();
        foreach (var obj in instanceCompteurModel.InstanceCadrans)
        {
            cadranDtos.Add(obj.ToInstanceCadranDto());
        }
        return new InstanceCompteurDto
        {
            InstanceCompteurId = instanceCompteurModel.InstanceCompteurId,
            CompteurId = instanceCompteurModel.CompteurId,
            DateInstallation = instanceCompteurModel.DateInstallation,
            BatimentId = instanceCompteurModel.BatimentId,
            InstanceCadrans = cadranDtos
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