using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BatimentController(
    IBatimentRepository batimentRepository,
    ApplicationDbContext context,
    ILogger<BatimentController> logger
    ) : ControllerBase
{
    private readonly IBatimentRepository _batimentRepository = batimentRepository;
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<BatimentController> _logger = logger;
    
    [HttpGet]
    public async Task<IActionResult> GetAllBatiments()
    {
        IEnumerable<Batiment> batiments = await _batimentRepository.GetAllAsync();
        foreach (var batiment in batiments)
        {
            batiment.ToBatimentDto();
        }
        return Ok(batiments);
        
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetBatimentById([FromRoute] int id)
    {
        var batiments = await _batimentRepository.GetByIdAsync(id);
        if (batiments != null) return Ok(batiments.ToBatimentDto());
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateBatiment([FromBody] CreateBatimentRequestDto batimentDto)
    {
        var batimentModel = batimentDto.ToBatimentFromCreateDto();
        await _batimentRepository.CreateAsync(batimentModel);
        return CreatedAtAction(nameof(GetBatimentById), new { id = batimentModel.BatimentId, }, batimentModel.ToBatimentDto());
    }
    
    [HttpPut]
    [Route("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBatimentRequestDto updateDto)
    {
        var batimentModel = await _batimentRepository.UpdateAsync(id, updateDto);
        if (batimentModel == null)
        {
            return NotFound();
        }
        return Ok(batimentModel.ToBatimentDto());
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _batimentRepository.DeleteAsync(id));
    }
    
    // Modifier l'adresse d'un bâtiment
    [HttpPut("modifierAdresse/{idBatiment:int:min(1)}/{nouvelleAdresse}")]
    public async Task<IActionResult> ModifierAdresseBatiment(
        [FromRoute] int idBatiment, 
        [FromRoute] string nouvelleAdresse
        )
    {
        try
        {
            var batiment = await _batimentRepository.ModifierAdresseBatiment(idBatiment, nouvelleAdresse);
            return Ok(batiment.ToBatimentDto());
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite pendant la modification de l'adresse : " + exception.Message);
            return StatusCode(500);
        }
    }
    
    // Modifier les détails d'un bâtiment, sans les instances compteurs
    [HttpPut("modifierDetails/{idBatiment:int:min(1)}")]
    public async Task<IActionResult> ModifierDetailsBatiment(
        [FromRoute] int idBatiment, 
        [FromBody]  UpdateBatimentRequestDto updateBatimentRequestDto
    )
    {
        try
        {
            var batiment = await _batimentRepository.ModifierDetailsBatiment(idBatiment, updateBatimentRequestDto);
            return Ok(batiment.ToBatimentDto());
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite pendant la modification des détails du bâtiment : " + exception.Message);
            return StatusCode(500);
        }
    }
    
    // Ajouter une instance de compteur à un bâtiment
    [HttpPost("ajouterInstanceCompteur")]
    public async Task<IActionResult> AjouterInstanceCompteur(
        [FromBody] AjouterInstanceCompteurRequestDto ajouterInstanceCompteurRequestDto
        )
    {
        try
        {
            var batiment = await _batimentRepository.AjouterInstanceCompteur(ajouterInstanceCompteurRequestDto);
            return Ok(batiment.ToBatimentDto());
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite pendant l'ajout de l'instance compteur : " + exception.Message);
            return StatusCode(500);
        }
    }
    
    // Retrouver toutes les instances compteur d'un bâtiment
    [HttpGet("retrouverInstancesCompteur/{idBatiment:int:min(1)}")]
    public async Task<IActionResult> RetrouverInstanceCompteur(
        [FromRoute] int idBatiment
        )
    {
       try
        {
            var batiment = await _batimentRepository.RetrouverInstancesCompteurs(idBatiment);
            return Ok(batiment.ToBatimentDto());
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite pendant la recherche des instances compteurs " + exception.Message);
            return StatusCode(500);
        }
    }
    
}