using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Model.Interfaces;

public interface IReleveRepository
{
    Task<Releve?> CreerNouvelleReleve(AjouterNouvelleReleveRequestDto ajouterNouvelleReleveRequestDto);

    Task<Releve?> ConfirmerCreationNouvelleReleve(
        ConfirmerCreationNouvelleReleveRequestDto confirmerCreationNouvelleReleveRequestDto);
    Task<Releve?> ModifierReleve(ModifierReleveRequestDto modifierReleveRequestDto);
    Task<Releve?> TrouverReleveEtRelevesCadran(int idReleve);
    Task<bool> DeleteReleve(int idReleve);
}