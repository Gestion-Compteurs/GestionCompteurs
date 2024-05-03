using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class InstanceCompteurMapper
{
    public static InstanceCompteurDto ToInstanceCompteurDto(this InstanceCompteur instanceCompteurModel)
    {
        return new InstanceCompteurDto
        {
            InstanceCompteurId = instanceCompteurModel.InstanceCompteurId,
            CompteurId = instanceCompteurModel.CompteurId,
            DateInstallation = instanceCompteurModel.DateInstallation,
            BatimentId = instanceCompteurModel.BatimentId,
            
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