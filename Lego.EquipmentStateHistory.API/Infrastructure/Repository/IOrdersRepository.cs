using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Repository
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetScheduledOrders(long equipmentId);
        Task<Order?> GetCurrentOrder(long equipmentId);
    }
}
