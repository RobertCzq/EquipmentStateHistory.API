using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Services
{
    public class StateToColorConvertor : IStateToColorConvertor
    {
        public string ConvertStateToColor(State state)
        {
            string? color;
            switch (state)
            {
                case State.Starting:
                case State.Stopping:
                    color = "Yellow";
                    break;
                case State.Standing:
                    color = "Red";
                    break;
                case State.Producing:
                    color = "Green";
                    break;
                default:
                    color = "Unknown";
                    break;
            }

            return color;
        }
    }
}
