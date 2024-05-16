using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompteurController : ControllerBase
{
    private readonly ICompteurRepository _compteurRepository;
    // private readonly ApplicationDbContext _context;
    private readonly ILogger<CompteurController> _logger;

    public CompteurController(ICompteurRepository compteurRepository,ApplicationDbContext context, ILogger<CompteurController> logger)
    {
        _compteurRepository = compteurRepository;
        _logger = logger;
        // _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompteurs()
    {
        IEnumerable<Compteur> compteurs = await _compteurRepository.GetAllAsync();
        foreach (var compteur in compteurs)
        {
            compteur.ToCompteurDto();
        }
        return Ok(compteurs);
        
    }


    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetCompteurById([FromRoute] int id)
    {
        var compteurs = await _compteurRepository.GetByIdAsync(id);
        if (compteurs != null) return Ok(compteurs.ToCompteurDto());
        return NotFound();
    }

    // Ajouter un compteur, avec les types cadrans dont nous avons besoin
    [HttpPost]
    public async Task<IActionResult> CreateCompteur([FromBody] AjouterCompteurRequestDto ajouterCompteurRequestDto)
    {
        try
        {
            var compteurEtTypesCadrans = CompteurMapper.ToCompteurDto(await _compteurRepository.AjouterCompteurEtTypesCadrans(ajouterCompteurRequestDto));
            if (compteurEtTypesCadrans is not null)
                return Ok(compteurEtTypesCadrans);
            return StatusCode(500);
        }
        catch (Exception exception)
        {
            _logger.LogError("Une erreur s'est produite pendant l'ajout du compteur et ses types cadrans : " + exception.Message);
            return StatusCode(500);
        }
    }
    
    [HttpPut]
    [Route("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCompteurRequestDto updateDto)
    {
        var compteurModel = await _compteurRepository.UpdateAsync(id, updateDto);
        if (compteurModel == null)
        {
            return NotFound();
        }
        return Ok(compteurModel.ToCompteurDto());
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<bool> Delete([FromRoute] int id)
    {
        return await _compteurRepository.DeleteAsync(id);
    }
}