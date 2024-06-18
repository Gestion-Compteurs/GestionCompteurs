using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReleveController(
    IReleveRepository releveRepository,
    ILogger<ReleveController> logger
    ) : ControllerBase
{
    // Le Repository de relève à injecter
    private readonly IReleveRepository _releveRepository = releveRepository;
    private readonly ILogger _logger = logger;
    
    // Créer une relève à une instance de compteur
    
    //ajouter verification existence operateur, instanceCompteur
    //max de releve cadran = count des instances cadrans de l'instance compteur
    //retrieve toutes les instances compteurs pour construire le formulaire coté front, GetById(instanceCompteurId)
    
    //enregistrer la releve 
//     [HttpPost]
//     [Route("AjoutReleve/{instanceCompteurId:int:min(1)}/{operateurId:int:min(1)}")]
//     public async Task<IActionResult> CreateReleve([FromRoute] int operateurId, [FromRoute] int instanceCompteurId,
//         [FromBody] CreateReleveRequestDto[] createReleveRequestDto)
//     {
//         // if(createReleveRequestDto.Count != instanceCompteur.InstanceCadrans.Count)
//         // return StatusCode(StatusCodes.Status400BadRequest);
//         Debug.WriteLine(createReleveRequestDto);
//         return StatusCode(StatusCodes.Status200OK);
//     }






    // Modifier une relève
    [HttpPut("modifierReleve")]
    public async Task<IActionResult> ModifierReleve(
        [FromBody] ModifierReleveRequestDto modifierReleveRequestDto
        )
    {
        
        try
        {
            var releve = await _releveRepository.ModifierReleve(modifierReleveRequestDto);
            return Ok(releve);
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite lors de la modification de la relève " + exception.Message); 
            return StatusCode(500);   
        }
    }
    
    // Retrouver une relève et ses relèves cadran
    [HttpGet("trouverReleve/{idReleve:int:min(1)}")]
    public async Task<IActionResult> TrouverReleveEtRelevesCadran(
        [FromRoute] int idReleve
    )
    {
        try
        {
            var releve = await _releveRepository.TrouverReleveEtRelevesCadran(idReleve);
            if (releve is null) return NotFound("La relève n'existe pas dans cette base de données");
            var releveDto = ReleveMapper.ToReleveDtoFromReleveEntity(releve);
            return Ok(releveDto);
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite lors de la modification de la relève " + exception.Message); 
            return StatusCode(500); 
        }
    }
    
    // Créer une nouvelle relève
    [HttpPost("ajouterPourInstanceCompteur")]
    public async Task<IActionResult> CreerNouvelleReleve(
        [FromBody] AjouterNouvelleReleveRequestDto ajouterNouvelleReleveRequestDto
    )
    {
        try
        {
            return Ok(await _releveRepository.CreerNouvelleReleve(ajouterNouvelleReleveRequestDto));
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite lors de la création d'une nouvelle relève " + exception.Message); 
            return StatusCode(500); 
        }
    }
    
    // Fonction pour confirmer la création de la nouvelle relève
    [HttpPost("confirmerAjouterPourInstanceCompteur")]
    public async Task<IActionResult> ConfirmerCreationNouvelleReleve(
        [FromBody] ConfirmerCreationNouvelleReleveRequestDto confirmerCreationNouvelleReleveRequestDto
    )
    {
        try
        {
            var nouvelleReleve =
                await _releveRepository.ConfirmerCreationNouvelleReleve(confirmerCreationNouvelleReleveRequestDto);
            return Ok(nouvelleReleve);
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite lors de la confirmation de la création d'une nouvelle relève " + exception.Message); 
            return StatusCode(500); 
        }
    }
    
    // Supprimer une relève
    [HttpDelete("{idReleve}")]
    public async Task<IActionResult> DeleteReleve(
        [FromRoute] int idReleve
    )
    {
        try
        {
            var deleted = await _releveRepository.DeleteReleve(idReleve);
            return deleted ? Ok(deleted) : NotFound("Cette relève n'existe pas");
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite lors de la suppression de la relève " + exception.Message); 
            return StatusCode(500); 
        }
    }
}