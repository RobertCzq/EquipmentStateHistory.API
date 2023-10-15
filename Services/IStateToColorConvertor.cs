using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Services
{
    public interface IStateToColorConvertor
    {
        string ConvertStateToColor(State state);
    }
}
