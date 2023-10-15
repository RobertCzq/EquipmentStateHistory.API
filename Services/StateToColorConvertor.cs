using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Services
{
    public class StateToColorConvertor : IStateToColorConvertor
    {
        public string ConvertStateToColor(State state)
        {
            var color = string.Empty;

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
            }

            return color;
        }
    }
}
