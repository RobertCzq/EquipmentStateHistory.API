using System.Runtime.Serialization;

namespace Lego.EquipmentStateHistory.API.Models
{
    public enum State
    {
        [EnumMember(Value = "Starting up")]
        Starting,
        [EnumMember(Value = "Producing normally")]
        Producing,
        [EnumMember(Value = "Standing still")]
        Standing,
        [EnumMember(Value = "Winding down")]
        Stopping
    }
}
