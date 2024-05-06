using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;


[ApiController]
[Route("api/instanceCadran")]
public class InstanceCadranController:ControllerBase
{
    private readonly IInstanceCadranRepository _instanceCadranRepository;
    private readonly ICadranRepository _cadranRepository;
    private readonly IBatimentRepository _batimentRepository;
    public InstanceCadranController(IInstanceCadranRepository instanceCadranRepository,ICadranRepository cadranRepository,IBatimentRepository batimentRepository)
    {
        _instanceCadranRepository = instanceCadranRepository;
        _cadranRepository = cadranRepository;
        _batimentRepository = batimentRepository;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var instanceCadrans = await _instanceCadranRepository.GetAllAsync();
        var dtoInstanceCadrans = instanceCadrans.Select(c => c.ToInstanceCadranDto());
        return Ok(dtoInstanceCadrans);
    }
    
    [Route("{id:int:min(1)}")]
    [HttpGet]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var instanceCadran = await _instanceCadranRepository.GetByIdAsync(id);
        if (instanceCadran == null) return NotFound();
        var dtoInstanceCadran = instanceCadran.ToInstanceCadranDto();
        return Ok(dtoInstanceCadran);
    }
    
    /*
     [HttpPost]
    [Route("{cadranId:int:min(1)}")]
    public async Task<IActionResult> Create([FromRoute] int cadranId,CreateInstanceCadranRequestDto createInstanceCadranDto)
    {
        if  (! await _cadranRepository.CadranExists(cadranId)) return NotFound("Cadran not found");
        var instanceCadran = createInstanceCadranDto.ToInstanceCadranFromCreateDto(cadranId: cadranId);
        var creation = await _instanceCadranRepository.CreateAsync(instanceCadran);
        if (creation != null) return CreatedAtAction(nameof(GetById), new { id = creation.InstanceCadranId }, creation.ToInstanceCadranDto());
        return StatusCode(500);

    }*/
    
}