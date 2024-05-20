using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;

namespace GestionBatimentsElectriquesMoyenneTension.Model.Mappers;

public static class BatimentMapper
{
    public static BatimentDto ToBatimentDto(this Batiment batimentModel)
    {
        var instanceCompteurDtosAMettre = batimentModel.InstanceCompteurs.Select(instanceCompteurDto => instanceCompteurDto.ToInstanceCompteurDto()).ToList();
        return new BatimentDto
        {
            BatimentId = batimentModel.BatimentId,
            Adresse = batimentModel.Adresse,
            NombreEtages = batimentModel.NombreEtages,
            TypeBatiment = batimentModel.TypeBatiment,
            InstanceCompteursDtos = instanceCompteurDtosAMettre,
            
        };
    }

    public static Batiment ToBatimentFromCreateDto(this CreateBatimentRequestDto batimentDto)
    {
        return new Batiment
        {
            Adresse = batimentDto.Adresse,
            NombreEtages = batimentDto.NombreEtages,
            TypeBatiment = batimentDto.TypeBatiment,
        };
    }
}