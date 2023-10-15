namespace Lego.EquipmentStateHistory.API.Models
{
    public class EquipmentState
    {
        public long EquipmentId { get; set; }
        public State State { get; set; }
        public DateTime DateModified { get; set; }
    }
}
