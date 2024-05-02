using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionBatimentsElectriquesMoyenneTension.Model.Mappers;

public static class BatimentMapper
{
    public static BatimentDto ToBatimentDto(this Batiment batimentModel)
    {
        return new BatimentDto
        {
            BatimentId = batimentModel.BatimentId,
            Adresse = batimentModel.Adresse
        };
    }

    public static Batiment ToBatimentFromCreateDto(this CreateBatimentRequestDto batimentDto)
    {
        return new Batiment
        {
            Adresse = batimentDto.Adresse
        };
    }
}