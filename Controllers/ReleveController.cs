using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReleveController(
    IReleveRepository releveRepository
    ) : ControllerBase
{
    // Le Repository de relève à injecter
    private readonly IReleveRepository _releveRepository = releveRepository;
    
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
    [HttpPut("modifier")]
    public async Task<IActionResult> ModifierReleve(
        [FromBody] ModifierReleveRequestDto modifierReleveRequestDto
        )
    {
        throw new NotImplementedException();
    }
    


}