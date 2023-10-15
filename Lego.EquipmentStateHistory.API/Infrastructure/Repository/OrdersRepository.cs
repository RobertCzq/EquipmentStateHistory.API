using Dapper;
using Lego.EquipmentStateHistory.API.Infrastructure.Data;
using Lego.EquipmentStateHistory.API.Models;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IDataContext _context;

        public OrdersRepository(IDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order?> GetCurrentOrder(long equipmentId)
        {
            var query = @"SELECT * FROM Orders WHERE EquipmentId = @EquipmentId AND OrderState = @OrderState";

            using var connection = _context.CreateConnection();
            var orderToRetrieve = new
            {
                EquipmentId = equipmentId,
                OrderState = OrderState.InProgress,
            };

            return await connection.QueryFirstOrDefaultAsync<Order>(query, orderToRetrieve);
        }

        public async Task<IEnumerable<Order>> GetScheduledOrders(long equipmentId)
        {
            var query = @"SELECT * FROM Orders 
                          WHERE EquipmentId = @EquipmentId 
                          AND OrderState = @OrderState 
                          ORDER BY datetime(DateAdded) ASC";

            using var connection = _context.CreateConnection();
            var orderToRetrieve = new
            {
                EquipmentId = equipmentId,
                OrderState = OrderState.InQueue
            };

            return await connection.QueryAsync<Order>(query, orderToRetrieve);
        }
    }
}
