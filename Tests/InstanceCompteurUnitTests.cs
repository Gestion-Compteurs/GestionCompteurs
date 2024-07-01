using GestionCompteursElectriquesMoyenneTension.Controllers;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCadran;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.InstanceCompteur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace GestionCompteursElectriquesMoyenneTension.Tests;

public class InstanceCompteurUnitTests
{
    private readonly Mock<IInstanceCompteurRepository> _mockInstanceCompteurRepository;
    private readonly Mock<IInstanceCadranRepository> _mockInstanceCadranRepository;
    private readonly Mock<ICompteurRepository> _mockCompteurRepository;
    private readonly Mock<IBatimentRepository> _mockBatimentRepository;
    private readonly Mock<ICadranRepository> _mockCadranRepository;
    private readonly Mock<ILogger<InstanceCompteurController>> _mockLogger;
    private readonly InstanceCompteurController _controller;
    
    
    public InstanceCompteurUnitTests()
    {
        _mockInstanceCompteurRepository = new Mock<IInstanceCompteurRepository>();
        _mockInstanceCadranRepository = new Mock<IInstanceCadranRepository>();
        _mockCompteurRepository = new Mock<ICompteurRepository>();
        _mockBatimentRepository = new Mock<IBatimentRepository>();
        _mockCadranRepository = new Mock<ICadranRepository>();
        _mockLogger = new Mock<ILogger<InstanceCompteurController>>();
        _controller = new InstanceCompteurController(
            _mockInstanceCadranRepository.Object,
            _mockInstanceCompteurRepository.Object,
            _mockCompteurRepository.Object,
            _mockBatimentRepository.Object,
            _mockCadranRepository.Object,
            _mockLogger.Object
        );
    }
    
    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfInstanceCompteurs()
    {
        // Arrange
        var instanceCompteurs = new List<InstanceCompteur>
        {
            new InstanceCompteur { InstanceCompteurId = 1 },
            new InstanceCompteur { InstanceCompteurId = 2 }
        };
        _mockInstanceCompteurRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(instanceCompteurs);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnCompteurs = Assert.IsType<List<InstanceCompteur>>(okResult.Value);
        Assert.Equal(instanceCompteurs.Count, returnCompteurs.Count);
        _mockInstanceCompteurRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }

    
    

[Fact]
public async Task GetById_ReturnsOkResult_WithInstanceCompteur()
{
    // Arrange
    var instanceCompteur = new InstanceCompteur { InstanceCompteurId = 1 };
    _mockInstanceCompteurRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(instanceCompteur);

    // Act
    var result = await _controller.GetById(1);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var returnCompteur = Assert.IsType<InstanceCompteurDto>(okResult.Value);
    _mockInstanceCompteurRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once);
}

[Fact]
public async Task GetById_ReturnsNotFound_WhenInstanceCompteurDoesNotExist()
{
    // Arrange
    _mockInstanceCompteurRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((InstanceCompteur)null);

    // Act
    var result = await _controller.GetById(1);

    // Assert
    Assert.IsType<NotFoundResult>(result);
    _mockInstanceCompteurRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once);
}
[Fact]
public async Task CreateInstanceCompteur_ReturnsCreatedAtActionResult()
{
    // Arrange
    var compteurId = 1;
    var batimentId = 1;
    var createDto = new CreateInstanceCompteurRequestDto { /* set properties */ };
    var instanceCompteur = new InstanceCompteur { InstanceCompteurId = 1 };

    _mockCompteurRepository.Setup(repo => repo.CompteurExists(compteurId)).ReturnsAsync(true);
    _mockBatimentRepository.Setup(repo => repo.BatimentExists(batimentId)).ReturnsAsync(true);
    _mockInstanceCompteurRepository.Setup(repo => repo.CreateAsync(It.IsAny<InstanceCompteur>())).ReturnsAsync(instanceCompteur);

    // Act
    var result = await _controller.Create(compteurId, batimentId, createDto);

    // Assert
    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    var returnCompteur = Assert.IsType<InstanceCompteurDto>(createdAtActionResult.Value);
    Assert.Equal(instanceCompteur.InstanceCompteurId, returnCompteur.InstanceCompteurId);
    _mockCompteurRepository.Verify(repo => repo.CompteurExists(compteurId), Times.Once);
    _mockBatimentRepository.Verify(repo => repo.BatimentExists(batimentId), Times.Once);
    _mockInstanceCompteurRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCompteur>()), Times.Once);
}

[Fact]
public async Task CreateInstanceCompteur_ReturnsNotFound_WhenCompteurDoesNotExist()
{
    // Arrange
    var compteurId = 1;
    var batimentId = 1;
    var createDto = new CreateInstanceCompteurRequestDto { /* set properties */ };

    _mockCompteurRepository.Setup(repo => repo.CompteurExists(compteurId)).ReturnsAsync(false);

    // Act
    var result = await _controller.Create(compteurId, batimentId, createDto);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("Compteur not found", notFoundResult.Value);
    _mockCompteurRepository.Verify(repo => repo.CompteurExists(compteurId), Times.Once);
    _mockBatimentRepository.Verify(repo => repo.BatimentExists(It.IsAny<int>()), Times.Never);
    _mockInstanceCompteurRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCompteur>()), Times.Never);
}

[Fact]
public async Task CreateInstanceCompteur_ReturnsNotFound_WhenBatimentDoesNotExist()
{
    // Arrange
    var compteurId = 1;
    var batimentId = 1;
    var createDto = new CreateInstanceCompteurRequestDto { /* set properties */ };

    _mockCompteurRepository.Setup(repo => repo.CompteurExists(compteurId)).ReturnsAsync(true);
    _mockBatimentRepository.Setup(repo => repo.BatimentExists(batimentId)).ReturnsAsync(false);

    // Act
    var result = await _controller.Create(compteurId, batimentId, createDto);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("Batiment not found", notFoundResult.Value);
    _mockCompteurRepository.Verify(repo => repo.CompteurExists(compteurId), Times.Once);
    _mockBatimentRepository.Verify(repo => repo.BatimentExists(batimentId), Times.Once);
    _mockInstanceCompteurRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCompteur>()), Times.Never);
}
[Fact]
public async Task CreateInstanceCadran_ReturnsCreatedAtActionResult()
{
    // Arrange
    var cadranId = 1;
    var createDto = new CreateInstanceCadranRequestDto { InstanceCompteurId = 1 };
    var instanceCadran = new InstanceCadran { InstanceCadranId = 1 };

    _mockCadranRepository.Setup(repo => repo.CadranExists(cadranId)).ReturnsAsync(true);
    _mockInstanceCompteurRepository.Setup(repo => repo.InstanceCompteurExists(createDto.InstanceCompteurId)).ReturnsAsync(true);
    _mockInstanceCadranRepository.Setup(repo => repo.CreateAsync(It.IsAny<InstanceCadran>())).ReturnsAsync(instanceCadran);

    // Act
    var result = await _controller.Create(cadranId, createDto);

    // Assert
    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    var returnCadran = Assert.IsType<InstanceCadranDto>(createdAtActionResult.Value);
    Assert.Equal(instanceCadran.InstanceCadranId, returnCadran.InstanceCadranId);
    _mockCadranRepository.Verify(repo => repo.CadranExists(cadranId), Times.Once);
    _mockInstanceCompteurRepository.Verify(repo => repo.InstanceCompteurExists(createDto.InstanceCompteurId), Times.Once);
    _mockInstanceCadranRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCadran>()), Times.Once);
}

[Fact]
public async Task CreateInstanceCadran_ReturnsNotFound_WhenCadranDoesNotExist()
{
    // Arrange
    var cadranId = 1;
    var createDto = new CreateInstanceCadranRequestDto { InstanceCompteurId = 1 };

    _mockCadranRepository.Setup(repo => repo.CadranExists(cadranId)).ReturnsAsync(false);

    // Act
    var result = await _controller.Create(cadranId, createDto);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("Cadran not found", notFoundResult.Value);
    _mockCadranRepository.Verify(repo => repo.CadranExists(cadranId), Times.Once);
    _mockInstanceCompteurRepository.Verify(repo => repo.InstanceCompteurExists(It.IsAny<int>()), Times.Never);
    _mockInstanceCadranRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCadran>()), Times.Never);
}

[Fact]
public async Task CreateInstanceCadran_ReturnsNotFound_WhenInstanceCompteurDoesNotExist()
{
    // Arrange
    var cadranId = 1;
    var createDto = new CreateInstanceCadranRequestDto() { InstanceCompteurId = 1 };

    _mockCadranRepository.Setup(repo => repo.CadranExists(cadranId)).ReturnsAsync(true);
    _mockInstanceCompteurRepository.Setup(repo => repo.InstanceCompteurExists(createDto.InstanceCompteurId)).ReturnsAsync(false);

    // Act
    var result = await _controller.Create(cadranId, createDto);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("Instance of Compteur not found", notFoundResult.Value);
    _mockCadranRepository.Verify(repo => repo.CadranExists(cadranId), Times.Once);
    _mockInstanceCompteurRepository.Verify(repo => repo.InstanceCompteurExists(createDto.InstanceCompteurId), Times.Once);
    _mockInstanceCadranRepository.Verify(repo => repo.CreateAsync(It.IsAny<InstanceCadran>()), Times.Never);
}
[Fact]
public async Task TrouverInstanceEtReleves_ReturnsOkResult_WithInstanceCompteur()
{
    // Arrange
    var instanceCompteur = new InstanceCompteur { InstanceCompteurId = 1, Releves = new List<Releve>() };
    _mockInstanceCompteurRepository.Setup(repo => repo.TrouverInstanceEtReleves(1)).ReturnsAsync(instanceCompteur);

    // Act
    var result = await _controller.TrouverInstanceEtReleves(1);

    // Assert
    var okResult = Assert.IsType<OkObjectResult>(result);
    var returnCompteur = Assert.IsType<InstanceCompteurDto>(okResult.Value);
    _mockInstanceCompteurRepository.Verify(repo => repo.TrouverInstanceEtReleves(1), Times.Once);
}

[Fact]
public async Task TrouverInstanceEtReleves_ReturnsNotFound_WhenInstanceCompteurDoesNotExist()
{
    // Arrange
    _mockInstanceCompteurRepository.Setup(repo => repo.TrouverInstanceEtReleves(1)).ReturnsAsync((InstanceCompteur)null);

    // Act
    var result = await _controller.TrouverInstanceEtReleves(1);

    // Assert
    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
    Assert.Equal("L'instance compteur n'existe pas dans cette base de données", notFoundResult.Value);
    _mockInstanceCompteurRepository.Verify(repo => repo.TrouverInstanceEtReleves(1), Times.Once);
}
}
