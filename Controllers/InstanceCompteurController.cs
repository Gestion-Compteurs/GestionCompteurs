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
    private readonly ILogger _logger;
    public InstanceCompteurController(
        IInstanceCadranRepository instanceCadranRepository,
        IInstanceCompteurRepository instanceCompteurRepository,
        ICompteurRepository compteurRepository,
        IBatimentRepository batimentRepository,
        ICadranRepository cadranRepository,
        ILogger<InstanceCompteurController> logger
        )
    {
        _instanceCompteurRepository = instanceCompteurRepository;
        _compteurRepository = compteurRepository;
        _cadranRepository = cadranRepository;
        _batimentRepository = batimentRepository;
        _instanceCadranRepository = instanceCadranRepository;
        _logger = logger;
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
    
    // Retrouver toutes les relèves d'une instance compteur
    [HttpGet("listerReleves/{idInstanceCompteur:int:min(1)}")]
    public async Task<IActionResult> TrouverInstanceEtReleves(
        [FromRoute] int idInstanceCompteur
    )
    {
        try 
        {
            var instanceCompteur = await _instanceCompteurRepository.TrouverInstanceEtReleves(idInstanceCompteur);
            if(instanceCompteur is not null) 
            {
                return Ok(InstanceCompteurMapper.ToInstanceCompteurDto(instanceCompteur));
            }
            return NotFound("L'instance compteur n'existe pas dans cette base de données");
                     
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Une erreur s'est produite lors de la recherche de l'instance compteur et de ses relèves " + exception.Message);
            return StatusCode(500);
        }
    }
    
    // TODO : Supprimer une instance compteur
    [HttpDelete("SupprimerInstanceCompteur/{idInstanceCompteur:int:min(0)}")]
    public async Task<IActionResult> SupprimerInstanceCompteur(int idInstanceCompteur)
    {
        try
        {
            var deleted = await _instanceCompteurRepository.SupprimerInstanceCompteur(idInstanceCompteur);
            if (deleted is true)
            {
                return Ok($"L'instance compteur avec l'identifiant {idInstanceCompteur} à été supprimée avec succès.");
            }
            return NotFound(
                $"L'instance compteur avec l'identifiant {idInstanceCompteur} n'existe pas dans la base de données");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Une erreur s'est produite lors de la suppression de l'instance compteur" + exception.Message);
            return StatusCode(500);
        }
    }
}