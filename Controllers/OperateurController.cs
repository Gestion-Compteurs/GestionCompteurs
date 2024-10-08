
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace GestionCompteursElectriquesMoyenneTension.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class OperateurController : ControllerBase
    {
        private readonly IOperateurRepository _operateurRepository;
        //private readonly ApplicationDbContext _context;
        private readonly ILogger<OperateurController> _logger;

        public OperateurController(IOperateurRepository operateurRepository, ApplicationDbContext context, ILogger<OperateurController> logger)
        {
            _operateurRepository = operateurRepository;
            _logger = logger;
           // _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperateurs()
        {
            IEnumerable<Operateur> operateurs = await _operateurRepository.GetAllAsync();
            foreach (var operateur in operateurs)
            {
                OperateurMapper.ToOperateurDto(operateur); 
            }
            return Ok(operateurs);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetOperateurById([FromRoute] int id)
        {
            var operateurs = await _operateurRepository.GetByIdAsync(id);
            if (operateurs != null) 
                return Ok(operateurs.ToOperateurDto()); 
            return NotFound();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateOperateur([FromBody] CreateOperateurRequestDto operateurDto)
        {
            try
            {
                var operateurModel = OperateurMapper.ToOperateurFromCreateDto(operateurDto);
                await _operateurRepository.CreateAsync(operateurModel);
                var operateurResultDto = OperateurMapper.ToOperateurDto(operateurModel);
                if (operateurResultDto is not null)
                    return CreatedAtAction(nameof(GetOperateurById), new { id = operateurModel.OperateurId }, operateurResultDto);
                return StatusCode(500);
            }
            catch (Exception exception)
            {
                _logger.LogError("Une erreur s'est produite pendant l'ajout de l'opérateur : " + exception.Message);
                return StatusCode(500);
            }
        }

        
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateOperateur([FromRoute] int id, [FromBody] UpdateOperateurRequestDto updateDto)
        {
            var operateurModel = await _operateurRepository.UpdateAsync(id, updateDto);
            if (operateurModel == null)
                return NotFound();
            return Ok(OperateurMapper.ToOperateurDto(operateurModel)); 
        }
        

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteOperateur([FromRoute] int id)
        {
            var operateurModel = await _operateurRepository.DeleteAsync(id);
            if (operateurModel == null)
                return NotFound();
            return NoContent();
        }
    }

