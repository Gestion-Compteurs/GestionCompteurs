using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IReleveRepository
{
    Task<Releve> ModifierReleve(ModifierReleveRequestDto modifierReleveRequestDto);
}