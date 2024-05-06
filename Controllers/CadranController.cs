using GestionCadransElectriquesMoyenneTension.Model.Mappers;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Cadran;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCadransElectriquesMoyenneTension.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CadranController : ControllerBase
{
    private readonly ICadranRepository _cadranRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CadranController> _logger;

    public CadranController(ICadranRepository cadranRepository, ApplicationDbContext context,
        ILogger<CadranController> logger)
    {
        _cadranRepository = cadranRepository;
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCadrans()
    {
        IEnumerable<Cadran> cadrans = await _cadranRepository.GetAllAsync();
        foreach (var cadran in cadrans)
        {
            cadran.ToCadranDto();
        }

        return Ok(cadrans);

    }


    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetCadranById([FromRoute] int id)
    {
        var cadrans = await _cadranRepository.GetByIdAsync(id);
        if (cadrans != null) return Ok(cadrans.ToCadranDto());
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCadran([FromBody] CreateCadranRequestDto cadranDto)
    {
        var cadranModel = cadranDto.ToCadranFromCreateDto();
        await _cadranRepository.CreateAsync(cadranModel);
        return CreatedAtAction(nameof(GetCadranById), new { id = cadranModel.CadranId, }, cadranModel.ToCadranDto());
    }

    [HttpPut]
    [Route("{id:int:min(1)}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCadranRequestDto updateDto)
    {
        var cadranModel = await _cadranRepository.UpdateAsync(id, updateDto);
        if (cadranModel == null)
        {
            return NotFound();
        }

        return Ok(cadranModel.ToCadranDto());
    }

    [HttpDelete("{id:int:min(1)}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var cadranModel = _cadranRepository.DeleteAsync(id);
        if (cadranModel == null)
            return NotFound();
        return NoContent();
    }
}
    
