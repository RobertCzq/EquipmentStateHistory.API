using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Repository
{
    public interface IStateHistoryRepository
    {
        Task<EquipmentState?> GetCurrentState(long equipmentId);
        Task<IEnumerable<EquipmentState>> GetAll(long equipmentId);
        Task<bool> AddState(EquipmentState state);
    }
}
