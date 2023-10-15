using Lego.EquipmentStateHistory.API.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lego.EquipmentStateHistory.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        }

        [HttpGet("GetCurrentOrder/{equipmentId}")]
        public async Task<IActionResult> GetCurrent(long equipmentId)
        {
            var curentOrder = await _ordersRepository.GetCurrentOrder(equipmentId);

            if (curentOrder == null)
            {
                return NotFound();
            }

            return Ok(curentOrder);
        }

        [HttpGet("GetScheduledOrders/{equipmentId}")]
        public async Task<IActionResult> GetScheduledOrders(long equipmentId)
        {
            var orders = await _ordersRepository.GetScheduledOrders(equipmentId);

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}
