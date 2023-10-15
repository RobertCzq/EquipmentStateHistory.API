using FluentAssertions;
using Lego.EquipmentStateHistory.API.Models;
using Lego.EquipmentStateHistory.API.Services;

namespace Lego.EquipmentStateHistory.API.UnitTests.Systems.Services
{
    public class TestStateToColorConvertor
    {
        [Theory]
        [MemberData(nameof(StateData))]
        public void Converting_Starting_ReturnsYellow(State state, string color)
        {
            //Arrange
            var sut = new StateToColorConvertor();

            //Act
            var result = sut.ConvertStateToColor(state);

            //Assert
            result.Should().Be(color);
        }

        public static IEnumerable<object[]> StateData =>
            new List<object[]>
            {
                new object[] { State.Starting, "Yellow"},
                new object[] { State.Producing, "Green" },
                new object[] { State.Standing, "Red" },
                new object[] { State.Stopping, "Yellow"},
                new object[] { 4, "Unknown"}
            };
    }
}
