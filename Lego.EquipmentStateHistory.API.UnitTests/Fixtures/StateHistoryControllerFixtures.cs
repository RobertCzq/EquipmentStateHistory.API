using Lego.EquipmentStateHistory.API.Controllers;
using Lego.EquipmentStateHistory.API.Infrastructure.Repository;
using Lego.EquipmentStateHistory.API.Models;
using Lego.EquipmentStateHistory.API.Services;
using Moq;

namespace Lego.EquipmentStateHistory.API.UnitTests.Fixtures
{
    internal static class StateHistoryControllerFixtures
    {
        public static StateHistoryController SetupSut(EquipmentState mockState = null, bool add = false)
        {
            var mockStateHistoryRepository = new Mock<IStateHistoryRepository>();
            var mockStateToColorConvertor = new Mock<IStateToColorConvertor>();

            if (mockState != null)
            {
                if (add)
                {
                    mockStateHistoryRepository.Setup(service => service.AddState(mockState))
                        .ReturnsAsync(true);
                }

                mockStateHistoryRepository.Setup(service => service.GetAll(mockState.EquipmentId))
                    .ReturnsAsync(new List<EquipmentState>() { mockState });

                mockStateHistoryRepository.Setup(service => service.GetCurrentState(mockState.EquipmentId))
                    .ReturnsAsync(mockState);
            }

            var sut = new StateHistoryController(mockStateHistoryRepository.Object, mockStateToColorConvertor.Object);
            return sut;
        }
    }
}
