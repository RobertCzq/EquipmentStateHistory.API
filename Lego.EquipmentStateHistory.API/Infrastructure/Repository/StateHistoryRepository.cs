using Dapper;
using Lego.EquipmentStateHistory.API.Infrastructure.Data;
using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Repository
{
    public class StateHistoryRepository : IStateHistoryRepository
    {
        private readonly IDataContext _context;
        public StateHistoryRepository(IDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddState(EquipmentState equipmentState)
        {
            using var connection = _context.CreateConnection();
            var query = "INSERT INTO EquipmentState (EquipmentId, State, DateModified) VALUES (@EquipmentId, @State, @DateModified)";
            var equipmentStateToAdd = new
            {
                EquipmentId = equipmentState.EquipmentId,
                State = equipmentState.State,
                DateModified = equipmentState.DateModified
            };

            return await connection.ExecuteAsync(query, equipmentStateToAdd) > 0;
        }

        public async Task<IEnumerable<EquipmentState>> GetAll(long equipmentId)
        {
            var query = "SELECT EquipmentId, State, DateModified FROM EquipmentState WHERE EquipmentId = @EquipmentId";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EquipmentState>(query, new { EquipmentId = equipmentId });
        }

        public async Task<EquipmentState?> GetCurrentState(long equipmentId)
        {
            var query = @"SELECT EquipmentId, State, DateModified FROM EquipmentState 
                          WHERE EquipmentId = @EquipmentId ORDER BY datetime(DateModified) DESC LIMIT 1";
            using var connection = _context.CreateConnection();
            var currentEquipmentState = await connection.QueryFirstOrDefaultAsync<EquipmentState>(query, new { EquipmentId = equipmentId });

            return currentEquipmentState;
        }
    }
}
