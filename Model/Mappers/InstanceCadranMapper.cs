using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class InstanceCadranMapper
{
    public static InstanceCadranDto ToInstanceCadranDto(this InstanceCadran instanceCadranModel)
    {
        return new InstanceCadranDto
        {
            InstanceCadranId = instanceCadranModel.InstanceCadranId,
            IndexRoues = instanceCadranModel.IndexRoues,
            CadranId = instanceCadranModel.CadranId,
            InstanceCompteurId = instanceCadranModel.InstanceCompteurId,
            
        };
    }
    public static InstanceCadran ToInstanceCadranFromCreateDto(
        this CreateInstanceCadranRequestDto instanceCadranModel, int cadranId)

    {
        return new InstanceCadran
        {
            CadranId = cadranId,
            IndexRoues = 0,
            InstanceCompteurId = instanceCadranModel.InstanceCompteurId,
            
        };
    }
}