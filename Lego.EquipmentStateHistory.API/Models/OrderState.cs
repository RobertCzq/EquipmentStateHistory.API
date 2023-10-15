using System.Runtime.Serialization;

namespace Lego.EquipmentStateHistory.API.Models
{
    public enum OrderState
    {
        [EnumMember(Value = "In queue")]
        InQueue,
        [EnumMember(Value = "In progress")]
        InProgress,
        [EnumMember(Value = "Done")]
        Done
    }
}
