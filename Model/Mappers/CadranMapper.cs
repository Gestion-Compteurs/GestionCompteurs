using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Mappers;

public static class CadranMapper
{
    public static CadranDto ToCadranDto(this Cadran cadranModel)
    {
        return new CadranDto
        {
            CadranId = cadranModel.CadranId,
            NombreRoues = cadranModel.NombreRoues,
            PrixWatt = cadranModel.PrixWatt,
            HeureArret = cadranModel.HeureArret,
            HeureActivation = cadranModel.HeureActivation,
            CadranModel = cadranModel.CadranModel,
        };
    }

    public static Cadran ToCadranFromCreateDto(this CreateCadranRequestDto cadranDto)
    {
        return new Cadran
        {
            NombreRoues = cadranDto.NombreRoues,
            PrixWatt = cadranDto.PrixWatt,
            HeureArret = cadranDto.HeureArret,
            HeureActivation = cadranDto.HeureActivation,
            CadranModel = cadranDto.CadranModel
        };
    }
}