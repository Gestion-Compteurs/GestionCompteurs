using EntityFrameworkCore.Testing.Moq;
using FakeItEasy;
using GestionCompteursElectriquesMoyenneTension.Controllers;
using GestionCompteursElectriquesMoyenneTension.Data;
using GestionCompteursElectriquesMoyenneTension.Model.Entities;
using GestionCompteursElectriquesMoyenneTension.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace GestionCompteursElectriquesMoyenneTension.Tests;

public class CompteurUnitTests
{
    /*private readonly ApplicationDbContext _db;*/
    private readonly Mock<ILogger<CompteurController>> _logger;
    private readonly Mock<ICompteurRepository> _mockCompteurRepository;
    private readonly CompteurController _controller;
    
    public CompteurUnitTests()
    {
        _mockCompteurRepository = new Mock<ICompteurRepository>();
        _logger = new Mock<ILogger<CompteurController>>();
        _controller = new CompteurController(_mockCompteurRepository.Object,_logger.Object);
    }
    
    [Fact]
    public async Task InsertCompteurIsInsertingNewInstance()
    {
        
        // var fakeCompteurs = A.CollectionOfDummy<Compteur>(5).AsEnumerable();//FakeItEasy
        // A.CallTo(() => instanceCompteurRepository.GetAllAsync());
        // var _db = Create.MockedDbContextFor<ApplicationDbContext>();
        // var _logger = Mock.Of<ILogger<CompteurController>>();
        
        //Arrange
        var fakeCompteurs = new List<Compteur>();
        for (int i = 1; i <= 5; i++)
        {
            fakeCompteurs.Add(new Compteur
            {
                CompteurId = i,
                Marque = $"Marque{i}",
                Modele = $"Modele{i}",
                AnneeCreation = 2000 + i,
                VoltageMax = 100 + i * 10,
                TypesCadrans = new List<Cadran>(),
                InstanceCompteurs = new List<InstanceCompteur>()
            });
        }
        _mockCompteurRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeCompteurs);
        //Act
        var result = await _controller.GetAllCompteurs();
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnCompteurs = Assert.IsType<List<Compteur>>(okResult.Value);
        Assert.Equal(fakeCompteurs.Count(), returnCompteurs.Count);
        _mockCompteurRepository.Verify(repo => repo.GetAllAsync(), Moq.Times.Once);
    }
    
    [Fact]
    public async Task Delete_DeletesCompteur_ReturnsTrue()
    {
        // Arrange
        var compteurIdToDelete = 1;

        _mockCompteurRepository.Setup(repo => repo.DeleteAsync(compteurIdToDelete))
            .ReturnsAsync(true);

        // Act
        var result = await _controller.Delete(compteurIdToDelete);

        // Assert
        Assert.True(result);
        _mockCompteurRepository.Verify(repo => repo.DeleteAsync(compteurIdToDelete), Moq.Times.Once);
    }

    [Fact]
    public async Task Delete_NonExistentCompteur_ReturnsFalse()
    {
        // Arrange
        var compteurIdToDelete = 1;

        _mockCompteurRepository.Setup(repo => repo.DeleteAsync(compteurIdToDelete))
            .ReturnsAsync(false);

        // Act
        var result = await _controller.Delete(compteurIdToDelete);

        // Assert
        Assert.False(result);
        _mockCompteurRepository.Verify(repo => repo.DeleteAsync(compteurIdToDelete), Moq.Times.Once);
    }

}