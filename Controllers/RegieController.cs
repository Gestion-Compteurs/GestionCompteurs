using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RegieController(IRegieRepository regieRepository) : ControllerBase
{
    private readonly IRegieRepository _regieRepository = regieRepository;
    
}