
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.ReleveCadran;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;



[ApiController]
[Route("api/releveCadran")]
public class ReleveCadranController:ControllerBase
{
    private readonly IReleveCadranRepository _releveCadranRepository;
    private readonly IInstanceCadranRepository _instanceCadranRepository;
    private readonly ICompteurRepository _compteurRepository;
    private readonly ICadranRepository _cadranRepository;
    public ReleveCadranController(
        IInstanceCadranRepository instanceCadranRepository,
        IReleveCadranRepository releveCadranRepository,
        ICompteurRepository compteurRepository,
        ICadranRepository cadranRepository
        )
    {
        _releveCadranRepository = releveCadranRepository;
        _compteurRepository = compteurRepository;
        _cadranRepository = cadranRepository;
        _instanceCadranRepository = instanceCadranRepository;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var releveCadrans = await _releveCadranRepository.GetAllAsync();
        foreach (var compteur in releveCadrans)
        {
            compteur.ToReleveCadranDto();
        }
        return Ok(releveCadrans);
    }
    
    [Route("{id:int:min(1)}")]
    [HttpGet]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var releveCadran = await _releveCadranRepository.GetByIdAsync(id);
        if (releveCadran == null) return NotFound();
        var dtoReleveCadran = releveCadran.ToReleveCadranDto();
        return Ok(dtoReleveCadran);
    }
    
    [HttpPost]
    [Route("createReleveCadran")]
    public async Task<IActionResult> Create(
        [FromBody] CreateReleveCadranRequestDto createReleveCadranDto
        )
    {
        if  (! await _instanceCadranRepository.InstanceCadranExists(createReleveCadranDto.InstanceCadranId)) return NotFound("Instance Cadran not found");
        var releveCadran = createReleveCadranDto.ToReleveCadranFromCreateDto();
        var creation = await _releveCadranRepository.CreateAsync(releveCadran);
        if (creation != null) return CreatedAtAction(nameof(GetById), new { id = creation.ReleveCadranId }, creation.ToReleveCadranDto());
        return StatusCode(500);
    }
    
    // Modifier une relève de cadran
    public async Task<IActionResult> ModifierReleveCadran(ModifierReleveCadranRequestDto modifierReleveCadranRequestDto)
    {
        throw new NotImplementedException();
    }
}