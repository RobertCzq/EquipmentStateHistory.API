namespace Lego.EquipmentStateHistory.API.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long EquipmentId { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
