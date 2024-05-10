using GestionBatimentsElectriquesMoyenneTension.Model.Mappers;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionBatimentsElectriquesMoyenneTension.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BatimentController : ControllerBase
{
    private readonly IBatimentRepository _batimentRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<BatimentController> _logger;

    public BatimentController(IBatimentRepository batimentRepository,ApplicationDbContext context, ILogger<BatimentController> logger)
    {
        _batimentRepository = batimentRepository;
        _logger = logger;
        _context = context;
    }

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
    public IActionResult Delete([FromRoute] int id)
    {
        var batimentModel = _batimentRepository.DeleteAsync(id);
        if (batimentModel == null)
            return NotFound();
        return NoContent();
    }
    
    // Modifier l'adresse d'un bâtiment
    [HttpPut("modifierAdresse/{idBatiment:int:min(1)}/{nouvelleAdresse}")]
    public async Task<IActionResult> ModifierAdresseBatiment(
        [FromRoute] int idBatiment, 
        [FromRoute] string nouvelleAdresse
        )
    {
        throw new NotImplementedException();
    }
    
    // Ajouter une instance de compteur à un bâtiment
    [HttpPost("ajouterInstanceCompteur")]
    public async Task<IActionResult> AjouterInstanceCompteur(
        [FromBody] AjouterInstanceCompteurRequestDto ajouterInstanceCompteurRequestDto
        )
    {
        throw new NotImplementedException();
    }
    
    // Retrouver toutes les instances compteur d'un bâtiment
    [HttpGet("retrouverInstancesCompteur/{idBatiment:int:min(1)}")]
    public async Task<IActionResult> RetrouverInstanceCompteur(
        [FromRoute] int idBatiment
        )
    {
        throw new NotImplementedException();
    }
    
}