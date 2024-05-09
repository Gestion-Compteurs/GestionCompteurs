using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class ReleveCadranMapper
{
    public static ReleveCadranDto ToReleveCadranDto(this ReleveCadran releveCadranModel)
    {
        
        return new ReleveCadranDto
        {
            ReleveCadranId = releveCadranModel.ReleveCadranId,
            InstanceCadranId = releveCadranModel.InstanceCadranId,
            PrixWatt = releveCadranModel.PrixWatt,
            IndexRoues = releveCadranModel.IndexRoues
        };
    }

    public static ReleveCadran ToReleveCadranFromCreateDto(
        this CreateReleveCadranRequestDto releveCadranModel)

    {
        return new ReleveCadran
        {
            InstanceCadranId = releveCadranModel.InstanceCadranId,
            PrixWatt = releveCadranModel.PrixWatt,
            IndexRoues = releveCadranModel.IndexRoues
        };
    }
}