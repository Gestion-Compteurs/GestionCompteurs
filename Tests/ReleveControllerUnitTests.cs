
namespace GestionCompteursElectriquesMoyenneTension.Tests;

using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Testing.Moq;
using GestionCompteursElectriquesMoyenneTension.Controllers;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Compteur;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Releve;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using  Microsoft.Extensions.Logging;


public class ReleveControllerUnitTests
{
    private readonly Mock<IReleveRepository> _mockReleveRepository;
    private readonly Mock<ILogger<ReleveController>> _mockLogger;
    private readonly ReleveController _controller;
  
    public ReleveControllerUnitTests()
    {
        _mockReleveRepository = new Mock<IReleveRepository>();
        _mockLogger = new Mock<ILogger<ReleveController>>();
        _controller = new ReleveController(_mockReleveRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task ModifierReleve_ReturnsOkResult_WithUpdatedReleve()
    {
        // Arrange
        var modifierReleveRequestDto = new ModifierReleveRequestDto();
        var updatedReleve = new Releve(); //

        _mockReleveRepository.Setup(repo => repo.ModifierReleve(modifierReleveRequestDto)).ReturnsAsync(updatedReleve);

        // Act
        var result = await _controller.ModifierReleve(modifierReleveRequestDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnReleve = Assert.IsType<Releve>(okResult.Value);

        _mockReleveRepository.Verify(repo => repo.ModifierReleve(modifierReleveRequestDto), Times.Once);
    }

    [Fact]
    public async Task TrouverReleveEtRelevesCadran_ReturnsOkResult_WithReleve()
    {
        // Arrange
        int idReleve = 1;
        var releve = new Releve(); 

        _mockReleveRepository.Setup(repo => repo.TrouverReleveEtRelevesCadran(idReleve)).ReturnsAsync(releve);

        // Act
        var result = await _controller.TrouverReleveEtRelevesCadran(idReleve);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnReleve = Assert.IsType<ReleveDto>(okResult.Value); // assuming ReleveDto is the DTO

        _mockReleveRepository.Verify(repo => repo.TrouverReleveEtRelevesCadran(idReleve), Times.Once);
    }

    [Fact]
    public async Task CreerNouvelleReleve_ReturnsOkResult_WithNewReleve()
    {
        // Arrange
        var ajouterNouvelleReleveRequestDto = new AjouterNouvelleReleveRequestDto();
        var newReleve = new Releve(); 

        _mockReleveRepository.Setup(repo => repo.CreerNouvelleReleve(ajouterNouvelleReleveRequestDto)).ReturnsAsync(newReleve);

        // Act
        var result = await _controller.CreerNouvelleReleve(ajouterNouvelleReleveRequestDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnReleve = Assert.IsType<Releve>(okResult.Value);

        _mockReleveRepository.Verify(repo => repo.CreerNouvelleReleve(ajouterNouvelleReleveRequestDto), Times.Once);
    }

    [Fact]
    public async Task ConfirmerCreationNouvelleReleve_ReturnsOkResult_WithConfirmedReleve()
    {
        // Arrange
        var confirmerCreationNouvelleReleveRequestDto = new ConfirmerCreationNouvelleReleveRequestDto();
        var confirmedReleve = new Releve(); 

        _mockReleveRepository.Setup(repo => repo.ConfirmerCreationNouvelleReleve(confirmerCreationNouvelleReleveRequestDto)).ReturnsAsync(confirmedReleve);

        // Act
        var result = await _controller.ConfirmerCreationNouvelleReleve(confirmerCreationNouvelleReleveRequestDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnReleve = Assert.IsType<Releve>(okResult.Value);

        _mockReleveRepository.Verify(repo => repo.ConfirmerCreationNouvelleReleve(confirmerCreationNouvelleReleveRequestDto), Times.Once);
    }

    [Fact]
    public async Task DeleteReleve_ReturnsOkResult_WhenReleveIsDeleted()
    {
        // Arrange
        int idReleve = 1;

        _mockReleveRepository.Setup(repo => repo.DeleteReleve(idReleve)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteReleve(idReleve);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<bool>(okResult.Value);
        Assert.True(returnValue);

        _mockReleveRepository.Verify(repo => repo.DeleteReleve(idReleve), Times.Once);
    }

    [Fact]
    public async Task DeleteReleve_ReturnsNotFound_WhenReleveDoesNotExist()
    {
        // Arrange
        int idReleve = 1;

        _mockReleveRepository.Setup(repo => repo.DeleteReleve(idReleve)).ReturnsAsync(false);

        // Act
        var result = await _controller.DeleteReleve(idReleve);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);

        _mockReleveRepository.Verify(repo => repo.DeleteReleve(idReleve), Times.Once);
    }
}
