using FluentAssertions;
using Lego.EquipmentStateHistory.API.Models;
using Lego.EquipmentStateHistory.API.UnitTests.Fixtures;
using Lego.EquipmentStateHistory.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Lego.EquipmentStateHistory.API.UnitTests.Systems.Controllers
{
    public class TestStateHistoryController
    {
        #region GetAll

        [Fact]
        public async Task GetAll_OnSuccess_ReturnsOk()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState.Object);

            //Act
            var result = (OkObjectResult)await sut.GetAll(mockState.Object.EquipmentId);

            //Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetAll_WhenNoStates_ReturnsNotFound()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut();

            //Act
            var result = (NotFoundResult)await sut.GetAll(mockState.Object.EquipmentId);

            //Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetAll_OnSuccess_ReturnsListOfStatesVM()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState.Object);

            //Act
            var result = await sut.GetAll(mockState.Object.EquipmentId);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<EquipmentStateViewModel>>();
        }

        #endregion

        #region AddState

        [Fact]
        public async Task AddState_OnSuccess_RetunsCreated()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState.Object, add: true);

            //Act
            var result = (CreatedResult)await sut.AddState(mockState.Object);

            //Assert
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task AddState_OnFail_ReturnsConflict()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut();

            //Act
            var result = (ConflictResult)await sut.AddState(mockState.Object);

            //Assert
            result.StatusCode.Should().Be(409);
        }

        [Fact]
        public async Task AddState_OnSuccess_RetunsEquipmentState()
        {
            //Arrange
            var mockState = new EquipmentState();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState, add: true);

            //Act
            var result = await sut.AddState(mockState);

            //Assert
            result.Should().BeOfType<CreatedResult>();

            ((CreatedResult)result).Value.Should().BeOfType<EquipmentState>();
        }

        #endregion

        #region GetCurrent

        [Fact]
        public async Task GetCurrent_OnSuccess_ReturnsOk()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState.Object);

            //Act
            var result = (OkObjectResult)await sut.GetCurrent(mockState.Object.EquipmentId);

            //Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetCurrent_WhenNoStates_ReturnsNotFound()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut();

            //Act
            var result = (NotFoundResult)await sut.GetCurrent(mockState.Object.EquipmentId);

            //Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetCurrent_OnSuccess_ReturnsStateVM()
        {
            //Arrange
            var mockState = new Mock<EquipmentState>();
            var sut = StateHistoryControllerFixtures.SetupSut(mockState.Object);

            //Act
            var result = await sut.GetCurrent(mockState.Object.EquipmentId);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<EquipmentStateViewModel>();
        }

        #endregion
    }
}