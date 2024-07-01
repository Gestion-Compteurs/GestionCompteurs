using EntityFrameworkCore.Testing.Moq;
using GestionCompteursElectriquesMoyenneTension.Controllers;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.DTOs.Operateur;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GestionCompteursElectriquesMoyenneTension.Tests;

public class OperateursUnitTests
{
    private readonly Mock<IOperateurRepository> _mockOperateurRepository;
    private readonly Mock<ILogger<OperateurController>> _mockLogger;
    private readonly OperateurController _controller;
    private readonly ApplicationDbContext _db;

    public OperateursUnitTests()
    {
        _mockOperateurRepository = new Mock<IOperateurRepository>();
        _mockLogger = new Mock<ILogger<OperateurController>>();
        _db = Create.MockedDbContextFor<ApplicationDbContext>();
        _controller = new OperateurController(_mockOperateurRepository.Object, _db, _mockLogger.Object);
    }

    [Fact]
    public async Task UpdateOperateur_ReturnsOkResult_WithUpdatedOperateur()
    {
        // Arrange
        int operateurId = 1;
        var updateDto = new UpdateOperateurRequestDto()
        {
            DateEmbauche = DateTime.Today - TimeSpan.FromDays(1),
            DateDeNaissance = DateTime.Today - TimeSpan.FromDays(1),
        };
        var updatedOperateur = new Operateur
        {
            OperateurId = operateurId,
            // Initialize with updated properties
            DateEmbauche = DateTime.Today,
            DateDeNaissance = DateTime.UtcNow,
            releves = new List<Releve>()
        };

        _mockOperateurRepository.Setup(repo => repo.UpdateAsync(operateurId, updateDto)).ReturnsAsync(updatedOperateur);

        // Act
        var result = await _controller.UpdateOperateur(operateurId, updateDto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnOperateur = Assert.IsType<OperateurDto>(okResult.Value);
        Assert.Equal(operateurId, returnOperateur.OperateurId);

        _mockOperateurRepository.Verify(repo => repo.UpdateAsync(operateurId, updateDto), Times.Once);
    }

    [Fact]
    public async Task UpdateOperateur_ReturnsNotFound_WhenOperateurDoesNotExist()
    {
        // Arrange
        int operateurId = 1;
        var updateDto = new UpdateOperateurRequestDto
        {
            DateEmbauche = DateTime.Today - TimeSpan.FromDays(1),
            DateDeNaissance = DateTime.Today - TimeSpan.FromDays(1),
        };

        _mockOperateurRepository.Setup(repo => repo.UpdateAsync(operateurId, updateDto)).ReturnsAsync((Operateur)null);

        // Act
        var result = await _controller.UpdateOperateur(operateurId, updateDto);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        _mockOperateurRepository.Verify(repo => repo.UpdateAsync(operateurId, updateDto), Times.Once);
    }

    [Fact]
    public async Task DeleteOperateur_ReturnsNoContent_WhenOperateurIsDeleted()
    {
        // Arrange
        int operateurId = 1;
        var deletedOperateur = new Operateur
        {
            OperateurId = operateurId,
            
        };

        _mockOperateurRepository.Setup(repo => repo.DeleteAsync(operateurId)).ReturnsAsync(deletedOperateur);

        // Act
        var result = await _controller.DeleteOperateur(operateurId);

        // Assert
        Assert.IsType<NoContentResult>(result);

        _mockOperateurRepository.Verify(repo => repo.DeleteAsync(operateurId), Times.Once);
    }

    [Fact]
    public async Task DeleteOperateur_ReturnsNotFound_WhenOperateurDoesNotExist()
    {
        // Arrange
        int operateurId = 1;

        _mockOperateurRepository.Setup(repo => repo.DeleteAsync(operateurId)).ReturnsAsync((Operateur)null);

        // Act
        var result = await _controller.DeleteOperateur(operateurId);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        _mockOperateurRepository.Verify(repo => repo.DeleteAsync(operateurId), Times.Once);
    }
}