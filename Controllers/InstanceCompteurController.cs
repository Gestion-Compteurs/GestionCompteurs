using System.Diagnostics;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;



[ApiController]
[Route("api/instanceCompteur")]
public class InstanceCompteurController:ControllerBase
{
    private readonly IInstanceCompteurRepository _instanceCompteurRepository;
    private readonly IInstanceCadranRepository _instanceCadranRepository;
    private readonly ICompteurRepository _compteurRepository;
    private readonly ICadranRepository _cadranRepository;
    private readonly IBatimentRepository _batimentRepository;
    public InstanceCompteurController(
        IInstanceCadranRepository instanceCadranRepository,
        IInstanceCompteurRepository instanceCompteurRepository,
        ICompteurRepository compteurRepository,
        IBatimentRepository batimentRepository,
        ICadranRepository cadranRepository
        )
    {
        _instanceCompteurRepository = instanceCompteurRepository;
        _compteurRepository = compteurRepository;
        _cadranRepository = cadranRepository;
        _batimentRepository = batimentRepository;
        _instanceCadranRepository = instanceCadranRepository;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var instanceCompteurs = await _instanceCompteurRepository.GetAllAsync();
        Console.WriteLine(instanceCompteurs);
        // var dtoInstanceCompteurs = instanceCompteurs.Select(c => c.ToInstanceCompteurDto());//complexify results and chop things, use debugger
        //select must use things that works like include, I guess
        // Console.WriteLine(dtoInstanceCompteurs);
        foreach (var compteur in instanceCompteurs)
        {
            compteur.ToInstanceCompteurDto();
        }

        Console.WriteLine(instanceCompteurs);
        return Ok(instanceCompteurs);
    }
    
    [Route("{id:int:min(1)}")]
    [HttpGet]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var instanceCompteur = await _instanceCompteurRepository.GetByIdAsync(id);
        if (instanceCompteur == null) return NotFound();
        Console.WriteLine(instanceCompteur);
        var dtoInstanceCompteur = instanceCompteur.ToInstanceCompteurDto();
        Console.WriteLine(dtoInstanceCompteur);
        return Ok(dtoInstanceCompteur);
    }
    
    [HttpPost]
    [Route("{compteurId:int:min(1)}/{batimentId:int:min(1)}")]
    public async Task<IActionResult> Create([FromRoute] int compteurId, [FromRoute] int batimentId,
        CreateInstanceCompteurRequestDto createInstanceCompteurDto)
    {
        if  (! await _compteurRepository.CompteurExists(compteurId)) return NotFound("Compteur not found");
        if  (! await _batimentRepository.BatimentExists(batimentId)) return NotFound("Batiment not found");
        var instanceCompteur = createInstanceCompteurDto.ToInstanceCompteurFromCreateDto(compteurId: compteurId,batimentId:batimentId);
        var creation = await _instanceCompteurRepository.CreateAsync(instanceCompteur);
        if (creation != null) return CreatedAtAction(nameof(GetById), new { id = creation.InstanceCompteurId }, creation.ToInstanceCompteurDto());
        return StatusCode(500);
    }
    
    [HttpPost]
    [Route("AjoutCadran/{cadranId:int:min(1)}")]
    public async Task<IActionResult> Create([FromRoute] int cadranId,[FromBody] CreateInstanceCadranRequestDto createInstanceCadranDto)
    {
        if  (! await _cadranRepository.CadranExists(cadranId)) return NotFound("Cadran not found");
        if  (! await _instanceCompteurRepository.InstanceCompteurExists(createInstanceCadranDto.InstanceCompteurId)) return NotFound("Instance of Compteur not found");
        
        // var instanceCadran = createInstanceCadranDto.ToInstanceCadranFromCreateDto(cadranId: cadranId,instanceCompteurId:createInstanceCadranDto.InstanceCompteurId);
        
        var instanceCadran = createInstanceCadranDto.ToInstanceCadranFromCreateDto(cadranId: cadranId);
        var creation = await _instanceCadranRepository.CreateAsync(instanceCadran);
        if (creation != null) return CreatedAtAction(nameof(GetById), new { id = creation.InstanceCadranId }, creation.ToInstanceCadranDto());
        return StatusCode(500);
    }

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
}