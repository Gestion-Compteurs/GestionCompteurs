
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
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OperateurController> _logger;

        public OperateurController(IOperateurRepository operateurRepository, ApplicationDbContext context, ILogger<OperateurController> logger)
        {
            _operateurRepository = operateurRepository;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperateurs()
        {
            IEnumerable<Operateur> operateurs = await _operateurRepository.GetAllAsync();
            foreach (var operateur in operateurs)
            {
                operateur.ToOperateurDto(); 
            }
            return Ok(operateurs);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetOperateurById([FromRoute] int id)
        {
            var operateur = await _operateurRepository.GetByIdAsync(id);
            if (operateur != null) 
                return Ok(operateur.ToOperateurDto()); 
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperateur([FromBody] CreateOperateurRequestDto operateurDto)
        {
            var operateurModel = operateurDto.ToOperateurFromCreateDto(); 
            await _operateurRepository.CreateAsync(operateurModel);
            return CreatedAtAction(nameof(GetOperateurById), new { id = operateurModel.OperateurId }, operateurModel.ToOperateurDto()); 
        }
        
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateOperateur([FromRoute] int id, [FromBody] UpdateOperateurRequestDto updateDto)
        {
            var operateurModel = await _operateurRepository.UpdateAsync(id, updateDto);
            if (operateurModel == null)
                return NotFound();
            return Ok(operateurModel.ToOperateurDto()); 
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

