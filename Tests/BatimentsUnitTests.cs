using GestionCompteursElectriquesMoyenneTension.Controllers;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Batiment;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using GestionCompteursElectriquesMoyenneTension.Model.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace GestionCompteursElectriquesMoyenneTension.Tests;

using Moq;
using Xunit;
public class BatimentsUnitTests
{
    private readonly Mock<IBatimentRepository> _mockBatimentRepository;
    private readonly Mock<ILogger<BatimentController>> _mockLogger;
    private readonly BatimentController _controller;

    public BatimentsUnitTests()
    {
        _mockBatimentRepository = new Mock<IBatimentRepository>();
        _mockLogger = new Mock<ILogger<BatimentController>>();
        _controller = new BatimentController(_mockBatimentRepository.Object, _mockLogger.Object);
    }
    
    [Fact]
    public async Task GetAllBatiments_ReturnsOkResult_WithListOfBatiments()
    {
        // Arrange
        var batiments = new List<Batiment>
        {
            new Batiment { BatimentId = 1, Adresse = "Address 1" },
            new Batiment { BatimentId = 2, Adresse = "Address 2" }
        };
        _mockBatimentRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(batiments);

        // Act
        var result = await _controller.GetAllBatiments();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiments = Assert.IsType<List<Batiment>>(okResult.Value);
        Assert.Equal(batiments.Count, returnBatiments.Count);
        _mockBatimentRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }
    [Fact]
    public async Task GetBatimentById_ReturnsOkResult_WithBatiment()
    {
        // Arrange
        var batiment = new Batiment { BatimentId = 1, Adresse = "Address 1" };
        _mockBatimentRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(batiment);

        // Act
        var result = await _controller.GetBatimentById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once);
    }
    [Fact]
    public async Task GetBatimentById_ReturnsNotFound_WhenBatimentDoesNotExist()
    {
        // Arrange
        _mockBatimentRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Batiment)null);

        // Act
        var result = await _controller.GetBatimentById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _mockBatimentRepository.Verify(repo => repo.GetByIdAsync(1), Times.Once);
    }
    [Fact]
    public async Task CreateBatiment_ReturnsCreatedAtActionResult()
    {
        // Arrange
        var createDto = new CreateBatimentRequestDto { Adresse = "New Address" };
        var batimentModel = createDto.ToBatimentFromCreateDto();

        _mockBatimentRepository.Setup(repo => repo.CreateAsync(It.IsAny<Batiment>())).ReturnsAsync(batimentModel);

        // Act
        var result = await _controller.CreateBatiment(createDto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(createdAtActionResult.Value);
        Assert.Equal(batimentModel.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.CreateAsync(It.IsAny<Batiment>()), Times.Once);
    }
    [Fact]
    public async Task Update_ReturnsOkResult_WithUpdatedBatiment()
    {
        // Arrange
        var updateDto = new UpdateBatimentRequestDto { Adresse = "Updated Address" };
        var batiment = new Batiment { BatimentId = 1, Adresse = "Updated Address" };

        _mockBatimentRepository.Setup(repo => repo.UpdateAsync(1, updateDto)).ReturnsAsync(batiment);

        // Act
        var result = await _controller.Update(1, updateDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.UpdateAsync(1, updateDto), Times.Once);
    }
    [Fact]
    public async Task Update_ReturnsNotFound_WhenBatimentDoesNotExist()
    {
        // Arrange
        var updateDto = new UpdateBatimentRequestDto { Adresse = "Updated Address" };

        _mockBatimentRepository.Setup(repo => repo.UpdateAsync(1, updateDto)).ReturnsAsync((Batiment)null);

        // Act
        var result = await _controller.Update(1, updateDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        _mockBatimentRepository.Verify(repo => repo.UpdateAsync(1, updateDto), Times.Once);
    }
    [Fact]
    public async Task Delete_ReturnsOkResult_WithDeletionStatus()
    {
        // Arrange
        _mockBatimentRepository.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.True((bool)okResult.Value);
        _mockBatimentRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }
    [Fact]
    public async Task ModifierAdresseBatiment_ReturnsOkResult_WithUpdatedBatiment()
    {
        // Arrange
        var batiment = new Batiment { BatimentId = 1, Adresse = "New Address" };

        _mockBatimentRepository.Setup(repo => repo.ModifierAdresseBatiment(1, "New Address")).ReturnsAsync(batiment);

        // Act
        var result = await _controller.ModifierAdresseBatiment(1, "New Address");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.ModifierAdresseBatiment(1, "New Address"), Times.Once);
    }
    [Fact]
    public async Task ModifierDetailsBatiment_ReturnsOkResult_WithUpdatedBatiment()
    {
        // Arrange
        var updateDto = new UpdateBatimentRequestDto { Adresse = "Updated Address", TypeBatiment = "Type", NombreEtages = 2 };
        var batiment = new Batiment { BatimentId = 1, Adresse = "Updated Address", TypeBatiment = "Type", NombreEtages = 2 };

        _mockBatimentRepository.Setup(repo => repo.ModifierDetailsBatiment(1, updateDto)).ReturnsAsync(batiment);

        // Act
        var result = await _controller.ModifierDetailsBatiment(1, updateDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.ModifierDetailsBatiment(1, updateDto), Times.Once);
    }
    [Fact]
    public async Task AjouterInstanceCompteur_ReturnsOkResult_WithUpdatedBatiment()
    {
        // Arrange
        var ajouterDto = new AjouterInstanceCompteurRequestDto { BatimentId = 1, CompteurId = 1, DateInstallation = DateOnly.FromDateTime(DateTime.Now) };
        var batiment = new Batiment { BatimentId = 1 };

        _mockBatimentRepository.Setup(repo => repo.AjouterInstanceCompteur(ajouterDto)).ReturnsAsync(batiment);

        // Act
        var result = await _controller.AjouterInstanceCompteur(ajouterDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.AjouterInstanceCompteur(ajouterDto), Times.Once);
    }
    [Fact]
    public async Task RetrouverInstanceCompteur_ReturnsOkResult_WithBatiment()
    {
        // Arrange
        var batiment = new Batiment { BatimentId = 1, InstanceCompteurs = new List<InstanceCompteur>() };
        _mockBatimentRepository.Setup(repo => repo.RetrouverInstancesCompteurs(1)).ReturnsAsync(batiment);

        // Act
        var result = await _controller.RetrouverInstanceCompteur(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnBatiment = Assert.IsType<BatimentDto>(okResult.Value);
        Assert.Equal(batiment.BatimentId, returnBatiment.BatimentId);
        _mockBatimentRepository.Verify(repo => repo.RetrouverInstancesCompteurs(1), Times.Once);
    }



}
